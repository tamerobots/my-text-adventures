Imports Microsoft.VisualBasic

Namespace BE
    <Serializable()> _
    Public Class Room
        Private _RoomId As String
        Private _StoryId As String
        Private _RoomName As String
        Private _StartRoomStateId As String
        Private _NorthRoomId As String
        Private _EastRoomId As String
        Private _SouthRoomId As String
        Private _WestRoomId As String

        Public Sub New()
            RoomId = Guid.NewGuid().ToString
        End Sub

        Public Property RoomId() As String
            Get
                Return _RoomId
            End Get
            Set(ByVal value As String)
                _RoomId = value
            End Set
        End Property
        Public Property StoryId() As String
            Get
                Return _StoryId
            End Get
            Set(ByVal value As String)
                _StoryId = value
            End Set
        End Property
        Public Property RoomName() As String
            Get
                Return _RoomName
            End Get
            Set(ByVal value As String)
                _RoomName = value
            End Set
        End Property
        Public Property StartRoomStateId() As String
            Get
                Return _StartRoomStateId
            End Get
            Set(ByVal value As String)
                _StartRoomStateId = value
            End Set
        End Property
        Public Property NorthRoomId() As String
            Get
                Return _NorthRoomId
            End Get
            Set(ByVal value As String)
                _NorthRoomId = value
            End Set
        End Property
        Public Property EastRoomId() As String
            Get
                Return _EastRoomId
            End Get
            Set(ByVal value As String)
                _EastRoomId = value
            End Set
        End Property
        Public Property SouthRoomId() As String
            Get
                Return _SouthRoomId
            End Get
            Set(ByVal value As String)
                _SouthRoomId = value
            End Set
        End Property
        Public Property WestRoomId() As String
            Get
                Return _WestRoomId
            End Get
            Set(ByVal value As String)
                _WestRoomId = value
            End Set
        End Property

    End Class
End Namespace