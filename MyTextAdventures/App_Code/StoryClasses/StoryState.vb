Imports Microsoft.VisualBasic
Namespace MTATools
    <Serializable()> _
    Public Class StoryState
        Private _player As BE.Player
        Private _currentStory As BE.Story
        Private _currentauthor As BE.Author
        Private _currentroom As BE.Room
        Private _currentroomstate As BE.RoomState
        Private _currententities As ArrayList
        Private _currententitystates As ArrayList
        Private _inventoryitems As ArrayList
        Private _availableitems As ArrayList
        'nonserialized attribute stops these properties being added to the viewstate stream
        'they do not need to be stored 'twixt postbacks.
        <NonSerialized()> Dim roomacc As New DAL.RoomAccessor
        <NonSerialized()> Dim roomstateacc As New DAL.RoomStateAccessor
        <NonSerialized()> Dim authoracc As New DAL.AuthorAccessor
        <NonSerialized()> Dim storyacc As New DAL.StoryAccessor
        <NonSerialized()> Dim playeracc As New DAL.PlayerAccessor

        Public Sub New(ByVal StoryId As String)
            Me.Story = storyacc.GetStory(StoryId)
            'the below is set in play.aspx load as it depends on the user
            'Dim newplayer As BE.Player = New BE.Player
            'playeracc.Add(newplayer)
            'Me.Player = newplayer
            Me.Author = authoracc.GetAuthor(Story.AuthorId)
            Me.Room = roomacc.GetRoom(Story.StartRoomId)
            Me.RoomState = roomstateacc.GetRoomState(Room.StartRoomStateId)
            Me.currententities = New ArrayList
            Me.currententitystates = New ArrayList
            Me.inventoryitems = New ArrayList
            Me.availableitems = New ArrayList

        End Sub

        'You could make another Overloaded New here, with a playerid argument,
        ' which could load a player if you have time to implement that functionality.





        Public Property availableitems() As ArrayList
            Get
                Return _availableitems
            End Get
            Set(ByVal value As ArrayList)
                _availableitems = value
            End Set
        End Property


        Public Property inventoryitems() As ArrayList
            Get
                Return _inventoryitems
            End Get
            Set(ByVal value As ArrayList)
                _inventoryitems = value
            End Set
        End Property


        Public Property currententitystates() As ArrayList
            Get
                Return _currententitystates
            End Get
            Set(ByVal value As ArrayList)
                _currententitystates = value
            End Set
        End Property


        Public Property currententities() As ArrayList
            Get
                Return _currententities
            End Get
            Set(ByVal value As ArrayList)
                _currententities = value
            End Set
        End Property


        Public Property Player() As BE.Player
            Get
                Return _player
            End Get
            Set(ByVal value As BE.Player)
                _player = value
            End Set
        End Property


        Public Property RoomState() As BE.RoomState
            Get
                Return _currentroomstate
            End Get
            Set(ByVal value As BE.RoomState)
                _currentroomstate = value
            End Set
        End Property

        Public Property Room() As BE.Room
            Get
                Return _currentroom
            End Get
            Set(ByVal value As BE.Room)
                _currentroom = value
            End Set
        End Property

        Public Property Author() As BE.Author
            Get
                Return _currentauthor
            End Get
            Set(ByVal value As BE.Author)
                _currentauthor = value
            End Set
        End Property

        Public Property Story() As BE.Story
            Get
                Return _currentStory
            End Get
            Set(ByVal value As BE.Story)
                _currentStory = value
            End Set
        End Property


    End Class
End Namespace