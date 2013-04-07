Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class EntityAccessor
        Inherits DataAccessor


        Private strSQL As String

        Public Sub Add(ByVal input As BE.Entity)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.EntityId
            strSQL += "', '" + input.EntityName
            strSQL += "', '" + input.Description
            strSQL += "', '" + input.RoomId
            strSQL += "', '" + input.RoomStateId
            strSQL += "', " + input.Visible.ToString
            strSQL += ", '" + input.StartEntityStateId
            strSQL += "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetEntity(ByVal EntityId As String) As BE.Entity
            Dim DataSet = New DataSet
            Dim outputEntity As New BE.Entity
            DataSet = MyBase.GetObjectDataSet(GetType(BE.Entity), "EntityId", EntityId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    outputEntity.EntityId = .Item("EntityId").ToString
                    outputEntity.EntityName = .Item("EntityName").ToString
                    outputEntity.Description = .Item("Description").ToString
                    outputEntity.RoomId = .Item("RoomId").ToString
                    outputEntity.RoomStateId = .Item("RoomStateId").ToString
                    outputEntity.Visible = .Item("Visible").ToString
                    outputEntity.StartEntityStateId = .Item("StartEntityStateId").ToString

                End With
                Return outputEntity
            End If
        End Function
        Public Function getEntitiesByRoomStateId(ByVal RoomStateId As String) As DataSet
            Dim STRSQL As String = "SELECT E.* " & _
            "FROM Entity AS E " & _
            "WHERE E.RoomStateId = '" + RoomStateId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function

        Public Function getEntitiesByRoomId(ByVal RoomId As String) As DataSet
            Dim STRSQL As String = "SELECT E.* " & _
            "FROM Entity AS E " & _
            "WHERE E.RoomId = '" + RoomId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function


        Public Sub Update(ByVal input As BE.Entity)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET Entityid='" + input.EntityId
            strSQL += "', EntityName='" + input.EntityName
            strSQL += "', RoomId='" + input.RoomId
            strSQL += "', RoomStateId='" + input.RoomStateId
            strSQL += "', Visible=" + input.Visible.ToString
            strSQL += ", StartEntityStateId='" + input.StartEntityStateId
            strSQL += "' WHERE Entityid='" + input.EntityId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Overloads Sub Delete(ByVal Entityid As String)
            MyBase.Delete(GetType(BE.Entity), "EntityId", Entityid)
        End Sub

    End Class
End Namespace