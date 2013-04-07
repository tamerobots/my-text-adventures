Imports Microsoft.VisualBasic

Namespace BE
    <Serializable()> _
    Public Class Item

        Private _ItemId As String
        Private _ItemName As String
        Private _Description As String
        Private _LongDescription As String
        Private _ParentStateId As String
        Private _Hint As String
        Private _StoryId As String


        Public Sub New()
            ItemId = Guid.NewGuid.ToString

        End Sub


        Public Property StoryId() As String
            Get
                Return _StoryId
            End Get
            Set(ByVal value As String)
                _StoryId = value
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

        Public Property ParentStateId() As String
            Get
                Return _ParentStateId
            End Get
            Set(ByVal value As String)
                _ParentStateId = value
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


        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return _ItemName
            End Get
            Set(ByVal value As String)
                _ItemName = value
            End Set
        End Property

        Public Property ItemId() As String
            Get
                Return _ItemId
            End Get
            Set(ByVal value As String)
                _ItemId = value
            End Set
        End Property

    End Class
End Namespace