Imports System.Data
Imports System.Configuration
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmBuscaUsuario

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

    Private Sub frmBuscaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        'Me.KeyPreview = True

        txtNombreUsuario.Focus()
        Cargar_Usuarios()

        'ESCONDE LA PRIMERA COLUMNA
        DataGridView1.RowHeadersVisible = False

        'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
        DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

        Me.DataGridView1.Columns(0).Width = 80
        Me.DataGridView1.Columns(1).Width = 250

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            txtNombreUsuario.Text = DataGridView1.Item(1, e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub Cargar_Usuarios()
        Try
            cn.Open()
            'Dim da As New SqlCeDataAdapter("SELECT IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO FROM TELEFONO INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO WHERE STATUSUSUARIO = 'ACTIVO' ORDER BY IDTELEFONO ASC", cn)
            Dim da As New SqlCeDataAdapter("SELECT Telefono.idTelefono AS NÚMERO, Usuario.NombreUsuario AS USUARIO, Dispositivo.Dispositivo AS DISPOSITIVO, Proveedor.Proveedor AS PROVEEDOR FROM Telefono INNER JOIN Usuario ON Telefono.idUsuario = Usuario.idUsuario INNER JOIN Dispositivo ON Telefono.idDispositivo = Dispositivo.idDispositivo INNER JOIN Proveedor ON Telefono.idProveedor = Proveedor.idProveedor WHERE Usuario.StatusUsuario = 'ACTIVO' ORDER BY NÚMERO ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet
            da.Fill(ds)
            cn.Close()
            dv.Table = ds.Tables(0)
            DataGridView1.DataSource = dv
            DataGridView1.ClearSelection()

            DataGridView1.Columns("USUARIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnTraspasar_Click(sender As Object, e As EventArgs) Handles btnTraspasar.Click
        Me.ActiveControl = Nothing
        Try
            If txtNombreUsuario.Text = "" Then
                MsgBox("Debe seleccionar un trabajador antes de presionar este botón", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            Else

                Dim f3 As frmMant_Equipo = CType(Application.OpenForms("frmMant_Equipo"), frmMant_Equipo)
                f3.Limpiar()
                f3.cboNumero.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
                f3.btnVerificar.PerformClick()
                f3.btnVerificar.Focus()
                f3.DataGridView1.ClearSelection()
                Me.Dispose()

            End If
        Catch
            MsgBox("Seleccione un usuario de la lista", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End Try

    End Sub

    Private Sub txtNombreUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtNombreUsuario.TextChanged

        Try
            dv.RowFilter = String.Format("USUARIO LIKE '%{0}%'", txtNombreUsuario.Text)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

End Class