Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Runtime.InteropServices

Public Class frmUsuario

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

    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cursor = Cursors.WaitCursor

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM USUARIO ORDER BY IDUSUARIO", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarUsuarios()
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

        Cursor = Cursors.Default

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

    End Sub

    Private Sub CargarUsuarios()

        Try
            'CARGA TODAS LAS MARCAS REGISTRADAS EN EL DATAGRIDVIEW
            Dim mostrar_usuarios As New SqlCeDataAdapter("SELECT IDUSUARIO AS CÓDIGO, NOMBREUSUARIO AS NOMBRE, STATUSUSUARIO AS STATUS FROM USUARIO ORDER BY IDUSUARIO", cn)
            mostrar_usuarios.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            mostrar_usuarios.Fill(ds)
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            DataGridView1.Columns.Item("NOMBRE").Width = 286
            Me.DataGridView1.Columns("NOMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns("STATUS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtNombreUsuario_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombreUsuario.KeyUp

        DataGridView1.DataSource = Me.Filtrar_Nombre

    End Sub

    Private Function Filtrar_Nombre() As DataTable

        Dim da As New SqlCeDataAdapter("SELECT IDUSUARIO AS CÓDIGO, NOMBREUSUARIO AS NOMBRE, STATUSUSUARIO AS STATUS FROM USUARIO WHERE NOMBREUSUARIO LIKE'%" & txtNombreUsuario.Text.Trim() & "%' ORDER BY IDUSUARIO", cn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt

        Me.DataGridView1.Columns(5).Width = 250

    End Function

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            TxtidUsuario.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value()
            txtNombreUsuario.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value()
            cboStatusUsuario.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value()

        Catch

        End Try

    End Sub

    Private Sub txtNombreUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreUsuario.KeyPress

        e.KeyChar = Char.ToUpper(e.KeyChar)

    End Sub

    Private Sub Limpiar()

        txtNombreUsuario.Clear()
        cboStatusUsuario.SelectedIndex = -1
        TxtidUsuario.Clear()

    End Sub


    Private Sub btnCrearNuevo_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        Me.ActiveControl = Nothing

        If txtNombreUsuario.Text.Length = 0 Then
            MsgBox("No puede dejar el nombre en blanco.", MsgBoxStyle.Information, "Error")
            txtNombreUsuario.Focus()
            txtNombreUsuario.SelectAll()
            Exit Sub
        End If

        If cboStatusUsuario.SelectedIndex = -1 Then
            cboStatusUsuario.SelectedIndex = 0
        End If

        'CONSULTAMOS SI NO EXISTE UN TRABAJADOR REPETIDO
        cn.Open()
        Dim da As New SqlCeDataAdapter("SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO = '" & txtNombreUsuario.Text & "'", cn)
        da.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        da.Fill(dt)
        cn.Close()
        'SI EL TRABAJADOR YA EXISTE, MUESTRA UN AVISO Y ACABA LA TRANSACCIÓN
        If dt.Rows.Count > 0 Then
            MsgBox("El usuario ya está registrado, revise nuevamente.", MsgBoxStyle.Exclamation, "Error")
            txtNombreUsuario.Focus()
            txtNombreUsuario.SelectAll()
            Exit Sub
        Else

            Try
                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    'OBTENER ULTIMO IDUSUARIO
                    Dim consultar As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDUSUARIO),0) FROM USUARIO", cn)
                    Dim dt_ultimoid As New DataTable
                    consultar.Fill(dt_ultimoid)
                    Dim id As Integer
                    id = Format((CInt(dt_ultimoid.Rows(0).Item(0)) + 1))

                    'SI NO SE REPITE, CREAMOS EL NUEVO USUARIO
                    Dim cmd As New SqlCeCommand("INSERT INTO USUARIO VALUES(@IDUSUARIO, @NOMBREUSUARIO, @STATUSUSUARIO)", cn)
                    cmd.Parameters.AddWithValue("@IDUSUARIO", id)
                    cmd.Parameters.AddWithValue("@NOMBREUSUARIO", txtNombreUsuario.Text)
                    cmd.Parameters.AddWithValue("@STATUSUSUARIO", cboStatusUsuario.Text)

                    cmd.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Se creó correctamente el nuevo trabajador.", MsgBoxStyle.Information, "Información")
                Limpiar()
                CargarUsuarios()

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

        If txtNombreUsuario.Text.Length <> 0 Then

            'COMPRUEBA QUE EXISTE EL USUARIO
            Dim consultar As New SqlCeCommand("SELECT IDUSUARIO FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO", cn)
            consultar.CommandType = CommandType.Text
            consultar.Parameters.AddWithValue("@IDUSUARIO", TxtidUsuario.Text)
            Dim da As New SqlCeDataAdapter(consultar)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MsgBox("El usuario no está registrado.", MsgBoxStyle.Exclamation, "Error")
                txtNombreUsuario.Focus()
                txtNombreUsuario.SelectAll()
                Exit Sub
            Else

                If MsgBox("¿Está seguro(a) que desea actualizar al trabajador?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then

                    Try
                        Dim transactionOptions = New TransactionOptions()
                        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                        transactionOptions.Timeout = TransactionManager.MaximumTimeout
                        Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                            If (cn.State = ConnectionState.Closed) Then cn.Open()

                            Dim cmd As New SqlCeCommand("UPDATE USUARIO SET IDUSUARIO=@IDUSUARIO, NOMBREUSUARIO=@NOMBREUSUARIO, STATUSUSUARIO=@STATUSUSUARIO WHERE IDUSUARIO=@IDUSUARIO", cn)
                            cmd.CommandType = CommandType.Text

                            cmd.Parameters.AddWithValue("@IDUSUARIO", TxtidUsuario.Text)
                            cmd.Parameters.AddWithValue("@NOMBREUSUARIO", txtNombreUsuario.Text)
                            cmd.Parameters.AddWithValue("@STATUSUSUARIO", cboStatusUsuario.Text)
                            cmd.ExecuteNonQuery()
                            tran1.Complete()
                            cn.Close()
                            tran1.Dispose()
                        End Using

                        MsgBox("Se actualizaron los datos del trabajador.", MsgBoxStyle.Information, "Información")
                        txtNombreUsuario.Clear()
                        cboStatusUsuario.SelectedIndex = -1
                        CargarUsuarios()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        If Not (cn Is Nothing) Then
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                        End If
                    End Try

                Else
                    Exit Sub
                End If

            End If

        Else
            MsgBox("Debe seleccionar un trabajador antes de presionar este botón", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Me.ActiveControl = Nothing

        Try
            If txtNombreUsuario.Text.Length <> 0 Then


                Dim consultar As New SqlCeCommand("SELECT IDUSUARIO FROM USUARIO WHERE NOMBREUSUARIO = @NOMBREUSUARIO", cn)
                consultar.CommandType = CommandType.Text
                consultar.Parameters.AddWithValue("@NOMBREUSUARIO", txtNombreUsuario.Text)
                Dim da As New SqlCeDataAdapter(consultar)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count = 0 Then
                    MsgBox("El trabajador no está registrado o no ha presionado el botón 'BUSCAR'.", MsgBoxStyle.Exclamation, "Error")
                    txtNombreUsuario.Focus()
                    txtNombreUsuario.SelectAll()
                    Exit Sub
                Else

                    'OBTENER IDUSUARIO
                    Dim consultarid As New SqlCeDataAdapter("SELECT IDUSUARIO FROM USUARIO WHERE NOMBREUSUARIO='" & txtNombreUsuario.Text & "'", cn)
                    Dim dt_ultimoid As New DataTable
                    consultarid.Fill(dt_ultimoid)
                    Dim id As Integer
                    id = Format((CInt(dt_ultimoid.Rows(0).Item(0))))

                    'COMPRUEBA SI EL TRABAJADOR TIENE MOVIMIENTO ANTES DE ELIMINARLO
                    Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDUSUARIO FROM TELEFONO WHERE IDUSUARIO=@IDUSUARIO", cn)
                    consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                    consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDUSUARIO", id)
                    Dim dt_consultar As New DataTable
                    consultar_movimiento.Fill(dt_consultar)

                    If MsgBox("¿Desea eliminar al trabajador?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        If dt_consultar.Rows.Count > 0 Then
                            MsgBox("El trabajador está asignado a un equipo. Si aún desea eliminar al usuario, debe eliminar su historial.", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        Else
                            Try
                                Dim transactionOptions = New TransactionOptions()
                                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                                transactionOptions.Timeout = TransactionManager.MaximumTimeout
                                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                                    Dim cmd As New SqlCeCommand("DELETE FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO", cn)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Parameters.AddWithValue("@IDUSUARIO", id)
                                    cmd.ExecuteNonQuery()
                                    tran1.Complete()
                                    cn.Close()
                                    tran1.Dispose()
                                End Using

                            Catch ex As Exception
                                MsgBox(ex.ToString)
                            Finally
                                If Not (cn Is Nothing) Then
                                    If (cn.State = ConnectionState.Open) Then
                                        cn.Close()
                                    End If
                                End If
                            End Try

                            MsgBox("Trabajador eliminado correctamente.", MsgBoxStyle.Information, "Aviso")
                            Limpiar()
                            CargarUsuarios()
                        End If
                    End If
                End If
            Else
                MsgBox("Debe seleccionar un trabajador antes de presionar este botón", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtNombreUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtNombreUsuario.TextChanged

        If txtNombreUsuario.Text = "" Then
            cboStatusUsuario.SelectedIndex = -1
            TxtidUsuario.Clear()
        End If

    End Sub

    Private Sub btnExportarTrabajador_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        Cursor = Cursors.WaitCursor

        Me.ActiveControl = Nothing

        Try
            Dim i, j As Integer

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets(1)
            xlWorkSheet = xlWorkBook.ActiveSheet

            cn.Open()
            Dim da As New SqlCeDataAdapter("SELECT * FROM USUARIO", cn)
            Dim ds As New DataSet
            da.Fill(ds)

            For j = 0 To ds.Tables(0).Columns.Count - 1
                xlWorkSheet.Cells(1, j + 1) = ds.Tables(0).Columns(j).ToString()
                xlWorkSheet.Cells(1, j + 1).Font.Bold = True
            Next

            For i = 1 To ds.Tables(0).Rows.Count
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i - 1)(j).ToString()
                Next
            Next
            xlWorkSheet.Columns.AutoFit()
            xlApp.Columns.AutoFit()
            xlApp.Visible = True

            cn.Close()

            Cursor = Cursors.Default

        Catch
            MsgBox("No hay datos para exportar", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then

            Dim f As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmMant_Equipo").SingleOrDefault()
            If f Is Nothing Then
                Me.Dispose()
            Else
                Dim f1 As frmMant_Equipo = CType(Application.OpenForms("frmMant_Equipo"), frmMant_Equipo)
                Dim cb As ComboBox = CType(f1.Controls("cboUsuario"), ComboBox)
                f1.Cargar_Usuario()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class
