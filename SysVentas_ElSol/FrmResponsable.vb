Imports System.Data.SqlClient

Public Class FrmResponsable

    Private Sub Limpiar_Campos(ByVal Limpiar As String)
        lblId_Responsable.Text = Limpiar
        txtNombre.Clear()
        mtbCedula.Clear()
        dgvCelular.Rows.Clear()
    End Sub

    Private Sub Activar_Desactivar_Controles(ByVal v1 As Boolean, ByVal v2 As Boolean)
        lblId_Responsable.Enabled = v2
        txtNombre.Enabled = v2
        mtbCedula.Enabled = v2
        dgvCelular.Enabled = v2
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

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar_Desactivar_Controles(False, True)
        lblId_Responsable.Text = Mostrar_ID("SELECT * FROM RESPONSABLE")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar_Opcion()
    End Sub

    Private Sub Guargar_Datos_Responsable()
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO RESPONSABLE VALUES (@Id_Responsable,@Nombre,@Cedula,@Id_Proveedor)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Responsable", lblId_Responsable.Text))
            .Add(New SqlClient.SqlParameter("@Nombre", txtNombre.Text))
            .Add(New SqlClient.SqlParameter("@Cedula", mtbCedula.Text))
            .Add(New SqlClient.SqlParameter("@Id_Proveedor", 0))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Private Sub Guardar_Celulares_Responsable()
        If dgvCelular.RowCount > 1 Then
            For i = 0 To dgvCelular.Rows.Count - 2
                Dim ComandoSQL As New SqlCommand
                StrComando = "INSERT INTO CELULAR_RESPONSABLE VALUES (@Id_Responsable,@Celular,@Telefonia)"
                Abrir_Conexion()
                ComandoSQL.CommandText = StrComando
                ComandoSQL.Connection = Conexion

                With ComandoSQL.Parameters
                    .Add(New SqlClient.SqlParameter("@Id_Responsable", CInt(lblId_Responsable.Text)))
                    .Add(New SqlClient.SqlParameter("@Celular", dgvCelular(0, i).Value))
                    If dgvCelular(1, i).Value = Nothing Then
                        .Add(New SqlClient.SqlParameter("@Telefonia", "--"))
                    Else
                        .Add(New SqlClient.SqlParameter("@Telefonia", dgvCelular(1, i).Value))
                    End If
                End With
                ComandoSQL.ExecuteNonQuery()
                Cerrar_Conexion()
            Next i
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guargar_Datos_Responsable()
        Guardar_Celulares_Responsable()
        Limpiar_Campos("") : Activar_Desactivar_Controles(True, False)
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Validacion_Solo_Letras(e)

    End Sub
End Class