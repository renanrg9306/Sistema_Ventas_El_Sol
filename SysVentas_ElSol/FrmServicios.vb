Imports System.Data.SqlClient

Public Class FrmServicios
    'Validacion Campos
    Private Sub txtServicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServicio.KeyPress
        Validacion_Solo_Letras(e)
    End Sub

    Private Sub txtPrecio_Unit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio_Unit.KeyPress
        Validacion_Flotantes(e, txtPrecio_Unit)
    End Sub

    Private Sub txtPrecio_Unit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPrecio_Unit.Validating
        If txtPrecio_Unit.Text <> Nothing And txtPrecio_Unit.Text <> "." Then
            txtPrecio_Unit.Text = Format(CDec(txtPrecio_Unit.Text), "#.##")
        End If
    End Sub

    'Limpieza de los campos
    Private Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Servicio.Text = Limpiar
        txtServicio.Clear()
        txtPrecio_Unit.Clear()
    End Sub

    ' Procedimiento para activar y desactivar campos
    Private Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean)
        lblId_Servicio.Enabled = v2
        txtServicio.Enabled = v2
        txtPrecio_Unit.Enabled = v2
        btnNuevo.Enabled = v1
        btnGuardar.Enabled = v2
        btnCancelar.Enabled = v2
        btnModificar.Enabled = v1
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar_Desactivar_Controles(False, True)
        lblId_Servicio.Text = Mostrar_ID("SELECT * FROM SERVICIO")
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

    Private Sub Insertar_Servicio()
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO SERVICIO VALUES (@Id_Servicio,@Descripcion,@Precio)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Servicio", CInt(lblId_Servicio.Text)))
            .Add(New SqlClient.SqlParameter("@Descripcion", txtServicio.Text))
            .Add(New SqlClient.SqlParameter("@Precio", CDbl(txtPrecio_Unit.Text)))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
        Limpiar_Campos("") : Activar_Desactivar_Controles(True, False)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ErrorComponente.SetError(txtServicio, Nothing)
        ErrorComponente.SetError(txtPrecio_Unit, Nothing)
        If txtServicio.Text.Trim = Nothing Then
            ErrorComponente.SetError(txtServicio, "NO HA INGRESADO EL NOMBRE") : Exit Sub
        ElseIf txtPrecio_Unit.Text = Nothing Or txtPrecio_Unit.Text = "." Then
            ErrorComponente.SetError(txtPrecio_Unit, "NO HA INGRESADO EL PRECIO") : Exit Sub
        Else
            Insertar_Servicio()
        End If
    End Sub


End Class