Public Class frmMenu_Principal
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    ' Opción insertar y modificar de proveedor
    Private Sub InsertarYModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarYModificarToolStripMenuItem.Click
        Hijo(FrmProveedores, Me)
    End Sub

    ' Opción insertar y modificar de llantas
    Private Sub InsertarYModificarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarYModificarToolStripMenuItem1.Click
        Hijo(frmLlantas, Me)
    End Sub

    ' Opción insertar y modificar de liquidos
    Private Sub InsertarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarToolStripMenuItem.Click
        Hijo(FrmProductoLiq, Me)
    End Sub

    ' Opción de buscar liquido
    Private Sub BuscarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem2.Click
        Hijo(Busqueda_ProLiquido, Me)
    End Sub

    ' Insertar y modificar repuesto
    Private Sub InsertarYModificarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarYModificarToolStripMenuItem2.Click
        Hijo(frmRepuestos, Me)
    End Sub

    ' Buscar repuesto
    Private Sub BuscarToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem3.Click
        Hijo(Busqueda_Repuesto, Me)
    End Sub

    ' Insertar y modificar Servicios
    Private Sub ServiciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiciosToolStripMenuItem.Click
        Hijo(FrmServicios, Me)
    End Sub

    ' Insertar y modificar clientes
    Private Sub IngresoYModificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoYModificacionToolStripMenuItem.Click
        Hijo(FrmClientes, Me)
    End Sub

    'Buscar proveedor
    Private Sub BuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem.Click
        Hijo(frmBusqueda_Proveedor, Me)
    End Sub

    Private Sub frmMenu_Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub ModificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificacionToolStripMenuItem.Click
        Hijo(FrmResponsable, Me)
    End Sub

    Private Sub MostrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarToolStripMenuItem1.Click
        Hijo(Busqueda_Responsable, Me)
    End Sub

    Private Sub BuscarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem1.Click

    End Sub
End Class
