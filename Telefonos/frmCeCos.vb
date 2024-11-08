Imports System.Data
Imports System.Transactions
Imports System.Data.SqlServerCe
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports ErikEJ.SqlCe
Imports System.Runtime.InteropServices

Public Class frmCeCos

    Dim idceco_siguiente As Integer

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

    Private Sub frmCeCos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarProveedor()

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

    End Sub

    'CARGA EL COMBOBOX PROVEEDOR
    Private Sub CargarProveedor()
        Try
            Dim da_proveedor As New SqlCeDataAdapter("SELECT IDPROVEEDOR, PROVEEDOR FROM PROVEEDOR", cn)
            Dim dtb_proveedor As New DataTable
            da_proveedor.Fill(dtb_proveedor)
            ComboBox1.DataSource = dtb_proveedor
            ComboBox1.DisplayMember = "PROVEEDOR"
            ComboBox1.ValueMember = "IDPROVEEDOR"
            ComboBox1.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los proveedores", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargarCeCos()

        Try
            'CARGA LOS CENTROS DE COSTO REGISTRADOS EN EL DATAGRIDVIEW
            Dim mostrar_cecos As New SqlCeDataAdapter("SELECT IDCECO AS CÓDIGO, PROVEEDOR AS PROVEEDOR, NUMEROCECO AS NUM_CENTRO_COSTO, CECO AS CENTRO_COSTO FROM CENTROCOSTO INNER JOIN PROVEEDOR ON CENTROCOSTO.IDPROVEEDOR = PROVEEDOR.IDPROVEEDOR WHERE PROVEEDOR = '" & ComboBox1.Text & "'", cn)
            mostrar_cecos.SelectCommand.CommandType = CommandType.Text
            Dim dtb As New DataTable
            mostrar_cecos.Fill(dtb)
            'dv.Table = ds.Tables(0)
            'DataGridView1.DataSource = dv
            DataGridView1.DataSource = dtb
            Me.DataGridView1.Columns(0).Visible = False
            Me.DataGridView1.Columns(1).Width = 90
            Me.DataGridView1.Columns(2).Width = 140
            Me.DataGridView1.Columns(3).Width = 300
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("Se produjo un error al cargar las marcas, reinicie el sistema.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

    End Sub

    Private Sub txtCeCo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCeCo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub


    Private Sub Obtener_idCeCo_siguiente()

        Try
            Dim da_ultimo_idceco As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDCECO),'0') FROM CENTROCOSTO", cn)
            da_ultimo_idceco.SelectCommand.CommandType = CommandType.Text
            Dim dt_ultimo_idceco As New DataTable
            da_ultimo_idceco.Fill(dt_ultimo_idceco)

            idceco_siguiente = Format((CInt(dt_ultimo_idceco.Rows(0).Item(0)) + 1), "0")

        Catch

        End Try

    End Sub


    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        If txtCeCo.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de Centro de Costo antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            'MetroFramework.MetroMessageBox.Show(Me, "Llene los campos antes de presionar este botón.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCeCo.Focus()
            Exit Sub
        End If

        'VALIDA QUE EL CENTRO DE COSTO NO EXISTA EN LA LISTA
        Dim validar_ceco As New SqlCeDataAdapter("SELECT IDPROVEEDOR, NUMEROCECO, CECO FROM CENTROCOSTO WHERE NUMEROCECO=@NUMEROCECO OR CECO=@CECO", cn)
        validar_ceco.SelectCommand.CommandType = CommandType.Text
        'validar_ceco.SelectCommand.Parameters.AddWithValue("@IDPROVEEDOR", ComboBox1.SelectedValue)
        validar_ceco.SelectCommand.Parameters.AddWithValue("@NUMEROCECO", txtNumCeCo.Text)
        validar_ceco.SelectCommand.Parameters.AddWithValue("@CECO", txtCeCo.Text)
        Dim dt As New DataTable
        validar_ceco.Fill(dt)

        If dt.Rows.Count > 0 Then
            MsgBox("El Centro de Costo ya existe, revise el texto ingresado.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        Else

            Try

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Obtener_idCeCo_siguiente()

                    Dim crear_ceco As New SqlCeCommand("INSERT INTO CENTROCOSTO VALUES(@IDCECO, @IDPROVEEDOR, @NUMEROCECO, @CECO)", cn)
                    crear_ceco.CommandType = CommandType.Text
                    crear_ceco.Parameters.AddWithValue("@IDCECO", idceco_siguiente)
                    crear_ceco.Parameters.AddWithValue("@IDPROVEEDOR", ComboBox1.SelectedValue)
                    crear_ceco.Parameters.AddWithValue("@NUMEROCECO", txtNumCeCo.Text)
                    crear_ceco.Parameters.AddWithValue("@CECO", txtCeCo.Text)
                    crear_ceco.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Se creó el Centro de Costo correctamente", MsgBoxStyle.Information, "Aviso")
                txtCeCo.Clear()
                txtNumCeCo.Clear()
                CargarCeCos()

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
                        Dim actualizar As New SqlCeCommand("UPDATE CENTROCOSTO SET IDCECO=@IDCECO, IDPROVEEDOR=@IDPROVEEDOR, NUMEROCECO=@NUMEROCECO, CECO=@CECO WHERE IDCECO=@IDCECO", cn)
                        actualizar.CommandType = CommandType.Text
                        actualizar.Parameters.AddWithValue("@IDCECO", txtIdCeCo.Text)
                        actualizar.Parameters.AddWithValue("@IDPROVEEDOR", ComboBox1.SelectedValue)
                        actualizar.Parameters.AddWithValue("@NUMEROCECO", txtNumCeCo.Text)
                        actualizar.Parameters.AddWithValue("@CECO", txtCeCo.Text)

                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()
                    Next

                End Using

                MsgBox("Se actualizó correctamente el Centro de Costo", MsgBoxStyle.Information, "Aviso")
                txtCeCo.Clear()
                txtNumCeCo.Clear()
                CargarCeCos()
                txtIdCeCo.Clear()
                ComboBox1.Focus()

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

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                'Obtener_idCeCo_actual()

                'COMPRUEBA SI EL IDCECO TIENE MOVIMIENTO ANTES DE ELIMINARLO
                Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDCECO FROM TELEFONO WHERE IDCECO=@IDCECO", cn)
                consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDCECO", txtIdCeCo.Text)
                Dim dt As New DataTable
                consultar_movimiento.Fill(dt)

                If MsgBox("¿Desea eliminar el Centro de Costo de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then

                    If dt.Rows.Count > 0 Then
                        MsgBox("El Centro de Costo tiene movimiento, no se puede eliminar", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                    Else

                        '***************************************
                        'COMPRUEBA SI EXISTE EL ITEM SELECCIONADO

                        Dim comprueba As New SqlCeDataAdapter("SELECT IDCECO FROM CENTROCOSTO WHERE IDCECO = @IDCECO", cn)
                        comprueba.SelectCommand.CommandType = CommandType.Text
                        comprueba.SelectCommand.Parameters.AddWithValue("@IDCECO", txtIdCeCo.Text)
                        Dim dt1 As New DataTable
                        comprueba.Fill(dt1)

                        If dt1.Rows.Count > 0 Then

                            '***************************************
                            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()
                                Dim cmd As New SqlCeCommand("DELETE FROM CENTROCOSTO WHERE IDCECO=@IDCECO", cn)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@IDCECO", txtIdCeCo.Text)

                                cmd.ExecuteNonQuery()
                                tran1.Complete()
                                cn.Close()
                                tran1.Dispose()

                            End Using
                            MsgBox("Centro de Costo eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                            CargarCeCos()
                            txtNumCeCo.Clear()
                            txtCeCo.Clear()
                            txtIdCeCo.Clear()
                            ComboBox1.Select()
                            Exit Sub
                        Else
                            MsgBox("Seleccione un item válido.", MsgBoxStyle.Exclamation, "Aviso")
                            ComboBox1.Select()
                            Exit Sub
                        End If

                    End If

                Else
                    MsgBox("Seleccione un item de la lista para poder eliminar", MsgBoxStyle.Exclamation, "Error")
                    ComboBox1.Select()
                    Exit Sub
                End If

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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then

            txtIdCeCo.Text = DataGridView1.Item(0, e.RowIndex).Value.ToString
            'txtIdProveedor.Text = DataGridView1.Item(1, e.RowIndex).Value.ToString
            txtNumCeCo.Text = DataGridView1.Item(2, e.RowIndex).Value.ToString
            txtCeCo.Text = DataGridView1.Item(3, e.RowIndex).Value.ToString

        End If

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged

        txtIdCeCo.Clear()
        txtNumCeCo.Clear()
        txtCeCo.Clear()

        If ComboBox1.SelectedIndex = -1 Then
            DataGridView1.DataSource = -1
        Else
            Dim consulta_data As New SqlCeDataAdapter("SELECT IDCECO AS CÓDIGO, PROVEEDOR AS PROVEEDOR, NUMEROCECO AS NUMERO_CENTRO_COSTO, CECO AS CENTRO_COSTO FROM CENTROCOSTO INNER JOIN PROVEEDOR ON CENTROCOSTO.IDPROVEEDOR = PROVEEDOR.IDPROVEEDOR WHERE PROVEEDOR = '" & ComboBox1.Text & "'", cn)
            consulta_data.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            consulta_data.Fill(dt)

            If dt.Rows.Count > 0 Then
                CargarCeCos()
            Else
                DataGridView1.DataSource = -1
            End If
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
                Dim cb As ComboBox = CType(f1.Controls("cboCeCo"), ComboBox)
                f1.Cargar_CeCo()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class