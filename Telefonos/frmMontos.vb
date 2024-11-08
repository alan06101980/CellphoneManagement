Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmMontos

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


    Private Sub frmMontos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

        Consulta()

    End Sub

    Private Sub Consulta()

        Try
            DataGridView1.DataSource = Nothing

            Dim consulta As New SqlCeDataAdapter("SELECT PROVEEDOR AS PROVEEDOR, TELEFONO.IDCECO AS CÓDIGO, CECO AS CENTRO_COSTO, CAST(COALESCE(SUM(PRECIO_PLAN),0) AS NUMERIC(10,2)) AS MONTO FROM TELEFONO INNER JOIN CENTROCOSTO ON TELEFONO.IDCECO = CENTROCOSTO.IDCECO INNER JOIN PLANES ON TELEFONO.IDPLAN = PLANES.IDPLAN INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR = PROVEEDOR.IDPROVEEDOR WHERE TELEFONO.STATUS_CAT = 'EN USO' GROUP BY PROVEEDOR, TELEFONO.IDCECO, CECO", cn)
            consulta.SelectCommand.CommandType = CommandType.Text
            Dim dt_consulta As New DataTable
            consulta.Fill(dt_consulta)

            If dt_consulta.Rows.Count > 0 Then

                DataGridView1.DataSource = dt_consulta

                'CALCULA EL TOTAL DE LA COLUMNA #3
                Dim total As Double
                For k As Integer = 0 To DataGridView1.Rows.Count - 1
                    total = total + DataGridView1.Rows(k).Cells(3).Value
                Next

                Dim fila = dt_consulta.NewRow
                fila(2) = "MONTO TOTAL:"
                fila(3) = total.ToString("N2")
                dt_consulta.Rows.Add(fila)
            Else
                MsgBox("No hay datos para mostrar.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If

            Cursor = Cursors.Default
            'NEGRITAS EN LA ÚLTIMA FILA
            DataGridView1.Rows(DataGridView1.RowCount - 1).DefaultCellStyle.Font = New Font("Malgun Gothic", 8, FontStyle.Regular)

            'PINTA EL TEXTO DE LA ÚLTIMA FILA
            DataGridView1.Rows(DataGridView1.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

            'PINTA EL FONDO DE LA ÚLTIMA FILA
            DataGridView1.Rows(DataGridView1.RowCount - 1).DefaultCellStyle.BackColor = Color.SteelBlue

            DataGridView1.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Me.DataGridView1.Columns(0).Width = 80
        Me.DataGridView1.Columns(1).Width = 80
        Me.DataGridView1.Columns(2).Width = 220
        Me.DataGridView1.Columns(3).Width = 80

        Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        Cursor = Cursors.WaitCursor

        If DataGridView1.Rows.Count > 0 Then
            'MsgBox("Por favor, espere unos segundos mientras generamos la lista en excel.", MsgBoxStyle.Information, "Aviso")
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

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then
            Me.Dispose()
        Else
            Exit Sub
        End If

    End Sub

End Class