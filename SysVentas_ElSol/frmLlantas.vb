Imports System.Data.SqlClient

Public Class frmLlantas

    Dim Modificar As Boolean = False
    Dim IdPro, IdMarc, Id_Vehiculo As Integer

    Public Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Llanta.Text = Limpiar
        cboMarca.DataSource = Nothing : cboProducto.DataSource = Nothing
        cboProducto.Items.Clear() : cboProducto.Text = Limpiar
        cboMarca.Items.Clear() : cboMarca.Text = Limpiar
        cboTraspaso.SelectedIndex = -1
        cboVehiculo.SelectedIndex = -1
        rbRadial.Checked = True
        txMedida.Clear()
        rbConvencional.Checked = False
        txtCantidad.Clear()
        txtPrecio_Unit.Clear()
        lblLocal.Text = Limpiar
        lblBodegaa.Text = Limpiar
    End Sub

    Public Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean, ByVal v3 As Boolean)
        lblId_Llanta.Enabled = v2
        cboProducto.Enabled = v2
        cboMarca.Enabled = v2
        rbRadial.Enabled = v2
        txMedida.Enabled = v2
        rbConvencional.Enabled = v2
        cboVehiculo.Enabled = v2
        cboTraspaso.Enabled = v3
        txtCantidad.Enabled = v3
        txtPrecio_Unit.Enabled = v3
        btnNuevo.Enabled = v1
        btnGuardar.Enabled = Not (v1)
        btnCancelar.Enabled = Not (v1)
        btnModificar.Enabled = v1
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar_Desactivar_Controles(False, True, False)
        lblId_Llanta.Text = Mostrar_ID("SELECT * FROM LLANTA")
        Llenar_Combo_Productos("SELECT DISTINCT PRODUCTO.Id_Producto, PRODUCTO.NombrePro FROM PRODUCTO INNER " _
                       & "JOIN LLANTA ON LLANTA.Id_Producto = PRODUCTO.Id_Producto", cboProducto)
        Llenar_Combo_Marca("SELECT * FROM MARCA", cboMarca)
        Llenar_Combo_Vehiculo("SELECT * FROM TIPO_VEHICULO", cboVehiculo)
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

    Private Sub Insertar_Llanta(ByVal local As Integer, ByVal Bodega As Integer, ByVal Precio As Double)
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO LLANTA VALUES (@Cod_LLanta,@Id_Producto," _
                     & "@Estilo,@Medida,@Existencia_Local,@Existencia_Bodega,@Precio_Unitario)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Cod_LLanta", lblId_Llanta.Text))
            .Add(New SqlClient.SqlParameter("@Id_Producto", IdPro))

            If rbRadial.Checked Then
                .Add(New SqlClient.SqlParameter("@Estilo", rbRadial.Text))
            ElseIf rbConvencional.Checked Then
                .Add(New SqlClient.SqlParameter("@Estilo", rbConvencional.Text))
            End If
            .Add(New SqlClient.SqlParameter("@Medida", txMedida.Text))
            .Add(New SqlClient.SqlParameter("@Existencia_Local", local))
            .Add(New SqlClient.SqlParameter("@Existencia_Bodega", Bodega))
            .Add(New SqlClient.SqlParameter("@Precio_Unitario", Precio))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub Relaciones(ByVal Sentencia As String, ByVal Parametro1 As String, ByVal Parametro2 As String, ByVal id1 As Integer, ByVal id2 As Integer)
        Dim ComandoSQL As New SqlCommand
        StrComando = Sentencia
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter(Parametro1, id1))
            .Add(New SqlClient.SqlParameter(Parametro2, id2))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        IdPro = Val(cboProducto.SelectedValue)
        IdMarc = Val(cboMarca.SelectedValue)
        Id_Vehiculo = Val(cboVehiculo.SelectedValue)

        If cboProducto.SelectedValue = Nothing Then
            IdPro = Devolver_Datos("SELECT * FROM PRODUCTO").Rows.Count + 1
            Insertar_Producto(cboProducto.Text, IdPro)
        End If

        If cboMarca.SelectedValue = Nothing Then
            IdMarc = Devolver_Datos("SELECT * FROM MARCA").Rows.Count + 1
            Insertar_Marca(cboMarca.Text, IdMarc)
        End If

        If cboVehiculo.SelectedValue = Nothing Then
            Id_Vehiculo = Devolver_Datos("SELECT * FROM TIPO_VEHICULO").Rows.Count + 1
            Insertar_Tipo_Vehiculo(cboVehiculo.Text, Id_Vehiculo)
        End If

        Insertar_Llanta(0, 0, 0)
        'Relacion entre llanta y marca
        Relaciones("INSERT INTO LLANTA_MARCA VALUES(@Cod_Llanta,@Id_Marca)", "@Cod_Llanta", "@Id_Marca", Val(lblId_Llanta.Text), IdMarc)
        'Relacion entre llanta y tipo de vehiculo
        Relaciones("INSERT INTO LLANTA_VEHICULO VALUES (@Cod_Llanta,@Id_Vehiculo)", "@Cod_Llanta", "@Id_Vehiculo", Val(lblId_Llanta.Text), Id_Vehiculo)
        RELACION_PRODUCTO_MARCA("INSERT INTO PRODUCTO_MARCA VALUES (@Id_Producto,@Id_Marca)", "@Id_Producto", "@Id_Marca", IdPro, IdMarc)
        Activar_Desactivar_Controles(True, False, False) : Limpiar_Campos("") : Modificar = False
    End Sub


    Private Sub lblLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLocal.Click

    End Sub
End Class