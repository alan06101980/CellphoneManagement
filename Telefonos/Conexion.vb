Imports System.Data
Imports System.Data.SqlServerCe
Imports System.IO


Module Conexion

    Public connectionString As String = "Data Source=|DataDirectory|\Telefonos.sdf"
    'Public connectionString As String = "Data Source=D:\Teléfonos_Inicial\Telefonos\Telefonos\Telefonos.sdf"
    Public cn As New SqlCeConnection(connectionString)

End Module






