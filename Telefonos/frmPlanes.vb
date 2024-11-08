Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmPlanes

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

    Private Sub frmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM PLANES", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarPlanes()
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
        Me.DataGridView1.Columns(1).Width = 220

    End Sub

    Private Sub CargarPlanes()

        Try
            'CARGA TODAS LAS MARCAS REGISTRADAS EN EL DATAGRIDVIEW
            Dim mostrar_planes As New SqlCeDataAdapter("SELECT IDPLAN AS CÓDIGO, PLAN_LINEA AS PLAN_LINEA, PRECIO_PLAN AS PRECIO_PLAN FROM PLANES", cn)
            mostrar_planes.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            mostrar_planes.Fill(ds)
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            Me.DataGridView1.Columns("PLAN_LINEA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns("PRECIO_PLAN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("Se produjo un error al cargar las marcas, reinicie el sistema.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub Recargar_Planes()

        Dim consulta_data As New SqlCeDataAdapter("SELECT * FROM PLANES", cn)
        consulta_data.SelectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        consulta_data.Fill(dt)

        If dt.Rows.Count > 0 Then
            CargarPlanes()
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
            TextBox2.Text = DataGridView1.Item(2, e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de Área antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        'VALIDA QUE EL PLAN NO EXISTA EN LA LISTA
        Dim validar_plan As New SqlCeDataAdapter("SELECT PLAN_LINEA FROM PLANES WHERE PLAN_LINEA=@PLAN_LINEA", cn)
        validar_plan.SelectCommand.CommandType = CommandType.Text
        validar_plan.SelectCommand.Parameters.AddWithValue("@PLAN_LINEA", TextBox1.Text)
        Dim dt As New DataTable
        validar_plan.Fill(dt)

        If dt.Rows.Count > 0 Then
            MsgBox("El Plan ya existe, revise el texto ingresado.", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            TextBox1.SelectAll()
            CargarPlanes()
        Else

            Try

                'OBTENER ULTIMO IDPROVEEDOR
                Dim consultar_idplan As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDPLAN),0) FROM PLANES", cn)
                Dim dt_ultimoidplan As New DataTable
                consultar_idplan.Fill(dt_ultimoidplan)
                Dim idplan As Integer
                idplan = Format((CInt(dt_ultimoidplan.Rows(0).Item(0)) + 1))

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout


                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim crear_plan As New SqlCeCommand("INSERT INTO PLANES VALUES(@IDPLAN, @PLAN_LINEA, @PRECIO_PLAN)", cn)
                    crear_plan.CommandType = CommandType.Text
                    crear_plan.Parameters.AddWithValue("@IDPLAN", idplan)
                    crear_plan.Parameters.AddWithValue("@PLAN_LINEA", TextBox1.Text)
                    crear_plan.Parameters.AddWithValue("@PRECIO_PLAN", TextBox2.Text)

                    crear_plan.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Se creó el Plan correctamente", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarPlanes()

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

                        Dim actualizar As New SqlCeCommand("UPDATE PLANES SET PLAN_LINEA=@PLAN_LINEA, PRECIO_PLAN=@PRECIO_PLAN WHERE IDPLAN=@IDPLAN", cn)
                        actualizar.CommandType = CommandType.Text
                        actualizar.Parameters.AddWithValue("@IDPLAN", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)
                        actualizar.Parameters.AddWithValue("@PLAN_LINEA", TextBox1.Text)
                        actualizar.Parameters.AddWithValue("@PRECIO_PLAN", TextBox2.Text)
                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()

                    Next

                End Using

                MsgBox("Se actualizó correctamente el Plan", MsgBoxStyle.Information, "Aviso")
                TextBox1.Clear()
                CargarPlanes()

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

                For x = 0 To DataGridView1.SelectedRows.Count - 1

                    'COMPRUEBA SI EL PLAN TIENE MOVIMIENTO ANTES DE ELIMINARLO
                    Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDPLAN FROM TELEFONO WHERE IDPLAN=@IDPLAN", cn)
                    consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                    consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDPLAN", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)
                    Dim dt As New DataTable
                    consultar_movimiento.Fill(dt)

                    If MsgBox("¿Desea eliminar el Plan de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        If dt.Rows.Count > 0 Then
                            MsgBox("El Plan tiene movimiento, no se puede eliminar", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        Else

                            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()

                                Dim cmd As New SqlCeCommand("DELETE FROM PLANES WHERE IDPLAN=@IDPLAN", cn)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@IDPLAN", DataGridView1.SelectedRows(x).Cells(0).Value.ToString)

                                cmd.ExecuteNonQuery()
                                tran1.Complete()
                                cn.Close()
                                tran1.Dispose()

                            End Using

                            MsgBox("Plan eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                            CargarPlanes()
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
            TextBox2.Clear()
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
                Dim cb As ComboBox = CType(f1.Controls("cboPlan"), ComboBox)
                f1.Cargar_Planes()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class