Imports Microsoft.VisualBasic
Namespace BE
    <Serializable()> _
    Public Class RoomState
        Private _RoomStateId As String
        Private _RoomStateName As String
        Private _ParentRoomId As String
        Private _canGoNorth As Boolean
        Private _canGoEast As Boolean
        Private _canGoSouth As Boolean
        Private _canGoWest As Boolean
        Private _PointsAwarded As Integer
        Private _Description As String
        Private _LongDescription As String
        Private _isEndGameTrigger As Boolean

        Private _nextRoomStateId As String

        Public Sub New()
            Me.RoomStateId = Guid.NewGuid().ToString
            Me.canGoEast = False
            Me.canGoNorth = False
            Me.canGoSouth = False
            Me.canGoWest = False
            Me.PointsAwarded = 0
            Me.isEndGameTrigger = False

        End Sub


        Public Property RoomStateId() As String
            Get
                Return _RoomStateId
            End Get
            Set(ByVal value As String)
                _RoomStateId = value
            End Set
        End Property

        Public Property RoomStateName() As String
            Get
                Return _RoomStateName
            End Get
            Set(ByVal value As String)
                _RoomStateName = value
            End Set
        End Property

        Public Property ParentRoomId() As String
            Get
                Return _ParentRoomId
            End Get
            Set(ByVal value As String)
                _ParentRoomId = value
            End Set
        End Property

        Public Property canGoNorth() As Boolean
            Get
                Return _canGoNorth
            End Get
            Set(ByVal value As Boolean)
                _canGoNorth = value
            End Set
        End Property

        Public Property canGoEast() As Boolean
            Get
                Return _canGoEast
            End Get
            Set(ByVal value As Boolean)
                _canGoEast = value
            End Set
        End Property

        Public Property canGoSouth() As Boolean
            Get
                Return _canGoSouth
            End Get
            Set(ByVal value As Boolean)
                _canGoSouth = value
            End Set
        End Property

        Public Property canGoWest() As Boolean
            Get
                Return _canGoWest
            End Get
            Set(ByVal value As Boolean)
                _canGoWest = value
            End Set
        End Property

        Public Property PointsAwarded() As Integer
            Get
                Return _PointsAwarded
            End Get
            Set(ByVal value As Integer)
                _PointsAwarded = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Public Property LongDescription() As String
            Get
                Return _LongDescription
            End Get
            Set(ByVal value As String)
                _LongDescription = value
            End Set
        End Property

        Public Property isEndGameTrigger() As Boolean
            Get
                Return _isEndGameTrigger
            End Get
            Set(ByVal value As Boolean)
                _isEndGameTrigger = value
            End Set
        End Property



        Public Property nextRoomStateId() As String
            Get
                Return _nextRoomStateId
            End Get
            Set(ByVal value As String)
                _nextRoomStateId = value
            End Set
        End Property


    End Class
End Namespace