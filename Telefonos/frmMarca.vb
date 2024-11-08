﻿Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmMarca

    Private dv As New DataView

#Region "Arrastrar Formulario desde el panel y formulario"

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub MenuTop_MouseDown(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

#End Region
#Region "Borde formulario"
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)

        e.Graphics.DrawRectangle(Pens.Silver, rect)
    End Sub
#End Region

    Private Sub frmMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM MARCA", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarMarcas()
        Else
            DataGridView1.DataSource = -1
        End If

        'FORMATO DE COLOR EN LAS FILAS
        'With Me.DataGridView1
        '    .RowsDefaultCellStyle.BackColor = Color.Moccasin
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        'End With

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 344

    End Sub

    Private Sub CargarMarcas()

        Try
            'CARGA TODAS LAS MARCAS REGISTRADAS EN EL DATAGRIDVIEW
            Dim mostrar_marcas As New SqlCeDataAdapter("SELECT IDMARCA AS CÓDIGO, MARCA AS MARCA FROM MARCA", cn)
            mostrar_marcas.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            mostrar_marcas.Fill(ds)
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            Me.DataGridView1.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("Se produjo un error al cargar las marcas, reinicie el sistema.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub Recargar_Marcas()

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM MARCA", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarMarcas()
        Else
            DataGridView1.DataSource = -1
        End If

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            TextBox1.Text = DataGridView1.Item(1, e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Me.ActiveControl = Nothing
        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de marca antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        'VALIDA QUE LA MARCA NO EXISTA EN LA LISTA
        Dim validar_marca As New SqlCeDataAdapter("SELECT MARCA FROM MARCA WHERE MARCA=@MARCA", cn)
        validar_marca.SelectCommand.CommandType = CommandType.Text
        validar_marca.SelectCommand.Parameters.AddWithValue("@MARCA", TextBox1.Text)
        Dim dt As New DataTable
        validar_marca.Fill(dt)

        If dt.Rows.Count > 0 Then
            MsgBox("La Marca ya existe, revise el texto ingresado.", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            TextBox1.SelectAll()
            CargarMarcas()
        Else
            Try
                'OBTENER ULTIMO IDMARCA Y AGREGAR UNO
                Dim consultar_id As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDMARCA),0) FROM MARCA", cn)
                Dim dt_ultimoid As New DataTable
                consultar_id.Fill(dt_ultimoid)
                Dim idmarca As Integer
                idmarca = Format((CInt(dt_ultimoid.Rows(0).Item(0)) + 1))

                'OBTENER ULTIMO IDMODELO Y AGREGAR UNO
                Dim consultar_id1 As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDMODELO),0) FROM MODELO", cn)
                Dim dt_ultimoid1 As New DataTable
                consultar_id1.Fill(dt_ultimoid1)
                Dim idmodelo As Integer
                idmodelo = Format((CInt(dt_ultimoid1.Rows(0).Item(0)) + 1))


                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim crear_marca As New SqlCeCommand("INSERT INTO MARCA VALUES(@IDMARCA, @MARCA)", cn)
                    crear_marca.CommandType = CommandType.Text
                    crear_marca.Parameters.AddWithValue("@IDMARCA", idmarca)
                    crear_marca.Parameters.AddWithValue("@MARCA", TextBox1.Text)


                    Dim crear_marca1 As New SqlCeCommand("INSERT INTO MODELO VALUES(@IDMODELO, @IDMARCA, '')", cn)
                    crear_marca1.CommandType = CommandType.Text
                    crear_marca1.Parameters.AddWithValue("@IDMODELO", idmodelo)
                    crear_marca1.Parameters.AddWithValue("@IDMARCA", idmarca)

                    crear_marca.ExecuteNonQuery()
                    crear_marca1.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()
                End Using

                MsgBox("Se creó la marca correctamente", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarMarcas()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                If Not (cn Is Nothing) Then
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                End If
            End Try
        End If


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Me.ActiveControl = Nothing
        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    For x = 0 To DataGridView1.SelectedRows.Count - 1

                        Dim actualizar As New SqlCeCommand("UPDATE MARCA SET MARCA='" & TextBox1.Text & "' WHERE IDMARCA=@IDMARCA", cn)
                        actualizar.CommandType = CommandType.Text
                        actualizar.Parameters.AddWithValue("@IDMARCA", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)

                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()
                    Next

                End Using

                MsgBox("Se actualizó correctamente la marca", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarMarcas()

            Else
                MsgBox("Seleccione un item de la lista antes de presionar 'Actualizar'", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not (cn Is Nothing) Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.ActiveControl = Nothing
        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                For x = 0 To DataGridView1.SelectedRows.Count - 1

                    If MsgBox("¿Desea eliminar la marca de teléfono de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then

                        'COMPRUEBA SI LA MARCA TIENE MOVIMIENTO ANTES DE ELIMINARLA
                        Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDMARCA FROM TELEFONO WHERE IDMARCA=@IDMARCA", cn)
                        consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                        consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDMARCA", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)
                        Dim dt As New DataTable
                        consultar_movimiento.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            MsgBox("La marca de teléfono tiene movimiento, no se puede eliminar", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        Else

                            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()

                                Dim cmd As New SqlCeCommand("DELETE FROM MARCA WHERE IDMARCA=@IDMARCA", cn)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@IDMARCA", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)

                                cmd.ExecuteNonQuery()
                                tran1.Complete()
                                cn.Close()
                                tran1.Dispose()

                            End Using

                            MsgBox("Marca eliminada correctamente", MsgBoxStyle.Information, "Aviso")
                            CargarMarcas()
                            TextBox1.Clear()

                        End If
                    End If
                Next
            Else
                MsgBox("Seleccione un item de la lista para poder eliminar", MsgBoxStyle.Exclamation, "Error")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not (cn Is Nothing) Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            DataGridView1.ClearSelection()
        End If

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then

            Dim f As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmMant_Equipo").SingleOrDefault()
            If f Is Nothing Then
                Me.Dispose()
            Else
                Dim f1 As frmMant_Equipo = CType(Application.OpenForms("frmMant_Equipo"), frmMant_Equipo)
                Dim cb As ComboBox = CType(f1.Controls("cboMarca"), ComboBox)
                f1.Cargar_Marca()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class