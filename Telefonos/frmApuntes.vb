Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmApuntes

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

    Private Sub frmApuntes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim mostrar As New SqlCeDataAdapter("SELECT APUNTES FROM APUNTES WHERE ID=@ID", cn)
        mostrar.SelectCommand.CommandType = CommandType.Text
        mostrar.SelectCommand.Parameters.AddWithValue("@ID", "1")
        Dim ds_mostrar As New DataSet
        mostrar.Fill(ds_mostrar)

        TextBox1.Text = ds_mostrar.Tables(0).Rows(0)("APUNTES").ToString

        TextBox1.Focus()
        TextBox1.Select(TextBox1.Text.Length, 0)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Try

            Dim transactionOptions = New TransactionOptions()
            transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
            transactionOptions.Timeout = TransactionManager.MaximumTimeout

            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                If (cn.State = ConnectionState.Closed) Then cn.Open()

                Dim actualizar As New SqlCeCommand("UPDATE APUNTES SET APUNTES=@APUNTES WHERE ID=@ID", cn)
                actualizar.CommandType = CommandType.Text
                actualizar.Parameters.AddWithValue("@ID", "1")
                actualizar.Parameters.AddWithValue("@APUNTES", TextBox1.Text)
                actualizar.ExecuteNonQuery()
                tran1.Complete()
                cn.Close()
                tran1.Dispose()
                Exit Sub

            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        Try

            Dim transactionOptions = New TransactionOptions()
            transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
            transactionOptions.Timeout = TransactionManager.MaximumTimeout

            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                If (cn.State = ConnectionState.Closed) Then cn.Open()

                Dim actualizar As New SqlCeCommand("UPDATE APUNTES SET APUNTES=@APUNTES WHERE ID=@ID", cn)
                actualizar.CommandType = CommandType.Text
                actualizar.Parameters.AddWithValue("@ID", "1")
                actualizar.Parameters.AddWithValue("@APUNTES", TextBox1.Text)
                actualizar.ExecuteNonQuery()
                tran1.Complete()
                cn.Close()
                tran1.Dispose()
                Me.Dispose()
                Exit Sub

            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class