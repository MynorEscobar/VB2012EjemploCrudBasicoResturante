Module ModuloConexion
    'Cadena de conexion se coloca dentro de comillas
    Public conex As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurante.accdb")
    'crear metodo para conexion 
    Public Sub abrirConexion()
        Try
            'con esta linea se abre la conexión para poder realizar cualquier proceso
            conex.Open()
        Catch ex As Exception
            MsgBox("Error en conexión")
        End Try
    End Sub
    'crear metodo para desconectar
    Public Sub cerrarConexion()
        Try
            conex.Close()
        Catch ex As Exception

        End Try
    End Sub
End Module
