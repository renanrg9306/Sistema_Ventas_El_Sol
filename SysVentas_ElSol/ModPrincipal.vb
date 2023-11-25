Imports System.Data.SqlClient

Module ModPrincipal
    Public Conexion As New SqlConnection

    Public boton As New MsgBoxStyle
    Public StrComando As String
    Public boolPrecio As Boolean
    Public boolEncontrado As Boolean

    Public Sub Abrir_Conexion()
        Try
            Conexion.ConnectionString = "Data Source=(local);Initial Catalog=SysVentasElSol;Integrated Security=true"
            Conexion.Open()
        Catch ex As Exception
            MsgBox("HA OCURRIDO UN ERROR EN LA CONEXION")
        End Try
    End Sub

    Public Sub Cerrar_Conexion()
        Conexion.Close()
    End Sub

    Public Sub Hijo(ByVal Hijos As Form, ByVal Padre As Form)
        Hijos.MdiParent = Padre
        Hijos.Show()
    End Sub

    Public Function Mostrar_ID(ByVal Sentencia As String) As String
        Dim daId As New SqlDataAdapter(Sentencia, Conexion)
        Dim dtId As New DataTable

        Abrir_Conexion()
        daId.Fill(dtId)
        Cerrar_Conexion()

        If dtId.Rows.Count = 0 Then Mostrar_ID = (CodigoID(1)) : Exit Function
        Mostrar_ID = CodigoID(dtId.Rows.Count + 1)
    End Function

    Public Function CodigoID(ByVal Numero As Integer) As String
        Dim Retorno As String = ""
        Select Case Numero
            Case 1 To 9
                Retorno = "000000" & Numero
            Case 10 To 99
                Retorno = "00000" & Numero
            Case 100 To 999
                Retorno = "0000" & Numero
            Case 1000 To 9999
                Retorno = "000" & Numero
            Case 10000 To 99999
                Retorno = "00" & Numero
            Case 100000 To 999999
                Retorno = "0" & Numero
            Case 1000000
                Retorno = "1000000"
        End Select
        CodigoID = Retorno
    End Function

    Public Sub Validacion_Solo_Letras(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsLetter(e.KeyChar)) And e.KeyChar.ToString <> vbBack And e.KeyChar.ToString <> " " Then e.Handled = True
    End Sub

    Public Sub Validacion_Numeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (IsNumeric(e.KeyChar)) And e.KeyChar.ToString <> vbBack Then e.Handled = True
    End Sub

    Public Sub Validacion_Flotantes(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txtDecimal As TextBox)
        If Not (IsNumeric(e.KeyChar)) And e.KeyChar.ToString <> vbBack Then
            e.Handled = True
        End If

        If Not (txtDecimal.Text.Contains(".")) And e.KeyChar.ToString = "." Then
            e.Handled = False : boolPrecio = True
        End If

        'Dim cadena = txtDecimal.Text & e.KeyChar 'Se usa para mostrar el total de caracteres del textbox
        'For i = 1 To cadena.Length
        '    If Strings.Mid(cadena, i, 1) = "." And (cadena.Length - i) = 3 Then
        '        boolEncontrado = True
        '    End If
        'Next
    End Sub

    Public Function Mensaje(ByVal Cadena As String, ByVal Formato As MsgBoxStyle, ByVal Titulo As String) As MsgBoxResult
        Mensaje = MsgBox(Cadena, Formato, Titulo)
    End Function

    Public Function Devolver_Datos(ByVal sentencia As String) As DataTable
        Dim daLlenar As New SqlDataAdapter(sentencia, Conexion)
        Dim dtLlenar As New DataTable

        Abrir_Conexion()
        daLlenar.Fill(dtLlenar)
        Cerrar_Conexion()

        Devolver_Datos = dtLlenar
    End Function

    'Llenar Combos_Productos y marcas y vehiculo
    Public Sub Llenar_Combo_Productos(ByVal sentencia As String, ByVal combo As ComboBox)
        combo.DataSource = Devolver_Datos(sentencia)

        combo.DisplayMember = "NombrePro"
        combo.ValueMember = "Id_Producto"
    End Sub

    Public Sub Llenar_Combo_Marca(ByVal sentencia As String, ByVal combo As ComboBox)
        combo.DataSource = Devolver_Datos(sentencia)

        combo.DisplayMember = "Marca"
        combo.ValueMember = "Id_Marca"
    End Sub

    Public Sub Llenar_Combo_Vehiculo(ByVal sentencia As String, ByVal combo As ComboBox)
        combo.DataSource = Devolver_Datos(sentencia)

        combo.DisplayMember = "Tipo"
        combo.ValueMember = "Id_Vehiculo"
    End Sub

    'Insercion de productos y marcas nuevas
    Public Sub Insertar_Producto(ByVal Producto As String, ByVal Id As Integer)
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO PRODUCTO VALUES (@Id_Producto,@NombrePro)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Producto", Id))
            .Add(New SqlClient.SqlParameter("@NombrePro", Producto))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Public Sub Insertar_Marca(ByVal Marca As String, ByVal Id As Integer)
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO MARCA VALUES (@Id_Marca,@Marca)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Marca", Id))
            .Add(New SqlClient.SqlParameter("@Marca", Marca))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Public Sub Insertar_Tipo_Vehiculo(ByVal Tipo As String, ByVal Id As Integer)
        Dim ComandoSQL As New SqlCommand
        StrComando = "INSERT INTO TIPO_VEHICULO VALUES (@Id_Vehiculo,@Tipo)"
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter("@Id_Vehiculo", Id))
            .Add(New SqlClient.SqlParameter("@Tipo", Tipo))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    'guardar relacion entre marca y producto
    Public Sub RELACION_PRODUCTO_MARCA(ByVal sentencia As String, ByVal Parametro1 As String, _
                                       ByVal Parametro2 As String, ByVal IdPro As Integer, ByVal IdMarc As Integer)
        Dim ComandoSQL As New SqlCommand
        StrComando = sentencia
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            .Add(New SqlClient.SqlParameter(Parametro1, IdPro))
            .Add(New SqlClient.SqlParameter(Parametro2, IdMarc))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub

    Public Sub Insertar_Producto_Modificado(ByVal Sentencia As String, ByVal Cantidad As Integer, _
                                         ByVal Local As Integer, ByVal Bodega As Integer, _
                                         ByVal precio As Double, ByVal Combo As ComboBox)
        Dim ComandoSQL As New SqlCommand
        StrComando = Sentencia
        Abrir_Conexion()
        ComandoSQL.CommandText = StrComando
        ComandoSQL.Connection = Conexion

        With ComandoSQL.Parameters
            If Combo.Text = "BODEGA A LOCAL" Then
                .Add(New SqlClient.SqlParameter("@EL", Cantidad + Local))
                .Add(New SqlClient.SqlParameter("@EB", Bodega - Cantidad))
            Else
                .Add(New SqlClient.SqlParameter("@EL", Local - Cantidad))
                .Add(New SqlClient.SqlParameter("@EB", Bodega + Cantidad))
            End If

            .Add(New SqlClient.SqlParameter("@PU", precio))
        End With
        ComandoSQL.ExecuteNonQuery()
        Cerrar_Conexion()
    End Sub
End Module
