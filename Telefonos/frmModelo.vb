Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmModelo

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

    Private Sub frmModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'MsgBox("Para crear un modelo, primero seleccione una marca del combobox y luego haga click en cualquier item de la lista", MsgBoxStyle.Information, "Información")

        CargarMarcas()

        'FORMATO DE COLOR EN LAS FILAS
        'With Me.DataGridView1
        '    .RowsDefaultCellStyle.BackColor = Color.Moccasin
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        'End With

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)

        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 150
        Me.DataGridView1.Columns(2).Width = 208

        DGV.ClearSelection()

    End Sub

    Private Sub CargarMarcas()
        'CARGA EL COMBOBOX MARCA
        Try
            Dim da_marca As New SqlCeDataAdapter("SELECT DISTINCT IDMARCA, MARCA FROM MARCA", cn)
            Dim dtb_marca As New DataTable
            da_marca.Fill(dtb_marca)
            ComboBox1.DataSource = dtb_marca
            ComboBox1.DisplayMember = "MARCA"
            ComboBox1.ValueMember = "IDMARCA"
            ComboBox1.SelectedIndex = -1
        Catch
            MsgBox("Error al cargar las Marcas", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try

            dv.RowFilter = String.Format("MARCA Like '%{0}%'", TextBox1.Text)

        Catch ex As Exception
            MsgBox("Valor no admitido", MsgBoxStyle.Critical, "Mensaje de advertencia")
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            TextBox1.Text = DataGridView1.Item(2, e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Me.ActiveControl = Nothing
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Escoja una marca del ComboBox", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de marca antes de presionar 'Crear'", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        If DataGridView1.Rows.Count > 0 Then

            For X = 0 To DataGridView1.Rows.Count - 1

                If DataGridView1.Rows(X).Cells(2).Value.ToString = "" Then

                    Try
                        Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                            If (cn.State = ConnectionState.Closed) Then cn.Open()

                            Dim actualizar_modelo As New SqlCeCommand("UPDATE MODELO SET MODELO=@MODELO WHERE IDMARCA=@MARCA", cn)
                            actualizar_modelo.CommandType = CommandType.Text
                            actualizar_modelo.Parameters.AddWithValue("@MARCA", ComboBox1.SelectedValue)
                            actualizar_modelo.Parameters.AddWithValue("@MODELO", TextBox1.Text)

                            actualizar_modelo.ExecuteNonQuery()
                            tran1.Complete()
                            cn.Close()
                            tran1.Dispose()

                            Actualizar_Datagrid()
                            MsgBox("Se creó el modelo correctamente.", MsgBoxStyle.Information, "Aviso")

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

                    Exit Sub

                ElseIf DataGridView1.Rows(X).Cells(1).Value <> "" Then

                    'VALIDAR QUE EL MODELO NO EXISTE
                    Dim Validar_modelo As New SqlCeDataAdapter("SELECT * FROM MODELO WHERE IDMARCA=@MARCA AND MODELO=@MODELO", cn)
                    Validar_modelo.SelectCommand.CommandType = CommandType.Text
                    Validar_modelo.SelectCommand.Parameters.AddWithValue("@MARCA", ComboBox1.SelectedValue)
                    Validar_modelo.SelectCommand.Parameters.AddWithValue("@MODELO", TextBox1.Text)
                    Dim dtb_modelo As New DataTable
                    Validar_modelo.Fill(dtb_modelo)

                    If dtb_modelo.Rows.Count > 0 Then
                        MsgBox("El modelo ya existe", MsgBoxStyle.Exclamation, "Error")
                        TextBox1.SelectAll()
                        Exit Sub
                    Else

                        Try
                            Using tran2 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                If (cn.State = ConnectionState.Closed) Then cn.Open()

                                '***********************OBTENER ULTIMO IDMODELO*******************************************************
                                Dim da_ultimoregistro As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDMODELO),0) FROM MODELO", cn)
                                da_ultimoregistro.SelectCommand.CommandType = CommandType.Text
                                Dim dt_ultimoregistro As New DataTable
                                da_ultimoregistro.Fill(dt_ultimoregistro)
                                Dim idmodelo
                                idmodelo = Format((CInt(dt_ultimoregistro.Rows(0).Item(0)) + 1), "0")
                                '*****************************************************************************************************


                                Dim actualizar_modelo As New SqlCeCommand("INSERT INTO MODELO VALUES(@IDMODELO, @IDMARCA, @MODELO)", cn)
                                actualizar_modelo.CommandType = CommandType.Text
                                actualizar_modelo.Parameters.AddWithValue("@IDMODELO", idmodelo)
                                actualizar_modelo.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                                actualizar_modelo.Parameters.AddWithValue("@MODELO", TextBox1.Text)

                                actualizar_modelo.ExecuteNonQuery()
                                tran2.Complete()
                                cn.Close()
                                tran2.Dispose()

                                Actualizar_Datagrid()
                                MsgBox("Se creó el modelo correctamente.", MsgBoxStyle.Information, "Aviso")
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

                        Exit Sub

                    End If

                End If

            Next

            Exit Sub

            'PROBANDO SENTENCIA
        ElseIf DataGridView1.Rows.Count = 0 Then

            'VALIDAR QUE EL MODELO NO EXISTE
            Dim Validar_modelo As New SqlCeDataAdapter("SELECT * FROM MODELO WHERE IDMARCA=@MARCA AND MODELO=@MODELO", cn)
            Validar_modelo.SelectCommand.CommandType = CommandType.Text
            Validar_modelo.SelectCommand.Parameters.AddWithValue("@MARCA", ComboBox1.SelectedValue)
            Validar_modelo.SelectCommand.Parameters.AddWithValue("@MODELO", TextBox1.Text)
            Dim dtb_modelo As New DataTable
            Validar_modelo.Fill(dtb_modelo)

            If dtb_modelo.Rows.Count > 0 Then
                MsgBox("El modelo ya existe", MsgBoxStyle.Exclamation, "Error")
                TextBox1.SelectAll()
                Exit Sub
            Else

                Try
                    Using tran3 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                        If (cn.State = ConnectionState.Closed) Then cn.Open()

                        '***********************OBTENER ULTIMO IDMODELO*******************************************************
                        Dim da_ultimoregistro As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDMODELO),0) FROM MODELO", cn)
                        da_ultimoregistro.SelectCommand.CommandType = CommandType.Text
                        Dim dt_ultimoregistro As New DataTable
                        da_ultimoregistro.Fill(dt_ultimoregistro)
                        Dim idmodelo
                        idmodelo = Format((CInt(dt_ultimoregistro.Rows(0).Item(0)) + 1), "0")
                        '*****************************************************************************************************


                        Dim actualizar_modelo As New SqlCeCommand("INSERT INTO MODELO VALUES(@IDMODELO, @IDMARCA, @MODELO)", cn)
                        actualizar_modelo.CommandType = CommandType.Text
                        actualizar_modelo.Parameters.AddWithValue("@IDMODELO", idmodelo)
                        actualizar_modelo.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                        actualizar_modelo.Parameters.AddWithValue("@MODELO", TextBox1.Text)

                        actualizar_modelo.ExecuteNonQuery()
                        tran3.Complete()
                        cn.Close()
                        tran3.Dispose()

                        Actualizar_Datagrid()
                        MsgBox("Se creó el modelo correctamente.", MsgBoxStyle.Information, "Aviso")
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

                Exit Sub

            End If

        End If

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Me.ActiveControl = Nothing

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Seleccione una marca del Combobox y de la lista para poder editar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If TextBox1.Text.Trim.Length = 0 Then
            MsgBox("Digite una descripción de marca antes de presionar 'Actualizar'", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Escoja una marca del ComboBox", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try

            Dim X As Integer

            For X = 0 To DataGridView1.SelectedRows.Count - 1

                If TextBox1.Text <> "" Then

                    Dim transactionOptions = New TransactionOptions()
                    transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                    transactionOptions.Timeout = TransactionManager.MaximumTimeout

                    Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                        If (cn.State = ConnectionState.Closed) Then cn.Open()

                        Dim actualizar_tipo As New SqlCeCommand("UPDATE MODELO SET MODELO=@MODELO WHERE IDMODELO='" & DataGridView1.SelectedRows(X).Cells(0).Value & "'", cn)
                        actualizar_tipo.CommandType = CommandType.Text
                        actualizar_tipo.Parameters.AddWithValue("@MODELO", TextBox1.Text)

                        actualizar_tipo.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()

                        MsgBox("Se actualizó el modelo correctamente.", MsgBoxStyle.Information, "Aviso")
                        Actualizar_Datagrid()
                    End Using
                End If

                Exit Sub
            Next

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

    Private Sub Actualizar_Datagrid()

        DataGridView1.DataSource = -1
        TextBox1.Clear()

        cn.Open()
        Dim da As New SqlCeDataAdapter("SELECT DISTINCT IDMODELO AS CÓDIGO, MARCA AS MARCA, MODELO AS MODELO FROM MARCA INNER JOIN MODELO ON MARCA.IDMARCA=MODELO.IDMARCA WHERE MARCA ='" & ComboBox1.Text & "' ORDER BY MODELO", cn)
        Dim dtb As New DataTable
        da.Fill(dtb)
        cn.Close()

        DataGridView1.DataSource = dtb
        Me.DataGridView1.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.Columns("MODELO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView1.ClearSelection()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.ActiveControl = Nothing
        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        Dim X As Integer

        For X = 0 To DataGridView1.Rows.Count - 1

            If DataGridView1.SelectedRows.Count > 0 Then

                If MsgBox("¿Desea eliminar el modelo de teléfono?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then


                    'COMPRUEBA SI EL MODELO ESTÁ ASIGNADO A UN USUARIO
                    Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDMODELO, IDUSUARIO FROM TELEFONO WHERE IDMODELO=@IDMODELO", cn)
                    consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                    consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDMODELO", DataGridView1.SelectedRows(X).Cells(0).Value.ToString)
                    Dim dt As New DataTable
                    consultar_movimiento.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        MsgBox("El modelo está asignado a un usuario y no se puede eliminar. Si desea eliminarlo de todas formas, debería quitarle la asignación al usuario.", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                        DataGridView1.ClearSelection()

                    Else
                        If DataGridView1.Rows.Count > 1 Then

                            'COMPRUEBA SI EL MODELO EXISTE ANTES DE ELIMINARLO
                            Dim consultar_modelo As New SqlCeDataAdapter("SELECT IDMODELO FROM MODELO WHERE IDMARCA=@IDMARCA AND MODELO=@MODELO", cn)
                            consultar_modelo.SelectCommand.CommandType = CommandType.Text
                            consultar_modelo.SelectCommand.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                            consultar_modelo.SelectCommand.Parameters.AddWithValue("@MODELO", DataGridView1.SelectedRows(X).Cells(2).Value)
                            Dim dt1 As New DataTable
                            consultar_modelo.Fill(dt1)

                            If dt1.Rows.Count > 0 Then

                                Try
                                    Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                        If (cn.State = ConnectionState.Closed) Then cn.Open()

                                        Dim cmd As New SqlCeCommand("DELETE FROM MODELO WHERE IDMARCA=@IDMARCA AND IDMODELO=@IDMODELO", cn)
                                        cmd.CommandType = CommandType.Text
                                        cmd.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                                        cmd.Parameters.AddWithValue("@IDMODELO", DataGridView1.SelectedRows(X).Cells(0).Value)

                                        cmd.ExecuteNonQuery()
                                        tran1.Complete()
                                        cn.Close()
                                        tran1.Dispose()
                                    End Using

                                    MsgBox("Modelo eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                                    Actualizar_Datagrid()
                                    Exit Sub
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
                                MsgBox("¡El Modelo no existe!", MsgBoxStyle.Exclamation, "Error")
                                Exit Sub
                            End If

                        ElseIf DataGridView1.Rows.Count = 1 Then

                            If TextBox1.Text = "" Then
                                MsgBox("No hay modelos para eliminar", MsgBoxStyle.Exclamation, "Error")
                                Exit Sub

                            ElseIf MsgBox("Es el único modelo; ¿Desea eliminarlo?. Si acepta, la marca quedará sin modelos", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then

                                Try
                                    'COMPRUEBA SI EL MODELO EXISTE ANTES DE ELIMINARLO
                                    Dim consultar_modelo As New SqlCeDataAdapter("SELECT MODELO FROM MODELO WHERE IDMARCA=@IDMARCA AND MODELO=@MODELO", cn)
                                    consultar_modelo.SelectCommand.CommandType = CommandType.Text
                                    consultar_modelo.SelectCommand.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                                    consultar_modelo.SelectCommand.Parameters.AddWithValue("@MODELO", DataGridView1.SelectedRows(X).Cells(2).Value)
                                    Dim dt2 As New DataTable
                                    consultar_modelo.Fill(dt2)

                                    If dt2.Rows.Count > 0 Then

                                        Using tran2 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                                            If (cn.State = ConnectionState.Closed) Then cn.Open()

                                            Dim actualizar_modelo As New SqlCeCommand("UPDATE MODELO SET IDMODELO='" & DataGridView1.SelectedRows(X).Cells(0).Value & "', IDMARCA=@IDMARCA, MODELO=@MODELO WHERE IDMARCA=@IDMARCA AND MODELO='" & DataGridView1.SelectedRows(X).Cells(2).Value & "'", cn)
                                            actualizar_modelo.CommandType = CommandType.Text
                                            actualizar_modelo.Parameters.AddWithValue("@IDMARCA", ComboBox1.SelectedValue)
                                            actualizar_modelo.Parameters.AddWithValue("@MODELO", "")

                                            actualizar_modelo.ExecuteNonQuery()
                                            tran2.Complete()
                                            cn.Close()
                                            tran2.Dispose()

                                        End Using

                                        MsgBox("Modelo eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                                        Actualizar_Datagrid()
                                        Exit Sub

                                    Else
                                        MsgBox("¡El Modelo de teléfono no existe!", MsgBoxStyle.Exclamation, "Error")
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

                            End If
                        End If

                    End If

                End If
            End If
        Next
    End Sub


    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged

        DataGridView1.DataSource = -1
        TextBox1.Clear()

        'MUESTRA DATOS EN EL COMBOBOX MODELOS, SEGÚN EL FILTRO EN EL COMBOBOX MARCA Y CARGA EL DATAGRIDVIEW
        Try
            Dim da As New SqlCeDataAdapter("SELECT DISTINCT IDMODELO AS CÓDIGO, MARCA.MARCA AS MARCA, MODELO AS MODELO FROM MARCA INNER JOIN MODELO ON MARCA.IDMARCA=MODELO.IDMARCA WHERE MARCA ='" & ComboBox1.Text & "' ORDER BY MODELO", cn)
            Dim dtb As New DataTable
            da.Fill(dtb)

            DataGridView1.DataSource = dtb
            Me.DataGridView1.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns("MODELO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.ClearSelection()
        Catch
            MsgBox("Error al cargar las marcas de teléfonos.", MsgBoxStyle.Critical, "Error")
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
                Dim cb As ComboBox = CType(f1.Controls("cboModelo"), ComboBox)
                f1.Cargar_Modelo()
                Me.Dispose()
            End If

        Else
            Exit Sub
        End If

    End Sub

End Class