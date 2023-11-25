Imports System.Data.SqlClient

Public Class frmBusqueda_Proveedor

    Private Sub btnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusqueda.Click
        If rbRuc.Checked Then
            dgvBusqProveedor.DataSource = Busqueda_Datos("SELECT * FROM PROVEEDOR", True, txtBusqueda.Text, "RUC")
        ElseIf rbNombre.Checked Then
            dgvBusqProveedor.DataSource = Busqueda_Datos("SELECT * FROM PROVEEDOR", True, txtBusqueda.Text, "Nombre")
        End If
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
                    dtBuscar1.Rows.Add(drBuscar("Id_Proveedor").ToString, _
                        drBuscar("RUC").ToString, drBuscar("Nombre").ToString, _
                        drBuscar("Correo").ToString, drBuscar("Direccion").ToString)
                End If
            Next
        End If

        Busqueda_Datos = dtBuscar1
    End Function

    Private Sub frmBusqueda_Proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvBusqProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect 'Linea para seleccionar la fila entera
        Llenar_Completo()
    End Sub

    Private Sub Llenar_Completo()
        dgvBusqProveedor.DataSource = Busqueda_Datos("SELECT * FROM PROVEEDOR", False)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If txtBusqueda.Text = Nothing Then
            Llenar_Completo()
        End If
    End Sub
End Class