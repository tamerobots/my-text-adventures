Imports Microsoft.VisualBasic

Namespace BE
    <Serializable()> _
    Public Class Author
        Private _AuthorId As String
        Private _UserName As String
        Private _FirstName As String
        Private _LastName As String
        Private _Password As String
        Private _Email As String
        Private _CreatedOn As DateTime

        Public Sub New()
            AuthorId = Nothing
        End Sub

        Public Property AuthorId() As String
            Get
                Return _AuthorId
            End Get
            Set(ByVal value As String)
                _AuthorId = value
            End Set
        End Property
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        Public Property CreatedOn() As DateTime
            Get
                Return _CreatedOn
            End Get
            Set(ByVal value As DateTime)
                _CreatedOn = value
            End Set
        End Property

    End Class
End Namespace