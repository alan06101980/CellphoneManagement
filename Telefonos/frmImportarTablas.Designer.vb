<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarTablas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarTablas))
        Me.OpenFileDialogArea = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogCecos = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogEquipos = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogMarca = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogPlanes = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogUsuario = New System.Windows.Forms.OpenFileDialog()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelUsuario = New System.Windows.Forms.Button()
        Me.txtImportarUsuarios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelPlanes = New System.Windows.Forms.Button()
        Me.txtImportarPlanes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelMarca = New System.Windows.Forms.Button()
        Me.txtImportarMarca = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelEquipos = New System.Windows.Forms.Button()
        Me.txtImportarEquipos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelCecos = New System.Windows.Forms.Button()
        Me.txtImportarCecos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarExcelArea = New System.Windows.Forms.Button()
        Me.txtImportarArea = New System.Windows.Forms.TextBox()
        Me.btnImportarArea = New System.Windows.Forms.Button()
        Me.btnImportarCecos = New System.Windows.Forms.Button()
        Me.btnImportarEquipos = New System.Windows.Forms.Button()
        Me.btnImportarMarca = New System.Windows.Forms.Button()
        Me.btnImportarPlanes = New System.Windows.Forms.Button()
        Me.btnImportarUsuario = New System.Windows.Forms.Button()
        Me.PanelTextBox = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'OpenFileDialogArea
        '
        Me.OpenFileDialogArea.FileName = "OpenFileDialogArea"
        Me.OpenFileDialogArea.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogArea.InitialDirectory = "C:\"
        '
        'OpenFileDialogCecos
        '
        Me.OpenFileDialogCecos.FileName = "OpenFileDialogCecos"
        Me.OpenFileDialogCecos.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogCecos.InitialDirectory = "C:\"
        '
        'OpenFileDialogEquipos
        '
        Me.OpenFileDialogEquipos.FileName = "OpenFileDialogEquipos"
        Me.OpenFileDialogEquipos.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogEquipos.InitialDirectory = "C:\"
        '
        'OpenFileDialogMarca
        '
        Me.OpenFileDialogMarca.FileName = "OpenFileDialoGMarca"
        Me.OpenFileDialogMarca.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogMarca.InitialDirectory = "C:\"
        '
        'OpenFileDialogPlanes
        '
        Me.OpenFileDialogPlanes.FileName = "OpenFileDialogPlanes"
        Me.OpenFileDialogPlanes.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogPlanes.InitialDirectory = "C:\"
        '
        'OpenFileDialogUsuario
        '
        Me.OpenFileDialogUsuario.FileName = "OpenFileDialogUsuario"
        Me.OpenFileDialogUsuario.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"";"
        Me.OpenFileDialogUsuario.InitialDirectory = "C:\"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSalir.Location = New System.Drawing.Point(573, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(22, 22)
        Me.btnSalir.TabIndex = 90
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Malgun Gothic Semilight", 12.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(216, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(165, 21)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Importación de Tablas"
        '
        'btnBuscarExcelUsuario
        '
        Me.btnBuscarExcelUsuario.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelUsuario.Image = CType(resources.GetObject("btnBuscarExcelUsuario.Image"), System.Drawing.Image)
        Me.btnBuscarExcelUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelUsuario.Location = New System.Drawing.Point(12, 449)
        Me.btnBuscarExcelUsuario.Name = "btnBuscarExcelUsuario"
        Me.btnBuscarExcelUsuario.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelUsuario.TabIndex = 128
        Me.btnBuscarExcelUsuario.UseVisualStyleBackColor = True
        '
        'txtImportarUsuarios
        '
        Me.txtImportarUsuarios.BackColor = System.Drawing.Color.White
        Me.txtImportarUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarUsuarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarUsuarios.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarUsuarios.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarUsuarios.Location = New System.Drawing.Point(45, 455)
        Me.txtImportarUsuarios.Name = "txtImportarUsuarios"
        Me.txtImportarUsuarios.ReadOnly = True
        Me.txtImportarUsuarios.ShortcutsEnabled = False
        Me.txtImportarUsuarios.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarUsuarios.TabIndex = 127
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(12, 429)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 15)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Importación de la Tabla Usuarios"
        '
        'btnBuscarExcelPlanes
        '
        Me.btnBuscarExcelPlanes.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelPlanes.Image = CType(resources.GetObject("btnBuscarExcelPlanes.Image"), System.Drawing.Image)
        Me.btnBuscarExcelPlanes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelPlanes.Location = New System.Drawing.Point(12, 382)
        Me.btnBuscarExcelPlanes.Name = "btnBuscarExcelPlanes"
        Me.btnBuscarExcelPlanes.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelPlanes.TabIndex = 124
        Me.btnBuscarExcelPlanes.UseVisualStyleBackColor = True
        '
        'txtImportarPlanes
        '
        Me.txtImportarPlanes.BackColor = System.Drawing.Color.White
        Me.txtImportarPlanes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarPlanes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarPlanes.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarPlanes.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarPlanes.Location = New System.Drawing.Point(45, 388)
        Me.txtImportarPlanes.Name = "txtImportarPlanes"
        Me.txtImportarPlanes.ReadOnly = True
        Me.txtImportarPlanes.ShortcutsEnabled = False
        Me.txtImportarPlanes.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarPlanes.TabIndex = 123
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(12, 362)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 15)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Importación de la Tabla Planes"
        '
        'btnBuscarExcelMarca
        '
        Me.btnBuscarExcelMarca.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelMarca.Image = CType(resources.GetObject("btnBuscarExcelMarca.Image"), System.Drawing.Image)
        Me.btnBuscarExcelMarca.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelMarca.Location = New System.Drawing.Point(12, 315)
        Me.btnBuscarExcelMarca.Name = "btnBuscarExcelMarca"
        Me.btnBuscarExcelMarca.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelMarca.TabIndex = 120
        Me.btnBuscarExcelMarca.UseVisualStyleBackColor = True
        '
        'txtImportarMarca
        '
        Me.txtImportarMarca.BackColor = System.Drawing.Color.White
        Me.txtImportarMarca.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarMarca.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarMarca.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarMarca.Location = New System.Drawing.Point(45, 321)
        Me.txtImportarMarca.Name = "txtImportarMarca"
        Me.txtImportarMarca.ReadOnly = True
        Me.txtImportarMarca.ShortcutsEnabled = False
        Me.txtImportarMarca.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarMarca.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(12, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 15)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Importación de la Tabla Marcas"
        '
        'btnBuscarExcelEquipos
        '
        Me.btnBuscarExcelEquipos.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelEquipos.Image = CType(resources.GetObject("btnBuscarExcelEquipos.Image"), System.Drawing.Image)
        Me.btnBuscarExcelEquipos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelEquipos.Location = New System.Drawing.Point(12, 245)
        Me.btnBuscarExcelEquipos.Name = "btnBuscarExcelEquipos"
        Me.btnBuscarExcelEquipos.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelEquipos.TabIndex = 116
        Me.btnBuscarExcelEquipos.UseVisualStyleBackColor = True
        '
        'txtImportarEquipos
        '
        Me.txtImportarEquipos.BackColor = System.Drawing.Color.White
        Me.txtImportarEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarEquipos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarEquipos.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarEquipos.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarEquipos.Location = New System.Drawing.Point(45, 250)
        Me.txtImportarEquipos.Name = "txtImportarEquipos"
        Me.txtImportarEquipos.ReadOnly = True
        Me.txtImportarEquipos.ShortcutsEnabled = False
        Me.txtImportarEquipos.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarEquipos.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(12, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 15)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Importación de la Tabla Principal de Equipos"
        '
        'btnBuscarExcelCecos
        '
        Me.btnBuscarExcelCecos.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelCecos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelCecos.Image = CType(resources.GetObject("btnBuscarExcelCecos.Image"), System.Drawing.Image)
        Me.btnBuscarExcelCecos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelCecos.Location = New System.Drawing.Point(12, 174)
        Me.btnBuscarExcelCecos.Name = "btnBuscarExcelCecos"
        Me.btnBuscarExcelCecos.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelCecos.TabIndex = 112
        Me.btnBuscarExcelCecos.UseVisualStyleBackColor = True
        '
        'txtImportarCecos
        '
        Me.txtImportarCecos.BackColor = System.Drawing.Color.White
        Me.txtImportarCecos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarCecos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarCecos.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarCecos.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarCecos.Location = New System.Drawing.Point(45, 180)
        Me.txtImportarCecos.Name = "txtImportarCecos"
        Me.txtImportarCecos.ReadOnly = True
        Me.txtImportarCecos.ShortcutsEnabled = False
        Me.txtImportarCecos.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarCecos.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(12, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 15)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Importación de la Tabla Centro de Costos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 15)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Importación de la Tabla Áreas"
        '
        'btnBuscarExcelArea
        '
        Me.btnBuscarExcelArea.FlatAppearance.BorderSize = 0
        Me.btnBuscarExcelArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarExcelArea.Image = CType(resources.GetObject("btnBuscarExcelArea.Image"), System.Drawing.Image)
        Me.btnBuscarExcelArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscarExcelArea.Location = New System.Drawing.Point(12, 102)
        Me.btnBuscarExcelArea.Name = "btnBuscarExcelArea"
        Me.btnBuscarExcelArea.Size = New System.Drawing.Size(27, 26)
        Me.btnBuscarExcelArea.TabIndex = 107
        Me.btnBuscarExcelArea.UseVisualStyleBackColor = True
        '
        'txtImportarArea
        '
        Me.txtImportarArea.BackColor = System.Drawing.Color.White
        Me.txtImportarArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportarArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImportarArea.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportarArea.ForeColor = System.Drawing.Color.DimGray
        Me.txtImportarArea.Location = New System.Drawing.Point(45, 108)
        Me.txtImportarArea.Name = "txtImportarArea"
        Me.txtImportarArea.ReadOnly = True
        Me.txtImportarArea.ShortcutsEnabled = False
        Me.txtImportarArea.Size = New System.Drawing.Size(399, 15)
        Me.txtImportarArea.TabIndex = 106
        '
        'btnImportarArea
        '
        Me.btnImportarArea.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarArea.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarArea.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarArea.Image = CType(resources.GetObject("btnImportarArea.Image"), System.Drawing.Image)
        Me.btnImportarArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarArea.Location = New System.Drawing.Point(461, 91)
        Me.btnImportarArea.Name = "btnImportarArea"
        Me.btnImportarArea.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarArea.TabIndex = 129
        Me.btnImportarArea.Text = "  Importar"
        Me.btnImportarArea.UseVisualStyleBackColor = True
        '
        'btnImportarCecos
        '
        Me.btnImportarCecos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarCecos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarCecos.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarCecos.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarCecos.Image = CType(resources.GetObject("btnImportarCecos.Image"), System.Drawing.Image)
        Me.btnImportarCecos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarCecos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarCecos.Location = New System.Drawing.Point(461, 163)
        Me.btnImportarCecos.Name = "btnImportarCecos"
        Me.btnImportarCecos.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarCecos.TabIndex = 130
        Me.btnImportarCecos.Text = "  Importar"
        Me.btnImportarCecos.UseVisualStyleBackColor = True
        '
        'btnImportarEquipos
        '
        Me.btnImportarEquipos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarEquipos.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarEquipos.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarEquipos.Image = CType(resources.GetObject("btnImportarEquipos.Image"), System.Drawing.Image)
        Me.btnImportarEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarEquipos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarEquipos.Location = New System.Drawing.Point(461, 234)
        Me.btnImportarEquipos.Name = "btnImportarEquipos"
        Me.btnImportarEquipos.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarEquipos.TabIndex = 131
        Me.btnImportarEquipos.Text = "  Importar"
        Me.btnImportarEquipos.UseVisualStyleBackColor = True
        '
        'btnImportarMarca
        '
        Me.btnImportarMarca.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarMarca.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarMarca.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarMarca.Image = CType(resources.GetObject("btnImportarMarca.Image"), System.Drawing.Image)
        Me.btnImportarMarca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarMarca.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarMarca.Location = New System.Drawing.Point(461, 304)
        Me.btnImportarMarca.Name = "btnImportarMarca"
        Me.btnImportarMarca.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarMarca.TabIndex = 132
        Me.btnImportarMarca.Text = "  Importar"
        Me.btnImportarMarca.UseVisualStyleBackColor = True
        '
        'btnImportarPlanes
        '
        Me.btnImportarPlanes.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarPlanes.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarPlanes.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarPlanes.Image = CType(resources.GetObject("btnImportarPlanes.Image"), System.Drawing.Image)
        Me.btnImportarPlanes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarPlanes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarPlanes.Location = New System.Drawing.Point(461, 371)
        Me.btnImportarPlanes.Name = "btnImportarPlanes"
        Me.btnImportarPlanes.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarPlanes.TabIndex = 133
        Me.btnImportarPlanes.Text = "  Importar"
        Me.btnImportarPlanes.UseVisualStyleBackColor = True
        '
        'btnImportarUsuario
        '
        Me.btnImportarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImportarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarUsuario.Font = New System.Drawing.Font("Malgun Gothic", 9.0!)
        Me.btnImportarUsuario.ForeColor = System.Drawing.Color.Gray
        Me.btnImportarUsuario.Image = CType(resources.GetObject("btnImportarUsuario.Image"), System.Drawing.Image)
        Me.btnImportarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarUsuario.Location = New System.Drawing.Point(461, 438)
        Me.btnImportarUsuario.Name = "btnImportarUsuario"
        Me.btnImportarUsuario.Size = New System.Drawing.Size(120, 35)
        Me.btnImportarUsuario.TabIndex = 134
        Me.btnImportarUsuario.Text = "  Importar"
        Me.btnImportarUsuario.UseVisualStyleBackColor = True
        '
        'PanelTextBox
        '
        Me.PanelTextBox.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PanelTextBox.Location = New System.Drawing.Point(45, 124)
        Me.PanelTextBox.Name = "PanelTextBox"
        Me.PanelTextBox.Size = New System.Drawing.Size(399, 1)
        Me.PanelTextBox.TabIndex = 135
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Location = New System.Drawing.Point(45, 196)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 1)
        Me.Panel1.TabIndex = 136
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Location = New System.Drawing.Point(45, 266)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(399, 1)
        Me.Panel2.TabIndex = 136
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel3.Location = New System.Drawing.Point(45, 337)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(399, 1)
        Me.Panel3.TabIndex = 136
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel4.Location = New System.Drawing.Point(45, 404)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(399, 1)
        Me.Panel4.TabIndex = 136
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel5.Location = New System.Drawing.Point(45, 471)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(399, 1)
        Me.Panel5.TabIndex = 136
        '
        'frmImportarTablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 502)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTextBox)
        Me.Controls.Add(Me.btnImportarUsuario)
        Me.Controls.Add(Me.btnImportarPlanes)
        Me.Controls.Add(Me.btnImportarMarca)
        Me.Controls.Add(Me.btnImportarEquipos)
        Me.Controls.Add(Me.btnImportarCecos)
        Me.Controls.Add(Me.btnImportarArea)
        Me.Controls.Add(Me.btnBuscarExcelUsuario)
        Me.Controls.Add(Me.txtImportarUsuarios)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBuscarExcelPlanes)
        Me.Controls.Add(Me.txtImportarPlanes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscarExcelMarca)
        Me.Controls.Add(Me.txtImportarMarca)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscarExcelEquipos)
        Me.Controls.Add(Me.txtImportarEquipos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnBuscarExcelCecos)
        Me.Controls.Add(Me.txtImportarCecos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscarExcelArea)
        Me.Controls.Add(Me.txtImportarArea)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmImportarTablas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialogArea As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogCecos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogEquipos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogMarca As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogPlanes As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialogUsuario As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents btnBuscarExcelUsuario As Button
    Friend WithEvents txtImportarUsuarios As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBuscarExcelPlanes As Button
    Friend WithEvents txtImportarPlanes As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBuscarExcelMarca As Button
    Friend WithEvents txtImportarMarca As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBuscarExcelEquipos As Button
    Friend WithEvents txtImportarEquipos As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBuscarExcelCecos As Button
    Friend WithEvents txtImportarCecos As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarExcelArea As Button
    Friend WithEvents txtImportarArea As TextBox
    Friend WithEvents btnImportarArea As Button
    Friend WithEvents btnImportarCecos As Button
    Friend WithEvents btnImportarEquipos As Button
    Friend WithEvents btnImportarMarca As Button
    Friend WithEvents btnImportarPlanes As Button
    Friend WithEvents btnImportarUsuario As Button
    Friend WithEvents PanelTextBox As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
End Class
