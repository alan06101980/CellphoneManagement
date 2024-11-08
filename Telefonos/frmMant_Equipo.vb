Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Transactions
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices

Public Class frmMant_Equipo

    Inherits Form

    Dim DGV As DataGridView

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


    Private Sub frmMant_Equipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Region = New Region(New RectangleF(Me.TabPage1.Left, Me.TabPage1.Top, Me.TabPage1.Width, Me.TabPage1.Height))

        Cargar_Numeros()
        Formato_Datepickers()
        Cargar_Usuario()
        Cargar_Empresa()
        Cargar_Marca()
        Cargar_CeCo()
        Cargar_Area()
        Cargar_Planes()
        Cargar_Dispositivo()
        Cargar_Categorias()
        Cargar_Proveedor()

        'DESHABILITA EL BOTÓN ACTUALIZAR
        btnActualizarNumero.Enabled = False
        DTP_Cierre.Enabled = False

        '****************************************************************
        'PARA UNA DEMO DE MÁXIMO 5 REGISTROS
        'Dim da As New SqlCeDataAdapter("SELECT * FROM TELEFONO", cn)
        'da.SelectCommand.CommandType = CommandType.Text
        'Dim dt As New DataTable
        'da.Fill(dt)

        'If dt.Rows.Count >= 5 Then
        '    btnNuevoNumero.Enabled = False
        'Else
        '    btnNuevoNumero.Enabled = True
        'End If
        '****************************************************************
        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        'cboEstatus.DrawMode = DrawMode.OwnerDrawFixed
        'cboEstatus.Font = New Font("Arial", 8)
        'cboEstatus.DropDownStyle = ComboBoxStyle.DropDownList
        'cboEstatus.Items.Add("EN USO/ACTIVO")
        'cboEstatus.Items.Add("EQUIPO LIBRE")
        'cboEstatus.Items.Add("DE BAJA")

    End Sub

    'CUANDO CLEARSELECTION NO FUNCIONA, UTILIZAR LO SIGUIENTE:
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        'Dim DGV As DataGridView
        DGV = CType(sender, DataGridView)
        DGV.ClearSelection()
        ObtenerNumeracion()

    End Sub

    'Private Sub frmMant_Equipo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    '    If e.KeyCode = Keys.Enter Then
    '        btnVerificar.PerformClick()
    '        DGV.ClearSelection()
    '    End If

    'End Sub

    Public Sub Limpiar()

        'TABPAGE1
        Dim obj As Control
        For Each obj In Me.TabPage1.Controls
            If TypeOf obj Is TextBox Then
                CType(obj, TextBox).Clear()
            End If

        Next

        Dim obj1 As Control
        For Each obj1 In Me.TabPage1.Controls
            If TypeOf obj1 Is ComboBox Then
                CType(obj1, ComboBox).SelectedIndex = -1
                CType(obj1, ComboBox).Text = ""
            End If
        Next

        Dim obj2 As Control
        For Each obj2 In Me.TabPage1.Controls
            If TypeOf obj2 Is DateTimePicker Then
                CType(obj2, DateTimePicker).CustomFormat = " "
            End If
        Next

        'TABPAGE2
        Dim obj3 As Control
        For Each obj3 In Me.TabPage2.Controls
            If TypeOf obj3 Is TextBox Then
                CType(obj3, TextBox).Clear()
            End If

        Next

        Dim obj4 As Control
        For Each obj4 In Me.TabPage2.Controls
            If TypeOf obj4 Is ComboBox Then
                CType(obj4, ComboBox).SelectedIndex = -1
                CType(obj4, ComboBox).Text = ""
            End If
        Next

        Dim obj5 As Control
        For Each obj5 In Me.TabPage2.Controls
            If TypeOf obj5 Is DateTimePicker Then
                CType(obj5, DateTimePicker).CustomFormat = " "
            End If
        Next

        cboUsuario.Text = ""
        cboNumero.SelectedIndex = -1
        cboEstatus.SelectedIndex = -1

        Dtp_FechaIncidente.Value = Date.Today
        DTP_Cierre.Format = DateTimePickerFormat.Custom
        DTP_Cierre.CustomFormat = " "
        txtCorrelativo.Clear()
        cboStatusIncidente.SelectedIndex = -1
        txtMontoIncidente.Clear()
        cboLiquidacion.SelectedIndex = -1
        txtIncidente.Clear()
        ObtenerNumeracion()
        cboCategoria.SelectedIndex = -1
        txtIdHistorial.Clear()
        ObtenerIdHistorial()
        btnActualizarNumero.Enabled = False
        Datagridview1_Refrescar()
        TabControl1.SelectedTab = TabPage1

    End Sub


    Private Sub Formato_Datepickers()

        Dtp_Compra.Format = DateTimePickerFormat.Custom
        Dtp_Compra.CustomFormat = " "

        DTP_Asignacion.Format = DateTimePickerFormat.Custom
        DTP_Asignacion.CustomFormat = " "

        DTP_Asignacion.Format = DateTimePickerFormat.Custom
        DTP_Asignacion.CustomFormat = " "

        DTP_Cierre.Format = DateTimePickerFormat.Custom
        DTP_Cierre.CustomFormat = " "

    End Sub

    Public Sub Cargar_Numeros()

        Try
            Dim cargar_numeros As New SqlCeDataAdapter("SELECT IDTELEFONO FROM TELEFONO ORDER BY IDTELEFONO ASC", cn)
            cargar_numeros.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            cargar_numeros.Fill(dt)

            cboNumero.DataSource = dt
            cboNumero.DisplayMember = "IDTELEFONO"
            cboNumero.ValueMember = "IDTELEFONO"
            cboNumero.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los números telefónicos.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub


    Public Sub Cargar_Proveedor()

        Try
            Dim cargar_proveedor As New SqlCeDataAdapter("SELECT IDPROVEEDOR, PROVEEDOR FROM PROVEEDOR ORDER BY IDPROVEEDOR ASC", cn)
            cargar_proveedor.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            cargar_proveedor.Fill(dt)

            cboProveedor.DataSource = dt
            cboProveedor.DisplayMember = "PROVEEDOR"
            cboProveedor.ValueMember = "IDPROVEEDOR"
            cboProveedor.SelectedIndex = -1
        Catch
            MsgBox("Error al cargar los proveedores.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Empresa()

        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM EMPRESA ORDER BY EMPRESA ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            da.Fill(dt)

            cboEmpresa.DataSource = dt
            cboEmpresa.DisplayMember = "EMPRESA"
            cboEmpresa.ValueMember = "IDEMPRESA"
            cboEmpresa.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar la lista de empresas.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_CeCo()

        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM CENTROCOSTO ORDER BY CECO ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            da.Fill(dt)

            cboCeCo.DataSource = dt
            cboCeCo.DisplayMember = "CECO"
            cboCeCo.ValueMember = "IDCECO"
            cboCeCo.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los Centros de Costo.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Usuario()
        Try
            Dim mostrar_cargotrabajador As New SqlCeDataAdapter("SELECT * FROM USUARIO WHERE STATUSUSUARIO='ACTIVO' ORDER BY NOMBREUSUARIO ASC", cn)
            mostrar_cargotrabajador.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            mostrar_cargotrabajador.Fill(dt)

            cboUsuario.DataSource = dt
            cboUsuario.DisplayMember = "NOMBREUSUARIO"
            cboUsuario.ValueMember = "IDUSUARIO"
            cboUsuario.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los usuarios.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Area()
        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM AREA ORDER BY AREA ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            da.Fill(dt)

            cboArea.DataSource = dt
            cboArea.DisplayMember = "AREA"
            cboArea.ValueMember = "IDAREA"
            cboArea.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar las áreas.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Marca()
        Try
            Dim da As New SqlCeDataAdapter("SELECT IDMARCA, MARCA FROM MARCA ORDER BY MARCA ASC", cn)
            Dim dtb As New DataTable
            da.Fill(dtb)

            cboMarca.DataSource = dtb
            cboMarca.DisplayMember = "MARCA"
            cboMarca.ValueMember = "IDMARCA"
            cboMarca.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar las marcas.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Modelo()
        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM MARCA INNER JOIN MODELO ON MARCA.IDMARCA=MODELO.IDMARCA WHERE MARCA ='" & cboMarca.Text & "' ORDER BY MODELO ASC", cn)
            Dim dtb As New DataTable
            da.Fill(dtb)

            cboModelo.DisplayMember = "MODELO"
            cboModelo.ValueMember = "IDMODELO"
            cboModelo.DataSource = dtb
            cboModelo.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los modelos.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Public Sub Cargar_Planes()
        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM PLANES ORDER BY IDPLAN ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dtb As New DataTable
            da.Fill(dtb)

            cboPlan.DataSource = dtb
            cboPlan.DisplayMember = "PLAN_LINEA"
            cboPlan.ValueMember = "IDPLAN"
            cboPlan.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los planes.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Categorias()

        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM CATEGORIAS ORDER BY CATEGORIA ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            da.Fill(dt)

            cboCategoria.DataSource = dt
            cboCategoria.DisplayMember = "CATEGORIA"
            cboCategoria.ValueMember = "IDCATEGORIA"
            cboCategoria.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar las categorías.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Public Sub Cargar_Dispositivo()

        Try
            Dim da As New SqlCeDataAdapter("SELECT * FROM DISPOSITIVO ORDER BY DISPOSITIVO ASC", cn)
            da.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            da.Fill(dt)

            cboDispositivo.DataSource = dt
            cboDispositivo.DisplayMember = "DISPOSITIVO"
            cboDispositivo.ValueMember = "IDDISPOSITIVO"
            cboDispositivo.SelectedIndex = -1

        Catch
            MsgBox("Error al cargar los estatus del equipo.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub txtNumero_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboNumero.KeyPress

        eventArgs.Handled = Fg_SoloNumeros_SinPunto(eventArgs.KeyChar, cboNumero.Text & CChar(eventArgs.KeyChar))

    End Sub

    Private Sub txtMontoIncidenteKeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoIncidente.KeyPress

        eventArgs.Handled = Fg_SoloNumeros(eventArgs.KeyChar, txtMontoIncidente.Text & CChar(eventArgs.KeyChar))

    End Sub

    Private Sub txtPrecioEquipoKeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioEquipo.KeyPress

        eventArgs.Handled = Fg_SoloNumeros(eventArgs.KeyChar, txtPrecioEquipo.Text & CChar(eventArgs.KeyChar))

    End Sub

    Function Fg_SoloNumeros(ByVal Digito As String, ByVal Texto As String) As Boolean

        Dim Dt_Entero As Integer = CInt(Asc(Digito))
        If Dt_Entero = 8 Then
            Fg_SoloNumeros = False
        Else
            If InStr("1234567890.", Digito) = 0 Then
                Fg_SoloNumeros = True
            ElseIf IsNumeric(Texto) = True Then
                Fg_SoloNumeros = False
            ElseIf IsNumeric(Texto) = False Then
                Fg_SoloNumeros = True
            End If
        End If
        Return Fg_SoloNumeros

    End Function

    Function Fg_SoloNumeros_SinPunto(ByVal Digito As String, ByVal Texto As String) As Boolean

        Dim Dt_Entero As Integer = CInt(Asc(Digito))
        If Dt_Entero = 8 Then
            Fg_SoloNumeros_SinPunto = False
        Else
            If InStr("1234567890", Digito) = 0 Then
                Fg_SoloNumeros_SinPunto = True
            ElseIf IsNumeric(Texto) = True Then
                Fg_SoloNumeros_SinPunto = False
            ElseIf IsNumeric(Texto) = False Then
                Fg_SoloNumeros_SinPunto = True
            End If
        End If
        Return Fg_SoloNumeros_SinPunto

    End Function


    Private Sub cboUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUsuario.KeyPress

        e.KeyChar = e.KeyChar.ToString.ToUpper

    End Sub

    Private Sub ObtenerUltimoRegistro()

        Try
            Dim da_ultimoregistro As New SqlCeDataAdapter("SELECT COALESCE(MAX(CONTADOR),'0') FROM HISTORIAL WHERE IDTELEFONO=@IDTELEFONO", cn)
            da_ultimoregistro.SelectCommand.CommandType = CommandType.Text
            da_ultimoregistro.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
            Dim dt_ultimoregistro As New DataTable
            da_ultimoregistro.Fill(dt_ultimoregistro)

            txtCorrelativo.Text = Format((CInt(dt_ultimoregistro.Rows(0).Item(0)) + 1), "0")

        Catch

        End Try

    End Sub

    'OBTENER IDHISTORIAL
    Private Sub ObtenerIdHistorial()

        Try
            Dim da_idhistorial As New SqlCeDataAdapter("SELECT COALESCE(MAX(IDHISTORIAL),'0') FROM HISTORIAL", cn)
            da_idhistorial.SelectCommand.CommandType = CommandType.Text
            Dim dt_idhistorial As New DataTable
            da_idhistorial.Fill(dt_idhistorial)
            txtIdHistorial.Text = Format((CInt(dt_idhistorial.Rows(0).Item(0)) + 1), "0")
        Catch

        End Try

    End Sub


    Private Sub ObtenerNumeracion()

        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = CStr(i + 1)
        Next

    End Sub


    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Me.ActiveControl = Nothing
        'cboEstatus.SelectedIndex = -1

        If cboNumero.Text.Length <= 8 Then
            MsgBox("Digite el número correctamente.")
            Exit Sub
        End If

        Try

            Dim da As New SqlCeDataAdapter("SELECT IDTELEFONO, PROVEEDOR, EMPRESA, CeCo, Area, FECHACOMPRA, NombreUsuario, FECHAASIGNACION, Marca, Modelo, PRECIO, Plan_Linea, IMEI1, IMEI2, STATUS_CAT, Dispositivo, OBSERVACIONES FROM TELEFONO LEFT JOIN PROVEEDOR ON TELEFONO.idProveedor=Proveedor.idProveedor LEFT JOIN EMPRESA ON TELEFONO.idEmpresa=EMPRESA.idEmpresa LEFT JOIN CENTROCOSTO ON CentroCosto.IDCECO=TELEFONO.IDCECO LEFT join area on area.idArea=telefono.idarea LEFT join usuario on usuario.idUsuario=telefono.idUsuario LEFT join marca on marca.idMarca=telefono.idMarca LEFT join modelo on modelo.idModelo=telefono.idModelo LEFT join planes on planes.idPlan=telefono.idPlan LEFT join dispositivo on Dispositivo.idDispositivo=Telefono.idDispositivo WHERE IDTELEFONO=@IDTELEFONO", cn)
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
            Dim ds As New DataSet
            da.Fill(ds)

            If ds.Tables.Count > 0 Then

                cboProveedor.Text = ds.Tables(0).Rows(0)("PROVEEDOR").ToString
                cboEmpresa.Text = ds.Tables(0).Rows(0)("EMPRESA").ToString
                cboCeCo.Text = ds.Tables(0).Rows(0)("CECO").ToString
                cboArea.Text = ds.Tables(0).Rows(0)("AREA").ToString

                If ds.Tables(0).Rows(0)("FECHACOMPRA").ToString = "NULL" Then
                    Dtp_Compra.Format = DateTimePickerFormat.Custom
                    Dtp_Compra.CustomFormat = " "
                Else
                    Dtp_Compra.Format = DateTimePickerFormat.Custom
                    Dtp_Compra.CustomFormat = ("dd/MM/yyyy")
                    Dtp_Compra.Text = ds.Tables(0).Rows(0)("FECHACOMPRA").ToString
                End If

                cboUsuario.Text = ds.Tables(0).Rows(0)("NOMBREUSUARIO").ToString

                If ds.Tables(0).Rows(0)("FECHAASIGNACION").ToString = "NULL" Then
                    DTP_Asignacion.Format = DateTimePickerFormat.Custom
                    DTP_Asignacion.CustomFormat = " "
                Else
                    DTP_Asignacion.Format = DateTimePickerFormat.Custom
                    DTP_Asignacion.CustomFormat = ("dd/MM/yyyy")
                    DTP_Asignacion.Text = ds.Tables(0).Rows(0)("FECHAASIGNACION").ToString
                End If

                cboMarca.Text = ds.Tables(0).Rows(0)("MARCA").ToString
                cboModelo.Text = ds.Tables(0).Rows(0)("MODELO").ToString
                txtPrecioEquipo.Text = ds.Tables(0).Rows(0)("PRECIO").ToString
                cboPlan.Text = ds.Tables(0).Rows(0)("PLAN_LINEA").ToString
                txtImei1.Text = ds.Tables(0).Rows(0)("IMEI1").ToString
                txtImei2.Text = ds.Tables(0).Rows(0)("IMEI2").ToString
                cboEstatus.Text = ds.Tables(0).Rows(0)("STATUS_CAT").ToString
                cboDispositivo.Text = ds.Tables(0).Rows(0)("DISPOSITIVO").ToString
                txtObservacion.Text = ds.Tables(0).Rows(0)("OBSERVACIONES").ToString

            End If

            'ACTIVA EL BOTÓN ACTUALIZAR
            btnActualizarNumero.Enabled = True

            'MUESTRA EL HISTORIAL
            Datagridview1_Refrescar()
            txtCorrelativo.Clear()
            ObtenerUltimoRegistro()
            ObtenerNumeracion()
            'txtEstatus_TextChanged(sender, e)
            DataGridView1.ClearSelection()

        Catch 'ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("Número no registrado o mal digitado.", MsgBoxStyle.Information, "Error")
        End Try

    End Sub


    Private Sub Dtp_Compra_DropDown(sender As Object, e As EventArgs) Handles Dtp_Compra.DropDown

        Dtp_Compra.Format = DateTimePickerFormat.Custom
        Dtp_Compra.CustomFormat = ("dd/MM/yyyy")
        Dtp_Compra.Value = Date.Today

    End Sub


    Private Sub DTP_Asignacion_DropDown(sender As Object, e As EventArgs) Handles DTP_Asignacion.DropDown

        DTP_Asignacion.Format = DateTimePickerFormat.Custom
        DTP_Asignacion.CustomFormat = ("dd/MM/yyyy")
        DTP_Asignacion.Value = Date.Today

    End Sub

    Private Sub DTP_Cierre_DropDown(sender As Object, e As EventArgs) Handles DTP_Cierre.DropDown

        DTP_Cierre.Format = DateTimePickerFormat.Custom
        DTP_Cierre.CustomFormat = ("dd/MM/yyyy")
        DTP_Cierre.Value = Date.Today

    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Me.ActiveControl = Nothing
        Limpiar()

    End Sub

    Private Sub Datagridview1_Refrescar()

        Try
            Dim refrescar_datagrid As New SqlCeDataAdapter("SELECT CONTADOR AS NRO, IDTELEFONO AS NÚMERO, NOMBREUSUARIO AS USUARIO, FECHA_HISTORIAL AS FECHA, ESTATUS_HISTORIAL AS ESTATUS, FECHA_CIERRE AS FECHA_CIERRE, CATEGORIA AS CATEGORIA, MONTO_HISTORIAL AS MONTO, DESC_HISTORIAL AS LIQUIDADO, INCIDENTE_HISTORIAL AS INCIDENTE, IDHISTORIAL FROM HISTORIAL INNER JOIN CATEGORIAS ON HISTORIAL.IDCATEGORIA=CATEGORIAS.IDCATEGORIA WHERE IDTELEFONO=@IDTELEFONO ORDER BY CONTADOR ASC", cn)
            refrescar_datagrid.SelectCommand.CommandType = CommandType.Text
            refrescar_datagrid.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
            Dim dt_refrescar As New DataTable
            refrescar_datagrid.Fill(dt_refrescar)

            DataGridView1.DataSource = dt_refrescar

            '////////////////////////////FORMATEAR EL DATAGRIDVIEW
            'MUESTRA LA PRIMERA COLUMNA
            'DataGridView1.RowHeadersVisible = True

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(10).Visible = False

            'ACELERA EL RENDIMIENTO DEL DATAGRIDVIEW
            DataGridView1.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

            'OBTENER NUMERACIÓN EN LAS COLUMNAS
            ObtenerNumeracion()

            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridView1.ClearSelection()

        Catch 'ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("Error al actualizar la lista", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub cboMarca_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMarca.SelectedValueChanged

        Cargar_Modelo()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then

            Dtp_FechaIncidente.Text = DataGridView1.Item(3, e.RowIndex).Value.ToString
            cboStatusIncidente.Text = DataGridView1.Item(4, e.RowIndex).Value.ToString
            If cboStatusIncidente.Text = "ABIERTO" Or cboStatusIncidente.Text = "EN ESPERA" Then
                DTP_Cierre.Enabled = False
            Else
                DTP_Cierre.Enabled = True
                DTP_Cierre_DropDown(sender, e)
                DTP_Cierre.Text = DataGridView1.Item(5, e.RowIndex).Value.ToString
            End If
            cboCategoria.Text = DataGridView1.Item(6, e.RowIndex).Value.ToString
            txtMontoIncidente.Text = DataGridView1.Item(7, e.RowIndex).Value.ToString
            cboLiquidacion.Text = DataGridView1.Item(8, e.RowIndex).Value.ToString
            txtIncidente.Text = DataGridView1.Item(9, e.RowIndex).Value.ToString

        End If

    End Sub

    Private Sub cboNumero_TextChanged(sender As Object, e As EventArgs) Handles cboNumero.TextChanged

        If cboNumero.Text = "" Then
            Limpiar()
            cboEstatus.BackColor = Nothing

            'LIMPIA EL TAB2
            DataGridView1.DataSource = Nothing
            Dtp_FechaIncidente.Value = Date.Today
            cboStatusIncidente.SelectedIndex = -1
            txtMontoIncidente.Clear()
            cboLiquidacion.SelectedIndex = -1
            txtIncidente.Clear()
            cboNumero.Focus()

        End If

    End Sub

    Private Sub btnNuevoNumero_Click(sender As Object, e As EventArgs) Handles btnNuevoNumero.Click

        Me.ActiveControl = Nothing

        If cboNumero.Text.Length = 0 Or cboNumero.Text.Length > 9 Then
            MsgBox("Debe digitar un número telefónico correcto.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboUsuario.SelectedIndex = -1 Then
            MsgBox("El usuario no puede quedar en blanco. Si no sabe qué usuario lo utilizará, cree un usuario llamado SIN ASIGNAR y asígnele el número.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboProveedor.SelectedIndex = -1 Then
            MsgBox("El proveedor no puede quedar en blanco.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboDispositivo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un tipo de dispositivo.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboMarca.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una marca.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboModelo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un modelo.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'CONSULTAMOS SI NO EXISTE UN NÚMERO REPETIDO
        Dim da As New SqlCeDataAdapter("SELECT IDTELEFONO FROM TELEFONO WHERE IDTELEFONO=@IDTELEFONO", cn)
        da.SelectCommand.CommandType = CommandType.Text
        da.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            MsgBox("El número ya está registrado.", MsgBoxStyle.Information, "Verificar")
            Exit Sub
        End If

        'SI NO SE REPITE, CREAMOS EL NÚMERO
        Dim transactionOptions = New TransactionOptions()
        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        transactionOptions.Timeout = TransactionManager.MaximumTimeout

        Try

            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                If (cn.State = ConnectionState.Closed) Then cn.Open()

                Dim crear_telefono As New SqlCeCommand("INSERT INTO TELEFONO VALUES(@IDTELEFONO, @IDPROVEEDOR, @IDEMPRESA, @IDCECO, @IDAREA, @FECHACOMPRA, @IDUSUARIO, @FECHAASIGNACION, @IDMARCA, @IDMODELO, @PRECIO, @IDPLAN, @IMEI1, @IMEI2, @STATUS_CAT, @IDDISPOSITIVO, @OBSERVACIONES)", cn)
                crear_telefono.CommandType = CommandType.Text
                crear_telefono.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
                crear_telefono.Parameters.AddWithValue("@IDPROVEEDOR", cboProveedor.SelectedValue)

                If cboEmpresa.SelectedIndex = -1 Then
                    crear_telefono.Parameters.AddWithValue("@IDEMPRESA", DBNull.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@IDEMPRESA", cboEmpresa.SelectedValue)
                End If

                If cboCeCo.SelectedIndex = -1 Then
                    crear_telefono.Parameters.AddWithValue("@IDCECO", DBNull.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@IDCECO", cboCeCo.SelectedValue)
                End If

                If cboArea.SelectedIndex = -1 Then
                    crear_telefono.Parameters.AddWithValue("@IDAREA", DBNull.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@IDAREA", cboArea.SelectedValue)
                End If

                If Dtp_Compra.Text = " " Then
                    Dtp_Compra_DropDown(sender, e)
                    'crear_telefono.Parameters.AddWithValue("@FECHACOMPRA", Convert.ToString(Dtp_Compra.Value.ToShortDateString()))
                    crear_telefono.Parameters.AddWithValue("@FECHACOMPRA", Dtp_Compra.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@FECHACOMPRA", Dtp_Compra.Value)
                End If

                crear_telefono.Parameters.AddWithValue("@IDUSUARIO", cboUsuario.SelectedValue)

                If DTP_Asignacion.Text = " " Then
                    DTP_Asignacion_DropDown(sender, e)
                    crear_telefono.Parameters.AddWithValue("@FECHAASIGNACION", DTP_Asignacion.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@FECHAASIGNACION", DTP_Asignacion.Value)
                End If


                crear_telefono.Parameters.AddWithValue("@IDMARCA", cboMarca.SelectedValue)
                crear_telefono.Parameters.AddWithValue("@IDMODELO", cboModelo.SelectedValue)

                If txtPrecioEquipo.Text = "" Then
                    crear_telefono.Parameters.AddWithValue("@PRECIO", "0.00")
                Else
                    crear_telefono.Parameters.AddWithValue("@PRECIO", txtPrecioEquipo.Text)
                End If

                crear_telefono.Parameters.AddWithValue("@IDPLAN", cboPlan.SelectedValue)
                crear_telefono.Parameters.AddWithValue("@IMEI1", txtImei1.Text)
                crear_telefono.Parameters.AddWithValue("@IMEI2", txtImei2.Text)
                crear_telefono.Parameters.AddWithValue("@STATUS_CAT", cboEstatus.Text)
                crear_telefono.Parameters.AddWithValue("@IDDISPOSITIVO", cboDispositivo.SelectedValue)

                If txtObservacion.Text = "" Then
                    crear_telefono.Parameters.AddWithValue("@OBSERVACIONES", DBNull.Value)
                Else
                    crear_telefono.Parameters.AddWithValue("@OBSERVACIONES", txtObservacion.Text)
                End If

                crear_telefono.ExecuteNonQuery()
                tran1.Complete()
                cn.Close()
                tran1.Dispose()
            End Using

            MsgBox("Teléfono registrado correctamente.", MsgBoxStyle.Information, "Correcto")
            Limpiar()
            Cargar_Numeros()

            'LIMPIA EL 2DO TAB
            DataGridView1.DataSource = Nothing
            Dtp_FechaIncidente.Value = Date.Today
            txtCorrelativo.Clear()
            cboStatusIncidente.SelectedIndex = -1
            txtMontoIncidente.Clear()
            cboLiquidacion.SelectedIndex = -1
            txtIncidente.Clear()
            DTP_Cierre.Enabled = False
            dtpCierre_Reset_Click(sender, e)
            cboCategoria.SelectedIndex = -1


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not (cn Is Nothing) Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub btnActualizarNumero_Click(sender As Object, e As EventArgs) Handles btnActualizarNumero.Click

        Me.ActiveControl = Nothing

        'VALIDA QUE EL COMBOBOX ESTATUS NO ESTÉ EN BLANCO
        If cboEstatus.SelectedIndex = -1 Then
            MsgBox("Verificar el estatus del item.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'VALIDA QUE EXISTA EL USUARIO
        Dim existe_usuario As New SqlCeDataAdapter("SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO = '" & cboUsuario.Text & "'", cn)
        existe_usuario.SelectCommand.CommandType = CommandType.Text
        Dim dt_existeusuario As New DataTable
        existe_usuario.Fill(dt_existeusuario)

        If dt_existeusuario.Rows.Count > 0 Then

            'VALIDA QUE EXISTA EL NÚMERO TELEFÓNICO
            Dim existe As New SqlCeDataAdapter("SELECT IDTELEFONO FROM TELEFONO WHERE IDTELEFONO=@IDTELEFONO", cn)
            existe.SelectCommand.CommandType = CommandType.Text
            existe.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
            Dim dt_existe As New DataTable
            existe.Fill(dt_existe)

            If dt_existe.Rows.Count > 0 Then

                Try
                    Dim transactionOptions = New TransactionOptions()
                    transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                    transactionOptions.Timeout = TransactionManager.MaximumTimeout

                    Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                        If (cn.State = ConnectionState.Closed) Then cn.Open()

                        Dim actualizar As New SqlCeCommand("UPDATE TELEFONO SET IDTELEFONO=@IDTELEFONO, IDPROVEEDOR=@IDPROVEEDOR, IDEMPRESA=@IDEMPRESA, IDCECO=@IDCECO, IDAREA=@IDAREA, FECHACOMPRA=@FECHACOMPRA, IDUSUARIO=@IDUSUARIO, FECHAASIGNACION=@FECHAASIGNACION, IDMARCA=@IDMARCA, IDMODELO=@IDMODELO, PRECIO=@PRECIO, IDPLAN=@IDPLAN, IMEI1=@IMEI1, IMEI2=@IMEI2, STATUS_CAT=@STATUS_CAT, IDDISPOSITIVO=@IDDISPOSITIVO, OBSERVACIONES=@OBSERVACIONES WHERE IDTELEFONO='" & cboNumero.Text & "'", cn)
                        actualizar.CommandType = CommandType.Text

                        actualizar.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)

                        If cboProveedor.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDPROVEEDOR", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDPROVEEDOR", cboProveedor.SelectedValue)
                        End If

                        If cboEmpresa.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDEMPRESA", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDEMPRESA", cboEmpresa.SelectedValue)
                        End If

                        If cboCeCo.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDCECO", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDCECO", cboCeCo.SelectedValue)
                        End If

                        If cboArea.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDAREA", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDAREA", cboArea.SelectedValue)
                        End If

                        If Dtp_Compra.Text = " " Then
                            actualizar.Parameters.AddWithValue("@FECHACOMPRA", DBNull.Value)
                        Else
                            'actualizar.Parameters.AddWithValue("@FECHACOMPRA", Convert.ToString(Dtp_Compra.Value.ToShortDateString()))
                            actualizar.Parameters.AddWithValue("@FECHACOMPRA", Dtp_Compra.Value)
                        End If

                        If cboUsuario.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDUSUARIO", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDUSUARIO", cboUsuario.SelectedValue)
                        End If

                        If DTP_Asignacion.Text = " " Then
                            actualizar.Parameters.AddWithValue("@FECHAASIGNACION", DBNull.Value)
                        Else
                            'actualizar.Parameters.AddWithValue("@FECHAASIGNACION", Convert.ToString(DTP_Asignacion.Value.ToShortDateString()))
                            actualizar.Parameters.AddWithValue("@FECHAASIGNACION", DTP_Asignacion.Value)
                        End If

                        If cboMarca.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDMARCA", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDMARCA", cboMarca.SelectedValue)
                        End If

                        If cboModelo.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDMODELO", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDMODELO", cboModelo.SelectedValue)
                        End If

                        If txtPrecioEquipo.Text = "" Then
                            actualizar.Parameters.AddWithValue("@PRECIO", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@PRECIO", txtPrecioEquipo.Text)
                        End If

                        If cboPlan.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDPLAN", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDPLAN", cboPlan.SelectedValue)
                        End If

                        If txtImei1.Text = "" Then
                            actualizar.Parameters.AddWithValue("@IMEI1", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IMEI1", txtImei1.Text)
                        End If

                        If txtImei2.Text = "" Then
                            actualizar.Parameters.AddWithValue("@IMEI2", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IMEI2", txtImei2.Text)
                        End If

                        actualizar.Parameters.AddWithValue("@STATUS_CAT", cboEstatus.Text)

                        If cboDispositivo.SelectedIndex = -1 Then
                            actualizar.Parameters.AddWithValue("@IDDISPOSITIVO", DBNull.Value)
                        Else
                            actualizar.Parameters.AddWithValue("@IDDISPOSITIVO", cboDispositivo.SelectedValue)
                        End If

                        actualizar.Parameters.AddWithValue("@OBSERVACIONES", txtObservacion.Text)

                        actualizar.ExecuteNonQuery()
                        tran1.Complete()
                        cn.Close()
                        tran1.Dispose()

                    End Using

                    MsgBox("Datos actualizados correctamente.", MsgBoxStyle.Information, "Aviso")
                    btnVerificar_Click(sender, e)
                    'txtEstatus_TextChanged(sender, e)

                    'Limpiar()
                    'Cargar_Numeros()
                    'btnActualizarNumero.Enabled = False

                    ''LIMPIA EL 2DO TAB
                    'DataGridView1.DataSource = Nothing
                    'Dtp_FechaIncidente.Value = Date.Today
                    'txtCorrelativo.Clear()
                    'cboStatusIncidente.SelectedIndex = -1
                    'txtMontoIncidente.Clear()
                    'cboLiquidacion.SelectedIndex = -1
                    'txtIncidente.Clear()
                    'cboCategoria.SelectedIndex = -1
                    'DTP_Cierre.Enabled = False
                    'dtpCierre_Reset_Click(sender, e)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    If Not (cn Is Nothing) Then
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                    End If
                End Try

            Else
                MsgBox("Error, no se puede actualizar el número seleccionado.", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If

        Else
            MsgBox("El usuario seleccionado no existe.", MsgBoxStyle.Exclamation, "Error")
            cboUsuario.Focus()
            cboUsuario.SelectAll()
            Exit Sub
        End If

    End Sub

    Private Sub btnAgregaIncidente_Click(sender As Object, e As EventArgs) Handles btnAgregaIncidente.Click

        Me.ActiveControl = Nothing

        ObtenerIdHistorial()
        ObtenerUltimoRegistro()

        If cboNumero.Text.Length = 0 Then
            MsgBox("Debe seleccionar un número antes de agregar información.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If cboStatusIncidente.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un estatus de incidente.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If txtIncidente.Text.Length < 2 Then
            MsgBox("Debe ingresar un incidente.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If cboCategoria.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una categoría.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If cboStatusIncidente.Text = "CERRADO" And DTP_Cierre.Text = " " Then
            MsgBox("Debe seleccionar una fecha de cierre.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try

            Dim da As New SqlCeDataAdapter("SELECT * FROM TELEFONO WHERE IDTELEFONO=@IDTELEFONO", cn)
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
            Dim ds As New DataSet
            da.Fill(ds)

            If ds.Tables.Count > 0 Then

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim insertar_fila As New SqlCeCommand("INSERT INTO HISTORIAL (IDHISTORIAL, CONTADOR, IDTELEFONO, NOMBREUSUARIO, FECHA_HISTORIAL, ESTATUS_HISTORIAL, MONTO_HISTORIAL, DESC_HISTORIAL, INCIDENTE_HISTORIAL, IDCATEGORIA, FECHA_CIERRE) VALUES (@IDHISTORIAL, @CONTADOR, @IDTELEFONO, @NOMBREUSUARIO, @FECHA_HISTORIAL, @ESTATUS_HISTORIAL, @MONTO_HISTORIAL, @DESC_HISTORIAL, @INCIDENTE_HISTORIAL, @IDCATEGORIA, @FECHA_CIERRE)", cn)
                    insertar_fila.CommandType = CommandType.Text
                    insertar_fila.Parameters.AddWithValue("@IDHISTORIAL", txtIdHistorial.Text)
                    insertar_fila.Parameters.AddWithValue("@CONTADOR", txtCorrelativo.Text)
                    insertar_fila.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
                    insertar_fila.Parameters.AddWithValue("@NOMBREUSUARIO", cboUsuario.Text)
                    insertar_fila.Parameters.AddWithValue("@FECHA_HISTORIAL", Dtp_FechaIncidente.Value.ToShortDateString)

                    If cboStatusIncidente.SelectedIndex = -1 Then
                        insertar_fila.Parameters.AddWithValue("@ESTATUS_HISTORIAL", "ABIERTO")
                    Else
                        insertar_fila.Parameters.AddWithValue("@ESTATUS_HISTORIAL", cboStatusIncidente.Text)
                    End If

                    If txtMontoIncidente.Text = "" Then
                        insertar_fila.Parameters.AddWithValue("@MONTO_HISTORIAL", "0.00")
                    Else
                        insertar_fila.Parameters.AddWithValue("@MONTO_HISTORIAL", txtMontoIncidente.Text)
                    End If

                    If cboLiquidacion.SelectedIndex = -1 Then
                        insertar_fila.Parameters.AddWithValue("@DESC_HISTORIAL", "NO APLICA")
                    Else
                        insertar_fila.Parameters.AddWithValue("@DESC_HISTORIAL", cboLiquidacion.Text)
                    End If

                    insertar_fila.Parameters.AddWithValue("@INCIDENTE_HISTORIAL", txtIncidente.Text)

                    insertar_fila.Parameters.AddWithValue("@IDCATEGORIA", cboCategoria.SelectedValue)

                    If cboStatusIncidente.Text = "ABIERTO" Then
                        insertar_fila.Parameters.AddWithValue("@FECHA_CIERRE", DBNull.Value)
                    Else
                        insertar_fila.Parameters.AddWithValue("@FECHA_CIERRE", DTP_Cierre.Value.ToShortDateString)
                    End If


                    Dim actualizar_status_cat As New SqlCeCommand("UPDATE TELEFONO SET STATUS_CAT=@STATUS_CAT WHERE IDTELEFONO=@IDTELEFONO", cn)
                    actualizar_status_cat.CommandType = CommandType.Text

                    actualizar_status_cat.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)

                    If cboCategoria.Text = "SUSPENSIÓN" Then
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "DE BAJA")
                    ElseIf cboCategoria.Text = "DAR DE BAJA" Then
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "DE BAJA")
                    Else
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "EN USO")
                    End If

                    insertar_fila.ExecuteNonQuery()
                    actualizar_status_cat.ExecuteNonQuery()
                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()

                End Using

                MsgBox("Incidente agregado correctamente", MsgBoxStyle.Information, "Aviso")
                Datagridview1_Refrescar()
                Dtp_FechaIncidente.Value = Date.Today
                txtCorrelativo.Clear()
                cboStatusIncidente.SelectedIndex = -1
                txtMontoIncidente.Clear()
                cboLiquidacion.SelectedIndex = -1
                txtIncidente.Clear()
                txtIdHistorial.Clear()
                ObtenerIdHistorial()
                ObtenerNumeracion()
                DTP_Cierre.Value = Date.Today
                dtpCierre_Reset_Click(sender, e)
                DTP_Cierre.Enabled = False
                btnVerificar_Click(sender, e)
                cboCategoria.SelectedIndex = -1

            Else
                MsgBox("Debe seleccionar un número válido.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not (cn Is Nothing) Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub btnActualizaIncidente_Click(sender As Object, e As EventArgs) Handles btnActualizaIncidente.Click

        Me.ActiveControl = Nothing

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una fila antes de editar.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        If cboStatusIncidente.Text = "CERRADO" And DTP_Cierre.Text = " " Then
            MsgBox("Debe seleccionar una fecha de cierre.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Try

            Dim X As Integer

            For X = 0 To DataGridView1.SelectedRows.Count - 1

                Dim transactionOptions = New TransactionOptions()
                transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                transactionOptions.Timeout = TransactionManager.MaximumTimeout

                Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                    If (cn.State = ConnectionState.Closed) Then cn.Open()

                    Dim actualizar_historial As New SqlCeCommand("UPDATE HISTORIAL SET FECHA_HISTORIAL=@FECHA_HISTORIAL, ESTATUS_HISTORIAL=@ESTATUS_HISTORIAL, MONTO_HISTORIAL=@MONTO_HISTORIAL, DESC_HISTORIAL=@DESC_HISTORIAL, INCIDENTE_HISTORIAL=@INCIDENTE_HISTORIAL, IDCATEGORIA=@IDCATEGORIA, FECHA_CIERRE=@FECHA_CIERRE WHERE IDTELEFONO='" & cboNumero.Text & "' AND IDHISTORIAL= '" & DataGridView1.SelectedRows(X).Cells(10).Value & "'", cn)
                    actualizar_historial.CommandType = CommandType.Text
                    actualizar_historial.Parameters.AddWithValue("@FECHA_HISTORIAL", Dtp_FechaIncidente.Value)

                    If cboStatusIncidente.SelectedIndex = -1 Then
                        actualizar_historial.Parameters.AddWithValue("@ESTATUS_HISTORIAL", "ABIERTO")
                    Else
                        actualizar_historial.Parameters.AddWithValue("@ESTATUS_HISTORIAL", cboStatusIncidente.Text)
                    End If

                    If txtMontoIncidente.Text = "" Then
                        actualizar_historial.Parameters.AddWithValue("@MONTO_HISTORIAL", "0.00")
                    Else
                        actualizar_historial.Parameters.AddWithValue("@MONTO_HISTORIAL", txtMontoIncidente.Text)
                    End If

                    If cboLiquidacion.SelectedIndex = -1 Then
                        actualizar_historial.Parameters.AddWithValue("@DESC_HISTORIAL", "NO APLICA")
                    Else
                        actualizar_historial.Parameters.AddWithValue("@DESC_HISTORIAL", cboLiquidacion.Text)
                    End If

                    actualizar_historial.Parameters.AddWithValue("@INCIDENTE_HISTORIAL", txtIncidente.Text)

                    actualizar_historial.Parameters.AddWithValue("@IDCATEGORIA", cboCategoria.SelectedValue)

                    If cboStatusIncidente.Text = "ABIERTO" Then
                        actualizar_historial.Parameters.AddWithValue("@FECHA_CIERRE", DBNull.Value)
                    Else
                        actualizar_historial.Parameters.AddWithValue("@FECHA_CIERRE", DTP_Cierre.Value)
                    End If


                    Dim actualizar_status_cat As New SqlCeCommand("UPDATE TELEFONO SET STATUS_CAT=@STATUS_CAT WHERE IDTELEFONO='" & cboNumero.Text & "'", cn)

                    If cboCategoria.Text = "SUSPENSIÓN" Then
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "SUSPENDIDO")
                    ElseIf cboCategoria.Text = "DAR DE BAJA" Then
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "DE BAJA")
                    Else
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "EN USO")
                    End If

                    actualizar_historial.ExecuteNonQuery()
                    actualizar_status_cat.ExecuteNonQuery()

                    tran1.Complete()
                    cn.Close()
                    tran1.Dispose()
                End Using

                MsgBox("Se actualizaron los datos del historial seleccionado.", MsgBoxStyle.Information, "Aviso")
                Dtp_FechaIncidente.Value = Date.Today
                DTP_Cierre.Value = Date.Today
                DTP_Cierre.Enabled = False
                dtpCierre_Reset_Click(sender, e)
                cboStatusIncidente.SelectedIndex = -1
                txtMontoIncidente.Clear()
                cboLiquidacion.SelectedIndex = -1
                txtIncidente.Clear()
                Datagridview1_Refrescar()
                txtIdHistorial.Clear()
                ObtenerIdHistorial()
                ObtenerNumeracion()
                cboCategoria.SelectedIndex = -1
                btnVerificar_Click(sender, e)

            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnEliminarIncidente_Click(sender As Object, e As EventArgs) Handles btnEliminarIncidente.Click

        Me.ActiveControl = Nothing

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item antes de presionar el botón 'Remover'", MsgBoxStyle.Exclamation, "Error")
            DataGridView1.ClearSelection()
            Exit Sub
        End If

        Try

            Dim transactionOptions = New TransactionOptions()
            transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
            transactionOptions.Timeout = TransactionManager.MaximumTimeout

            Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                If (cn.State = ConnectionState.Closed) Then cn.Open()

                Dim UltimaFila As Integer
                UltimaFila = DataGridView1.Rows.Count - 1 'Aquí saco el número de filas del DataGridView, y le resto uno porque los índices comienza a contar en cero

                If UltimaFila = 0 Then
                    For X = 0 To DataGridView1.Rows.Count - 1
                        Dim actualizar_status_cat As New SqlCeCommand("UPDATE TELEFONO SET STATUS_CAT=@STATUS_CAT WHERE IDTELEFONO='" & cboNumero.Text & "'", cn)
                        actualizar_status_cat.CommandType = CommandType.Text
                        actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "EN USO")

                        Dim remover_registro As New SqlCeCommand("DELETE FROM HISTORIAL WHERE IDTELEFONO = '" & cboNumero.Text & "' AND IDHISTORIAL ='" & DataGridView1.SelectedRows(X).Cells(10).Value & "'", cn)
                        remover_registro.CommandType = CommandType.Text

                        actualizar_status_cat.ExecuteNonQuery()
                        remover_registro.ExecuteNonQuery()
                    Next
                Else

                    For X = 0 To DataGridView1.SelectedRows.Count - 1

                        Dim remover_registro As New SqlCeCommand("DELETE FROM HISTORIAL WHERE IDTELEFONO = '" & cboNumero.Text & "' AND IDHISTORIAL ='" & DataGridView1.SelectedRows(X).Cells(10).Value & "'", cn)
                        remover_registro.CommandType = CommandType.Text
                        remover_registro.ExecuteNonQuery()

                        'REFRESCO EL DATAGRIDVIEW
                        Datagridview1_Refrescar()
                        'SELECCIONO LA ÚLTIMA FILA DEL DATAGRIDVIEW LUEGO DE ELIMINAR LA SELECCIONADA
                        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True

                        Dim actualizar_status_cat As New SqlCeCommand("UPDATE TELEFONO SET STATUS_CAT=@STATUS_CAT WHERE IDTELEFONO='" & cboNumero.Text & "'", cn)
                        actualizar_status_cat.CommandType = CommandType.Text
                        If DataGridView1.SelectedRows(X).Cells(6).Value = "SUSPENSIÓN" Then
                            actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "DE BAJA")
                        ElseIf DataGridView1.SelectedRows(X).Cells(6).Value = "DAR DE BAJA" Then
                            actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "DE BAJA")
                        Else
                            actualizar_status_cat.Parameters.AddWithValue("@STATUS_CAT", "EN USO")
                        End If
                        actualizar_status_cat.ExecuteNonQuery()
                    Next

                End If

                tran1.Complete()
                cn.Close()
                tran1.Dispose()

            End Using

            MsgBox("Incidente removido correctamente.", MsgBoxStyle.Information, "Removido")
            Dtp_FechaIncidente.Value = Date.Today
            cboStatusIncidente.SelectedIndex = -1
            txtMontoIncidente.Clear()
            cboLiquidacion.SelectedIndex = -1
            txtIncidente.Clear()
            txtCorrelativo.Clear()
            txtIdHistorial.Clear()
            ObtenerIdHistorial()
            Datagridview1_Refrescar()
            cboCategoria.SelectedIndex = -1
            DTP_Cierre.Value = Date.Today
            dtpCierre_Reset_Click(sender, e)
            DTP_Cierre.Enabled = False
            btnVerificar_Click(sender, e)
            ObtenerUltimoRegistro()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub btnEliminarRegistro_Click(sender As Object, e As EventArgs) Handles btnEliminarRegistro.Click

        Me.ActiveControl = Nothing

        If cboNumero.SelectedIndex = -1 Then
            MsgBox("Primero debe seleccionar un número de la lista.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'VALIDA QUE EXISTA EL NÚMERO TELEFÓNICO
        Dim existe As New SqlCeDataAdapter("SELECT IDTELEFONO FROM TELEFONO WHERE IDTELEFONO=@IDTELEFONO", cn)
        existe.SelectCommand.CommandType = CommandType.Text
        existe.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
        Dim dt_existe As New DataTable
        existe.Fill(dt_existe)

        If dt_existe.Rows.Count > 0 Then

            If MsgBox("¿Desea eliminar el número?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then

                'COMPRUEBA SI EL MODELO TIENE MOVIMIENTO ANTES DE ELIMINARLO
                Dim consultar_movimiento As New SqlCeDataAdapter("SELECT IDTELEFONO FROM HISTORIAL WHERE IDTELEFONO = @IDTELEFONO", cn)
                consultar_movimiento.SelectCommand.CommandType = CommandType.Text
                consultar_movimiento.SelectCommand.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)
                Dim dt As New DataTable
                consultar_movimiento.Fill(dt)

                If dt.Rows.Count > 0 Then
                    MsgBox("El número tiene movimiento y no se puede eliminar. Si desea eliminarlo de todas formas, deberá eliminar el historial.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                Else

                    Try

                        Dim transactionOptions = New TransactionOptions()
                        transactionOptions.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
                        transactionOptions.Timeout = TransactionManager.MaximumTimeout

                        Using tran1 As New Transactions.TransactionScope(TransactionScopeOption.Required, transactionOptions)

                            If (cn.State = ConnectionState.Closed) Then cn.Open()

                            Dim cmd As New SqlCeCommand("DELETE FROM TELEFONO WHERE IDTELEFONO=@IDTELEFONO", cn)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@IDTELEFONO", cboNumero.Text)

                            cmd.ExecuteNonQuery()
                            tran1.Complete()
                            cn.Close()
                            tran1.Dispose()

                        End Using

                        MsgBox("Número eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                        'LIMPIA EL 1ER TAB
                        Limpiar()
                        Cargar_Numeros()
                        'txtEstatus.BackColor = Nothing


                        'LIMPIA EL 2DO TAB
                        DataGridView1.DataSource = Nothing
                        Dtp_FechaIncidente.Value = Date.Today
                        txtCorrelativo.Clear()
                        cboStatusIncidente.SelectedIndex = -1
                        txtMontoIncidente.Clear()
                        cboLiquidacion.SelectedIndex = -1
                        txtIncidente.Clear()
                        DTP_Cierre.Enabled = False
                        dtpCierre_Reset_Click(sender, e)
                        cboCategoria.SelectedIndex = -1

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        If Not (cn Is Nothing) Then
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                        End If
                    End Try

                End If

            Else
                Exit Sub
            End If

        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        Me.ActiveControl = Nothing

        Cursor = Cursors.WaitCursor

        MsgBox("Esto tomará unos minutos.", MsgBoxStyle.Information, "Aviso")

        Try

            Dim oExcel As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            oExcel = New Excel.Application
            oBook = oExcel.Workbooks.Add

            'PRIMERA
            If oExcel.Application.Sheets.Count() < 1 Then
                oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(1)
            End If

            oSheet.Name = "NÚMEROS"

            'Dim da As New sqlceDataAdapter("SELECT * FROM TELEFONO", cn)
            Dim da As New SqlCeDataAdapter("SELECT IDTELEFONO, PROVEEDOR, EMPRESA, CECO, AREA, FECHACOMPRA, NOMBREUSUARIO, MARCA, MODELO, PRECIO, PLAN_LINEA, STATUS_CAT, DISPOSITIVO FROM TELEFONO INNER JOIN PROVEEDOR ON TELEFONO.IDPROVEEDOR=PROVEEDOR.IDPROVEEDOR INNER JOIN EMPRESA ON TELEFONO.IDEMPRESA=EMPRESA.IDEMPRESA INNER JOIN CENTROCOSTO ON TELEFONO.IDCECO=CENTROCOSTO.IDCECO INNER JOIN AREA ON TELEFONO.IDAREA=AREA.IDAREA INNER JOIN USUARIO ON TELEFONO.IDUSUARIO=USUARIO.IDUSUARIO INNER JOIN MARCA ON TELEFONO.IDMARCA=MARCA.IDMARCA INNER JOIN MODELO ON TELEFONO.IDMODELO=MODELO.IDMODELO INNER JOIN PLANES ON TELEFONO.IDPLAN=PLANES.IDPLAN INNER JOIN DISPOSITIVO ON TELEFONO.IDDISPOSITIVO=DISPOSITIVO.IDDISPOSITIVO", cn)
            Dim ds As New DataSet
            da.Fill(ds)

            For j = 0 To ds.Tables(0).Columns.Count - 1
                oSheet.Cells(1, j + 1) = ds.Tables(0).Columns(j).ToString()
                oSheet.Cells(1, j + 1).Font.Bold = True
            Next

            For i = 1 To ds.Tables(0).Rows.Count
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    oSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i - 1)(j).ToString()
                    oSheet.Cells(i + 1, j + 1).VerticalAlignment = ContentAlignment.TopLeft
                Next
            Next

            ' SEGUNDA
            If oExcel.Application.Sheets.Count() < 2 Then
                oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(2)
            End If

            oSheet.Name = "OTROS"

            Dim da1 As New SqlCeDataAdapter("SELECT * FROM HISTORIAL", cn)
            Dim ds1 As New DataSet
            da1.Fill(ds1)

            For k = 0 To ds1.Tables(0).Columns.Count - 1
                oSheet.Cells(1, k + 1) = ds1.Tables(0).Columns(k).ToString()
                oSheet.Cells(1, k + 1).Font.Bold = True
            Next

            For k = 1 To ds1.Tables(0).Rows.Count
                For l = 0 To ds1.Tables(0).Columns.Count - 1
                    oSheet.Cells(k + 1, l + 1) = ds1.Tables(0).Rows(k - 1)(l).ToString()
                    oSheet.Cells(k + 1, l + 1).VerticalAlignment = ContentAlignment.TopLeft
                Next
            Next

            oSheet.Move(After:=oBook.Worksheets(oBook.Worksheets.Count))

            oSheet.Columns.AutoFit()
            oExcel.Visible = True

            Cursor = Cursors.Default

        Catch ex As Exception
            'MsgBox("No hay datos para exportar", MsgBoxStyle.Information, "Aviso")
            MsgBox(ex.ToString)
            Cursor = Cursors.Default
            Exit Sub
        End Try


    End Sub

    '************************************************************************************************************
    '************************************************************************************************************
    '************************************************************************************************************
    'METODO PARA ABRIR FORMULARIO DENTRO DEL PANEL 
    Private Sub AbrirFormEnPanel(Of Forms As {Form, New})()
        Dim formulario As Form
        formulario = frmMenu.PanelContenedor.Controls.OfType(Of Forms)().FirstOrDefault()

        If formulario Is Nothing Then
            formulario = New Forms()
            formulario.TopLevel = False
            formulario.Location = New Point(120, 95)
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.Dock = DockStyle.None
            formulario.Show()
            frmMenu.PanelContenedor.Controls.Add(formulario)
            frmMenu.PanelContenedor.Tag = formulario
            formulario.BringToFront()
        Else
            formulario.BringToFront()
        End If
    End Sub


    Private Sub btnBuscarUsuarios_Click(sender As Object, e As EventArgs) Handles btnBuscarUsuarios.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmBuscaUsuario)()
    End Sub

    Private Sub btnMantProveedor_Click(sender As Object, e As EventArgs) Handles btnMantProveedor.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmProveedor)()
    End Sub

    Private Sub btnMantEmpresa_Click(sender As Object, e As EventArgs) Handles btnMantEmpresa.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmEmpresa)()
    End Sub

    Private Sub btnCeCo_Click(sender As Object, e As EventArgs) Handles btnCeCo.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmCeCos)()
    End Sub

    Private Sub btnArea_Click(sender As Object, e As EventArgs) Handles btnArea.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmArea)()
    End Sub

    Private Sub btnMantAsignado_Click(sender As Object, e As EventArgs) Handles btnMantAsignado.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmUsuario)()
    End Sub

    Private Sub btnMantPlan_Click(sender As Object, e As EventArgs) Handles btnMantPlan.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmPlanes)()
    End Sub

    Private Sub btnMantDisp_Click(sender As Object, e As EventArgs) Handles btnMantDisp.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmDispositivo)()
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmCategorias)()
    End Sub

    Private Sub btnMantMarca_Click(sender As Object, e As EventArgs) Handles btnMantMarca.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmMarca)()
    End Sub

    Private Sub btnMantModelo_Click(sender As Object, e As EventArgs) Handles btnMantModelo.Click
        Me.ActiveControl = Nothing
        AbrirFormEnPanel(Of frmModelo)()
    End Sub

    Private Sub btnResetProv_Click(sender As Object, e As EventArgs) Handles btnResetProv.Click
        cboProveedor.SelectedIndex = -1
    End Sub

    Private Sub btnResetEmpresa_Click(sender As Object, e As EventArgs) Handles btnResetEmpresa.Click
        cboEmpresa.SelectedIndex = -1
    End Sub

    Private Sub btnResetCeCo_Click(sender As Object, e As EventArgs) Handles btnResetCeCo.Click
        cboCeCo.SelectedIndex = -1
    End Sub

    Private Sub btnResetArea_Click(sender As Object, e As EventArgs) Handles btnResetArea.Click
        cboArea.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dtp_Compra.Value = Date.Today
    End Sub

    Private Sub btnResetUsuario_Click(sender As Object, e As EventArgs) Handles btnResetUsuario.Click
        cboUsuario.SelectedIndex = -1
        cboUsuario.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DTP_Asignacion.Value = Date.Today
    End Sub

    Private Sub btnResetMarca_Click(sender As Object, e As EventArgs) Handles btnResetMarca.Click
        cboMarca.SelectedIndex = -1
        cboMarca.SelectedIndex = -1
        cboModelo.DataSource = Nothing
    End Sub

    Private Sub btnResetEquipo_Click(sender As Object, e As EventArgs) Handles btnResetEquipo.Click
        cboModelo.SelectedIndex = -1
        cboModelo.SelectedIndex = -1
    End Sub

    Private Sub btnResetPlan_Click(sender As Object, e As EventArgs) Handles btnResetPlan.Click
        cboPlan.SelectedIndex = -1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cboDispositivo.SelectedIndex = -1
    End Sub

    Private Sub cboStatusIncidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusIncidente.SelectedIndexChanged

        If cboStatusIncidente.Text = "CERRADO" Then
            DTP_Cierre.Enabled = True
        ElseIf cboStatusIncidente.Text = "ABIERTO" Or cboStatusIncidente.Text = "EN ESPERA" Then
            DTP_Cierre.Enabled = False
        End If

    End Sub

    Private Sub btnResetStats_Click(sender As Object, e As EventArgs) Handles btnResetStats.Click
        cboStatusIncidente.SelectedIndex = -1
    End Sub

    Private Sub btnResetCat_Click(sender As Object, e As EventArgs) Handles btnResetCat.Click
        cboCategoria.SelectedIndex = -1
    End Sub

    Private Sub btnResetDesc_Click(sender As Object, e As EventArgs) Handles btnResetDesc.Click
        cboLiquidacion.SelectedIndex = -1
    End Sub

    Private Sub dtpCierre_Reset_Click(sender As Object, e As EventArgs) Handles dtpCierre_Reset.Click
        DTP_Cierre.Format = DateTimePickerFormat.Custom
        DTP_Cierre.CustomFormat = " "
    End Sub

    Private Sub cboEstatus_TextChanged(sender As Object, e As EventArgs) Handles cboEstatus.TextChanged

        If cboEstatus.Text = "DE BAJA" Then
            cboEstatus.BackColor = Color.LightSalmon
        ElseIf cboEstatus.Text = "EN USO" Then
            cboEstatus.BackColor = Color.LightGreen
        Else
            cboEstatus.BackColor = DefaultBackColor
        End If

    End Sub

    Private Sub cboEstatus_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboEstatus.DrawItem

        If e.Index < 0 Then
            Return
        End If
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim CB As ComboBox = TryCast(sender, ComboBox)

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            If cboEstatus.Text = "DE BAJA" Then
                e.Graphics.FillRectangle(New SolidBrush(Color.LightSalmon), e.Bounds)
            ElseIf cboEstatus.Text = "EN USO" Then
                e.Graphics.FillRectangle(New SolidBrush(Color.LightGreen), e.Bounds)
            Else
                e.Graphics.FillRectangle(New SolidBrush(CB.BackColor), e.Bounds)
            End If
        Else
            e.Graphics.FillRectangle(New SolidBrush(Control.DefaultBackColor), e.Bounds)
            'e.Graphics.FillRectangle(New SolidBrush(CB.DefaultBackColor), e.Bounds)
        End If

        e.Graphics.DrawString(CB.Items(e.Index).ToString(), e.Font, New SolidBrush(CB.ForeColor), New Point(e.Bounds.X, e.Bounds.Y))
        e.DrawFocusRectangle()

    End Sub

    Private Sub btnMantenimiento_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click
        Me.ActiveControl = Nothing
        Me.tabIndicador1.Visible = True
        Me.TabControl1.SelectedTab = TabPage1
        Me.tabIndicador2.Visible = False

    End Sub

    Private Sub BtnHistorial_Click(sender As Object, e As EventArgs) Handles btnHistorial.Click
        Me.ActiveControl = Nothing
        Me.tabIndicador2.Visible = True
        Me.TabControl1.SelectedTab = TabPage2
        Me.tabIndicador1.Visible = False

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.ActiveControl = Nothing

        If MsgBox("¿Desea cerrar el formulario?", MsgBoxStyle.OkCancel, "Advertencia") = MsgBoxResult.Ok Then

            Dim f As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmCargando").SingleOrDefault()
            If f Is Nothing Then
                Me.Dispose()
            Else
                f.Dispose()
                Me.Dispose()
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub CboNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles cboNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnVerificar.PerformClick()
            DGV.ClearSelection()
        End If
    End Sub
End Class