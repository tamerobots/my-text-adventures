Imports Microsoft.VisualBasic
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Attribute
Namespace DAL
    Public Class DataAccessor

        Public Sub ExecuteCommand(ByVal strSQL As String)
            'This can be used by subclasses that inherit this class to execute SQL select, insert, delete etc statements
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            'Dim myConnection = New MySqlConnection(ConfigurationManager.ConnectionStrings("MTAConnectionString").ConnectionString)
            Dim myConnection = New MySqlConnection("server=localhost; user id=adminuser; password=!ifdb117; database=mta; pooling=false;")
            command.Connection = myConnection
            command.CommandType = CommandType.Text
            myConnection.Open()
            Try
                command.ExecuteNonQuery()
            Catch ex As Exception
                'MsgBox(ex.Message)
                MsgBox("There was a problem communicating with the database. Please go back a page, check your data and try again.")
            End Try

            myConnection.Close()
        End Sub

        Public Function GetObjectDataSet(ByVal inputType As Type, ByVal inputPK As String, ByVal inputID As String) As DataSet
            'Return a dataset for use populating gridviews using primary key name + primary key value + table name via type
            Dim strSQL As String
            strSQL = "SELECT * FROM " + inputType.Name
            strSQL += " WHERE " + inputPK + "= '" + inputID + "'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            Dim myConnection = New MySqlConnection("server=localhost; user id=adminuser; password=!ifdb117; database=mta; pooling=false;")
            command.Connection = myConnection
            command.CommandType = CommandType.Text
            myConnection.Open()
            Dim myDataAdapter As MySqlDataAdapter
            myDataAdapter = New MySqlDataAdapter(strSQL, myConnection)
            Dim myDataSet = New DataSet
            myDataAdapter.Fill(myDataSet)
            myConnection.Close()
            Return myDataSet
        End Function

        Public Function GetObjectDataSet(ByVal inputSQL As String) As DataSet
            'Have option to get dataset via sql statement
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = inputSQL
            Dim myConnection = New MySqlConnection("server=localhost; user id=adminuser; password=!ifdb117; database=mta; pooling=false;")
            command.Connection = myConnection
            command.CommandType = CommandType.Text
            myConnection.Open()
            Dim myDataAdapter As MySqlDataAdapter
            myDataAdapter = New MySqlDataAdapter(inputSQL, myConnection)
            Dim myDataSet = New DataSet
            myDataAdapter.Fill(myDataSet)
            myConnection.Close()
            Return myDataSet
        End Function

        Public Sub Delete(ByVal inputType As Type, ByVal inputPK As String, ByVal inputID As String)
            'deletes any record from any table according to parameters
            Dim strSQL As String
            strSQL = "DELETE FROM " + inputType.Name
            strSQL += " WHERE " + inputPK + "= '" + inputID + "'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            Dim myConnection = New MySqlConnection("server=localhost; user id=adminuser; password=!ifdb117; database=mta; pooling=false;")
            command.Connection = myConnection
            command.CommandType = CommandType.Text
            myConnection.Open()
            Try
                command.ExecuteNonQuery()
            Catch ex As Exception

                MsgBox("There was a problem deleting a record. Please go back and try again.")
            End Try
            myConnection.Close()
        End Sub
    End Class
End Namespace