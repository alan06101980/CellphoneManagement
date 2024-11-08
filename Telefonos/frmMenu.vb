Imports System.Data.SqlServerCe

Public Class frmMenu

    Dim iscollapsed_tablas As Boolean = True
    Dim iscollapsed_reportes As Boolean = True

    Private loading As Boolean

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location

        PanelMenu.Width = 45
        btnMaximizar.Visible = False
        btnRestore.Visible = True

        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        'For Each ctl As Control In Me.Controls
        '    Try
        '        Dim Mdi As System.Windows.Forms.Control = CType(ctl, MdiClient)
        '        Mdi.BackColor = System.Drawing.Color.DimGray

        '    Catch a As Exception
        '    End Try
        'Next

        'MUESTRA LA DATA DE LOS APUNTES SI HAY APUNTES ESCRITOS
        Dim mostrar As New SqlCeDataAdapter("SELECT APUNTES FROM APUNTES WHERE ID=@ID", cn)
        mostrar.SelectCommand.CommandType = CommandType.Text
        mostrar.SelectCommand.Parameters.AddWithValue("@ID", "1")
        Dim ds_mostrar As New DataSet
        mostrar.Fill(ds_mostrar)

        If ds_mostrar.Tables(0).Rows(0)("APUNTES").ToString <> Nothing Then

            AbrirFormEnPanel(Of frmApuntes)()

        Else
            'no hacer nada
        End If

    End Sub


    '************************************************************************************
    '************************************************************************************
    'METODOS PARA ABRIR FORM EN PANEL
    '************************************************************************************
    '************************************************************************************

    'METODO PARA ABRIR FORMULARIO DENTRO DEL PANEL 
    Public Sub AbrirFormEnPanel(Of Forms As {Form, New})()

        Dim formulario As Form
        formulario = PanelContenedor.Controls.OfType(Of Forms)().FirstOrDefault()

        If formulario Is Nothing Then

            formulario = New Forms()
            formulario.TopLevel = False
            If formulario.Name = "frmCargando" Then
                If PanelMenu.Width >= 220 Then
                    formulario.Location = New Point(300, 250)
                Else
                    formulario.Location = New Point(450, 250)
                End If
            Else
                formulario.Location = New Point(20, 60)
            End If
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.None
            formulario.Show()
            PanelContenedor.Controls.Add(formulario)
            PanelContenedor.Tag = formulario
            formulario.BringToFront()

        Else
            Dim f As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmCargando").SingleOrDefault()
            Dim f1 As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmMant_Equipo").SingleOrDefault()
            If f IsNot Nothing Then 'Si frmCargando es visible = isnot nothing
                If f1.Visible = True Then
                    f1.BringToFront()
                Else
                    Exit Sub
                End If
            Else
                formulario.BringToFront()
            End If
            formulario.BringToFront()
        End If

    End Sub

    Public Sub BtnEquipos_Click(sender As Object, e As EventArgs) Handles btnEquipos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmCargando)()
    End Sub

    Private Sub BtnTablas_Click(sender As Object, e As EventArgs) Handles BtnTablas.Click
        Me.ActiveControl = Nothing
        TimerTablas.Start()
    End Sub

    Private Sub BtnReportes_Click(sender As Object, e As EventArgs) Handles BtnReportes.Click
        Me.ActiveControl = Nothing
        TimerReportes.Start()
    End Sub

    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmBackup)()
    End Sub

    Private Sub BtnCeCos_Click(sender As Object, e As EventArgs) Handles btnCeCos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmCeCos)()
    End Sub

    Private Sub BtnAreas_Click(sender As Object, e As EventArgs) Handles btnAreas.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmArea)()
    End Sub

    Private Sub BtnDispositivos_Click(sender As Object, e As EventArgs) Handles btnDispositivos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmDispositivo)()
    End Sub

    Private Sub BtnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmPlanes)()
    End Sub

    Private Sub BtnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmProveedor)()
    End Sub

    Private Sub BtnEmpresas_Click(sender As Object, e As EventArgs) Handles btnEmpresas.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmEmpresa)()
    End Sub

    Private Sub BtnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmUsuario)()
    End Sub

    Private Sub BtnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmMarca)()
    End Sub

    Private Sub BtnModelos_Click(sender As Object, e As EventArgs) Handles btnModelos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmModelo)()
    End Sub

    Private Sub BtnApuntes_Click(sender As Object, e As EventArgs) Handles BtnApuntes.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmApuntes)()
    End Sub

    Private Sub BtnDeudores_Click(sender As Object, e As EventArgs) Handles btnDeudores.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteDeudores)()
    End Sub

    Private Sub BtnCerrados_Click(sender As Object, e As EventArgs) Handles btnCerrados.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteCerrados)()
    End Sub

    Private Sub BtnAbiertos_Click(sender As Object, e As EventArgs) Handles btnAbiertos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteIncidentesAbiertos)()
    End Sub

    Private Sub BtnHistoricos_Click(sender As Object, e As EventArgs) Handles btnHistoricos.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteIncidentesTotales)()
    End Sub

    Private Sub BtnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteEquiposDeBaja)()
    End Sub

    Private Sub BtnUltimacompra_Click(sender As Object, e As EventArgs) Handles btnUltimacompra.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteFechasPlan)()
    End Sub

    Private Sub BtnCentrosCosto_Click(sender As Object, e As EventArgs) Handles btnCentrosCosto.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmMontos)()
    End Sub

    Private Sub BtnEquiposOperadores_Click(sender As Object, e As EventArgs) Handles btnEquiposOperadores.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmReporteEquiposOperador)()
    End Sub

    Private Sub BtnImportacion_Click(sender As Object, e As EventArgs) Handles btnImportacion.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmImportarTablas)()
    End Sub

    Private Sub BtnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        Me.ActiveControl = Nothing
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        btnMaximizar.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.ActiveControl = Nothing
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Me.ActiveControl = Nothing
        Me.Size = New Size(1200, 650)
        Me.Location = New Point(100, 40)
        btnMaximizar.Visible = True
        btnRestore.Visible = False
    End Sub

