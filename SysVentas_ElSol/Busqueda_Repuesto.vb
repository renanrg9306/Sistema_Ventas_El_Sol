Imports System.Data.SqlClient

Public Class Busqueda_Repuesto

    Private Sub Busqueda_Repuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvBusqRepuesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        llenado_completo(False)
    End Sub

    Private Function Busqueda_Datos(ByVal Sentencia As String, ByVal Opcion As Boolean, Optional ByVal Cadena As String = "", _
                                    Optional ByVal Cadena1 As String = "") As DataTable
        Dim daBuscar As New SqlDataAdapter(Sentencia, Conexion)
        Dim dtBuscar, dtBuscar1 As New DataTable, drBuscar As DataRow

        Abrir_Conexion()
        daBuscar.Fill(dtBuscar)
        daBuscar.Fill(dtBuscar1)
        Cerrar_Conexion()

        If Opcion Then ' Variable booleana para saber si esta buscando por cadena
            dtBuscar1.Rows.Clear() ' Como se hicieron 2 datatable iguales se borra uno y en ese se van copiando los registros que
            For Each drBuscar In dtBuscar.Rows 'coincidan con la busqueda
                If LCase(Strings.Left(drBuscar(Cadena1).ToString, Cadena.Length)) = LCase(Cadena) Then
                    dtBuscar1.Rows.Add(drBuscar("N_Parte").ToString, _
                        drBuscar("NombrePro").ToString, drBuscar("Marca").ToString, _
                        drBuscar("Existencia_Local").ToString, drBuscar("Existencia_Bodega").ToString, _
                        drBuscar("Precio_Unitario").ToString)
                End If
            Next
        End If

        Busqueda_Datos = dtBuscar1
    End Function

    Private Sub llenado_completo(ByVal Opcion As Boolean, Optional ByVal Cadena As String = "", Optional ByVal Cadena1 As String = "")
        dgvBusqRepuesto.DataSource = Busqueda_Datos("SELECT REPUESTO.N_Parte,PRODUCTO.NombrePro,MARCA.Marca," _
                                          & "REPUESTO.Existencia_Local,REPUESTO.Existencia_Bodega,REPUESTO.Precio_Unitario " _
                                          & "FROM REPUESTO INNER JOIN PRODUCTO ON REPUESTO.Id_Producto = PRODUCTO.Id_Producto " _
                                          & "INNER JOIN REPUESTO_MARCA ON REPUESTO.N_Parte = REPUESTO_MARCA.N_Parte " _
                                          & "INNER JOIN MARCA ON REPUESTO_MARCA.Id_Marca = MARCA.Id_Marca", Opcion, Cadena, Cadena1)
    End Sub

    Private Sub btnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusqueda.Click
        If rbParte.Checked Then
            llenado_completo(True, txtBusqueda.Text, "N_Parte")
        ElseIf rbNombre.Checked Then
            llenado_completo(True, txtBusqueda.Text, "NombrePro")
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If txtBusqueda.Text = Nothing Then
            llenado_completo(False)
        End If
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        boton = MsgBoxStyle.ApplicationModal Or MessageBoxIcon.Exclamation Or MsgBoxStyle.OkOnly
        If dgvBusqRepuesto.RowCount = 0 Then
            MsgBox("No hay datos seleccionados", boton, "MENSAJE DE AVISO") : Exit Sub
        ElseIf cboEnvio.Text = Nothing Then
            MsgBox("No ha seleccionado la direccion de envio", boton, "MENSAJE DE AVISO") : Exit Sub
        End If

        If cboEnvio.Text = "Repuestos" Then
            Envio_Repuesto(dgvBusqRepuesto.CurrentRow.Index)
            frmRepuestos.Show()
        End If
    End Sub

    Private Sub Envio_Repuesto(ByVal fila As Integer)
        frmRepuestos.Limpiar_Campos("")
        frmRepuestos.Activar_Desactivar_Controles(True, False, False)

        frmRepuestos.txtParte.Text = dgvBusqRepuesto(0, fila).Value.ToString
        frmRepuestos.cboProducto.Text = dgvBusqRepuesto(1, fila).Value.ToString
        frmRepuestos.cboMarca.Text = dgvBusqRepuesto(2, fila).Value.ToString
        frmRepuestos.lblLocal.Text = dgvBusqRepuesto(3, fila).Value.ToString
        frmRepuestos.lblBodegaa.Text = dgvBusqRepuesto(4, fila).Value.ToString
        frmRepuestos.txtPrecio_Unit.Text = Format(CDec(dgvBusqRepuesto(5, fila).Value), "#.##")
    End Sub
End Class