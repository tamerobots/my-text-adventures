Imports Microsoft.VisualBasic

Namespace BE
    <Serializable()> _
    Public Class Entity
        'Originally Entity was going to be called 'Object' but Object
        'is of course a VB.NET reserved keyword, so entity will suffice,
        'and is more descriptive anyway

        Private _EntityId As String
        Private _EntityName As String
        Private _Description As String
        Private _RoomId As String
        Private _RoomStateId As String
        Private _visible As Boolean
        Private _startentitystateid As String

        Public Sub New()
            EntityId = Guid.NewGuid().ToString
        End Sub

        Public Property StartEntityStateId() As String
            Get
                Return _startentitystateid
            End Get
            Set(ByVal value As String)
                _startentitystateid = value
            End Set
        End Property

        Public Property Visible() As Boolean
            Get
                Return _visible
            End Get
            Set(ByVal value As Boolean)
                _visible = value
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

        Public Property RoomId() As String
            Get
                Return _RoomId
            End Get
            Set(ByVal value As String)
                _RoomId = value
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


        Public Property EntityName() As String
            Get
                Return _EntityName
            End Get
            Set(ByVal value As String)
                _EntityName = value
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


    End Class
End Namespace