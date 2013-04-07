Imports Microsoft.VisualBasic
Namespace BE
    <Serializable()> _
    Public Class PlayerInventory

        Private _PlayerInventoryId As String
        Private _PlayerId As String
        Private _ItemId As String

        Public Sub New()
            PlayerInventoryId = Guid.NewGuid.ToString
        End Sub

        Public Sub New(ByVal playerid As String, ByVal itemid As String)
            Me.PlayerInventoryId = Guid.NewGuid.ToString
            Me.PlayerId = playerid
            Me.ItemId = itemid
        End Sub

        Public Property ItemId() As String
            Get
                Return _ItemId
            End Get
            Set(ByVal value As String)
                _ItemId = value
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

        Public Property PlayerInventoryId() As String
            Get
                Return _PlayerInventoryId
            End Get
            Set(ByVal value As String)
                _PlayerInventoryId = value
            End Set
        End Property


    End Class
End Namespace