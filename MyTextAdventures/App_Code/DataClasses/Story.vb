Imports Microsoft.VisualBasic
Imports System.Guid
'BE = Business Entities
Namespace BE
    <Serializable()> _
    Public Class Story
        'All story business entities are serializable so they can be streamed into session state
        Private _StoryId As String
        Private _StoryName As String
        Private _AuthorId As String
        Private _Description As String
        Private _IsPublished As Boolean
        Private _CreatedOn As DateTime
        Private _PublishedOn As DateTime
        Private _StartRoomId As String

        Public Sub New()
            'use guid datatype to create new guid to use as primary key in database
            Me.StoryId = Guid.NewGuid().ToString
            Me.IsPublished = False
            Me.CreatedOn = Date.Now
            Me.PublishedOn = Date.MinValue
        End Sub

        'vb.net properties allow the developer to create get and sets for private properties.
        Public Property StoryId() As String
            Get
                Return _StoryId
            End Get
            Set(ByVal value As String)
                _StoryId = value
            End Set
        End Property

        Public Property StoryName() As String
            Get
                Return _StoryName
            End Get
            Set(ByVal value As String)
                _StoryName = value
            End Set
        End Property
        Public Property AuthorId() As String
            Get
                Return _AuthorId
            End Get
            Set(ByVal value As String)
                _AuthorId = value
            End Set
        End Property
        Public Property IsPublished() As Boolean
            Get
                Return _IsPublished
            End Get
            Set(ByVal value As Boolean)
                _IsPublished = value
            End Set
        End Property
        Public Property PublishedOn() As DateTime
            Get
                Return _PublishedOn
            End Get
            Set(ByVal value As DateTime)
                _PublishedOn = value
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

        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Public Property StartRoomId() As String
            Get
                Return _StartRoomId
            End Get
            Set(ByVal value As String)
                _StartRoomId = value
            End Set
        End Property


    End Class
End Namespace