Imports Microsoft.VisualBasic
Imports System.Guid

Namespace BE
    <Serializable()> _
    Public Class Player

        Private _PlayerId As String
        'Private _UserName As String
        Private _PlayerFirstName As String
        Private _PlayerLastName As String
        Private _AuthorId As String
        Private _CurrentRoomId As String
        Private intPoints As Integer
        Private _CreatedOn As DateTime
        Private _LastPlayed As DateTime


        Public Sub New()
            Me.PlayerId = Guid.NewGuid().ToString
            'Remember to handle errors and duplicates
            'Me.PlayerId = "420aeb96-b73d-44d1-8431-c9ea6b7f0a5c"
            Me.CreatedOn = Date.Now
            Me.LastPlayed = Date.Now
            Me.Points = 0



        End Sub

        Public Property PlayerId() As String
            Get
                Return _PlayerId
            End Get
            Set(ByVal value As String)
                _PlayerId = value
            End Set
        End Property


        'Public Property UserName() As String
        '    Get
        '        Return _UserName
        '    End Get
        '    Set(ByVal value As String)
        '        _UserName = value
        '    End Set
        'End Property

        Public Property PlayerFirstName() As String
            Get
                Return _PlayerFirstName
            End Get
            Set(ByVal value As String)
                _PlayerFirstName = value
            End Set
        End Property

        Public Property PlayerLastName() As String
            Get
                Return _PlayerLastName
            End Get
            Set(ByVal value As String)
                _PlayerLastName = value
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
        Public Property CurrentRoomId() As String
            Get
                Return _CurrentRoomId
            End Get
            Set(ByVal value As String)
                _CurrentRoomId = value
            End Set
        End Property
        Public Property Points() As Integer
            Get
                Return intPoints
            End Get
            Set(ByVal value As Integer)
                intPoints = value
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

        Public Property LastPlayed() As DateTime
            Get
                Return _LastPlayed
            End Get
            Set(ByVal value As DateTime)
                _LastPlayed = value
            End Set
        End Property



    End Class
End Namespace