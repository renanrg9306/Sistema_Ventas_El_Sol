<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busqueda_ProLiquido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busqueda_ProLiquido))
        Me.cboEnvio = New System.Windows.Forms.ComboBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.dgvBusqLiquido = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.rbNombre = New System.Windows.Forms.RadioButton()
        Me.rbCodigo = New System.Windows.Forms.RadioButton()
        CType(Me.dgvBusqLiquido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboEnvio
        '
        Me.cboEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvio.FormattingEnabled = True
        Me.cboEnvio.Items.AddRange(New Object() {"Productos Liquidos", "Factura de venta", "Factura de compra"})
        Me.cboEnvio.Location = New System.Drawing.Point(492, 365)
        Me.cboEnvio.Name = "cboEnvio"
        Me.cboEnvio.Size = New System.Drawing.Size(207, 21)
        Me.cboEnvio.TabIndex = 15
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.emailmarketing3
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnviar.Location = New System.Drawing.Point(434, 352)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(59, 51)
        Me.btnEnviar.TabIndex = 14
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'dgvBusqLiquido
        '
        Me.dgvBusqLiquido.AllowUserToAddRows = False
        Me.dgvBusqLiquido.AllowUserToDeleteRows = False
        Me.dgvBusqLiquido.AllowUserToResizeColumns = False
        Me.dgvBusqLiquido.AllowUserToResizeRows = False
        Me.dgvBusqLiquido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBusqLiquido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqLiquido.Location = New System.Drawing.Point(12, 120)
        Me.dgvBusqLiquido.MultiSelect = False
        Me.dgvBusqLiquido.Name = "dgvBusqLiquido"
        Me.dgvBusqLiquido.ReadOnly = True
        Me.dgvBusqLiquido.Size = New System.Drawing.Size(688, 226)
        Me.dgvBusqLiquido.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBusqueda)
        Me.GroupBox1.Controls.Add(Me.txtBusqueda)
        Me.GroupBox1.Controls.Add(Me.rbNombre)
        Me.GroupBox1.Controls.Add(Me.rbCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 100)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA POR"
        '
        'btnBusqueda
        '
        Me.btnBusqueda.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.buscar
        Me.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBusqueda.Location = New System.Drawing.Point(443, 34)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(32, 33)
        Me.btnBusqueda.TabIndex = 9
        Me.btnBusqueda.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(474, 41)
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
        'Busqueda_ProLiquido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 411)
        Me.Controls.Add(Me.cboEnvio)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.dgvBusqLiquido)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Busqueda_ProLiquido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSQUEDA DE PRODUCTOS LIQUIDOS"
        CType(Me.dgvBusqLiquido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents dgvBusqLiquido As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents rbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rbCodigo As System.Windows.Forms.RadioButton
End Class
