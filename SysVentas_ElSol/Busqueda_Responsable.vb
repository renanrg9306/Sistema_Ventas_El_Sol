Imports System.Data.SqlClient

Public Class Busqueda_Responsable
    Private Sub Busqueda_Responsable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvBusqResponsable.SelectionMode = DataGridViewSelectionMode.FullRowSelect 'Linea para seleccionar la fila entera
        dgvBusqResponsable.DataSource = Busqueda_Datos("SELECT Id_Responsable,Nombre,Cedula FROM RESPONSABLE", False)
    End Sub

    'Funcion para hacer la busqueda en los distintos escenarios
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
                If LCase(Strings.Left(drBuscar("Nombre").ToString, Cadena.Length)) = LCase(Cadena) Then
                    dtBuscar1.Rows.Add(drBuscar("Id_Responsable").ToString, _
                                      drBuscar("Nombre").ToString, drBuscar("Cedula").ToString)
                End If
            Next
        End If

        Busqueda_Datos = dtBuscar1
    End Function

    Private Sub btnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusqueda.Click
        If rbCodigo.Checked Then
            dgvBusqResponsable.DataSource = Busqueda_Datos("SELECT Id_Responsable,Nombre,Cedula FROM RESPONSABLE WHERE Id_Responsable=" & Val(txtBusqueda.Text), False)
        ElseIf rbNombre.Checked Then
            dgvBusqResponsable.DataSource = Busqueda_Datos("SELECT Id_Responsable,Nombre,Cedula FROM RESPONSABLE", True, txtBusqueda.Text)
        End If
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        boton = MsgBoxStyle.ApplicationModal Or MessageBoxIcon.Exclamation Or MsgBoxStyle.OkOnly
        If dgvBusqResponsable.RowCount = 0 Then
            MsgBox("No hay datos seleccionados", boton, "MENSAJE DE AVISO") : Exit Sub
        ElseIf cboEnvio.Text = Nothing Then
            MsgBox("No ha seleccionado la direccion de envio", boton, "MENSAJE DE AVISO") : Exit Sub
        End If

        If cboEnvio.Text = "Proveedores" Then
            FrmProveedores.dgvResponsable.Rows.Add(dgvBusqResponsable(0, dgvBusqResponsable.CurrentRow.Index).Value _
                                       , dgvBusqResponsable(1, dgvBusqResponsable.CurrentRow.Index).Value _
                                        , dgvBusqResponsable(2, dgvBusqResponsable.CurrentRow.Index).Value)
        End If

        FrmProveedores.Show()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If txtBusqueda.Text = Nothing Then
            dgvBusqResponsable.DataSource = Busqueda_Datos("SELECT Id_Responsable,Nombre,Cedula FROM RESPONSABLE", False)
        End If
    End Sub
End Class