Imports System.Runtime.InteropServices

Public Class frmCargando

    '<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    'Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
    'End Function

    'SendMessage(ProgressBar1.Handle, 1040, 3, 0)

    Private Sub FrmCargando_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.BringToFront()
        Me.ProgressBar1.Maximum = 100
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.RunWorkerAsync()
        frmMenu.btnEquipos.Enabled = False

    End Sub

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

    '************************************************************************************
    '************************************************************************************
    'METODOS PARA ABRIR FORM EN PANEL
    '************************************************************************************
    '************************************************************************************

    'METODO PARA ABRIR FORMULARIO DENTRO DEL PANEL 
    Private Sub AbrirFormEnPanel(Of Forms As {Form, New})()

        Dim formulario As Form
        formulario = frmMenu.PanelContenedor.Controls.OfType(Of Forms)().FirstOrDefault()

        If formulario Is Nothing Then

            formulario = New Forms()
            formulario.TopLevel = False
            formulario.Location = New Point(20, 20)
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.None
            formulario.Show()
            frmMenu.PanelContenedor.Controls.Add(formulario)
            frmMenu.PanelContenedor.Tag = formulario
            formulario.BringToFront()

        Else
            'If formulario.WindowState = FormWindowState.Minimized Then
            '    formulario.WindowState = FormWindowState.Normal
            'End If

            If formulario.Visible = False Then
                formulario.Show()
            Else
                formulario.BringToFront()
            End If
        End If

    End Sub

    Public Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For x = 0 To 10
            Threading.Thread.Sleep(200)
            BackgroundWorker1.ReportProgress(x * 10)
        Next x
    End Sub

    Public Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Public Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        Me.ProgressBar1.Visible = False
        Me.ProgressBar1.Value = 0
        AbrirFormEnPanel(Of frmMant_Equipo)()
        frmMenu.btnEquipos.Enabled = True
        Me.Hide()

    End Sub

End Class