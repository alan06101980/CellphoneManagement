Imports System.Data
Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmProveedor

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

    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM PROVEEDOR", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarProveedor()
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

    Private Sub CargarProveedor()

        Try
            'CARGA TODAS LAS MARCAS REGISTRADAS EN EL DATAGRIDVIEW
            Dim mostrar_prov As New SqlCeDataAdapter("SELECT IDPROVEEDOR AS CÓDIGO, PROVEEDOR AS PROVEEDOR FROM PROVEEDOR", cn)
            mostrar_prov.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            mostrar_prov.Fill(ds)
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            Me.DataGridView1.Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("Se produjo un error al cargar las marcas, reinicie el sistema.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub Recargar_Proveedor()

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM PROVEEDOR", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarProveedor()
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

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de Área antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        'VALIDA QUE EL ÁREA NO EXISTA EN LA LISTA
        Dim validar_prov As New SqlCeDataAdapter("SELECT PROVEEDOR FROM PROVEEDOR WHERE PROVEEDOR=@PROVEEDOR", cn)
        validar_prov.SelectCommand.CommandType = CommandType.Text
        validar_prov.SelectCommand.Parameters.AddWithValue("@PROVEEDOR", TextBox1.Text)
        Dim dt As New DataTable
        validar_prov.Fill(dt)

        If dt.Rows.Count > 0 Then
            MsgBox("El Proveedor ya existe, revise el texto ingresado.", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            TextBox1.SelectAll()
            CargarProveedor()
        Else

            Try

                'OBTENER ULTIMO IDPROVEEDOR
                Dim consultar_idprov As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDPROVEEDOR),0) FROM PROVEEDOR", cn)
                Dim dt_ultimoidprov As New DataTable
                consultar_idprov.Fill(dt_ultimoidprov)
                Dim idprov As Integer
                idprov = Format((CInt(dt_ultimoidprov.Rows(0).Item(0)) + 1))

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout


                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim crear_prov As New SqlCeCommand("INSERT INTO PROVEEDOR VALUES(@IDPROVEEDOR, @PROVEEDOR)", cn)
                    crear_prov.CommandType = CommandType.Text
                    crear_prov.Parameters.AddWithValue("@IDPROVEEDOR", idprov)
                    crear_prov.Parameters.AddWithValue("@PROVEEDOR", TextBox1.Text)
                    crear_prov.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Se creó el Proveedor correctamente", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarProveedor()

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

        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    For x = 0 To DataGridView1.SelectedRows.Count - 1

                        Dim actualizar As New SqlCeCommand("UPDATE PROVEEDOR SET PROVEEDOR='" & TextBox1.Text & "' WHERE IDPROVEEDOR=@IDPROVEEDOR", cn)
                        actualizar.CommandType = CommandType.Text
                        actualizar.Parameters.AddWithValue("@IDPROVEEDOR", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)

                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()
                    Next

                End Using

                MsgBox("Se actualizó correctamente el Proveedor", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarProveedor()

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

        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                Dim x As Integer
                For x = 0 To DataGridView1.SelectedRows.Count - 1

                    'COMPRUEBA SI EL ÁREA TIENE MOVIMIENTO ANTES DE ELIMINARLA
                    Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDPROVEEDOR FROM TELEFONO WHERE IDPROVEEDOR=@IDPROVEEDOR", cn)
                    consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                    consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDPROVEEDOR", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)
                    Dim dt As New DataTable
                    consultar_movimiento.Fill(dt)

                    If MsgBox("¿Desea eliminar el Proveedor de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        If dt.Rows.Count > 0 Then
                            MsgBox("El proveedor tiene movimiento, no se puede eliminar", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        Else

                            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()

                                Dim cmd As New SqlCeCommand("DELETE FROM PROVEEDOR WHERE IDPROVEEDOR=@IDPROVEEDOR", cn)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@IDPROVEEDOR", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)

                                cmd.ExecuteNonQuery()
                                tran1.Complete()
                                cn.Close()
                                tran1.Dispose()

                            End Using

                            MsgBox("Proveedor eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                            CargarProveedor()
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
                Dim cb As ComboBox = CType(f1.Controls("cboProveedor"), ComboBox)
                f1.Cargar_Proveedor()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class