#Region "Mostrar y Ocultar Menu"
    Private Sub tmOCULTAR_Tick(sender As Object, e As EventArgs) Handles tmOcultar.Tick
        Me.ActiveControl = Nothing
        If PanelMenu.Width = 45 Then
            Me.tmOcultar.Enabled = False
        Else

            If PanelTablas.Size = PanelTablas.MaximumSize Then
                PanelTablas.Height = PanelTablas.Height - 5
                PanelTablas.Size = PanelTablas.MinimumSize
                iscollapsed_tablas = True
                TimerTablas.Stop()
            ElseIf PanelReportes.Size = PanelReportes.MaximumSize Then
                PanelReportes.Height = PanelReportes.Height - 5
                PanelReportes.Size = PanelReportes.MinimumSize
                iscollapsed_reportes = True
                TimerReportes.Stop()
            End If
            Me.PanelMenu.Width = PanelMenu.Width - 20
        End If
    End Sub

    Private Sub tmMOSTRAR_Tick(sender As Object, e As EventArgs) Handles tmMostrar.Tick
        Me.ActiveControl = Nothing
        If PanelMenu.Width >= 220 Then
            Me.tmMostrar.Enabled = False
        Else
            Me.PanelMenu.Width = PanelMenu.Width + 20
        End If
    End Sub

    Private Sub MenuSidebar_Click(sender As Object, e As EventArgs) Handles MenuSidebar.Click
        Me.ActiveControl = Nothing

        If PanelMenu.Width >= 220 Then
            tmOcultar.Enabled = True

        ElseIf PanelMenu.Width = 45 Then
            tmMostrar.Enabled = True
        End If

    End Sub

    Private Sub TimerTablas_Tick(sender As Object, e As EventArgs) Handles TimerTablas.Tick

        Me.ActiveControl = Nothing

        tmMostrar.Enabled = True

        If iscollapsed_reportes = False Then
            PanelReportes.Height = PanelReportes.Height - 5
            'PanelReportes.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelReportes.Size = PanelReportes.MinimumSize Then
                TimerReportes.Stop()
                iscollapsed_reportes = True
            End If
        End If

        If iscollapsed_tablas = True Then
            PanelTablas.Height = PanelTablas.Height + 6 'Estaba en 5
            'PanelTablas.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelTablas.Size = PanelTablas.MaximumSize Then
                TimerTablas.Stop()
                iscollapsed_tablas = False
            End If
        Else
            PanelTablas.Height = PanelTablas.Height - 6 'Estaba en 5
            'PanelTablas.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelTablas.Size = PanelTablas.MinimumSize Then
                TimerTablas.Stop()
                iscollapsed_tablas = True
            End If

        End If

    End Sub

    Private Sub TimerReportes_Tick(sender As Object, e As EventArgs) Handles TimerReportes.Tick

        Me.ActiveControl = Nothing

        tmMostrar.Enabled = True

        If iscollapsed_tablas = False Then
            PanelTablas.Height = PanelTablas.Height - 8
            'PanelTablas.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelTablas.Size = PanelTablas.MinimumSize Then
                TimerTablas.Stop()
                iscollapsed_tablas = True
            End If
        End If

        If iscollapsed_reportes = True Then
            PanelReportes.Height = PanelReportes.Height + 5
            'PanelReportes.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelReportes.Size = PanelReportes.MaximumSize Then
                TimerReportes.Stop()
                iscollapsed_reportes = False
            End If
        Else
            PanelReportes.Height = PanelReportes.Height - 5
            'PanelReportes.BackColor = Drawing.Color.FromArgb(&HEE1A4A)
            If PanelReportes.Size = PanelReportes.MinimumSize Then
                TimerReportes.Stop()
                iscollapsed_reportes = True
            End If
        End If

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea salir del programa?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then
            Application.Exit()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnSalir1_Click(sender As Object, e As EventArgs) Handles BtnSalir1.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea salir del programa?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then
            Application.Exit()
        Else
            Exit Sub
        End If

    End Sub

#End Region

End Class