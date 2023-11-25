Imports System.Data.SqlClient

Public Class FrmClientes
    'Validacion de los campos
    Private Sub txtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        Validacion_Solo_Letras(e)
    End Sub

    Private Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Cliente.Text = Limpiar
        txtNombres.Clear()
        mtbCedula.Clear()
    End Sub

    Private Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean)
        lblId_Cliente.Enabled = v2
        txtNombres.Enabled = v2
        mtbCedula.Enabled = v2
        btnNuevo.Enabled = v1
        btnGuardar.Enabled = v2
        btnCancelar.Enabled = v2
        btnModificar.Enabled = v1
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

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar_Desactivar_Controles(False, True)
        lblId_Cliente.Text = Mostrar_ID("SELECT * FROM CLIENTE")
    End Sub

    Private Sub Insertar_Cliente()
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO CLIENTE VALUES (@Id_Cliente,@Nombre,@Cedula)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Cliente", lblId_Cliente.Text))
            .Add(New SqlClient.SqlParameter("@Nombre", txtNombres.Text))
            .Add(New SqlClient.SqlParameter("@Cedula", mtbCedula.Text))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
        Limpiar_Campos("") : Activar_Desactivar_Controles(True, False)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtNombres.Text.Trim = Nothing Then
            ErrorComponente.SetError(txtNombres, "NO HA INGRESADO EL NOMBRE")
        Else
            ErrorComponente.SetError(txtNombres, Nothing)
            Insertar_Cliente()
        End If
    End Sub

    Private Sub mtbCedula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtbCedula.KeyPress
        Dim Cedula As New System.Text.RegularExpressions.Regex("[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]{1}")
        Dim Expresion2 As New System.Text.RegularExpressions.Regex("[A-Z|Ñ]")

        If Not (Cedula.IsMatch(mtbCedula.Text)) Then
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub



    Private Sub mtbCedula_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mtbCedula.MaskInputRejected

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click

    End Sub
End Class
