Public Class Form1

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        abrirConexion()
        'elemento par escribir sql
        Dim sqlSelect As String
        sqlSelect = "select * from clientes where nit='" & txtNit.Text & "'"

        'objeto para ejecutar comandos en la base de datos
        Dim ejecutar As New OleDb.OleDbCommand
        'tipo de datos que aceptara
        ejecutar.CommandType = CommandType.Text
        'conexion a utilizar
        ejecutar.Connection = conex
        'asignar el texto que se ejecutara posteriormente
        ejecutar.CommandText = sqlSelect

        'utilizar un objeto que reciba el resultado de la busqueda para poderlo utilizar en vb
        Dim guardarSelect As OleDb.OleDbDataReader
        'ejecutar el codigo sql (select)y almacena el resultado obtenido
        guardarSelect = ejecutar.ExecuteReader
        'lee datos de la busqueda (puede contar con datos o no)
        guardarSelect.Read()

        'verificar si la busqueda cuenta con registros
        If guardarSelect.HasRows Then
            'cuento con al menos 1 registro
            'asignar valores a las cajas de texto respectivas
            txtNombre.Text = guardarSelect!nombre
            txtDireccion.Text = guardarSelect!direccion
            deshabilitarControlesCliente()
        Else
            'no localizo datos
            MsgBox("nit no existe en el sistema, deberá agregar al cliente")
            borrarDatos()
            habilitarControlesCliente()

        End If
        guardarSelect.Close() 'cerrar el objeto que almacena los resultados de la busqueda
        cerrarConexion()
    End Sub

    Private Sub borrarDatos()

        txtDireccion.Text = ""
        txtNombre.Text = ""
    End Sub
    Private Sub habilitarControlesCliente()
        txtDireccion.Enabled = True
        txtNombre.Enabled = True
        btnAgregarCliente.Enabled = True

    End Sub
    Private Sub deshabilitarControlesCliente()
        txtDireccion.Enabled = False
        txtNombre.Enabled = False
        btnAgregarCliente.Enabled = False
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        abrirConexion()
        Dim sqlInsert As String
        sqlInsert = "insert into clientes(nit, nombre, direccion) values ('" & txtNit.Text & "','" & txtNombre.Text & "','" & txtDireccion.Text & "')"
        'objeto para ejecutar comandos en la base de datos
        Dim ejecutar As New OleDb.OleDbCommand
        'tipo de datos que aceptara
        ejecutar.CommandType = CommandType.Text
        'conexion a utilizar
        ejecutar.Connection = conex
        'asignar el texto que se ejecutara posteriormente
        ejecutar.CommandText = sqlInsert

        'ejecutar codigo en base de datos
        ejecutar.ExecuteNonQuery()
        MsgBox("datos almacenados con exito")

        txtNit.Text = ""
        borrarDatos()

        cerrarConexion()

    End Sub
End Class
