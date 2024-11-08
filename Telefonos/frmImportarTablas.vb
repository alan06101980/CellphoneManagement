Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports ErikEJ.SqlCe

Public Class frmImportarTablas

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

    Private Sub frmImportarTablas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA ÁREA***********************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelArea_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelArea.Click
        Me.ActiveControl = Nothing
        OpenFileDialogArea.ShowDialog()

    End Sub

    Private Sub btnImportarArea_Click(sender As Object, e As EventArgs) Handles btnImportarArea.Click
        Me.ActiveControl = Nothing
        If txtImportarArea.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarArea.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)
            'DataGridView1.DataSource = data

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "Area"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Áreas realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarArea.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                txtImportarArea.Clear()
                cn.Close()
                Exit Sub

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarArea.Clear()
        End Try

    End Sub

    Private Sub OpenFileDialogArea_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogArea.FileOk
        Me.ActiveControl = Nothing
        txtImportarArea.Text = OpenFileDialogArea.FileName

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA CECOS**********************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelCecos_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelCecos.Click
        Me.ActiveControl = Nothing
        OpenFileDialogCecos.ShowDialog()

    End Sub

    Private Sub btnImportarCecos_Click(sender As Object, e As EventArgs) Handles btnImportarCecos.Click
        Me.ActiveControl = Nothing
        If txtImportarCecos.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarCecos.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "CentroCosto"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Centros de Costo realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarCecos.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                txtImportarCecos.Clear()
                cn.Close()
                Exit Sub
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarCecos.Clear()
        End Try

    End Sub


    Private Sub OpenFileDialogCecos_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogCecos.FileOk
        Me.ActiveControl = Nothing
        txtImportarCecos.Text = OpenFileDialogCecos.FileName

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA TELÉFONOS******************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelEquipos_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelEquipos.Click
        Me.ActiveControl = Nothing
        OpenFileDialogEquipos.ShowDialog()

    End Sub

    Private Sub btnImportarEquipos_Click(sender As Object, e As EventArgs) Handles btnImportarEquipos.Click
        Me.ActiveControl = Nothing
        If txtImportarEquipos.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarEquipos.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "Telefono"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Tabla Principal realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarEquipos.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                txtImportarEquipos.Clear()
                cn.Close()
                Exit Sub
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarEquipos.Clear()
        End Try

    End Sub


    Private Sub OpenFileDialogEquipos_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogEquipos.FileOk
        Me.ActiveControl = Nothing
        txtImportarEquipos.Text = OpenFileDialogEquipos.FileName

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA MARCA**********************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelMarca_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelMarca.Click
        Me.ActiveControl = Nothing
        OpenFileDialogMarca.ShowDialog()

    End Sub

    Private Sub btnImportarMarca_Click(sender As Object, e As EventArgs) Handles btnImportarMarca.Click
        Me.ActiveControl = Nothing
        If txtImportarMarca.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarMarca.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "Marca"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Marcas realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarMarca.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                txtImportarMarca.Clear()
                cn.Close()
                Exit Sub
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarMarca.Clear()
        End Try

    End Sub


    Private Sub OpenFileDialogMarca_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogMarca.FileOk
        Me.ActiveControl = Nothing
        txtImportarMarca.Text = OpenFileDialogMarca.FileName

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA PLANES*********************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelPlanes_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelPlanes.Click
        Me.ActiveControl = Nothing
        OpenFileDialogPlanes.ShowDialog()

    End Sub

    Private Sub btnImportarPlanes_Click(sender As Object, e As EventArgs) Handles btnImportarPlanes.Click
        Me.ActiveControl = Nothing
        If txtImportarPlanes.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarPlanes.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "Planes"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Planes realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarPlanes.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                cn.Close()
                txtImportarPlanes.Clear()
                Exit Sub
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarPlanes.Clear()
        End Try

    End Sub


    Private Sub OpenFileDialogPlanes_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogPlanes.FileOk
        Me.ActiveControl = Nothing
        txtImportarPlanes.Text = OpenFileDialogPlanes.FileName

    End Sub

    '**************************************************************************************************************************************
    '********************IMPORTAR TABLA USUARIO********************************************************************************************
    '**************************************************************************************************************************************

    Private Sub btnBuscarExcelUsuario_Click(sender As Object, e As EventArgs) Handles btnBuscarExcelUsuario.Click
        Me.ActiveControl = Nothing
        OpenFileDialogUsuario.ShowDialog()

    End Sub

    Private Sub btnImportarUsuario_Click(sender As Object, e As EventArgs) Handles btnImportarUsuario.Click
        Me.ActiveControl = Nothing
        If txtImportarUsuarios.Text = "" Then
            MsgBox("Debe seleccionar la información a importar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try
            Dim sheetN As String = "Hoja1"
            Dim constr As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & txtImportarUsuarios.Text & "';Extended Properties='Excel 8.0;HDR=YES;';")
            Dim EXcon As OleDbConnection = New OleDbConnection(constr)
            Dim oconn As OleDbCommand = New OleDbCommand("Select * From [Hoja1$]", EXcon)
            EXcon.Open()
            Dim sda As OleDbDataAdapter = New OleDbDataAdapter(oconn)
            Dim data As DataTable = New DataTable
            sda.Fill(data)

            Try
                cn.Open()
                Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                Dim bc As SqlCeBulkCopy = New SqlCeBulkCopy(cn, options)
                bc.DestinationTableName = "Usuario"
                bc.WriteToServer(data)
                cn.Close()
                MsgBox("Importación de Usuarios realizada correctamente.", MsgBoxStyle.Information, "Aviso")
                txtImportarUsuarios.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Proceso erróneo, verifica el archivo que deseas importar.", MsgBoxStyle.Exclamation, "Error")
                cn.Close()
                txtImportarUsuarios.Clear()
                Exit Sub
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtImportarUsuarios.Clear()
        End Try

    End Sub


    Private Sub OpenFileDialogUsuario_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogUsuario.FileOk
        Me.ActiveControl = Nothing
        txtImportarUsuarios.Text = OpenFileDialogUsuario.FileName

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