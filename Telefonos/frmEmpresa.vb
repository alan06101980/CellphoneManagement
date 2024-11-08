Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmEmpresa

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


    Private Sub frmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Recargar_Empresa()

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
        Me.DataGridView1.Columns(1).Width = 244

    End Sub

    Private Sub Cargarempresa()

        Try
            'CARGA TODAS LAS MARCAS REGISTRADAS EN EL DATAGRIDVIEW
            Dim mostrar_prov As New SqlCeDataAdapter("SELECT IDEMPRESA AS CÓDIGO, EMPRESA AS EMPRESA, RUC AS RUC FROM EMPRESA", cn)
            mostrar_prov.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            mostrar_prov.Fill(ds)
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            Me.DataGridView1.Columns("EMPRESA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("Se produjo un error al cargar las marcas, reinicie el sistema.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub Recargar_Empresa()

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM EMPRESA", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            Cargarempresa()
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
            txtRuc.Text = DataGridView1.Item(2, e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una Empresa antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        If txtRuc.Text.Trim.Length = 0 Then
            MsgBox("Debe digitar un número de Ruc", MsgBoxStyle.Exclamation, "Error")
            txtRuc.Focus()
            Exit Sub
        End If

        'VALIDA QUE LA EMPRESA NO EXISTA EN LA LISTA
        Dim validar_emp As New SqlCeDataAdapter("SELECT EMPRESA, RUC FROM EMPRESA WHERE EMPRESA=@EMPRESA AND RUC=@RUC", cn)
        validar_emp.SelectCommand.CommandType = CommandType.Text
        validar_emp.SelectCommand.Parameters.AddWithValue("@EMPRESA", TextBox1.Text)
        validar_emp.SelectCommand.Parameters.AddWithValue("@RUC", txtRuc.Text)
        Dim dt As New DataTable
        validar_emp.Fill(dt)

        If dt.Rows.Count > 0 Then
            MsgBox("La Empresa ya existe, revise el texto ingresado.", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            TextBox1.SelectAll()
            Cargarempresa()
        Else

            Try

                'OBTENER ULTIMO IDPROVEEDOR Y AGREGAR UNO
                Dim consultar_idemp As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDEMPRESA),0) FROM EMPRESA", cn)
                Dim dt_ultimoidemp As New DataTable
                consultar_idemp.Fill(dt_ultimoidemp)
                Dim idemp As Integer
                idemp = Format((CInt(dt_ultimoidemp.Rows(0).Item(0)) + 1))

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout


                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim crear As New SqlCeCommand("INSERT INTO EMPRESA VALUES(@IDEMPRESA, @EMPRESA, @RUC)", cn)
                    crear.CommandType = CommandType.Text
                    crear.Parameters.AddWithValue("@IDEMPRESA", idemp)
                    crear.Parameters.AddWithValue("@EMPRESA", TextBox1.Text)
                    crear.Parameters.AddWithValue("@RUC", txtRuc.Text)
                    crear.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Se creó la empresa correctamente", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                Cargarempresa()

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

                    Dim x As Integer
                    For x = 0 To DataGridView1.SelectedRows.Count - 1

                        Dim actualizar As New SqlCeCommand("UPDATE EMPRESA SET EMPRESA='" & TextBox1.Text & "', RUC='" & txtRuc.Text & "' WHERE EMPRESA=@EMPRESA", cn)
                        actualizar.CommandType = CommandType.Text
                        actualizar.Parameters.AddWithValue("@EMPRESA", DataGridView1.SelectedRows(x).Cells(0).Value)

                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()
                    Next

                End Using

                MsgBox("Se actualizó correctamente el Proveedor", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                Cargarempresa()

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

                    'COMPRUEBA SI LA EMPRESA TIENE MOVIMIENTO ANTES DE ELIMINARLA
                    Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDEMPRESA FROM TELEFONO WHERE IDEMPRESA=@IDEMPRESA", cn)
                    consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                    consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDEMPRESA", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)
                    Dim dt As New DataTable
                    consultar_movimiento.Fill(dt)

                    If MsgBox("¿Desea eliminar la Empresa de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        If dt.Rows.Count > 0 Then
                            MsgBox("La Empresa tiene movimiento, no se puede eliminar", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        Else

                            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()
                                For y = 0 To DataGridView1.SelectedRows.Count - 1
                                    Dim cmd As New SqlCeCommand("DELETE FROM EMPRESA WHERE IDEMPRESA=@IDEMPRESA", cn)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Parameters.AddWithValue("@IDEMPRESA", DataGridView1.SelectedRows(y).Cells(0).Value.ToString)

                                    cmd.ExecuteNonQuery()
                                    tran1.Complete()
                                    cn.Close()
                                    tran1.Dispose()
                                Next
                            End Using

                            MsgBox("Empresa eliminada correctamente", MsgBoxStyle.Information, "Aviso")
                            Cargarempresa()
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
            txtRuc.Clear()
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
                Dim cb As ComboBox = CType(f1.Controls("cboEmpresa"), ComboBox)
                f1.Cargar_Empresa()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class