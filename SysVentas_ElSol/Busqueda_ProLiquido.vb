Imports System.Data.SqlClient

Public Class Busqueda_ProLiquido
    Private Sub Busqueda_ProLiquido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvBusqLiquido.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Sentencia para mostrar todos los liquidos almacenados
        llenado_completo(False)
    End Sub

    Private Function Busqueda_Datos(ByVal Sentencia As String, ByVal Opcion As Boolean, Optional ByVal Cadena As String = "") As DataTable
        Dim daBuscar As New SqlDataAdapter(Sentencia, Conexion)
        Dim dtBuscar, dtBuscar1 As New DataTable, drBuscar As DataRow

        Abrir_Conexion()
        daBuscar.Fill(dtBuscar)
        daBuscar.Fill(dtBuscar1)
        Cerrar_Conexion()

        If Opcion Then ' Variable booleana para saber si esta buscando por cadena
            dtBuscar1.Rows.Clear() ' Como se hicieron 2 datatable iguales se borra uno y en ese se van copiando los registros que
            For Each drBuscar In dtBuscar.Rows 'coincidan con la busqueda
                If LCase(Strings.Left(drBuscar("NombrePro").ToString, Cadena.Length)) = LCase(Cadena) Then
                    dtBuscar1.Rows.Add(drBuscar("Cod_Liquido").ToString, _
                        drBuscar("NombrePro").ToString, drBuscar("Marca").ToString, drBuscar("Medida").ToString, _
                        drBuscar("Existencia_Local").ToString, drBuscar("Existencia_Bodega").ToString, _
                          drBuscar("Precio_Unitario").ToString)
                End If
            Next
        End If

        Busqueda_Datos = dtBuscar1
    End Function

    Private Sub llenado_completo(ByVal Opcion As Boolean, Optional ByVal Cadena As String = "")
        dgvBusqLiquido.DataSource = Busqueda_Datos("SELECT LIQUIDO.Cod_Liquido,PRODUCTO.NombrePro,MARCA.Marca,LIQUIDO.Medida," _
                                          & "LIQUIDO.Existencia_Local,LIQUIDO.Existencia_Bodega,LIQUIDO.Precio_Unitario " _
                                          & "FROM LIQUIDO INNER JOIN PRODUCTO ON LIQUIDO.Id_Producto = PRODUCTO.Id_Producto " _
                                          & "INNER JOIN LIQUIDO_MARCA ON LIQUIDO.Cod_Liquido = LIQUIDO_MARCA.Cod_Liquido " _
                                          & "INNER JOIN MARCA ON LIQUIDO_MARCA.Id_Marca = MARCA.Id_Marca", Opcion, Cadena)
    End Sub

    Private Sub btnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusqueda.Click
        If txtBusqueda.Text = Nothing Then
            llenado_completo(False) : Exit Sub
        End If

        If rbCodigo.Checked Then
            dgvBusqLiquido.DataSource = Busqueda_Datos("SELECT LIQUIDO.Cod_Liquido,PRODUCTO.NombrePro,MARCA.Marca,LIQUIDO.Medida," _
                                                  & "LIQUIDO.Existencia_Local,LIQUIDO.Existencia_Bodega,LIQUIDO.Precio_Unitario " _
                                                  & "FROM LIQUIDO INNER JOIN PRODUCTO ON LIQUIDO.Cod_Liquido= " & Val(txtBusqueda.Text) _
                                                  & " AND LIQUIDO.Id_Producto = PRODUCTO.Id_Producto " _
                                                  & "INNER JOIN LIQUIDO_MARCA ON LIQUIDO.Cod_Liquido = LIQUIDO_MARCA.Cod_Liquido " _
                                                  & "INNER JOIN MARCA ON LIQUIDO_MARCA.Id_Marca = MARCA.Id_Marca", False)
        ElseIf rbNombre.Checked Then
            llenado_completo(True, txtBusqueda.Text)
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If txtBusqueda.Text = Nothing Then
            llenado_completo(False)
        End If
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        boton = MsgBoxStyle.ApplicationModal Or MessageBoxIcon.Exclamation Or MsgBoxStyle.OkOnly
        If dgvBusqLiquido.RowCount = 0 Then
            MsgBox("No hay datos seleccionados", boton, "MENSAJE DE AVISO") : Exit Sub
        ElseIf cboEnvio.Text = Nothing Then
            MsgBox("No ha seleccionado la direccion de envio", boton, "MENSAJE DE AVISO") : Exit Sub
        End If

        If cboEnvio.Text = "Productos Liquidos" Then
            Envio_Liquidos(dgvBusqLiquido.CurrentRow.Index)
            FrmProductoLiq.Show()
        End If
    End Sub

    Private Sub Envio_Liquidos(ByVal fila As Integer)
        FrmProductoLiq.Limpiar_Campos("")
        FrmProductoLiq.Activar_Desactivar_Controles(True, False, False)

        FrmProductoLiq.lblId_Liquido.Text = CodigoID(Val(dgvBusqLiquido(0, fila).Value))
        FrmProductoLiq.cboProducto.Text = dgvBusqLiquido(1, fila).Value.ToString
        FrmProductoLiq.cboMarca.Text = dgvBusqLiquido(2, fila).Value.ToString

        ' Se asigna la cadena de medida.
        Dim Medida As String = dgvBusqLiquido(3, fila).Value.ToString
        ' Linea para tomar una subcadena a partir de la siguiente posicion del espacio en blanco
        FrmProductoLiq.cboMedida.Text = Medida.Substring(Strings.InStr(Medida, " ", CompareMethod.Text))
        ' Linea para obtener una subcadena a partir de la posicion 0 hasta la posicion antes de espacio en blanco
        FrmProductoLiq.txtNumero.Text = Medida.Substring(0, Strings.InStr(Medida, " ", CompareMethod.Text))

        FrmProductoLiq.lblLocal.Text = dgvBusqLiquido(4, fila).Value.ToString
        FrmProductoLiq.lblBodegaa.Text = dgvBusqLiquido(5, fila).Value.ToString
        FrmProductoLiq.txtPrecio_Unit.Text = Format(CDec(dgvBusqLiquido(6, fila).Value), "#.##")
    End Sub
End Class