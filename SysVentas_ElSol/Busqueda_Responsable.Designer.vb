<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busqueda_Responsable
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busqueda_Responsable))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.rbNombre = New System.Windows.Forms.RadioButton()
        Me.rbCodigo = New System.Windows.Forms.RadioButton()
        Me.dgvBusqResponsable = New System.Windows.Forms.DataGridView()
        Me.cmsMensajes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboEnvio = New System.Windows.Forms.ComboBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBusqResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMensajes.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBusqueda)
        Me.GroupBox1.Controls.Add(Me.txtBusqueda)
        Me.GroupBox1.Controls.Add(Me.rbNombre)
        Me.GroupBox1.Controls.Add(Me.rbCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA POR"
        '
        'btnBusqueda
        '
        Me.btnBusqueda.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.buscar
        Me.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBusqueda.Location = New System.Drawing.Point(138, 38)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(32, 33)
        Me.btnBusqueda.TabIndex = 9
        Me.btnBusqueda.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(169, 45)
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
        'rbCodigo
        '
        Me.rbCodigo.AutoSize = True
        Me.rbCodigo.Checked = True
        Me.rbCodigo.Location = New System.Drawing.Point(28, 34)
        Me.rbCodigo.Name = "rbCodigo"
        Me.rbCodigo.Size = New System.Drawing.Size(67, 17)
        Me.rbCodigo.TabIndex = 0
        Me.rbCodigo.TabStop = True
        Me.rbCodigo.Text = "CODIGO"
        Me.rbCodigo.UseVisualStyleBackColor = True
        '
        'dgvBusqResponsable
        '
        Me.dgvBusqResponsable.AllowUserToAddRows = False
        Me.dgvBusqResponsable.AllowUserToDeleteRows = False
        Me.dgvBusqResponsable.AllowUserToResizeColumns = False
        Me.dgvBusqResponsable.AllowUserToResizeRows = False
        Me.dgvBusqResponsable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBusqResponsable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqResponsable.Location = New System.Drawing.Point(13, 120)
        Me.dgvBusqResponsable.MultiSelect = False
        Me.dgvBusqResponsable.Name = "dgvBusqResponsable"
        Me.dgvBusqResponsable.ReadOnly = True
        Me.dgvBusqResponsable.Size = New System.Drawing.Size(376, 226)
        Me.dgvBusqResponsable.TabIndex = 1
        '
        'cmsMensajes
        '
        Me.cmsMensajes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProveedoresToolStripMenuItem, Me.FacturaDeCompraToolStripMenuItem})
        Me.cmsMensajes.Name = "cmsMensajes"
        Me.cmsMensajes.Size = New System.Drawing.Size(174, 48)
        Me.cmsMensajes.Text = "Enviar a:"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'FacturaDeCompraToolStripMenuItem
        '
        Me.FacturaDeCompraToolStripMenuItem.Name = "FacturaDeCompraToolStripMenuItem"
        Me.FacturaDeCompraToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FacturaDeCompraToolStripMenuItem.Text = "Factura de compra"
        '
        'cboEnvio
        '
        Me.cboEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvio.FormattingEnabled = True
        Me.cboEnvio.Items.AddRange(New Object() {"Proveedores", "Factura de venta", "Factura de compra"})
        Me.cboEnvio.Location = New System.Drawing.Point(182, 365)
        Me.cboEnvio.Name = "cboEnvio"
        Me.cboEnvio.Size = New System.Drawing.Size(207, 21)
        Me.cboEnvio.TabIndex = 11
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.emailmarketing3
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnviar.Location = New System.Drawing.Point(124, 352)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(59, 51)
        Me.btnEnviar.TabIndex = 10
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Busqueda_Responsable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 409)
        Me.Controls.Add(Me.cboEnvio)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.dgvBusqResponsable)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Busqueda_Responsable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Responsable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBusqResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMensajes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rbCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents dgvBusqResponsable As System.Windows.Forms.DataGridView
    Friend WithEvents cmsMensajes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturaDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents cboEnvio As System.Windows.Forms.ComboBox
End Class
