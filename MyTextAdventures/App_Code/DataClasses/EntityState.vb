Imports Microsoft.VisualBasic

Namespace BE
    <Serializable()> _
    Public Class EntityState
        Private _EntityStateId As String
        Private _EntityStateName As String
        Private _EntityId As String
        Private _Description As String
        Private _LongDescription As String
        Private _AvailableItemId As String
        Private _Visible As Boolean
        Private _ActivationVerb As String
        Private _ActivationText As String
        Private _PointsAwarded As Integer
        Private _VerbUpdatesRoomState As Boolean
        Private _Hint As String
        Private _NextEntityStateId As String
        Private _ItemIdRequiredforRoomStateUpdate As String

        Public Sub New()
            Me.EntityStateId = Guid.NewGuid.ToString

        End Sub



        Public Property ActivationText() As String
            Get
                Return _ActivationText
            End Get
            Set(ByVal value As String)
                _ActivationText = value
            End Set
        End Property


        Public Property EntityStateId() As String
            Get
                Return _EntityStateId
            End Get
            Set(ByVal value As String)
                _EntityStateId = value
            End Set
        End Property


        Public Property EntityStateName() As String
            Get
                Return _EntityStateName
            End Get
            Set(ByVal value As String)
                _EntityStateName = value
            End Set
        End Property



        Public Property EntityId() As String
            Get
                Return _EntityId
            End Get
            Set(ByVal value As String)
                _EntityId = value
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


        Public Property AvailableItemId() As String
            Get
                Return _AvailableItemId
            End Get
            Set(ByVal value As String)
                _AvailableItemId = value
            End Set
        End Property


        Public Property Visible() As Boolean
            Get
                Return _Visible
            End Get
            Set(ByVal value As Boolean)
                _Visible = value
            End Set
        End Property

        Public Property ActivationVerb() As String
            Get
                Return _ActivationVerb
            End Get
            Set(ByVal value As String)
                _ActivationVerb = value
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

        Public Property VerbUpdatesRoomState() As Boolean
            Get
                Return _VerbUpdatesRoomState
            End Get
            Set(ByVal value As Boolean)
                _VerbUpdatesRoomState = value
            End Set
        End Property


        Public Property Hint() As String
            Get
                Return _Hint
            End Get
            Set(ByVal value As String)
                _Hint = value
            End Set
        End Property

        Public Property NextEntityStateId() As String
            Get
                Return _NextEntityStateId
            End Get
            Set(ByVal value As String)
                _NextEntityStateId = value
            End Set
        End Property


        Public Property ItemIdRequiredforRoomStateUpdate() As String
            Get
                Return _ItemIdRequiredforRoomStateUpdate
            End Get
            Set(ByVal value As String)
                _ItemIdRequiredforRoomStateUpdate = value
            End Set
        End Property

    End Class
End Namespace