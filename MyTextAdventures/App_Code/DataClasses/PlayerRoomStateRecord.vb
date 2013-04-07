Imports Microsoft.VisualBasic
Namespace BE
    <Serializable()> _
    Public Class PlayerRoomStateRecord


        Private _PlayerRoomStateRecordId As String
        Private _PlayerId As String
        Private _RoomStateId As String
        Private _RoomId As String

        Public Sub New()
            PlayerRoomStateRecordId = Guid.NewGuid.ToString
        End Sub


        Public Property RoomId() As String
            Get
                Return _RoomId
            End Get
            Set(ByVal value As String)
                _RoomId = value
            End Set
        End Property


        Public Property RoomStateId() As String
            Get
                Return _RoomStateId
            End Get
            Set(ByVal value As String)
                _RoomStateId = value
            End Set
        End Property


        Public Property PlayerId() As String
            Get
                Return _PlayerId
            End Get
            Set(ByVal value As String)
                _PlayerId = value
            End Set
        End Property


        Public Property PlayerRoomStateRecordId() As String
            Get
                Return _PlayerRoomStateRecordId
            End Get
            Set(ByVal value As String)
                _PlayerRoomStateRecordId = value
            End Set
        End Property

    End Class
End Namespace