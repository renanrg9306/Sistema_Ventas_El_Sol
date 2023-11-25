<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busqueda_Repuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busqueda_Repuesto))
        Me.cboEnvio = New System.Windows.Forms.ComboBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.dgvBusqRepuesto = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.rbNombre = New System.Windows.Forms.RadioButton()
        Me.rbParte = New System.Windows.Forms.RadioButton()
        CType(Me.dgvBusqRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboEnvio
        '
        Me.cboEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvio.FormattingEnabled = True
        Me.cboEnvio.Items.AddRange(New Object() {"Repuestos", "Factura de venta", "Factura de compra"})
        Me.cboEnvio.Location = New System.Drawing.Point(407, 364)
        Me.cboEnvio.Name = "cboEnvio"
        Me.cboEnvio.Size = New System.Drawing.Size(207, 21)
        Me.cboEnvio.TabIndex = 23
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.emailmarketing3
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnviar.Location = New System.Drawing.Point(349, 351)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(59, 51)
        Me.btnEnviar.TabIndex = 22
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'dgvBusqRepuesto
        '
        Me.dgvBusqRepuesto.AllowUserToAddRows = False
        Me.dgvBusqRepuesto.AllowUserToDeleteRows = False
        Me.dgvBusqRepuesto.AllowUserToResizeColumns = False
        Me.dgvBusqRepuesto.AllowUserToResizeRows = False
        Me.dgvBusqRepuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBusqRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqRepuesto.Location = New System.Drawing.Point(12, 119)
        Me.dgvBusqRepuesto.MultiSelect = False
        Me.dgvBusqRepuesto.Name = "dgvBusqRepuesto"
        Me.dgvBusqRepuesto.ReadOnly = True
        Me.dgvBusqRepuesto.Size = New System.Drawing.Size(601, 226)
        Me.dgvBusqRepuesto.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBusqueda)
        Me.GroupBox1.Controls.Add(Me.txtBusqueda)
        Me.GroupBox1.Controls.Add(Me.rbNombre)
        Me.GroupBox1.Controls.Add(Me.rbParte)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(601, 100)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA POR"
        '
        'btnBusqueda
        '
        Me.btnBusqueda.BackgroundImage = Global.SysVentas_ElSol.My.Resources.Resources.buscar
        Me.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBusqueda.Location = New System.Drawing.Point(338, 34)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(32, 33)
        Me.btnBusqueda.TabIndex = 9
        Me.btnBusqueda.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(369, 41)
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
        'rbParte
        '
        Me.rbParte.AutoSize = True
        Me.rbParte.Checked = True
        Me.rbParte.Location = New System.Drawing.Point(28, 34)
        Me.rbParte.Name = "rbParte"
        Me.rbParte.Size = New System.Drawing.Size(94, 17)
        Me.rbParte.TabIndex = 0
        Me.rbParte.TabStop = True
        Me.rbParte.Text = "N° DE PARTE"
        Me.rbParte.UseVisualStyleBackColor = True
        '
        'Busqueda_Repuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 406)
        Me.Controls.Add(Me.cboEnvio)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.dgvBusqRepuesto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Busqueda_Repuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSQUEDA DE REPUESTOS"
        CType(Me.dgvBusqRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents dgvBusqRepuesto As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents rbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rbParte As System.Windows.Forms.RadioButton
End Class
