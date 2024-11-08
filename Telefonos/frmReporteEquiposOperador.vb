Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmReporteEquiposOperador

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

    Private Sub frmReporteEquiposOperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False
        DataGridView2.RowHeadersVisible = False
        DataGridView3.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})
        DataGridView2.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView2, New Object() {True})
        DataGridView3.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView3, New Object() {True})

        Carga_DGV1()
        Carga_DGV2()
        Carga_DGV3()

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV1 As DataGridView
        DGV1 = CType(sender, DataGridView)
        DGV1.ClearSelection()

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView2_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView2.DataBindingComplete

        Dim DGV2 As DataGridView
        DGV2 = CType(sender, DataGridView)
        DGV2.ClearSelection()

    End Sub

    Private Sub DataGridView3_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView3.DataBindingComplete

        Dim DGV3 As DataGridView
        DGV3 = CType(sender, DataGridView)
        DGV3.ClearSelection()

    End Sub

    Private Sub Carga_DGV1()

        Try
            DataGridView1.DataSource = Nothing

            Dim consulta1 As New SqlCeDataAdapter("SELECT PROVEEDOR AS PROVEEDOR, COUNT(IDTELEFONO) AS CANTIDAD FROM TELEFONO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR = PROVEEDOR.IDPROVEEDOR WHERE STATUS_CAT = 'EN USO' GROUP BY PROVEEDOR", cn)
            consulta1.SelectCommand.CommandType = CommandType.Text
            Dim dt_consulta1 As New DataTable
            consulta1.Fill(dt_consulta1)

            If dt_consulta1.Rows.Count > 0 Then

                DataGridView1.DataSource = dt_consulta1
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'CALCULA EL TOTAL DE LA COLUMNA #2
                Dim total As Double
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    total = total + DataGridView1.Rows(i).Cells(1).Value
                Next

                Dim fila1 = dt_consulta1.NewRow
                fila1(0) = "TOTAL DE EQUIPOS:"
                fila1(1) = total.ToString '("N")
                dt_consulta1.Rows.Add(fila1)

                Me.DataGridView1.Columns(0).Width = 80
                Me.DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'NEGRITAS EN LA ÚLTIMA FILA
                Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.Font = New Font("Malgun Gothic", 9, FontStyle.Regular)

                'PINTA EL TEXTO DE LA ÚLTIMA FILA
                Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                'PINTA EL FONDO DE LA ÚLTIMA FILA
                Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).DefaultCellStyle.BackColor = Color.SteelBlue

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Carga_DGV2()

        Try
            DataGridView2.DataSource = Nothing

            Dim consulta2 As New SqlCeDataAdapter("SELECT PROVEEDOR AS PROVEEDOR, MARCA AS MARCA, MODELO AS MODELO, DISPOSITIVO AS DISPOSITIVO, COUNT(IDTELEFONO) AS CANTIDAD FROM TELEFONO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR = PROVEEDOR.IDPROVEEDOR INNER JOIN MARCA ON TELEFONO.IDMARCA = MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO = MODELO.IDMODELO INNER JOIN DISPOSITIVO ON TELEFONO.IDDISPOSITIVO = DISPOSITIVO.IDDISPOSITIVO WHERE STATUS_CAT = 'EN USO' GROUP BY PROVEEDOR, MARCA, MODELO, DISPOSITIVO ORDER BY PROVEEDOR", cn)
            consulta2.SelectCommand.CommandType = CommandType.Text
            Dim dt_consulta2 As New DataTable
            consulta2.Fill(dt_consulta2)

            If dt_consulta2.Rows.Count > 0 Then

                DataGridView2.DataSource = dt_consulta2
                Me.DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'CALCULA EL TOTAL DE LA COLUMNA #2
                Dim total As Double
                For j As Integer = 0 To DataGridView2.Rows.Count - 1
                    total = total + DataGridView2.Rows(j).Cells(4).Value
                Next

                Dim fila2 = dt_consulta2.NewRow
                fila2(3) = "TOTAL DE EQUIPOS:"
                fila2(4) = total.ToString '("N")
                dt_consulta2.Rows.Add(fila2)

                Me.DataGridView2.Columns(0).Width = 80
                Me.DataGridView2.Columns(1).Width = 80
                Me.DataGridView2.Columns(2).Width = 180
                Me.DataGridView2.Columns(3).Width = 150
                Me.DataGridView2.Columns(4).Width = 70
                DataGridView2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'NEGRITAS EN LA ÚLTIMA FILA
                DataGridView2.Rows(Me.DataGridView2.RowCount - 1).DefaultCellStyle.Font = New Font("Malgun Gothic", 9, FontStyle.Regular)

                'PINTA EL TEXTO DE LA ÚLTIMA FILA
                DataGridView2.Rows(Me.DataGridView2.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                'PINTA EL FONDO DE LA ÚLTIMA FILA
                DataGridView2.Rows(Me.DataGridView2.RowCount - 1).DefaultCellStyle.BackColor = Color.SteelBlue

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Carga_DGV3()

        Try
            DataGridView3.DataSource = Nothing

            Dim consulta3 As New SqlCeDataAdapter("SELECT IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS NOMBRE_USUARIO, MARCA AS MARCA, MODELO AS MODELO FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO = USUARIO.IDUSUARIO INNER JOIN MARCA ON TELEFONO.IDMARCA = MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO = MODELO.IDMODELO WHERE TELEFONO.STATUS_CAT = 'LIBRE'", cn)
            consulta3.SelectCommand.CommandType = CommandType.Text
            Dim dt_consulta3 As New DataTable
            consulta3.Fill(dt_consulta3)

            If dt_consulta3.Rows.Count > 0 Then

                DataGridView3.DataSource = dt_consulta3
                Me.DataGridView3.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.DataGridView3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

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