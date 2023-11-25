Imports System.Data.SqlClient

Public Class FrmProveedores
    Private Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Proveedor.Text = Limpiar
        txtRuc.Clear()
        txtNombre.Clear()
        txtCorreo.Clear()
        txtDireccion.Clear()
        dgvTelefonos.Rows.Clear()
        dgvResponsable.Rows.Clear()
    End Sub

    Private Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean)
        lblId_Proveedor.Enabled = v2
        txtNombre.Enabled = v2
        txtRuc.Enabled = v2
        txtCorreo.Enabled = v2
        txtDireccion.Enabled = v2
        dgvResponsable.Enabled = v2
        dgvTelefonos.Enabled = v2
        btnNuevo.Enabled = v1
        btnGuardar.Enabled = v2
        btnCancelar.Enabled = v2
        btnAgregar.Enabled = v2
        btnModificar.Enabled = v1
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar_Desactivar_Controles(False, True)
        lblId_Proveedor.Text = Mostrar_ID("SELECT * FROM PROVEEDOR")
    End Sub

    Private Sub Cancelar_Opcion()
        boton = MsgBoxStyle.ApplicationModal Or MsgBoxStyle.YesNo Or MessageBoxIcon.Stop
        If Mensaje("¿DESEA CANCELAR LAS OPERACIONES?", boton, "MENSAJE DE AVISO") = vbYes Then
            Activar_Desactivar_Controles(True, False) : Limpiar_Campos("")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar_Opcion()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Busqueda_Responsable.Show()
    End Sub

    Private Sub Actualizar_Responsable()
        If dgvResponsable.RowCount > 1 Then
            For i = 0 To dgvResponsable.RowCount - 2
                Dim ComandoSQL As New SqlCommand
                StrComando = "UPDATE RESPONSABLE SET Id_Proveedor= @Id_Proveedor WHERE Id_Responsable = " & dgvResponsable(0, i).Value
                Abrir_Conexion()
                ComandoSQL.CommandText = StrComando
                ComandoSQL.Connection = Conexion

                With ComandoSQL.Parameters
                    .Add(New SqlClient.SqlParameter("@Id_Proveedor", Val(lblId_Proveedor.Text)))
                End With
                ComandoSQL.ExecuteNonQuery()
                Cerrar_Conexion()
            Next
        End If
    End Sub

    Private Sub Guardar_Telefonos()
        If dgvTelefonos.RowCount > 1 Then
            For i = 0 To dgvTelefonos.Rows.Count - 2
                Dim ComandoSQL As New SqlCommand
                StrComando = "INSERT INTO TELEFONO_PROVEEDOR VALUES (@Id_Proveedor,@Telefono)"
                Abrir_Conexion()
                ComandoSQL.CommandText = StrComando
                ComandoSQL.Connection = Conexion

                With ComandoSQL.Parameters
                    .Add(New SqlClient.SqlParameter("@Id_Proveedor", CInt(lblId_Proveedor.Text)))
                    .Add(New SqlClient.SqlParameter("@Telefono", dgvTelefonos(0, i).Value))
                End With
                ComandoSQL.ExecuteNonQuery()
                Cerrar_Conexion()
            Next i
        End If
    End Sub

    Private Sub Insertar_Proveedor()
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO PROVEEDOR VALUES (@Id_Proveedor,@RUC,@Nombre,@Correo,@Direccion)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Proveedor", lblId_Proveedor.Text))
            .Add(New SqlClient.SqlParameter("@RUC", txtRuc.Text))
            .Add(New SqlClient.SqlParameter("@Nombre", txtNombre.Text))
            .Add(New SqlClient.SqlParameter("@Correo", txtCorreo.Text))
            .Add(New SqlClient.SqlParameter("@Direccion", txtDireccion.Text))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Insertar_Proveedor()
        Actualizar_Responsable()
        Guardar_Telefonos()
        Limpiar_Campos("") : Activar_Desactivar_Controles(True, False)
    End Sub
End Class