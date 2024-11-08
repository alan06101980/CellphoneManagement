Imports System.Runtime.InteropServices
Imports System.Data.SqlServerCe

Public Class frmReporteDeudores

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

    Private Sub frmReporteDeudores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AutoCompletar_Numero(txtNumeroUsuario)
        AutoCompletar_Nombre(txtUsuario)

        'ESCONDE LA PRIMERA COLUMNA
        'DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

    End Sub

    '/////////////FUNCIONES DE AUTOCOMPLETAR LOS DATOS DE PROVEEDORES//////////////////
    Public Function AutoCompletar_Numero(ByVal Control As TextBox) As AutoCompleteStringCollection

        Dim cmd As New SqlCeCommand("SELECT IDTELEFONO FROM TELEFONO ORDER BY IDTELEFONO", cn)
        cn.Open()
        Dim Lector As SqlCeDataReader = cmd.ExecuteReader()
        ' Realizamos un Loop mientras se está‚ leyendo.
        Dim Coleccion As New AutoCompleteStringCollection
        While Lector.Read()
            Coleccion.AddRange(New String() {Lector(0)})
        End While
        'Cerramos el SqlReader
        Lector.Close()
        'Cerramos la conexión
        cn.Close()

        'Ajustamos el control TextBox o ComboBox para recibir los datos de la siguiente manera.
        With Control
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = Coleccion
        End With
        'Devolvemos los datos recuperados de la base de datos
        Return Coleccion

    End Function

    Public Function AutoCompletar_Nombre(ByVal Control_Usuario As TextBox) As AutoCompleteStringCollection

        Dim cmd_Usuario As New SqlCeCommand("SELECT NOMBREUSUARIO FROM USUARIO ORDER BY NOMBREUSUARIO", cn)
        cn.Open()
        Dim Lector_Usuario As SqlCeDataReader = cmd_Usuario.ExecuteReader()
        ' Realizamos un Loop mientras se está‚ leyendo.
        Dim Coleccion_Usuario As New AutoCompleteStringCollection
        While Lector_Usuario.Read()
            Coleccion_Usuario.AddRange(New String() {Lector_Usuario(0)})
        End While
        'Cerramos el SqlReader
        Lector_Usuario.Close()
        'Cerramos la conexión
        cn.Close()

        'Ajustamos el control TextBox o ComboBox para recibir los datos de la siguiente manera.
        With Control_Usuario
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = Coleccion_Usuario
        End With
        'Devolvemos los datos recuperados de la base de datos
        Return Coleccion_Usuario
    End Function
    '/////////////FUNCIONES DE AUTOCOMPLETAR LOS DATOS DE PROVEEDORES//////////////////


    Private Sub txtNumeroUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroUsuario.KeyPress

        'SOLO NÚMEROS
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub ObtenerNumeracion()

        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = CStr(i + 1)
        Next

    End Sub

    Private Sub txtNumeroUsuario_Leave(sender As Object, e As EventArgs) Handles txtNumeroUsuario.Leave

        Try
            If txtNumeroUsuario.Text = "" Then
                txtUsuario.Clear()
            Else
                'OBTENER NOMBRE DEL USUARIO
                Dim da_nombre As New SqlCeDataAdapter("SELECT IDTELEFONO, NOMBREUSUARIO FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO WHERE IDTELEFONO = '" & txtNumeroUsuario.Text & "'", cn)
                da_nombre.SelectCommand.CommandType = CommandType.Text
                Dim dt_nombre As New DataTable
                da_nombre.Fill(dt_nombre)

                If dt_nombre.Rows.Count > 0 Then
                    txtUsuario.Text = dt_nombre.Rows(0).Item(1).ToString
                Else
                    MsgBox("El usuario no existe.", MsgBoxStyle.Information, "Error")
                    txtNumeroUsuario.Clear()
                    txtUsuario.Focus()
                    txtUsuario.Clear()
                    Exit Sub
                End If
            End If

        Catch

        End Try

    End Sub

    Private Sub txtUsuario_Leave(sender As Object, e As EventArgs) Handles txtUsuario.Leave

        Try
            If txtUsuario.Text = "" Then
                txtNumeroUsuario.Clear()
            Else
                'OBTENER NÚMERO DEL USUARIO
                Dim da_numero As New SqlCeDataAdapter("SELECT IDTELEFONO, NOMBREUSUARIO FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO WHERE NOMBREUSUARIO = '" & txtUsuario.Text & "'", cn)
                da_numero.SelectCommand.CommandType = CommandType.Text
                Dim dt_numero As New DataTable
                da_numero.Fill(dt_numero)
                If dt_numero.Rows.Count > 0 Then
                    txtNumeroUsuario.Text = dt_numero.Rows(0).Item(0).ToString
                Else
                    MsgBox("El número no existe.", MsgBoxStyle.Information, "Error")
                    txtNumeroUsuario.Clear()
                    txtUsuario.Clear()
                    txtUsuario.Focus()
                    Exit Sub
                End If
            End If

        Catch

        End Try

    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Me.ActiveControl = Nothing

        Try
            DataGridView1.DataSource = Nothing

            If chbTodos.Checked = True Then

                Dim consulta As New SqlCeDataAdapter("SELECT IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, FECHA_HISTORIAL AS FECHA_INCIDENTE, ESTATUS_HISTORIAL AS ESTATUS, CATEGORIA AS CATEGORIA, MONTO_HISTORIAL AS MONTO, DESC_HISTORIAL AS DESCONTADO, INCIDENTE_HISTORIAL AS INCIDENTE FROM HISTORIAL INNER JOIN CATEGORIAS ON HISTORIAL.IDCATEGORIA=CATEGORIAS.IDCATEGORIA WHERE DESC_HISTORIAL = 'NO' AND MONTO_HISTORIAL > 0 AND FECHA_HISTORIAL >= @FECHAINICIAL AND FECHA_HISTORIAL <= @FECHAFINAL ORDER BY FECHA_HISTORIAL", cn)
                consulta.SelectCommand.CommandType = CommandType.Text
                consulta.SelectCommand.Parameters.AddWithValue("@FECHAINICIAL", DateTimePicker1.Text)
                consulta.SelectCommand.Parameters.AddWithValue("@FECHAFINAL", DateTimePicker2.Text)
                Dim dt_consulta As New DataTable
                consulta.Fill(dt_consulta)

                If dt_consulta.Rows.Count > 0 Then

                    DataGridView1.DataSource = dt_consulta
                    DataGridView1.ClearSelection()
                    Me.DataGridView1.Columns(0).Width = 70
                    Me.DataGridView1.Columns(1).Width = 200
                    Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


                    'CALCULA EL TOTAL DE LA COLUMNA #4
                    Dim total As Double
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        total = total + DataGridView1.Rows(i).Cells(5).Value
                    Next

                    Dim fila = dt_consulta.NewRow
                    fila(4) = "TOTAL:"
                    fila(5) = total.ToString("N2")
                    dt_consulta.Rows.Add(fila)

                    'NEGRITAS EN LA ÚLTIMA FILA
                    Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.Font = New Font("Malgum Gothic", 8, FontStyle.Regular)

                    'PINTA EL TEXTO DE LA ÚLTIMA FILA
                    Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                    'PINTA EL FONDO DE LA ÚLTIMA FILA
                    Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.BackColor = Color.SteelBlue

                Else
                    MsgBox("No hay datos para mostrar", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If

            ElseIf chbTodos.Checked = False Then

                If txtNumeroUsuario.Text.Length <> 0 Then

                    Dim consulta1 As New SqlCeDataAdapter("SELECT IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, FECHA_HISTORIAL AS FECHA_INCIDENTE, ESTATUS_HISTORIAL AS ESTATUS, CATEGORIA AS CATEGORIA, MONTO_HISTORIAL AS MONTO, DESC_HISTORIAL AS DESCONTADO, INCIDENTE_HISTORIAL AS INCIDENTE FROM HISTORIAL INNER JOIN CATEGORIAS ON HISTORIAL.IDCATEGORIA = CATEGORIAS.IDCATEGORIA WHERE IDTELEFONO=@IDTELEFONO AND FECHA_HISTORIAL >= @FECHAINICIAL AND FECHA_HISTORIAL <= @FECHAFINAL", cn)
                    consulta1.SelectCommand.CommandType = CommandType.Text
                    consulta1.SelectCommand.Parameters.AddWithValue("@FECHAINICIAL", DateTimePicker1.Text)
                    consulta1.SelectCommand.Parameters.AddWithValue("@FECHAFINAL", DateTimePicker2.Text)
                    consulta1.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", txtNumeroUsuario.Text)
                    Dim dt_consulta1 As New DataTable
                    consulta1.Fill(dt_consulta1)

                    If dt_consulta1.Rows.Count > 0 Then

                        DataGridView1.DataSource = dt_consulta1
                        DataGridView1.ClearSelection()
                        Me.DataGridView1.Columns(0).Width = 70
                        Me.DataGridView1.Columns(1).Width = 200
                        Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                        'CALCULA EL TOTAL DE LA COLUMNA #4
                        Dim total As Double
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            total = total + DataGridView1.Rows(i).Cells(5).Value
                        Next

                        Dim fila = dt_consulta1.NewRow
                        fila(4) = "TOTAL:"
                        fila(5) = total.ToString("N2")
                        dt_consulta1.Rows.Add(fila)

                        'NEGRITAS EN LA ÚLTIMA FILA
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.Font = New Font("Malgun Gothic", 8, FontStyle.Regular)

                        'PINTA EL TEXTO DE LA ÚLTIMA FILA
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                        'PINTA EL FONDO DE LA ÚLTIMA FILA
                        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.BackColor = Color.SteelBlue

                    Else
                        MsgBox("No hay datos para mostrar", MsgBoxStyle.Information, "Aviso")
                        Exit Sub
                    End If

                Else
                    MsgBox("Debe seleccionar un teléfono.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If
            End If

            ObtenerNumeracion()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        If DataGridView1.Rows.Count > 0 Then
            MsgBox("Por favor, espere unos segundos mientras generamos la lista en excel.", MsgBoxStyle.Information, "Aviso")
            Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
            Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
            worksheet = workbook.Sheets(1)
            worksheet = workbook.ActiveSheet
            'Aca se agregan las cabeceras de nuestro datagrid.

            For i As Integer = 1 To Me.DataGridView1.Columns.Count
                worksheet.Cells(1, i) = Me.DataGridView1.Columns(i - 1).HeaderText
            Next

            'Aca se ingresa el detalle recorrera la tabla celda por celda

            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                For j As Integer = 0 To Me.DataGridView1.Columns.Count - 1
                    worksheet.Cells(i + 2, j + 1) = Me.DataGridView1.Rows(i).Cells(j).Value.ToString()
                Next
            Next

            'Aca le damos el formato a nuestro excel

            worksheet.Rows.Item(1).Font.Bold = 1
            worksheet.Rows.Item(1).HorizontalAlignment = 3
            worksheet.Columns.AutoFit()
            worksheet.Columns.HorizontalAlignment = 1

            app.Visible = True
            app = Nothing
            workbook = Nothing

            worksheet = Nothing
            FileClose(1)
            GC.Collect()
        Else
            MsgBox("No hay datos para exportar", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If

    End Sub

    Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged

        If chbTodos.Checked = True Then

            txtNumeroUsuario.Clear()
            txtUsuario.Clear()
            txtNumeroUsuario.Enabled = False
            txtUsuario.Enabled = False

        ElseIf chbTodos.Checked = False Then

            txtNumeroUsuario.Enabled = True
            txtUsuario.Enabled = True

        End If

    End Sub


    '************************************************************************************************************
    '************************************************************************************************************
    '************************************************************************************************************
    'METODO PARA ABRIR FORMULARIO DENTRO DEL PANEL 
    Private Sub AbrirFormEnPanel(Of Forms As {Form, New})()

        Dim formulario As Form
        formulario = frmMenu.PanelContenedor.Controls.OfType(Of Forms)().FirstOrDefault()

        If formulario Is Nothing Then
            formulario = New Forms()
            formulario.TopLevel = False
            formulario.Location = New Point(120, 95)
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.None
            formulario.Show()
            formulario.BringToFront()
            frmMenu.PanelContenedor.Controls.Add(formulario)
            frmMenu.PanelContenedor.Tag = formulario
        Else

            If formulario.WindowState = FormWindowState.Minimized Then
                formulario.WindowState = FormWindowState.Normal
            End If

            formulario.BringToFront()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Cursor = Cursors.WaitCursor

        AbrirFormEnPanel(Of frmMant_Equipo)()
        Dim f3 As frmMant_Equipo = CType(Application.OpenForms("frmMant_Equipo"), frmMant_Equipo)
        f3.BringToFront()
        f3.btnLimpiar.PerformClick()
        f3.btnMantenimiento.PerformClick()
        f3.cboNumero.Text = Me.DataGridView1.SelectedCells(0).Value.ToString
        f3.btnVerificar.PerformClick()
        f3.BringToFront()

        Cursor = Cursors.Default

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then
            Me.Dispose()
        Else
            Exit Sub
        End If

    End Sub

End Class