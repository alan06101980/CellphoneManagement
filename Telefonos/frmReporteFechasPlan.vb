Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmReporteFechasPlan

    Dim dv As New DataView

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

    Private Sub frmReporteFechasPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadioButton4.Enabled = False
        TextBox1.Enabled = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

        btnConsultar.Enabled = False

    End Sub

    Private Sub ObtenerNumeracion()

        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = CStr(i + 1)
        Next

    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Cursor = Cursors.WaitCursor

        Me.ActiveControl = Nothing

        RadioButton4.Enabled = False
        TextBox1.Clear()
        TextBox1.Enabled = False

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Try

            'Dim consulta As New SqlCeDataAdapter("SELECT TELEFONO.IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, PROVEEDOR AS PROVEEDOR, STATUS_CAT AS STATUS, MARCA AS MARCA, MODELO AS MODELO, PRECIO AS PRECIO, PLAN_LINEA AS PLAN_LINEA, CONVERT(NVARCHAR(10), FECHACOMPRA, 101) AS FECHA_COMPRA FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR INNER JOIN MARCA ON TELEFONO.IDMARCA=MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO=MODELO.IDMODELO INNER JOIN PLANES ON TELEFONO.IDPLAN=PLANES.IDPLAN ORDER BY FECHACOMPRA", cn)

            If RadioButton1.Checked = True Then

                Dim consulta As New SqlCeDataAdapter("SELECT TELEFONO.IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, PROVEEDOR AS PROVEEDOR, STATUS_CAT AS STATUS, MARCA AS MARCA, MODELO AS MODELO, PRECIO AS PRECIO, PLAN_LINEA AS PLAN_LINEA, FECHACOMPRA AS FECHA_COMPRA FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR INNER JOIN MARCA ON TELEFONO.IDMARCA=MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO=MODELO.IDMODELO INNER JOIN PLANES ON TELEFONO.IDPLAN=PLANES.IDPLAN WHERE STATUS_CAT <> 'DE BAJA' OR STATUS_CAT <> 'SUSPENDIDO' ORDER BY FECHACOMPRA", cn)
                consulta.SelectCommand.CommandType = CommandType.Text

                Dim ds As New DataSet
                consulta.Fill(ds)
                dv.Table = ds.Tables(0)
                'DataGridView1.DataSource = dv

                If ds.Tables(0).Rows.Count > 0 Then

                    'DataGridView1.DataSource = ds
                    DataGridView1.DataSource = dv
                    DataGridView1.ClearSelection()
                    Me.DataGridView1.Columns(0).Width = 70
                    Me.DataGridView1.Columns(1).Width = 180
                    Me.DataGridView1.Columns(3).Width = 70
                    Me.DataGridView1.Columns(7).Width = 180
                    DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DataGridView1.Columns("USUARIO").Frozen = True

                    DataGridView1.Columns.Add("MESES", "MESES")
                    DataGridView1.Columns("MESES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else
                    MsgBox("No hay datos para mostrar.", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If

            ElseIf RadioButton2.Checked = True Then

                Dim consulta As New SqlCeDataAdapter("SELECT TELEFONO.IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, PROVEEDOR AS PROVEEDOR, STATUS_CAT AS STATUS, MARCA AS MARCA, MODELO AS MODELO, PRECIO AS PRECIO, PLAN_LINEA AS PLAN_LINEA, FECHACOMPRA AS FECHA_COMPRA FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR INNER JOIN MARCA ON TELEFONO.IDMARCA=MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO=MODELO.IDMODELO INNER JOIN PLANES ON TELEFONO.IDPLAN=PLANES.IDPLAN WHERE STATUS_CAT = 'DE BAJA' OR STATUS_CAT = 'SUSPENDIDO' ORDER BY FECHACOMPRA", cn)
                consulta.SelectCommand.CommandType = CommandType.Text
                Dim ds As New DataSet
                consulta.Fill(ds)
                dv.Table = ds.Tables(0)
                'DataGridView1.DataSource = dv

                If ds.Tables(0).Rows.Count > 0 Then

                    'DataGridView1.DataSource = ds
                    DataGridView1.DataSource = dv
                    DataGridView1.ClearSelection()
                    Me.DataGridView1.Columns("USUARIO").Width = 200
                    DataGridView1.Columns("USUARIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("MODELO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("PRECIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.DataGridView1.Columns("PLAN_LINEA").Width = 150
                    DataGridView1.Columns("PLAN_LINEA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("FECHA_COMPRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DataGridView1.Columns("USUARIO").Frozen = True

                    DataGridView1.Columns.Add("MESES", "MESES")
                    DataGridView1.Columns("MESES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else
                    MsgBox("No hay datos para mostrar.", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If


            ElseIf RadioButton3.Checked = True Then

                Dim consulta As New SqlCeDataAdapter("SELECT TELEFONO.IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, PROVEEDOR AS PROVEEDOR, STATUS_CAT AS STATUS, MARCA AS MARCA, MODELO AS MODELO, PRECIO AS PRECIO, PLAN_LINEA AS PLAN_LINEA, FECHACOMPRA AS FECHA_COMPRA FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR INNER JOIN MARCA ON TELEFONO.IDMARCA=MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO=MODELO.IDMODELO INNER JOIN PLANES ON TELEFONO.IDPLAN=PLANES.IDPLAN ORDER BY FECHACOMPRA", cn)
                consulta.SelectCommand.CommandType = CommandType.Text
                Dim ds As New DataSet
                consulta.Fill(ds)
                dv.Table = ds.Tables(0)
                'DataGridView1.DataSource = dv

                If ds.Tables(0).Rows.Count > 0 Then

                    'DataGridView1.DataSource = ds
                    DataGridView1.DataSource = dv
                    DataGridView1.ClearSelection()
                    Me.DataGridView1.Columns("USUARIO").Width = 200
                    DataGridView1.Columns("USUARIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("MODELO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("PRECIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.DataGridView1.Columns("PLAN_LINEA").Width = 150
                    DataGridView1.Columns("PLAN_LINEA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns("FECHA_COMPRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DataGridView1.Columns("USUARIO").Frozen = True

                    DataGridView1.Columns.Add("MESES", "MESES")
                    DataGridView1.Columns("MESES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Else
                    MsgBox("No hay datos para mostrar.", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If

            End If

            Calcular_Meses()

            ObtenerNumeracion()

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Calcular_Meses()

        For X = 0 To DataGridView1.Rows.Count - 1

            Dim dt1 As Date = Date.Parse(DataGridView1.Rows(X).Cells(8).Value)
            Dim dt2 As Date = Date.Parse(Date.Today)
            DataGridView1.Rows(X).Cells(9).Value = DateDiff(DateInterval.Month, dt1, dt2)

        Next

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        Cursor = Cursors.WaitCursor

        Me.ActiveControl = Nothing

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

            Cursor = Cursors.Default

        Else
            MsgBox("No hay datos para exportar", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If

    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Or RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            btnConsultar.Enabled = True
        Else
            btnConsultar.Enabled = False
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If RadioButton1.Checked = True Or RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            btnConsultar.Enabled = True
        Else
            btnConsultar.Enabled = False
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If RadioButton1.Checked = True Or RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            btnConsultar.Enabled = True
        Else
            btnConsultar.Enabled = False
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
        f3.btnMantenimiento.PerformClick()
        f3.btnLimpiar.PerformClick()
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

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

        RadioButton4.Enabled = True

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Try
            dv.RowFilter = String.Format("USUARIO LIKE '%{0}%'", TextBox1.Text)
            Calcular_Meses()
            DataGridView1.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub RadioButton4_MouseClick(sender As Object, e As MouseEventArgs) Handles RadioButton4.MouseClick
        TextBox1.Enabled = True
    End Sub
End Class