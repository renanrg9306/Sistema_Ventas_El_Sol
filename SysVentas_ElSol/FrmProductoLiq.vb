Imports System.Data.SqlClient

Public Class FrmProductoLiq
    Dim Modificar As Boolean = False

    Dim IdPro, IdMarc As Integer

    Public Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Liquido.Text = Limpiar
        cboMarca.DataSource = Nothing : cboProducto.DataSource = Nothing
        cboProducto.Items.Clear() : cboProducto.Text = Limpiar
        cboMarca.Items.Clear() : cboMarca.Text = Limpiar
        cboMedida.SelectedIndex = -1 'Volver a su estado original con la funcion dropdownstyle activa
        cboTraspaso.SelectedIndex = -1
        txtNumero.Clear()
        txtCantidad.Clear()
        txtPrecio_Unit.Clear()
        lblLocal.Text = Limpiar
        lblBodegaa.Text = Limpiar
    End Sub

    Public Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean, ByVal v3 As Boolean)
        lblId_Liquido.Enabled = v2
        cboProducto.Enabled = v2
        cboMarca.Enabled = v2
        txtNumero.Enabled = v2
        cboMedida.Enabled = v2
        cboTraspaso.Enabled = v3
        txtCantidad.Enabled = v3
        txtPrecio_Unit.Enabled = v3
        btnNuevo.Enabled = v1
        btnGuardar.Enabled = Not (v1)
        btnCancelar.Enabled = Not (v1)
        btnModificar.Enabled = v1
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Modificar = False
        Activar_Desactivar_Controles(False, True, False)
        Limpiar_Campos("")
        Llenar_Combo_Productos("SELECT DISTINCT PRODUCTO.Id_Producto, PRODUCTO.NombrePro FROM PRODUCTO INNER " _
                        & "JOIN LIQUIDO ON LIQUIDO.Id_Producto = PRODUCTO.Id_Producto", cboProducto)
        Llenar_Combo_Marca("SELECT * FROM MARCA", cboMarca)
        lblId_Liquido.Text = Mostrar_ID("SELECT * FROM LIQUIDO")
    End Sub

    Private Sub Cancelar_Opcion()
        boton = MsgBoxStyle.ApplicationModal Or MsgBoxStyle.YesNo Or MessageBoxIcon.Stop
        If Mensaje("¿DESEA CANCELAR LAS OPERACIONES?", boton, "MENSAJE DE AVISO") = vbYes Then
            Activar_Desactivar_Controles(True, False, False) : Limpiar_Campos("") : Modificar = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar_Opcion()
    End Sub

    Private Sub Insertar_Liquido(ByVal local As Integer, ByVal Bodega As Integer, ByVal Precio As Double)
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO LIQUIDO VALUES (@Cod_Liquido,@Id_Producto," _
                     & "@Medida,@Existencia_Local,@Existencia_Bodega,@Precio_Unitario)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Cod_Liquido", lblId_Liquido.Text))
            .Add(New SqlClient.SqlParameter("@Id_Producto", IdPro))
            .Add(New SqlClient.SqlParameter("@Medida", txtNumero.Text & " " & cboMedida.Text))
            .Add(New SqlClient.SqlParameter("@Existencia_Local", local))
            .Add(New SqlClient.SqlParameter("@Existencia_Bodega", Bodega))
            .Add(New SqlClient.SqlParameter("@Precio_Unitario", Precio))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub Relacion_LIQUIDO_MARCA()
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO LIQUIDO_MARCA VALUES (@Cod_Liquido,@Id_Marca)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Cod_Liquido", lblId_Liquido.Text))
            .Add(New SqlClient.SqlParameter("@Id_Marca", IdMarc))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        boton = MsgBoxStyle.ApplicationModal Or MessageBoxIcon.Exclamation Or MsgBoxStyle.OkOnly
        If Modificar Then
            If cboTraspaso.Text = Nothing And txtCantidad.Text <> Nothing Then
                MsgBox("No ha seleccionado de donde se hara el traspaso de productos", boton, "MENSAJE DE AVISO") : Exit Sub
            End If

            If cboTraspaso.Text = "BODEGA A LOCAL" And Val(txtCantidad.Text) > lblBodegaa.Text Then
                MsgBox("La cantidad a trasladar es mayor que la que se encuentra en bodega", boton, "MENSAJE DE AVISO") : Exit Sub
            ElseIf cboTraspaso.Text = "LOCAL A BODEGA" And Val(txtCantidad.Text) > lblLocal.Text Then
                MsgBox("La cantidad a trasladar es mayor que la que se encuentra en el local", boton, "MENSAJE DE AVISO") : Exit Sub
            End If

            Insertar_Producto_Modificado("UPDATE LIQUIDO SET Existencia_Local= @EL,Existencia_Bodega=@EB," _
                                         & "Precio_Unitario=@PU WHERE Cod_Liquido = " & CInt(lblId_Liquido.Text), _
                                         Val(txtCantidad.Text), Val(lblLocal.Text), Val(lblBodegaa.Text), _
                                         CDbl(txtPrecio_Unit.Text), cboTraspaso)
        Else
            IdPro = Val(cboProducto.SelectedValue)
            IdMarc = Val(cboMarca.SelectedValue)

            If cboProducto.SelectedValue = Nothing Then
                IdPro = Devolver_Datos("SELECT * FROM PRODUCTO").Rows.Count + 1
                Insertar_Producto(cboProducto.Text, IdPro)
            End If

            If cboMarca.SelectedValue = Nothing Then
                IdMarc = Devolver_Datos("SELECT * FROM MARCA").Rows.Count + 1
                Insertar_Marca(cboMarca.Text, IdMarc)
            End If

            Insertar_Liquido(0, 0, 0)
            Relacion_LIQUIDO_MARCA()
            RELACION_PRODUCTO_MARCA("INSERT INTO PRODUCTO_MARCA VALUES (@Id_Producto,@Id_Marca)", "@Id_Producto", "@Id_Marca", IdPro, IdMarc)
        End If
        Activar_Desactivar_Controles(True, False, False) : Limpiar_Campos("") : Modificar = False
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        boton = MsgBoxStyle.ApplicationModal Or MessageBoxIcon.Exclamation Or MsgBoxStyle.OkOnly
        If lblId_Liquido.Text = Nothing Then
            MsgBox("No ha seleccionado aun ningun producto registrado", boton, "MENSAJE DE AVISO") : Exit Sub
        End If
        Modificar = True
        Activar_Desactivar_Controles(False, False, True)
    End Sub

    Private Sub txtPrecio_Unit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecio_Unit.LostFocus
        If txtPrecio_Unit.Text = Nothing Then
            txtPrecio_Unit.Text = "0"
        End If
    End Sub
End Class