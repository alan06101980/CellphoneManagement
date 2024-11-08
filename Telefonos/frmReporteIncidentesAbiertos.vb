Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmReporteIncidentesAbiertos

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

    Private Sub frmReporteIncidentesAbiertos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ESCONDE LA PRIMERA COLUMNA
        'DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

    End Sub

    Private Sub ObtenerNumeracion()

        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = CStr(i + 1)
        Next

    End Sub


    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Me.ActiveControl = Nothing

        Try
            DataGridView1.DataSource = Nothing

            Dim consulta As New SqlCeDataAdapter("SELECT HISTORIAL.IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, PROVEEDOR AS PROVEEDOR, FECHA_HISTORIAL AS FECHA_INCIDENTE, ESTATUS_HISTORIAL AS ESTATUS, CATEGORIA AS CATEGORIA, MONTO_HISTORIAL AS MONTO, DESC_HISTORIAL AS DESCONTADO, INCIDENTE_HISTORIAL AS INCIDENTE FROM HISTORIAL INNER JOIN CATEGORIAS ON HISTORIAL.IDCATEGORIA=CATEGORIAS.IDCATEGORIA INNER JOIN TELEFONO ON HISTORIAL.IDTELEFONO=TELEFONO.IDTELEFONO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR WHERE ESTATUS_HISTORIAL = 'ABIERTO' AND  FECHA_HISTORIAL BETWEEN @FECHAINICIAL AND @FECHAFINAL ORDER BY FECHA_HISTORIAL", cn)
            consulta.SelectCommand.CommandType = CommandType.Text
            consulta.SelectCommand.Parameters.AddWithValue("@FECHAINICIAL", DTP_Desde.Text)
            consulta.SelectCommand.Parameters.AddWithValue("@FECHAFINAL", DTP_Hasta.Text)
            Dim dt_consulta As New DataTable
            consulta.Fill(dt_consulta)

            If dt_consulta.Rows.Count > 0 Then

                DataGridView1.DataSource = dt_consulta
                DataGridView1.ClearSelection()
                Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView1.Columns(0).Width = 70
                Me.DataGridView1.Columns(1).Width = 180
                Me.DataGridView1.Columns(5).Width = 150
                Me.DataGridView1.Columns(8).Width = 600
            Else
                MsgBox("No hay datos para mostrar.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
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