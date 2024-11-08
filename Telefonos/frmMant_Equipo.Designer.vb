
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMant_Equipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMant_Equipo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Dtp_Compra = New System.Windows.Forms.DateTimePicker()
        Me.cboNumero = New System.Windows.Forms.ComboBox()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnEliminarRegistro = New System.Windows.Forms.Button()
        Me.btnActualizarNumero = New System.Windows.Forms.Button()
        Me.btnNuevoNumero = New System.Windows.Forms.Button()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnMantDisp = New System.Windows.Forms.Button()
        Me.btnBuscarUsuarios = New System.Windows.Forms.Button()
        Me.btnResetUsuario = New System.Windows.Forms.Button()
        Me.cboDispositivo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnResetPlan = New System.Windows.Forms.Button()
        Me.btnResetEquipo = New System.Windows.Forms.Button()
        Me.btnResetMarca = New System.Windows.Forms.Button()
        Me.btnResetArea = New System.Windows.Forms.Button()
        Me.btnResetCeCo = New System.Windows.Forms.Button()
        Me.btnResetEmpresa = New System.Windows.Forms.Button()
        Me.btnResetProv = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnMantEmpresa = New System.Windows.Forms.Button()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtImei2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_Asignacion = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtImei1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnMantPlan = New System.Windows.Forms.Button()
        Me.cboPlan = New System.Windows.Forms.ComboBox()
        Me.btnMantModelo = New System.Windows.Forms.Button()
        Me.cboModelo = New System.Windows.Forms.ComboBox()
        Me.btnMantMarca = New System.Windows.Forms.Button()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.btnMantAsignado = New System.Windows.Forms.Button()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.btnArea = New System.Windows.Forms.Button()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.btnCeCo = New System.Windows.Forms.Button()
        Me.cboCeCo = New System.Windows.Forms.ComboBox()
        Me.btnMantProveedor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecioEquipo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.txtIdHistorial = New System.Windows.Forms.TextBox()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DTP_Cierre = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.cboLiquidacion = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtMontoIncidente = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboStatusIncidente = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Dtp_FechaIncidente = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtIncidente = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtpCierre_Reset = New System.Windows.Forms.Button()
        Me.btnResetCat = New System.Windows.Forms.Button()
        Me.btnAgregaIncidente = New System.Windows.Forms.Button()
        Me.btnActualizaIncidente = New System.Windows.Forms.Button()
        Me.btnEliminarIncidente = New System.Windows.Forms.Button()
        Me.btnResetStats = New System.Windows.Forms.Button()
        Me.btnResetDesc = New System.Windows.Forms.Button()
        Me.TabPanel = New System.Windows.Forms.Panel()
        Me.tabIndicador2 = New System.Windows.Forms.Panel()
        Me.tabIndicador1 = New System.Windows.Forms.Panel()
        Me.btnHistorial = New System.Windows.Forms.Button()
        Me.btnMantenimiento = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(120, 30)
        Me.TabControl1.Location = New System.Drawing.Point(3, 29)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(932, 472)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Dtp_Compra)
        Me.TabPage1.Controls.Add(Me.cboNumero)
        Me.TabPage1.Controls.Add(Me.cboProveedor)
        Me.TabPage1.Controls.Add(Me.btnLimpiar)
        Me.TabPage1.Controls.Add(Me.btnExportarExcel)
        Me.TabPage1.Controls.Add(Me.btnEliminarRegistro)
        Me.TabPage1.Controls.Add(Me.btnActualizarNumero)
        Me.TabPage1.Controls.Add(Me.btnNuevoNumero)
        Me.TabPage1.Controls.Add(Me.cboEstatus)
        Me.TabPage1.Controls.Add(Me.txtObservacion)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.btnMantDisp)
        Me.TabPage1.Controls.Add(Me.btnBuscarUsuarios)
        Me.TabPage1.Controls.Add(Me.btnResetUsuario)
        Me.TabPage1.Controls.Add(Me.cboDispositivo)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.btnResetPlan)
        Me.TabPage1.Controls.Add(Me.btnResetEquipo)
        Me.TabPage1.Controls.Add(Me.btnResetMarca)
        Me.TabPage1.Controls.Add(Me.btnResetArea)
        Me.TabPage1.Controls.Add(Me.btnResetCeCo)
        Me.TabPage1.Controls.Add(Me.btnResetEmpresa)
        Me.TabPage1.Controls.Add(Me.btnResetProv)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.btnMantEmpresa)
        Me.TabPage1.Controls.Add(Me.cboEmpresa)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtImei2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.DTP_Asignacion)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.txtImei1)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.btnMantPlan)
        Me.TabPage1.Controls.Add(Me.cboPlan)
        Me.TabPage1.Controls.Add(Me.btnMantModelo)
        Me.TabPage1.Controls.Add(Me.cboModelo)
        Me.TabPage1.Controls.Add(Me.btnMantMarca)
        Me.TabPage1.Controls.Add(Me.cboMarca)
        Me.TabPage1.Controls.Add(Me.btnMantAsignado)
        Me.TabPage1.Controls.Add(Me.cboUsuario)
        Me.TabPage1.Controls.Add(Me.btnArea)
        Me.TabPage1.Controls.Add(Me.cboArea)
        Me.TabPage1.Controls.Add(Me.btnCeCo)
        Me.TabPage1.Controls.Add(Me.cboCeCo)
        Me.TabPage1.Controls.Add(Me.btnMantProveedor)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtPrecioEquipo)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnVerificar)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.DimGray
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(924, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mantenimiento"
        '
        'Dtp_Compra
        '
        Me.Dtp_Compra.CalendarForeColor = System.Drawing.Color.DimGray
        Me.Dtp_Compra.CalendarMonthBackground = System.Drawing.Color.White
        Me.Dtp_Compra.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.Dtp_Compra.CalendarTrailingForeColor = System.Drawing.Color.DimGray
        Me.Dtp_Compra.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_Compra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Compra.Location = New System.Drawing.Point(154, 190)
        Me.Dtp_Compra.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.Dtp_Compra.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Compra.Name = "Dtp_Compra"
        Me.Dtp_Compra.Size = New System.Drawing.Size(226, 22)
        Me.Dtp_Compra.TabIndex = 16
        '
        'cboNumero
        '
        Me.cboNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNumero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboNumero.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNumero.ForeColor = System.Drawing.Color.DimGray
        Me.cboNumero.Location = New System.Drawing.Point(154, 36)
        Me.cboNumero.Name = "cboNumero"
        Me.cboNumero.Size = New System.Drawing.Size(226, 21)
        Me.cboNumero.TabIndex = 1
        '
        'cboProveedor
        '
        Me.cboProveedor.BackColor = System.Drawing.Color.White
        Me.cboProveedor.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedor.ForeColor = System.Drawing.Color.DimGray
        Me.cboProveedor.Location = New System.Drawing.Point(154, 66)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(226, 21)
        Me.cboProveedor.TabIndex = 4
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DimGray
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(750, 379)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(150, 40)
        Me.btnLimpiar.TabIndex = 44
        Me.btnLimpiar.Text = "   Limpiar Todo"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackColor = System.Drawing.Color.White
        Me.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarExcel.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DimGray
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarExcel.Location = New System.Drawing.Point(568, 379)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(150, 40)
        Me.btnExportarExcel.TabIndex = 43
        Me.btnExportarExcel.Text = "    Exportar a Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'btnEliminarRegistro
        '
        Me.btnEliminarRegistro.BackColor = System.Drawing.Color.White
        Me.btnEliminarRegistro.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEliminarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarRegistro.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarRegistro.ForeColor = System.Drawing.Color.DimGray
        Me.btnEliminarRegistro.Image = CType(resources.GetObject("btnEliminarRegistro.Image"), System.Drawing.Image)
        Me.btnEliminarRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarRegistro.Location = New System.Drawing.Point(388, 379)
        Me.btnEliminarRegistro.Name = "btnEliminarRegistro"
        Me.btnEliminarRegistro.Size = New System.Drawing.Size(150, 40)
        Me.btnEliminarRegistro.TabIndex = 42
        Me.btnEliminarRegistro.Text = "      Eliminar Registro"
        Me.btnEliminarRegistro.UseVisualStyleBackColor = False
        '
        'btnActualizarNumero
        '
        Me.btnActualizarNumero.BackColor = System.Drawing.Color.White
        Me.btnActualizarNumero.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnActualizarNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarNumero.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarNumero.ForeColor = System.Drawing.Color.DimGray
        Me.btnActualizarNumero.Image = CType(resources.GetObject("btnActualizarNumero.Image"), System.Drawing.Image)
        Me.btnActualizarNumero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizarNumero.Location = New System.Drawing.Point(208, 379)
        Me.btnActualizarNumero.Name = "btnActualizarNumero"
        Me.btnActualizarNumero.Size = New System.Drawing.Size(150, 40)
        Me.btnActualizarNumero.TabIndex = 41
        Me.btnActualizarNumero.Text = "    Actualizar Datos"
        Me.btnActualizarNumero.UseVisualStyleBackColor = False
        '
        'btnNuevoNumero
        '
        Me.btnNuevoNumero.BackColor = System.Drawing.Color.White
        Me.btnNuevoNumero.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnNuevoNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoNumero.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoNumero.ForeColor = System.Drawing.Color.DimGray
        Me.btnNuevoNumero.Image = CType(resources.GetObject("btnNuevoNumero.Image"), System.Drawing.Image)
        Me.btnNuevoNumero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoNumero.Location = New System.Drawing.Point(27, 379)
        Me.btnNuevoNumero.Name = "btnNuevoNumero"
        Me.btnNuevoNumero.Size = New System.Drawing.Size(150, 40)
        Me.btnNuevoNumero.TabIndex = 40
        Me.btnNuevoNumero.Text = "    Crear Número"
        Me.btnNuevoNumero.UseVisualStyleBackColor = False
        '
        'cboEstatus
        '
        Me.cboEstatus.BackColor = System.Drawing.Color.White
        Me.cboEstatus.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstatus.ForeColor = System.Drawing.Color.DimGray
        Me.cboEstatus.Items.AddRange(New Object() {"EN USO", "DE BAJA", "LIBRE"})
        Me.cboEstatus.Location = New System.Drawing.Point(599, 158)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(236, 21)
        Me.cboEstatus.TabIndex = 35
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsReturn = True
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.BackColor = System.Drawing.Color.White
        Me.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.ForeColor = System.Drawing.Color.DimGray
        Me.txtObservacion.Location = New System.Drawing.Point(599, 222)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(301, 119)
        Me.txtObservacion.TabIndex = 39
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(866, 190)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(26, 24)
        Me.Button3.TabIndex = 38
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnMantDisp
        '
        Me.btnMantDisp.BackColor = System.Drawing.Color.Transparent
        Me.btnMantDisp.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantDisp.FlatAppearance.BorderSize = 0
        Me.btnMantDisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantDisp.Image = CType(resources.GetObject("btnMantDisp.Image"), System.Drawing.Image)
        Me.btnMantDisp.Location = New System.Drawing.Point(842, 189)
        Me.btnMantDisp.Name = "btnMantDisp"
        Me.btnMantDisp.Size = New System.Drawing.Size(26, 24)
        Me.btnMantDisp.TabIndex = 37
        Me.btnMantDisp.UseVisualStyleBackColor = False
        '
        'btnBuscarUsuarios
        '
        Me.btnBuscarUsuarios.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscarUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscarUsuarios.FlatAppearance.BorderSize = 0
        Me.btnBuscarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarUsuarios.Image = CType(resources.GetObject("btnBuscarUsuarios.Image"), System.Drawing.Image)
        Me.btnBuscarUsuarios.Location = New System.Drawing.Point(422, 34)
        Me.btnBuscarUsuarios.Name = "btnBuscarUsuarios"
        Me.btnBuscarUsuarios.Size = New System.Drawing.Size(26, 24)
        Me.btnBuscarUsuarios.TabIndex = 3
        Me.btnBuscarUsuarios.UseVisualStyleBackColor = False
        '
        'btnResetUsuario
        '
        Me.btnResetUsuario.BackColor = System.Drawing.Color.Transparent
        Me.btnResetUsuario.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetUsuario.FlatAppearance.BorderSize = 0
        Me.btnResetUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetUsuario.Image = CType(resources.GetObject("btnResetUsuario.Image"), System.Drawing.Image)
        Me.btnResetUsuario.Location = New System.Drawing.Point(422, 220)
        Me.btnResetUsuario.Name = "btnResetUsuario"
        Me.btnResetUsuario.Size = New System.Drawing.Size(26, 24)
        Me.btnResetUsuario.TabIndex = 20
        Me.btnResetUsuario.UseVisualStyleBackColor = False
        '
        'cboDispositivo
        '
        Me.cboDispositivo.BackColor = System.Drawing.Color.White
        Me.cboDispositivo.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDispositivo.ForeColor = System.Drawing.Color.DimGray
        Me.cboDispositivo.Location = New System.Drawing.Point(600, 191)
        Me.cboDispositivo.Name = "cboDispositivo"
        Me.cboDispositivo.Size = New System.Drawing.Size(235, 21)
        Me.cboDispositivo.TabIndex = 36
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(488, 195)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 15)
        Me.Label16.TabIndex = 131
        Me.Label16.Text = "Dispositivo"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(422, 253)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 24)
        Me.Button2.TabIndex = 22
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(422, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 24)
        Me.Button1.TabIndex = 17
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnResetPlan
        '
        Me.btnResetPlan.BackColor = System.Drawing.Color.Transparent
        Me.btnResetPlan.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetPlan.FlatAppearance.BorderSize = 0
        Me.btnResetPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetPlan.Image = CType(resources.GetObject("btnResetPlan.Image"), System.Drawing.Image)
        Me.btnResetPlan.Location = New System.Drawing.Point(866, 64)
        Me.btnResetPlan.Name = "btnResetPlan"
        Me.btnResetPlan.Size = New System.Drawing.Size(26, 24)
        Me.btnResetPlan.TabIndex = 32
        Me.btnResetPlan.UseVisualStyleBackColor = False
        '
        'btnResetEquipo
        '
        Me.btnResetEquipo.BackColor = System.Drawing.Color.Transparent
        Me.btnResetEquipo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetEquipo.FlatAppearance.BorderSize = 0
        Me.btnResetEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetEquipo.Image = CType(resources.GetObject("btnResetEquipo.Image"), System.Drawing.Image)
        Me.btnResetEquipo.Location = New System.Drawing.Point(422, 320)
        Me.btnResetEquipo.Name = "btnResetEquipo"
        Me.btnResetEquipo.Size = New System.Drawing.Size(26, 24)
        Me.btnResetEquipo.TabIndex = 28
        Me.btnResetEquipo.UseVisualStyleBackColor = False
        '
        'btnResetMarca
        '
        Me.btnResetMarca.BackColor = System.Drawing.Color.Transparent
        Me.btnResetMarca.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetMarca.FlatAppearance.BorderSize = 0
        Me.btnResetMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetMarca.Image = CType(resources.GetObject("btnResetMarca.Image"), System.Drawing.Image)
        Me.btnResetMarca.Location = New System.Drawing.Point(422, 287)
        Me.btnResetMarca.Name = "btnResetMarca"
        Me.btnResetMarca.Size = New System.Drawing.Size(26, 24)
        Me.btnResetMarca.TabIndex = 25
        Me.btnResetMarca.UseVisualStyleBackColor = False
        '
        'btnResetArea
        '
        Me.btnResetArea.BackColor = System.Drawing.Color.Transparent
        Me.btnResetArea.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetArea.FlatAppearance.BorderSize = 0
        Me.btnResetArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetArea.Image = CType(resources.GetObject("btnResetArea.Image"), System.Drawing.Image)
        Me.btnResetArea.Location = New System.Drawing.Point(422, 157)
        Me.btnResetArea.Name = "btnResetArea"
        Me.btnResetArea.Size = New System.Drawing.Size(26, 24)
        Me.btnResetArea.TabIndex = 15
        Me.btnResetArea.UseVisualStyleBackColor = False
        '
        'btnResetCeCo
        '
        Me.btnResetCeCo.BackColor = System.Drawing.Color.Transparent
        Me.btnResetCeCo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetCeCo.FlatAppearance.BorderSize = 0
        Me.btnResetCeCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetCeCo.Image = CType(resources.GetObject("btnResetCeCo.Image"), System.Drawing.Image)
        Me.btnResetCeCo.Location = New System.Drawing.Point(422, 125)
        Me.btnResetCeCo.Name = "btnResetCeCo"
        Me.btnResetCeCo.Size = New System.Drawing.Size(26, 24)
        Me.btnResetCeCo.TabIndex = 12
        Me.btnResetCeCo.UseVisualStyleBackColor = False
        '
        'btnResetEmpresa
        '
        Me.btnResetEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.btnResetEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetEmpresa.FlatAppearance.BorderSize = 0
        Me.btnResetEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetEmpresa.Image = CType(resources.GetObject("btnResetEmpresa.Image"), System.Drawing.Image)
        Me.btnResetEmpresa.Location = New System.Drawing.Point(422, 94)
        Me.btnResetEmpresa.Name = "btnResetEmpresa"
        Me.btnResetEmpresa.Size = New System.Drawing.Size(26, 24)
        Me.btnResetEmpresa.TabIndex = 9
        Me.btnResetEmpresa.UseVisualStyleBackColor = False
        '
        'btnResetProv
        '
        Me.btnResetProv.BackColor = System.Drawing.Color.Transparent
        Me.btnResetProv.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnResetProv.FlatAppearance.BorderSize = 0
        Me.btnResetProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetProv.Image = CType(resources.GetObject("btnResetProv.Image"), System.Drawing.Image)
        Me.btnResetProv.Location = New System.Drawing.Point(422, 64)
        Me.btnResetProv.Name = "btnResetProv"
        Me.btnResetProv.Size = New System.Drawing.Size(26, 24)
        Me.btnResetProv.TabIndex = 6
        Me.btnResetProv.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(487, 226)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 15)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = "Observaciones"
        '
        'btnMantEmpresa
        '
        Me.btnMantEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.btnMantEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantEmpresa.FlatAppearance.BorderSize = 0
        Me.btnMantEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantEmpresa.Image = CType(resources.GetObject("btnMantEmpresa.Image"), System.Drawing.Image)
        Me.btnMantEmpresa.Location = New System.Drawing.Point(391, 94)
        Me.btnMantEmpresa.Name = "btnMantEmpresa"
        Me.btnMantEmpresa.Size = New System.Drawing.Size(26, 24)
        Me.btnMantEmpresa.TabIndex = 8
        Me.btnMantEmpresa.UseVisualStyleBackColor = False
        '
        'cboEmpresa
        '
        Me.cboEmpresa.BackColor = System.Drawing.Color.White
        Me.cboEmpresa.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.ForeColor = System.Drawing.Color.DimGray
        Me.cboEmpresa.Location = New System.Drawing.Point(154, 96)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(226, 21)
        Me.cboEmpresa.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(24, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Empresa"
        '
        'txtImei2
        '
        Me.txtImei2.BackColor = System.Drawing.Color.White
        Me.txtImei2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImei2.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImei2.ForeColor = System.Drawing.Color.DimGray
        Me.txtImei2.Location = New System.Drawing.Point(599, 127)
        Me.txtImei2.Name = "txtImei2"
        Me.txtImei2.Size = New System.Drawing.Size(236, 22)
        Me.txtImei2.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(488, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Imei 2"
        '
        'DTP_Asignacion
        '
        Me.DTP_Asignacion.CalendarForeColor = System.Drawing.Color.DimGray
        Me.DTP_Asignacion.CalendarMonthBackground = System.Drawing.Color.White
        Me.DTP_Asignacion.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.DTP_Asignacion.CalendarTrailingForeColor = System.Drawing.Color.DimGray
        Me.DTP_Asignacion.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Asignacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Asignacion.Location = New System.Drawing.Point(154, 256)
        Me.DTP_Asignacion.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.DTP_Asignacion.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.DTP_Asignacion.Name = "DTP_Asignacion"
        Me.DTP_Asignacion.Size = New System.Drawing.Size(226, 22)
        Me.DTP_Asignacion.TabIndex = 21
        Me.DTP_Asignacion.Value = New Date(2017, 5, 12, 16, 55, 29, 0)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DimGray
        Me.Label20.Location = New System.Drawing.Point(24, 259)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(101, 15)
        Me.Label20.TabIndex = 127
        Me.Label20.Text = "Fecha Asignación"
        '
        'txtImei1
        '
        Me.txtImei1.BackColor = System.Drawing.Color.White
        Me.txtImei1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImei1.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImei1.ForeColor = System.Drawing.Color.DimGray
        Me.txtImei1.Location = New System.Drawing.Point(599, 96)
        Me.txtImei1.Name = "txtImei1"
        Me.txtImei1.Size = New System.Drawing.Size(236, 22)
        Me.txtImei1.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(488, 98)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 15)
        Me.Label19.TabIndex = 126
        Me.Label19.Text = "Imei 1"
        '
        'btnMantPlan
        '
        Me.btnMantPlan.BackColor = System.Drawing.Color.Transparent
        Me.btnMantPlan.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantPlan.FlatAppearance.BorderSize = 0
        Me.btnMantPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantPlan.Image = CType(resources.GetObject("btnMantPlan.Image"), System.Drawing.Image)
        Me.btnMantPlan.Location = New System.Drawing.Point(842, 64)
        Me.btnMantPlan.Name = "btnMantPlan"
        Me.btnMantPlan.Size = New System.Drawing.Size(26, 24)
        Me.btnMantPlan.TabIndex = 31
        Me.btnMantPlan.UseVisualStyleBackColor = False
        '
        'cboPlan
        '
        Me.cboPlan.BackColor = System.Drawing.Color.White
        Me.cboPlan.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPlan.ForeColor = System.Drawing.Color.DimGray
        Me.cboPlan.Location = New System.Drawing.Point(599, 66)
        Me.cboPlan.Name = "cboPlan"
        Me.cboPlan.Size = New System.Drawing.Size(236, 21)
        Me.cboPlan.TabIndex = 30
        '
        'btnMantModelo
        '
        Me.btnMantModelo.BackColor = System.Drawing.Color.Transparent
        Me.btnMantModelo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantModelo.FlatAppearance.BorderSize = 0
        Me.btnMantModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantModelo.Image = CType(resources.GetObject("btnMantModelo.Image"), System.Drawing.Image)
        Me.btnMantModelo.Location = New System.Drawing.Point(391, 320)
        Me.btnMantModelo.Name = "btnMantModelo"
        Me.btnMantModelo.Size = New System.Drawing.Size(26, 24)
        Me.btnMantModelo.TabIndex = 27
        Me.btnMantModelo.UseVisualStyleBackColor = False
        '
        'cboModelo
        '
        Me.cboModelo.BackColor = System.Drawing.Color.White
        Me.cboModelo.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModelo.ForeColor = System.Drawing.Color.DimGray
        Me.cboModelo.Location = New System.Drawing.Point(154, 322)
        Me.cboModelo.Name = "cboModelo"
        Me.cboModelo.Size = New System.Drawing.Size(226, 21)
        Me.cboModelo.TabIndex = 26
        '
        'btnMantMarca
        '
        Me.btnMantMarca.BackColor = System.Drawing.Color.Transparent
        Me.btnMantMarca.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantMarca.FlatAppearance.BorderSize = 0
        Me.btnMantMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantMarca.Image = CType(resources.GetObject("btnMantMarca.Image"), System.Drawing.Image)
        Me.btnMantMarca.Location = New System.Drawing.Point(391, 287)
        Me.btnMantMarca.Name = "btnMantMarca"
        Me.btnMantMarca.Size = New System.Drawing.Size(26, 24)
        Me.btnMantMarca.TabIndex = 24
        Me.btnMantMarca.UseVisualStyleBackColor = False
        '
        'cboMarca
        '
        Me.cboMarca.BackColor = System.Drawing.Color.White
        Me.cboMarca.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMarca.ForeColor = System.Drawing.Color.DimGray
        Me.cboMarca.Location = New System.Drawing.Point(154, 289)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(226, 21)
        Me.cboMarca.TabIndex = 23
        '
        'btnMantAsignado
        '
        Me.btnMantAsignado.BackColor = System.Drawing.Color.Transparent
        Me.btnMantAsignado.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantAsignado.FlatAppearance.BorderSize = 0
        Me.btnMantAsignado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantAsignado.Image = CType(resources.GetObject("btnMantAsignado.Image"), System.Drawing.Image)
        Me.btnMantAsignado.Location = New System.Drawing.Point(391, 220)
        Me.btnMantAsignado.Name = "btnMantAsignado"
        Me.btnMantAsignado.Size = New System.Drawing.Size(26, 24)
        Me.btnMantAsignado.TabIndex = 19
        Me.btnMantAsignado.UseVisualStyleBackColor = False
        '
        'cboUsuario
        '
        Me.cboUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUsuario.BackColor = System.Drawing.Color.White
        Me.cboUsuario.DropDownWidth = 250
        Me.cboUsuario.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuario.ForeColor = System.Drawing.Color.DimGray
        Me.cboUsuario.Location = New System.Drawing.Point(154, 223)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(226, 21)
        Me.cboUsuario.TabIndex = 18
        '
        'btnArea
        '
        Me.btnArea.BackColor = System.Drawing.Color.Transparent
        Me.btnArea.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnArea.FlatAppearance.BorderSize = 0
        Me.btnArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArea.Image = CType(resources.GetObject("btnArea.Image"), System.Drawing.Image)
        Me.btnArea.Location = New System.Drawing.Point(391, 157)
        Me.btnArea.Name = "btnArea"
        Me.btnArea.Size = New System.Drawing.Size(26, 24)
        Me.btnArea.TabIndex = 14
        Me.btnArea.UseVisualStyleBackColor = False
        '
        'cboArea
        '
        Me.cboArea.BackColor = System.Drawing.Color.White
        Me.cboArea.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboArea.ForeColor = System.Drawing.Color.DimGray
        Me.cboArea.Location = New System.Drawing.Point(154, 159)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(226, 21)
        Me.cboArea.TabIndex = 13
        '
        'btnCeCo
        '
        Me.btnCeCo.BackColor = System.Drawing.Color.Transparent
        Me.btnCeCo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCeCo.FlatAppearance.BorderSize = 0
        Me.btnCeCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCeCo.Image = CType(resources.GetObject("btnCeCo.Image"), System.Drawing.Image)
        Me.btnCeCo.Location = New System.Drawing.Point(391, 125)
        Me.btnCeCo.Name = "btnCeCo"
        Me.btnCeCo.Size = New System.Drawing.Size(26, 24)
        Me.btnCeCo.TabIndex = 11
        Me.btnCeCo.UseVisualStyleBackColor = False
        '
        'cboCeCo
        '
        Me.cboCeCo.BackColor = System.Drawing.Color.White
        Me.cboCeCo.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCeCo.ForeColor = System.Drawing.Color.DimGray
        Me.cboCeCo.Location = New System.Drawing.Point(154, 127)
        Me.cboCeCo.Name = "cboCeCo"
        Me.cboCeCo.Size = New System.Drawing.Size(226, 21)
        Me.cboCeCo.TabIndex = 10
        '
        'btnMantProveedor
        '
        Me.btnMantProveedor.BackColor = System.Drawing.Color.Transparent
        Me.btnMantProveedor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMantProveedor.FlatAppearance.BorderSize = 0
        Me.btnMantProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantProveedor.Image = CType(resources.GetObject("btnMantProveedor.Image"), System.Drawing.Image)
        Me.btnMantProveedor.Location = New System.Drawing.Point(391, 64)
        Me.btnMantProveedor.Name = "btnMantProveedor"
        Me.btnMantProveedor.Size = New System.Drawing.Size(26, 24)
        Me.btnMantProveedor.TabIndex = 5
        Me.btnMantProveedor.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(23, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 15)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Modelo Equipo:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(24, 292)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Marca Equipo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(488, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 15)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Plan"
        '
        'txtPrecioEquipo
        '
        Me.txtPrecioEquipo.BackColor = System.Drawing.Color.White
        Me.txtPrecioEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioEquipo.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioEquipo.ForeColor = System.Drawing.Color.DimGray
        Me.txtPrecioEquipo.Location = New System.Drawing.Point(599, 35)
        Me.txtPrecioEquipo.Name = "txtPrecioEquipo"
        Me.txtPrecioEquipo.Size = New System.Drawing.Size(236, 22)
        Me.txtPrecioEquipo.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(487, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Precio Equipo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(24, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Área"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(24, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 15)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Centro de Costo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(24, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Asignado a"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(488, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Estatus"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(24, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 15)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Fecha de Compra"
        '
        'btnVerificar
        '
        Me.btnVerificar.BackColor = System.Drawing.Color.Transparent
        Me.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVerificar.FlatAppearance.BorderSize = 0
        Me.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerificar.Image = CType(resources.GetObject("btnVerificar.Image"), System.Drawing.Image)
        Me.btnVerificar.Location = New System.Drawing.Point(391, 34)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(26, 24)
        Me.btnVerificar.TabIndex = 2
        Me.btnVerificar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(25, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(25, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Número"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.btnCategoria)
        Me.TabPage2.Controls.Add(Me.txtIdHistorial)
        Me.TabPage2.Controls.Add(Me.cboCategoria)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.DTP_Cierre)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtCorrelativo)
        Me.TabPage2.Controls.Add(Me.cboLiquidacion)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.txtMontoIncidente)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.cboStatusIncidente)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Dtp_FechaIncidente)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.txtIncidente)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Controls.Add(Me.dtpCierre_Reset)
        Me.TabPage2.Controls.Add(Me.btnResetCat)
        Me.TabPage2.Controls.Add(Me.btnAgregaIncidente)
        Me.TabPage2.Controls.Add(Me.btnActualizaIncidente)
        Me.TabPage2.Controls.Add(Me.btnEliminarIncidente)
        Me.TabPage2.Controls.Add(Me.btnResetStats)
        Me.TabPage2.Controls.Add(Me.btnResetDesc)
        Me.TabPage2.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.Color.DimGray
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(924, 434)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Historial"
        '
        'btnCategoria
        '
        Me.btnCategoria.BackColor = System.Drawing.Color.Transparent
        Me.btnCategoria.FlatAppearance.BorderSize = 0
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(669, 29)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(26, 24)
        Me.btnCategoria.TabIndex = 50
        Me.btnCategoria.UseVisualStyleBackColor = False
        '
        'txtIdHistorial
        '
        Me.txtIdHistorial.Enabled = False
        Me.txtIdHistorial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdHistorial.Location = New System.Drawing.Point(296, 33)
        Me.txtIdHistorial.Name = "txtIdHistorial"
        Me.txtIdHistorial.ReadOnly = True
        Me.txtIdHistorial.Size = New System.Drawing.Size(50, 20)
        Me.txtIdHistorial.TabIndex = 103
        Me.txtIdHistorial.Visible = False
        '
        'cboCategoria
        '
        Me.cboCategoria.BackColor = System.Drawing.Color.White
        Me.cboCategoria.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategoria.ForeColor = System.Drawing.Color.DimGray
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(462, 30)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(201, 21)
        Me.cboCategoria.TabIndex = 49
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DimGray
        Me.Label22.Location = New System.Drawing.Point(369, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 15)
        Me.Label22.TabIndex = 102
        Me.Label22.Text = "Categoría"
        '
        'DTP_Cierre
        '
        Me.DTP_Cierre.CalendarForeColor = System.Drawing.Color.DimGray
        Me.DTP_Cierre.CalendarMonthBackground = System.Drawing.Color.White
        Me.DTP_Cierre.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.DTP_Cierre.CalendarTrailingForeColor = System.Drawing.Color.DimGray
        Me.DTP_Cierre.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Cierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Cierre.Location = New System.Drawing.Point(462, 94)
        Me.DTP_Cierre.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.DTP_Cierre.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.DTP_Cierre.Name = "DTP_Cierre"
        Me.DTP_Cierre.Size = New System.Drawing.Size(201, 22)
        Me.DTP_Cierre.TabIndex = 54
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(369, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 15)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Fecha Cierre"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Enabled = False
        Me.txtCorrelativo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrelativo.Location = New System.Drawing.Point(296, 65)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.ReadOnly = True
        Me.txtCorrelativo.Size = New System.Drawing.Size(50, 20)
        Me.txtCorrelativo.TabIndex = 100
        Me.txtCorrelativo.Visible = False
        '
        'cboLiquidacion
        '
        Me.cboLiquidacion.BackColor = System.Drawing.Color.White
        Me.cboLiquidacion.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLiquidacion.ForeColor = System.Drawing.Color.DimGray
        Me.cboLiquidacion.FormattingEnabled = True
        Me.cboLiquidacion.Items.AddRange(New Object() {"SÍ", "NO", "NO APLICA"})
        Me.cboLiquidacion.Location = New System.Drawing.Point(132, 93)
        Me.cboLiquidacion.Name = "cboLiquidacion"
        Me.cboLiquidacion.Size = New System.Drawing.Size(155, 21)
        Me.cboLiquidacion.TabIndex = 47
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DimGray
        Me.Label21.Location = New System.Drawing.Point(23, 97)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 15)
        Me.Label21.TabIndex = 99
        Me.Label21.Text = "¿Descontado?"
        '
        'txtMontoIncidente
        '
        Me.txtMontoIncidente.BackColor = System.Drawing.Color.White
        Me.txtMontoIncidente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoIncidente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoIncidente.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.txtMontoIncidente.Location = New System.Drawing.Point(132, 63)
        Me.txtMontoIncidente.MaxLength = 10
        Me.txtMontoIncidente.Name = "txtMontoIncidente"
        Me.txtMontoIncidente.Size = New System.Drawing.Size(156, 22)
        Me.txtMontoIncidente.TabIndex = 46
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DimGray
        Me.Label23.Location = New System.Drawing.Point(23, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 15)
        Me.Label23.TabIndex = 98
        Me.Label23.Text = "Monto"
        '
        'cboStatusIncidente
        '
        Me.cboStatusIncidente.BackColor = System.Drawing.Color.White
        Me.cboStatusIncidente.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.cboStatusIncidente.FormattingEnabled = True
        Me.cboStatusIncidente.Items.AddRange(New Object() {"ABIERTO", "CERRADO", "EN ESPERA"})
        Me.cboStatusIncidente.Location = New System.Drawing.Point(462, 62)
        Me.cboStatusIncidente.Name = "cboStatusIncidente"
        Me.cboStatusIncidente.Size = New System.Drawing.Size(201, 21)
        Me.cboStatusIncidente.TabIndex = 52
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(369, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 15)
        Me.Label25.TabIndex = 95
        Me.Label25.Text = "Estatus"
        '
        'Dtp_FechaIncidente
        '
        Me.Dtp_FechaIncidente.CalendarForeColor = System.Drawing.Color.DimGray
        Me.Dtp_FechaIncidente.CalendarMonthBackground = System.Drawing.Color.White
        Me.Dtp_FechaIncidente.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.Dtp_FechaIncidente.CalendarTrailingForeColor = System.Drawing.Color.DimGray
        Me.Dtp_FechaIncidente.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_FechaIncidente.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaIncidente.Location = New System.Drawing.Point(132, 33)
        Me.Dtp_FechaIncidente.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.Dtp_FechaIncidente.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaIncidente.Name = "Dtp_FechaIncidente"
        Me.Dtp_FechaIncidente.Size = New System.Drawing.Size(155, 22)
        Me.Dtp_FechaIncidente.TabIndex = 45
        Me.Dtp_FechaIncidente.Value = New Date(2018, 11, 12, 0, 0, 0, 0)
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DimGray
        Me.Label26.Location = New System.Drawing.Point(23, 36)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 15)
        Me.Label26.TabIndex = 96
        Me.Label26.Text = "Fecha"
        '
        'txtIncidente
        '
        Me.txtIncidente.BackColor = System.Drawing.Color.White
        Me.txtIncidente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIncidente.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.txtIncidente.Location = New System.Drawing.Point(132, 131)
        Me.txtIncidente.Multiline = True
        Me.txtIncidente.Name = "txtIncidente"
        Me.txtIncidente.Size = New System.Drawing.Size(598, 53)
        Me.txtIncidente.TabIndex = 56
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DimGray
        Me.Label27.Location = New System.Drawing.Point(23, 128)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 15)
        Me.Label27.TabIndex = 97
        Me.Label27.Text = "Incidente"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.Location = New System.Drawing.Point(19, 207)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(886, 214)
        Me.DataGridView1.TabIndex = 60
        '
        'dtpCierre_Reset
        '
        Me.dtpCierre_Reset.BackColor = System.Drawing.Color.Transparent
        Me.dtpCierre_Reset.FlatAppearance.BorderSize = 0
        Me.dtpCierre_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dtpCierre_Reset.Image = CType(resources.GetObject("dtpCierre_Reset.Image"), System.Drawing.Image)
        Me.dtpCierre_Reset.Location = New System.Drawing.Point(697, 92)
        Me.dtpCierre_Reset.Name = "dtpCierre_Reset"
        Me.dtpCierre_Reset.Size = New System.Drawing.Size(26, 24)
        Me.dtpCierre_Reset.TabIndex = 55
        Me.dtpCierre_Reset.UseVisualStyleBackColor = False
        '
        'btnResetCat
        '
        Me.btnResetCat.BackColor = System.Drawing.Color.Transparent
        Me.btnResetCat.FlatAppearance.BorderSize = 0
        Me.btnResetCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetCat.Image = CType(resources.GetObject("btnResetCat.Image"), System.Drawing.Image)
        Me.btnResetCat.Location = New System.Drawing.Point(697, 29)
        Me.btnResetCat.Name = "btnResetCat"
        Me.btnResetCat.Size = New System.Drawing.Size(26, 24)
        Me.btnResetCat.TabIndex = 51
        Me.btnResetCat.UseVisualStyleBackColor = False
        '
        'btnAgregaIncidente
        '
        Me.btnAgregaIncidente.BackColor = System.Drawing.Color.White
        Me.btnAgregaIncidente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnAgregaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregaIncidente.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregaIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.btnAgregaIncidente.Image = CType(resources.GetObject("btnAgregaIncidente.Image"), System.Drawing.Image)
        Me.btnAgregaIncidente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregaIncidente.Location = New System.Drawing.Point(753, 30)
        Me.btnAgregaIncidente.Name = "btnAgregaIncidente"
        Me.btnAgregaIncidente.Size = New System.Drawing.Size(150, 40)
        Me.btnAgregaIncidente.TabIndex = 57
        Me.btnAgregaIncidente.Text = "  Agregar"
        Me.btnAgregaIncidente.UseVisualStyleBackColor = False
        '
        'btnActualizaIncidente
        '
        Me.btnActualizaIncidente.BackColor = System.Drawing.Color.White
        Me.btnActualizaIncidente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnActualizaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizaIncidente.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.btnActualizaIncidente.Image = CType(resources.GetObject("btnActualizaIncidente.Image"), System.Drawing.Image)
        Me.btnActualizaIncidente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaIncidente.Location = New System.Drawing.Point(753, 88)
        Me.btnActualizaIncidente.Name = "btnActualizaIncidente"
        Me.btnActualizaIncidente.Size = New System.Drawing.Size(150, 40)
        Me.btnActualizaIncidente.TabIndex = 58
        Me.btnActualizaIncidente.Text = "   Actualizar"
        Me.btnActualizaIncidente.UseVisualStyleBackColor = False
        '
        'btnEliminarIncidente
        '
        Me.btnEliminarIncidente.BackColor = System.Drawing.Color.White
        Me.btnEliminarIncidente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEliminarIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarIncidente.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarIncidente.ForeColor = System.Drawing.Color.DimGray
        Me.btnEliminarIncidente.Image = CType(resources.GetObject("btnEliminarIncidente.Image"), System.Drawing.Image)
        Me.btnEliminarIncidente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarIncidente.Location = New System.Drawing.Point(753, 144)
        Me.btnEliminarIncidente.Name = "btnEliminarIncidente"
        Me.btnEliminarIncidente.Size = New System.Drawing.Size(150, 40)
        Me.btnEliminarIncidente.TabIndex = 59
        Me.btnEliminarIncidente.Text = "  Eliminar"
        Me.btnEliminarIncidente.UseVisualStyleBackColor = False
        '
        'btnResetStats
        '
        Me.btnResetStats.BackColor = System.Drawing.Color.Transparent
        Me.btnResetStats.FlatAppearance.BorderSize = 0
        Me.btnResetStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetStats.Image = CType(resources.GetObject("btnResetStats.Image"), System.Drawing.Image)
        Me.btnResetStats.Location = New System.Drawing.Point(697, 61)
        Me.btnResetStats.Name = "btnResetStats"
        Me.btnResetStats.Size = New System.Drawing.Size(26, 24)
        Me.btnResetStats.TabIndex = 53
        Me.btnResetStats.UseVisualStyleBackColor = False
        '
        'btnResetDesc
        '
        Me.btnResetDesc.BackColor = System.Drawing.Color.Transparent
        Me.btnResetDesc.FlatAppearance.BorderSize = 0
        Me.btnResetDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetDesc.Image = CType(resources.GetObject("btnResetDesc.Image"), System.Drawing.Image)
        Me.btnResetDesc.Location = New System.Drawing.Point(295, 92)
        Me.btnResetDesc.Name = "btnResetDesc"
        Me.btnResetDesc.Size = New System.Drawing.Size(26, 24)
        Me.btnResetDesc.TabIndex = 48
        Me.btnResetDesc.UseVisualStyleBackColor = False
        '
        'TabPanel
        '
        Me.TabPanel.Controls.Add(Me.tabIndicador2)
        Me.TabPanel.Controls.Add(Me.tabIndicador1)
        Me.TabPanel.Controls.Add(Me.btnHistorial)
        Me.TabPanel.Controls.Add(Me.btnMantenimiento)
        Me.TabPanel.Location = New System.Drawing.Point(3, 4)
        Me.TabPanel.Name = "TabPanel"
        Me.TabPanel.Size = New System.Drawing.Size(297, 54)
        Me.TabPanel.TabIndex = 11
        '
        'tabIndicador2
        '
        Me.tabIndicador2.BackColor = System.Drawing.Color.SteelBlue
        Me.tabIndicador2.Location = New System.Drawing.Point(157, 44)
        Me.tabIndicador2.Name = "tabIndicador2"
        Me.tabIndicador2.Size = New System.Drawing.Size(135, 4)
        Me.tabIndicador2.TabIndex = 14
        Me.tabIndicador2.Visible = False
        '
        'tabIndicador1
        '
        Me.tabIndicador1.BackColor = System.Drawing.Color.SteelBlue
        Me.tabIndicador1.Location = New System.Drawing.Point(7, 44)
        Me.tabIndicador1.Name = "tabIndicador1"
        Me.tabIndicador1.Size = New System.Drawing.Size(135, 4)
        Me.tabIndicador1.TabIndex = 13
        '
        'btnHistorial
        '
        Me.btnHistorial.FlatAppearance.BorderSize = 0
        Me.btnHistorial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnHistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistorial.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorial.ForeColor = System.Drawing.Color.DimGray
        Me.btnHistorial.Location = New System.Drawing.Point(157, 2)
        Me.btnHistorial.Name = "btnHistorial"
        Me.btnHistorial.Size = New System.Drawing.Size(135, 39)
        Me.btnHistorial.TabIndex = 22
        Me.btnHistorial.Text = "Historial"
        Me.btnHistorial.UseVisualStyleBackColor = False
        '
        'btnMantenimiento
        '
        Me.btnMantenimiento.FlatAppearance.BorderSize = 0
        Me.btnMantenimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantenimiento.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMantenimiento.ForeColor = System.Drawing.Color.DimGray
        Me.btnMantenimiento.Location = New System.Drawing.Point(7, 3)
        Me.btnMantenimiento.Name = "btnMantenimiento"
        Me.btnMantenimiento.Size = New System.Drawing.Size(135, 39)
        Me.btnMantenimiento.TabIndex = 0
        Me.btnMantenimiento.Text = "Mantenimiento"
        Me.btnMantenimiento.UseVisualStyleBackColor = False
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
        Me.btnSalir.Location = New System.Drawing.Point(918, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(22, 22)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmMant_Equipo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(943, 514)
        Me.Controls.Add(Me.TabPanel)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Malgun Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMant_Equipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents btnEliminarRegistro As Button
    Friend WithEvents btnActualizarNumero As Button
    Friend WithEvents btnNuevoNumero As Button
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents btnMantDisp As Button
    Friend WithEvents btnBuscarUsuarios As Button
    Friend WithEvents btnResetUsuario As Button
    Friend WithEvents cboDispositivo As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnResetPlan As Button
    Friend WithEvents btnResetEquipo As Button
    Friend WithEvents btnResetMarca As Button
    Friend WithEvents btnResetArea As Button
    Friend WithEvents btnResetCeCo As Button
    Friend WithEvents btnResetEmpresa As Button
    Friend WithEvents btnResetProv As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents btnMantEmpresa As Button
    Friend WithEvents cboEmpresa As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtImei2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DTP_Asignacion As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents txtImei1 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btnMantPlan As Button
    Friend WithEvents cboPlan As ComboBox
    Friend WithEvents btnMantModelo As Button
    Friend WithEvents cboModelo As ComboBox
    Friend WithEvents btnMantMarca As Button
    Friend WithEvents cboMarca As ComboBox
    Friend WithEvents btnMantAsignado As Button
    Friend WithEvents cboUsuario As ComboBox
    Friend WithEvents btnArea As Button
    Friend WithEvents cboArea As ComboBox
    Friend WithEvents btnCeCo As Button
    Friend WithEvents cboCeCo As ComboBox
    Friend WithEvents btnMantProveedor As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrecioEquipo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnVerificar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPanel As Panel
    Friend WithEvents btnHistorial As Button
    Friend WithEvents btnMantenimiento As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents tabIndicador2 As Panel
    Friend WithEvents tabIndicador1 As Panel
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents btnCategoria As Button
    Friend WithEvents txtIdHistorial As TextBox
    Friend WithEvents dtpCierre_Reset As Button
    Friend WithEvents btnResetCat As Button
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents DTP_Cierre As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents btnAgregaIncidente As Button
    Friend WithEvents btnActualizaIncidente As Button
    Friend WithEvents btnEliminarIncidente As Button
    Friend WithEvents btnResetStats As Button
    Friend WithEvents btnResetDesc As Button
    Friend WithEvents txtCorrelativo As TextBox
    Friend WithEvents cboLiquidacion As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtMontoIncidente As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cboStatusIncidente As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Dtp_FechaIncidente As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents txtIncidente As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cboNumero As ComboBox
    Friend WithEvents Dtp_Compra As DateTimePicker
End Class
