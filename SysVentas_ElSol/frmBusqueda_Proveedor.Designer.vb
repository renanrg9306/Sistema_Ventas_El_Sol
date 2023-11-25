<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusqueda_Proveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusqueda_Proveedor))
        Me.cboEnvio = New System.Windows.Forms.ComboBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.dgvBusqProveedor = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbTelefonos = New System.Windows.Forms.RadioButton()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.rbNombre = New System.Windows.Forms.RadioButton()
        Me.rbRuc = New System.Windows.Forms.RadioButton()
        CType(Me.dgvBusqProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboEnvio
        '
        Me.cboEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvio.FormattingEnabled = True
        Me.cboEnvio.Items.AddRange(New Object() {"Factura de venta", "Factura de compra"})
        Me.cboEnvio.Location = New System.Drawing.Point(567, 366)
        Me.cboEnvio.Name = "cboEnvio"
        Me.cboEnvio.Size = New System.Drawing.Size(207, 21)
        Me.cboEnvio.TabIndex = 15
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.emailmarketing3
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnviar.Location = New System.Drawing.Point(509, 353)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(59, 51)
        Me.btnEnviar.TabIndex = 14
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'dgvBusqProveedor
        '
        Me.dgvBusqProveedor.AllowUserToAddRows = False
        Me.dgvBusqProveedor.AllowUserToDeleteRows = False
        Me.dgvBusqProveedor.AllowUserToResizeColumns = False
        Me.dgvBusqProveedor.AllowUserToResizeRows = False
        Me.dgvBusqProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBusqProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqProveedor.Location = New System.Drawing.Point(12, 119)
        Me.dgvBusqProveedor.MultiSelect = False
        Me.dgvBusqProveedor.Name = "dgvBusqProveedor"
        Me.dgvBusqProveedor.ReadOnly = True
        Me.dgvBusqProveedor.Size = New System.Drawing.Size(762, 226)
        Me.dgvBusqProveedor.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTelefonos)
        Me.GroupBox1.Controls.Add(Me.btnBusqueda)
        Me.GroupBox1.Controls.Add(Me.txtBusqueda)
        Me.GroupBox1.Controls.Add(Me.rbNombre)
        Me.GroupBox1.Controls.Add(Me.rbRuc)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(762, 100)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA POR"
        '
        'rbTelefonos
        '
        Me.rbTelefonos.AutoSize = True
        Me.rbTelefonos.Location = New System.Drawing.Point(136, 34)
        Me.rbTelefonos.Name = "rbTelefonos"
        Me.rbTelefonos.Size = New System.Drawing.Size(197, 17)
        Me.rbTelefonos.TabIndex = 10
        Me.rbTelefonos.Text = "TELEFONOS DE UN PROVEEDOR"
        Me.rbTelefonos.UseVisualStyleBackColor = True
        '
        'btnBusqueda
        '
        Me.btnBusqueda.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.buscar
        Me.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBusqueda.Location = New System.Drawing.Point(506, 39)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(32, 33)
        Me.btnBusqueda.TabIndex = 9
        Me.btnBusqueda.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(537, 46)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(192, 20)
        Me.txtBusqueda.TabIndex = 2
        '
        'rbNombre
        '
        Me.rbNombre.AutoSize = True
        Me.rbNombre.Location = New System.Drawing.Point(28, 67)
        Me.rbNombre.Name = "rbNombre"
        Me.rbNombre.Size = New System.Drawing.Size(72, 17)
        Me.rbNombre.TabIndex = 1
        Me.rbNombre.Text = "NOMBRE"
        Me.rbNombre.UseVisualStyleBackColor = True
        '
        'rbRuc
        '
        Me.rbRuc.AutoSize = True
        Me.rbRuc.Checked = True
        Me.rbRuc.Location = New System.Drawing.Point(28, 34)
        Me.rbRuc.Name = "rbRuc"
        Me.rbRuc.Size = New System.Drawing.Size(48, 17)
        Me.rbRuc.TabIndex = 0
        Me.rbRuc.TabStop = True
        Me.rbRuc.Text = "RUC"
        Me.rbRuc.UseVisualStyleBackColor = True
        '
        'frmBusqueda_Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 409)
        Me.Controls.Add(Me.cboEnvio)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.dgvBusqProveedor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBusqueda_Proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSQUEDA DE PROVEEDORES"
        CType(Me.dgvBusqProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents dgvBusqProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents rbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rbRuc As System.Windows.Forms.RadioButton
    Friend WithEvents rbTelefonos As System.Windows.Forms.RadioButton
End Class
