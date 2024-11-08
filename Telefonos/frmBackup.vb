Imports System.IO
Imports System.Data
Imports System.Security.Permissions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmBackup

    Dim cmd As SqlCeCommand

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            MsgBox("El proceso se realizó correctamente", MsgBoxStyle.Information, "Información")
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If

    End Sub
    Private Sub BtnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click

        Me.ActiveControl = Nothing

        Cursor = Cursors.WaitCursor

        Try
            SaveFileDialog1.Title = "Realizar Backup"
            SaveFileDialog1.Filter = "(*.bak)|*.bak"
            SaveFileDialog1.FileName = "BACKUP_TELEFONOS_" + Now.ToString("dd-MM-yyyy_hh.mm.ss")
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim Path As String = My.Application.Info.DirectoryPath + "\Telefonos.sdf"
                FileCopy(Path, SaveFileDialog1.FileName)

                Timer1.Enabled = True
                ProgressBar1.Visible = True
                cn.Close()
            Else
                Cursor = Cursors.Default
                Exit Sub
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub BtnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click

        Me.ActiveControl = Nothing

        Cursor = Cursors.WaitCursor

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Archivos de Backup (*.bak)|*.bak"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Title = "Abrir archivo de backup"
        SaveFileDialog1.FileName = "Telefonos.sdf"

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            cn.Close()
            Try
                File.Delete(My.Application.Info.DirectoryPath + "\Telefonos.sdf")
                FileCopy(OpenFileDialog1.FileName, SaveFileDialog1.FileName)

                Timer1.Enabled = True
                ProgressBar1.Visible = True

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then
            Me.Close()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
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

End Class