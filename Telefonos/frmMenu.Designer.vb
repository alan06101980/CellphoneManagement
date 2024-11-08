<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.tmMostrar = New System.Windows.Forms.Timer(Me.components)
        Me.tmOcultar = New System.Windows.Forms.Timer(Me.components)
        Me.TimerTablas = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuSidebar = New System.Windows.Forms.PictureBox()
        Me.btnEquipos = New System.Windows.Forms.Button()
        Me.PanelTablas = New System.Windows.Forms.Panel()
        Me.btnImportacion = New System.Windows.Forms.Button()
        Me.btnEmpresas = New System.Windows.Forms.Button()
        Me.btnDispositivos = New System.Windows.Forms.Button()
        Me.btnPlanes = New System.Windows.Forms.Button()
        Me.btnProveedores = New System.Windows.Forms.Button()
        Me.btnAreas = New System.Windows.Forms.Button()
        Me.btnCeCos = New System.Windows.Forms.Button()
        Me.btnModelos = New System.Windows.Forms.Button()
        Me.btnMarcas = New System.Windows.Forms.Button()
        Me.btnUsuario = New System.Windows.Forms.Button()
        Me.BtnTablas = New System.Windows.Forms.Button()
        Me.PanelReportes = New System.Windows.Forms.Panel()
        Me.btnEquiposOperadores = New System.Windows.Forms.Button()
        Me.btnCentrosCosto = New System.Windows.Forms.Button()
        Me.btnUltimacompra = New System.Windows.Forms.Button()
        Me.btnBaja = New System.Windows.Forms.Button()
        Me.btnCerrados = New System.Windows.Forms.Button()
        Me.btnHistoricos = New System.Windows.Forms.Button()
        Me.btnAbiertos = New System.Windows.Forms.Button()
        Me.btnDeudores = New System.Windows.Forms.Button()
        Me.BtnReportes = New System.Windows.Forms.Button()
        Me.BtnBackup = New System.Windows.Forms.Button()
        Me.BtnApuntes = New System.Windows.Forms.Button()
        Me.BtnSalir1 = New System.Windows.Forms.Button()
        Me.MenuTop = New System.Windows.Forms.Panel()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.btnMaximizar = New System.Windows.Forms.Button()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.TimerReportes = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMenu.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.MenuSidebar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTablas.SuspendLayout()
        Me.PanelReportes.SuspendLayout()
        Me.MenuTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmMostrar
        '
        Me.tmMostrar.Interval = 20
        '
        'tmOcultar
        '
        Me.tmOcultar.Interval = 20
        '
        'TimerTablas
        '
        Me.TimerTablas.Interval = 10
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.PanelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelMenu.Controls.Add(Me.PanelLogo)
        Me.PanelMenu.Controls.Add(Me.btnEquipos)
        Me.PanelMenu.Controls.Add(Me.PanelTablas)
        Me.PanelMenu.Controls.Add(Me.PanelReportes)
        Me.PanelMenu.Controls.Add(Me.BtnBackup)
        Me.PanelMenu.Controls.Add(Me.BtnApuntes)
        Me.PanelMenu.Controls.Add(Me.BtnSalir1)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PanelMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 648)
        Me.PanelMenu.TabIndex = 29
        '
        'PanelLogo
        '
        Me.PanelLogo.BackColor = System.Drawing.Color.Transparent
        Me.PanelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelLogo.Controls.Add(Me.Label1)
        Me.PanelLogo.Controls.Add(Me.MenuSidebar)
        Me.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMenu.SetFlowBreak(Me.PanelLogo, True)
        Me.PanelLogo.Location = New System.Drawing.Point(3, 3)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(217, 87)
        Me.PanelLogo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(50, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Menú"
        '
        'MenuSidebar
        '
        Me.MenuSidebar.BackgroundImage = CType(resources.GetObject("MenuSidebar.BackgroundImage"), System.Drawing.Image)
        Me.MenuSidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MenuSidebar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MenuSidebar.Location = New System.Drawing.Point(9, 26)
        Me.MenuSidebar.Name = "MenuSidebar"
        Me.MenuSidebar.Size = New System.Drawing.Size(24, 21)
        Me.MenuSidebar.TabIndex = 0
        Me.MenuSidebar.TabStop = False
        '
        'btnEquipos
        '
        Me.btnEquipos.BackColor = System.Drawing.Color.Transparent
        Me.btnEquipos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEquipos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEquipos.FlatAppearance.BorderSize = 0
        Me.btnEquipos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelMenu.SetFlowBreak(Me.btnEquipos, True)
        Me.btnEquipos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipos.ForeColor = System.Drawing.Color.White
        Me.btnEquipos.Image = CType(resources.GetObject("btnEquipos.Image"), System.Drawing.Image)
        Me.btnEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipos.Location = New System.Drawing.Point(0, 93)
        Me.btnEquipos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEquipos.MaximumSize = New System.Drawing.Size(220, 50)
        Me.btnEquipos.MinimumSize = New System.Drawing.Size(220, 50)
        Me.btnEquipos.Name = "btnEquipos"
        Me.btnEquipos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnEquipos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEquipos.Size = New System.Drawing.Size(220, 50)
        Me.btnEquipos.TabIndex = 1
        Me.btnEquipos.Text = "        Equipos"
        Me.btnEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipos.UseVisualStyleBackColor = False
        '
        'PanelTablas
        '
        Me.PanelTablas.BackColor = System.Drawing.Color.Transparent
        Me.PanelTablas.Controls.Add(Me.btnImportacion)
        Me.PanelTablas.Controls.Add(Me.btnEmpresas)
        Me.PanelTablas.Controls.Add(Me.btnDispositivos)
        Me.PanelTablas.Controls.Add(Me.btnPlanes)
        Me.PanelTablas.Controls.Add(Me.btnProveedores)
        Me.PanelTablas.Controls.Add(Me.btnAreas)
        Me.PanelTablas.Controls.Add(Me.btnCeCos)
        Me.PanelTablas.Controls.Add(Me.btnModelos)
        Me.PanelTablas.Controls.Add(Me.btnMarcas)
        Me.PanelTablas.Controls.Add(Me.btnUsuario)
        Me.PanelTablas.Controls.Add(Me.BtnTablas)
        Me.PanelTablas.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMenu.SetFlowBreak(Me.PanelTablas, True)
        Me.PanelTablas.Location = New System.Drawing.Point(0, 143)
        Me.PanelTablas.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelTablas.MaximumSize = New System.Drawing.Size(220, 304)
        Me.PanelTablas.MinimumSize = New System.Drawing.Size(220, 50)
        Me.PanelTablas.Name = "PanelTablas"
        Me.PanelTablas.Size = New System.Drawing.Size(220, 50)
        Me.PanelTablas.TabIndex = 31
        '
        'btnImportacion
        '
        Me.btnImportacion.BackColor = System.Drawing.Color.Transparent
        Me.btnImportacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImportacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnImportacion.FlatAppearance.BorderSize = 0
        Me.btnImportacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnImportacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnImportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportacion.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnImportacion.ForeColor = System.Drawing.Color.White
        Me.btnImportacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportacion.Location = New System.Drawing.Point(0, 275)
        Me.btnImportacion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnImportacion.Name = "btnImportacion"
        Me.btnImportacion.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnImportacion.Size = New System.Drawing.Size(220, 25)
        Me.btnImportacion.TabIndex = 12
        Me.btnImportacion.Text = "        Importación de Datos"
        Me.btnImportacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportacion.UseVisualStyleBackColor = False
        '
        'btnEmpresas
        '
        Me.btnEmpresas.BackColor = System.Drawing.Color.Transparent
        Me.btnEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEmpresas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEmpresas.FlatAppearance.BorderSize = 0
        Me.btnEmpresas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEmpresas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmpresas.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnEmpresas.ForeColor = System.Drawing.Color.White
        Me.btnEmpresas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpresas.Location = New System.Drawing.Point(0, 250)
        Me.btnEmpresas.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEmpresas.Name = "btnEmpresas"
        Me.btnEmpresas.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnEmpresas.Size = New System.Drawing.Size(220, 25)
        Me.btnEmpresas.TabIndex = 11
        Me.btnEmpresas.Text = "        Empresas"
        Me.btnEmpresas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpresas.UseVisualStyleBackColor = False
        '
        'btnDispositivos
        '
        Me.btnDispositivos.BackColor = System.Drawing.Color.Transparent
        Me.btnDispositivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDispositivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDispositivos.FlatAppearance.BorderSize = 0
        Me.btnDispositivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnDispositivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnDispositivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDispositivos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnDispositivos.ForeColor = System.Drawing.Color.White
        Me.btnDispositivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDispositivos.Location = New System.Drawing.Point(0, 225)
        Me.btnDispositivos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDispositivos.Name = "btnDispositivos"
        Me.btnDispositivos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnDispositivos.Size = New System.Drawing.Size(220, 25)
        Me.btnDispositivos.TabIndex = 10
        Me.btnDispositivos.Text = "        Dispositivos"
        Me.btnDispositivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDispositivos.UseVisualStyleBackColor = False
        '
        'btnPlanes
        '
        Me.btnPlanes.BackColor = System.Drawing.Color.Transparent
        Me.btnPlanes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPlanes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPlanes.FlatAppearance.BorderSize = 0
        Me.btnPlanes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnPlanes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlanes.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnPlanes.ForeColor = System.Drawing.Color.White
        Me.btnPlanes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlanes.Location = New System.Drawing.Point(0, 200)
        Me.btnPlanes.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPlanes.Name = "btnPlanes"
        Me.btnPlanes.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnPlanes.Size = New System.Drawing.Size(220, 25)
        Me.btnPlanes.TabIndex = 9
        Me.btnPlanes.Text = "        Planes"
        Me.btnPlanes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlanes.UseVisualStyleBackColor = False
        '
        'btnProveedores
        '
        Me.btnProveedores.BackColor = System.Drawing.Color.Transparent
        Me.btnProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProveedores.FlatAppearance.BorderSize = 0
        Me.btnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProveedores.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnProveedores.ForeColor = System.Drawing.Color.White
        Me.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProveedores.Location = New System.Drawing.Point(0, 175)
        Me.btnProveedores.Margin = New System.Windows.Forms.Padding(0)
        Me.btnProveedores.Name = "btnProveedores"
        Me.btnProveedores.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnProveedores.Size = New System.Drawing.Size(220, 25)
        Me.btnProveedores.TabIndex = 8
        Me.btnProveedores.Text = "        Proveedores"
        Me.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProveedores.UseVisualStyleBackColor = False
        '
        'btnAreas
        '
        Me.btnAreas.BackColor = System.Drawing.Color.Transparent
        Me.btnAreas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAreas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAreas.FlatAppearance.BorderSize = 0
        Me.btnAreas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnAreas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAreas.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnAreas.ForeColor = System.Drawing.Color.White
        Me.btnAreas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAreas.Location = New System.Drawing.Point(0, 150)
        Me.btnAreas.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAreas.Name = "btnAreas"
        Me.btnAreas.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnAreas.Size = New System.Drawing.Size(220, 25)
        Me.btnAreas.TabIndex = 7
        Me.btnAreas.Text = "        Áreas"
        Me.btnAreas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAreas.UseVisualStyleBackColor = False
        '
        'btnCeCos
        '
        Me.btnCeCos.BackColor = System.Drawing.Color.Transparent
        Me.btnCeCos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCeCos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCeCos.FlatAppearance.BorderSize = 0
        Me.btnCeCos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCeCos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCeCos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCeCos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnCeCos.ForeColor = System.Drawing.Color.White
        Me.btnCeCos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCeCos.Location = New System.Drawing.Point(0, 125)
        Me.btnCeCos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCeCos.Name = "btnCeCos"
        Me.btnCeCos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnCeCos.Size = New System.Drawing.Size(220, 25)
        Me.btnCeCos.TabIndex = 6
        Me.btnCeCos.Text = "        Centros de Costo"
        Me.btnCeCos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCeCos.UseVisualStyleBackColor = False
        '
        'btnModelos
        '
        Me.btnModelos.BackColor = System.Drawing.Color.Transparent
        Me.btnModelos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnModelos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnModelos.FlatAppearance.BorderSize = 0
        Me.btnModelos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnModelos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnModelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModelos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnModelos.ForeColor = System.Drawing.Color.White
        Me.btnModelos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModelos.Location = New System.Drawing.Point(0, 100)
        Me.btnModelos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnModelos.Name = "btnModelos"
        Me.btnModelos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnModelos.Size = New System.Drawing.Size(220, 25)
        Me.btnModelos.TabIndex = 5
        Me.btnModelos.Text = "        Modelos"
        Me.btnModelos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModelos.UseVisualStyleBackColor = False
        '
        'btnMarcas
        '
        Me.btnMarcas.BackColor = System.Drawing.Color.Transparent
        Me.btnMarcas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMarcas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMarcas.FlatAppearance.BorderSize = 0
        Me.btnMarcas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnMarcas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcas.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnMarcas.ForeColor = System.Drawing.Color.White
        Me.btnMarcas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcas.Location = New System.Drawing.Point(0, 75)
        Me.btnMarcas.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMarcas.Name = "btnMarcas"
        Me.btnMarcas.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnMarcas.Size = New System.Drawing.Size(220, 25)
        Me.btnMarcas.TabIndex = 4
        Me.btnMarcas.Text = "        Marcas"
        Me.btnMarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcas.UseVisualStyleBackColor = False
        '
        'btnUsuario
        '
        Me.btnUsuario.BackColor = System.Drawing.Color.Transparent
        Me.btnUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnUsuario.FlatAppearance.BorderSize = 0
        Me.btnUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuario.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnUsuario.ForeColor = System.Drawing.Color.White
        Me.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsuario.Location = New System.Drawing.Point(0, 50)
        Me.btnUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.btnUsuario.Name = "btnUsuario"
        Me.btnUsuario.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnUsuario.Size = New System.Drawing.Size(220, 25)
        Me.btnUsuario.TabIndex = 3
        Me.btnUsuario.Text = "        Usuarios"
        Me.btnUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsuario.UseVisualStyleBackColor = False
        '
        'BtnTablas
        '
        Me.BtnTablas.BackColor = System.Drawing.Color.Transparent
        Me.BtnTablas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnTablas.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnTablas.FlatAppearance.BorderSize = 0
        Me.BtnTablas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnTablas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnTablas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTablas.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTablas.ForeColor = System.Drawing.Color.White
        Me.BtnTablas.Image = CType(resources.GetObject("BtnTablas.Image"), System.Drawing.Image)
        Me.BtnTablas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTablas.Location = New System.Drawing.Point(0, 0)
        Me.BtnTablas.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnTablas.Name = "BtnTablas"
        Me.BtnTablas.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnTablas.Size = New System.Drawing.Size(220, 50)
        Me.BtnTablas.TabIndex = 2
        Me.BtnTablas.Text = "        Tablas                      +"
        Me.BtnTablas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTablas.UseVisualStyleBackColor = False
        '
        'PanelReportes
        '
        Me.PanelReportes.BackColor = System.Drawing.Color.Transparent
        Me.PanelReportes.Controls.Add(Me.btnEquiposOperadores)
        Me.PanelReportes.Controls.Add(Me.btnCentrosCosto)
        Me.PanelReportes.Controls.Add(Me.btnUltimacompra)
        Me.PanelReportes.Controls.Add(Me.btnBaja)
        Me.PanelReportes.Controls.Add(Me.btnCerrados)
        Me.PanelReportes.Controls.Add(Me.btnHistoricos)
        Me.PanelReportes.Controls.Add(Me.btnAbiertos)
        Me.PanelReportes.Controls.Add(Me.btnDeudores)
        Me.PanelReportes.Controls.Add(Me.BtnReportes)
        Me.PanelReportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMenu.SetFlowBreak(Me.PanelReportes, True)
        Me.PanelReportes.Location = New System.Drawing.Point(0, 193)
        Me.PanelReportes.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelReportes.MaximumSize = New System.Drawing.Size(220, 254)
        Me.PanelReportes.MinimumSize = New System.Drawing.Size(220, 50)
        Me.PanelReportes.Name = "PanelReportes"
        Me.PanelReportes.Size = New System.Drawing.Size(220, 50)
        Me.PanelReportes.TabIndex = 0
        '
        'btnEquiposOperadores
        '
        Me.btnEquiposOperadores.BackColor = System.Drawing.Color.Transparent
        Me.btnEquiposOperadores.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEquiposOperadores.FlatAppearance.BorderSize = 0
        Me.btnEquiposOperadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEquiposOperadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEquiposOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquiposOperadores.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnEquiposOperadores.ForeColor = System.Drawing.Color.White
        Me.btnEquiposOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquiposOperadores.Location = New System.Drawing.Point(0, 225)
        Me.btnEquiposOperadores.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEquiposOperadores.Name = "btnEquiposOperadores"
        Me.btnEquiposOperadores.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnEquiposOperadores.Size = New System.Drawing.Size(220, 25)
        Me.btnEquiposOperadores.TabIndex = 40
        Me.btnEquiposOperadores.Text = "        Equipos y Operadores"
        Me.btnEquiposOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquiposOperadores.UseVisualStyleBackColor = False
        '
        'btnCentrosCosto
        '
        Me.btnCentrosCosto.BackColor = System.Drawing.Color.Transparent
        Me.btnCentrosCosto.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCentrosCosto.FlatAppearance.BorderSize = 0
        Me.btnCentrosCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCentrosCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCentrosCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCentrosCosto.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnCentrosCosto.ForeColor = System.Drawing.Color.White
        Me.btnCentrosCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCentrosCosto.Location = New System.Drawing.Point(0, 200)
        Me.btnCentrosCosto.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCentrosCosto.Name = "btnCentrosCosto"
        Me.btnCentrosCosto.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnCentrosCosto.Size = New System.Drawing.Size(220, 25)
        Me.btnCentrosCosto.TabIndex = 39
        Me.btnCentrosCosto.Text = "        Montos por Ce.Co."
        Me.btnCentrosCosto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCentrosCosto.UseVisualStyleBackColor = False
        '
        'btnUltimacompra
        '
        Me.btnUltimacompra.BackColor = System.Drawing.Color.Transparent
        Me.btnUltimacompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnUltimacompra.FlatAppearance.BorderSize = 0
        Me.btnUltimacompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnUltimacompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnUltimacompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUltimacompra.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnUltimacompra.ForeColor = System.Drawing.Color.White
        Me.btnUltimacompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUltimacompra.Location = New System.Drawing.Point(0, 175)
        Me.btnUltimacompra.Margin = New System.Windows.Forms.Padding(0)
        Me.btnUltimacompra.Name = "btnUltimacompra"
        Me.btnUltimacompra.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnUltimacompra.Size = New System.Drawing.Size(220, 25)
        Me.btnUltimacompra.TabIndex = 38
        Me.btnUltimacompra.Text = "        Última Compra"
        Me.btnUltimacompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUltimacompra.UseVisualStyleBackColor = False
        '
        'btnBaja
        '
        Me.btnBaja.BackColor = System.Drawing.Color.Transparent
        Me.btnBaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBaja.FlatAppearance.BorderSize = 0
        Me.btnBaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnBaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaja.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnBaja.ForeColor = System.Drawing.Color.White
        Me.btnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaja.Location = New System.Drawing.Point(0, 150)
        Me.btnBaja.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnBaja.Size = New System.Drawing.Size(220, 25)
        Me.btnBaja.TabIndex = 37
        Me.btnBaja.Text = "        Equipos Datos de Baja"
        Me.btnBaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaja.UseVisualStyleBackColor = False
        '
        'btnCerrados
        '
        Me.btnCerrados.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrados.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCerrados.FlatAppearance.BorderSize = 0
        Me.btnCerrados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCerrados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCerrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrados.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnCerrados.ForeColor = System.Drawing.Color.White
        Me.btnCerrados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrados.Location = New System.Drawing.Point(0, 125)
        Me.btnCerrados.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCerrados.Name = "btnCerrados"
        Me.btnCerrados.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnCerrados.Size = New System.Drawing.Size(220, 25)
        Me.btnCerrados.TabIndex = 36
        Me.btnCerrados.Text = "        Incidentes Cerrados"
        Me.btnCerrados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrados.UseVisualStyleBackColor = False
        '
        'btnHistoricos
        '
        Me.btnHistoricos.BackColor = System.Drawing.Color.Transparent
        Me.btnHistoricos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHistoricos.FlatAppearance.BorderSize = 0
        Me.btnHistoricos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnHistoricos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnHistoricos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistoricos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnHistoricos.ForeColor = System.Drawing.Color.White
        Me.btnHistoricos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistoricos.Location = New System.Drawing.Point(0, 100)
        Me.btnHistoricos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHistoricos.Name = "btnHistoricos"
        Me.btnHistoricos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnHistoricos.Size = New System.Drawing.Size(220, 25)
        Me.btnHistoricos.TabIndex = 35
        Me.btnHistoricos.Text = "        Histórico de Incidentes"
        Me.btnHistoricos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistoricos.UseVisualStyleBackColor = False
        '
        'btnAbiertos
        '
        Me.btnAbiertos.BackColor = System.Drawing.Color.Transparent
        Me.btnAbiertos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAbiertos.FlatAppearance.BorderSize = 0
        Me.btnAbiertos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnAbiertos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnAbiertos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbiertos.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnAbiertos.ForeColor = System.Drawing.Color.White
        Me.btnAbiertos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbiertos.Location = New System.Drawing.Point(0, 75)
        Me.btnAbiertos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAbiertos.Name = "btnAbiertos"
        Me.btnAbiertos.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnAbiertos.Size = New System.Drawing.Size(220, 25)
        Me.btnAbiertos.TabIndex = 34
        Me.btnAbiertos.Text = "        Incidentes Abiertos"
        Me.btnAbiertos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbiertos.UseVisualStyleBackColor = False
        '
        'btnDeudores
        '
        Me.btnDeudores.BackColor = System.Drawing.Color.Transparent
        Me.btnDeudores.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDeudores.FlatAppearance.BorderSize = 0
        Me.btnDeudores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnDeudores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnDeudores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeudores.Font = New System.Drawing.Font("Malgun Gothic", 9.75!)
        Me.btnDeudores.ForeColor = System.Drawing.Color.White
        Me.btnDeudores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeudores.Location = New System.Drawing.Point(0, 50)
        Me.btnDeudores.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDeudores.Name = "btnDeudores"
        Me.btnDeudores.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btnDeudores.Size = New System.Drawing.Size(220, 25)
        Me.btnDeudores.TabIndex = 33
        Me.btnDeudores.Text = "        Deudores"
        Me.btnDeudores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeudores.UseVisualStyleBackColor = False
        '
        'BtnReportes
        '
        Me.BtnReportes.BackColor = System.Drawing.Color.Transparent
        Me.BtnReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnReportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnReportes.FlatAppearance.BorderSize = 0
        Me.BtnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReportes.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReportes.ForeColor = System.Drawing.Color.White
        Me.BtnReportes.Image = CType(resources.GetObject("BtnReportes.Image"), System.Drawing.Image)
        Me.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReportes.Location = New System.Drawing.Point(0, 0)
        Me.BtnReportes.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnReportes.Name = "BtnReportes"
        Me.BtnReportes.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnReportes.Size = New System.Drawing.Size(220, 50)
        Me.BtnReportes.TabIndex = 32
        Me.BtnReportes.Text = "        Reportes                   +"
        Me.BtnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReportes.UseVisualStyleBackColor = False
        '
        'BtnBackup
        '
        Me.BtnBackup.BackColor = System.Drawing.Color.Transparent
        Me.BtnBackup.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnBackup.FlatAppearance.BorderSize = 0
        Me.BtnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelMenu.SetFlowBreak(Me.BtnBackup, True)
        Me.BtnBackup.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackup.ForeColor = System.Drawing.Color.White
        Me.BtnBackup.Image = CType(resources.GetObject("BtnBackup.Image"), System.Drawing.Image)
        Me.BtnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBackup.Location = New System.Drawing.Point(0, 243)
        Me.BtnBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnBackup.Name = "BtnBackup"
        Me.BtnBackup.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnBackup.Size = New System.Drawing.Size(220, 50)
        Me.BtnBackup.TabIndex = 34
        Me.BtnBackup.Text = "        Backup"
        Me.BtnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBackup.UseVisualStyleBackColor = False
        '
        'BtnApuntes
        '
        Me.BtnApuntes.BackColor = System.Drawing.Color.Transparent
        Me.BtnApuntes.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnApuntes.FlatAppearance.BorderSize = 0
        Me.BtnApuntes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnApuntes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnApuntes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelMenu.SetFlowBreak(Me.BtnApuntes, True)
        Me.BtnApuntes.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApuntes.ForeColor = System.Drawing.Color.White
        Me.BtnApuntes.Image = CType(resources.GetObject("BtnApuntes.Image"), System.Drawing.Image)
        Me.BtnApuntes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnApuntes.Location = New System.Drawing.Point(0, 293)
        Me.BtnApuntes.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnApuntes.Name = "BtnApuntes"
        Me.BtnApuntes.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnApuntes.Size = New System.Drawing.Size(220, 50)
        Me.BtnApuntes.TabIndex = 33
        Me.BtnApuntes.Text = "        Apuntes"
        Me.BtnApuntes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnApuntes.UseVisualStyleBackColor = False
        '
        'BtnSalir1
        '
        Me.BtnSalir1.BackColor = System.Drawing.Color.Transparent
        Me.BtnSalir1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnSalir1.FlatAppearance.BorderSize = 0
        Me.BtnSalir1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnSalir1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BtnSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelMenu.SetFlowBreak(Me.BtnSalir1, True)
        Me.BtnSalir1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir1.ForeColor = System.Drawing.Color.White
        Me.BtnSalir1.Image = CType(resources.GetObject("BtnSalir1.Image"), System.Drawing.Image)
        Me.BtnSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir1.Location = New System.Drawing.Point(0, 343)
        Me.BtnSalir1.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnSalir1.MaximumSize = New System.Drawing.Size(220, 50)
        Me.BtnSalir1.MinimumSize = New System.Drawing.Size(220, 50)
        Me.BtnSalir1.Name = "BtnSalir1"
        Me.BtnSalir1.Padding = New System.Windows.Forms.Padding(7, 0, 0, 0)
        Me.BtnSalir1.Size = New System.Drawing.Size(220, 50)
        Me.BtnSalir1.TabIndex = 35
        Me.BtnSalir1.Text = "        Salir"
        Me.BtnSalir1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir1.UseVisualStyleBackColor = False
        '
        'MenuTop
        '
        Me.MenuTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MenuTop.Controls.Add(Me.btnRestore)
        Me.MenuTop.Controls.Add(Me.btnMaximizar)
        Me.MenuTop.Controls.Add(Me.btnMinimizar)
        Me.MenuTop.Controls.Add(Me.btnSalir)
        Me.MenuTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuTop.Location = New System.Drawing.Point(220, 0)
        Me.MenuTop.Name = "MenuTop"
        Me.MenuTop.Size = New System.Drawing.Size(1144, 40)
        Me.MenuTop.TabIndex = 35
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.BackColor = System.Drawing.Color.Transparent
        Me.btnRestore.BackgroundImage = CType(resources.GetObject("btnRestore.BackgroundImage"), System.Drawing.Image)
        Me.btnRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestore.FlatAppearance.BorderSize = 0
        Me.btnRestore.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestore.Location = New System.Drawing.Point(1066, 8)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(24, 24)
        Me.btnRestore.TabIndex = 5
        Me.btnRestore.UseVisualStyleBackColor = False
        Me.btnRestore.Visible = False
        '
        'btnMaximizar
        '
        Me.btnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximizar.BackColor = System.Drawing.Color.Transparent
        Me.btnMaximizar.BackgroundImage = CType(resources.GetObject("btnMaximizar.BackgroundImage"), System.Drawing.Image)
        Me.btnMaximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMaximizar.FlatAppearance.BorderSize = 0
        Me.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaximizar.Location = New System.Drawing.Point(1066, 8)
        Me.btnMaximizar.Name = "btnMaximizar"
        Me.btnMaximizar.Size = New System.Drawing.Size(22, 22)
        Me.btnMaximizar.TabIndex = 4
        Me.btnMaximizar.UseVisualStyleBackColor = False
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimizar.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.BackgroundImage = CType(resources.GetObject("btnMinimizar.BackgroundImage"), System.Drawing.Image)
        Me.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimizar.FlatAppearance.BorderSize = 0
        Me.btnMinimizar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Location = New System.Drawing.Point(1023, 9)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(22, 22)
        Me.btnMinimizar.TabIndex = 3
        Me.btnMinimizar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(1109, 8)
        Me.btnSalir.MaximumSize = New System.Drawing.Size(24, 24)
        Me.btnSalir.MinimumSize = New System.Drawing.Size(24, 24)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(24, 24)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(220, 40)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(1144, 608)
        Me.PanelContenedor.TabIndex = 36
        '
        'TimerReportes
        '
        Me.TimerReportes.Interval = 10
        '
        'frmMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1364, 648)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.MenuTop)
        Me.Controls.Add(Me.PanelMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMenu"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelLogo.ResumeLayout(False)
        Me.PanelLogo.PerformLayout()
        CType(Me.MenuSidebar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTablas.ResumeLayout(False)
        Me.PanelReportes.ResumeLayout(False)
        Me.MenuTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmMostrar As Timer
    Friend WithEvents tmOcultar As Timer
    Friend WithEvents TimerTablas As Timer
    Friend WithEvents PanelMenu As FlowLayoutPanel
    Friend WithEvents btnEquipos As Button
    Friend WithEvents PanelTablas As Panel
    Friend WithEvents btnEmpresas As Button
    Friend WithEvents btnDispositivos As Button
    Friend WithEvents btnPlanes As Button
    Friend WithEvents btnProveedores As Button
    Friend WithEvents btnAreas As Button
    Friend WithEvents btnCeCos As Button
    Friend WithEvents btnModelos As Button
    Friend WithEvents btnMarcas As Button
    Friend WithEvents btnUsuario As Button
    Friend WithEvents BtnTablas As Button
    Friend WithEvents BtnReportes As Button
    Friend WithEvents BtnBackup As Button
    Friend WithEvents BtnApuntes As Button
    Friend WithEvents MenuTop As Panel
    Friend WithEvents MenuSidebar As PictureBox
    Friend WithEvents btnRestore As Button
    Friend WithEvents btnMaximizar As Button
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents PanelContenedor As Panel
    Friend WithEvents PanelReportes As Panel
    Friend WithEvents btnEquiposOperadores As Button
    Friend WithEvents btnCentrosCosto As Button
    Friend WithEvents btnUltimacompra As Button
    Friend WithEvents btnBaja As Button
    Friend WithEvents btnCerrados As Button
    Friend WithEvents btnHistoricos As Button
    Friend WithEvents btnAbiertos As Button
    Friend WithEvents btnDeudores As Button
    Friend WithEvents TimerReportes As Timer
    Friend WithEvents BtnSalir1 As Button
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImportacion As Button
End Class
