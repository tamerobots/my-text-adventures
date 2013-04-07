Imports Microsoft.VisualBasic
Namespace BE
    <Serializable()> _
    Public Class PlayerEntityStateRecord


        Private _PlayerEntityStateRecordId As String
        Private _PlayerId As String
        Private _EntityStateId As String
        Private _EntityId As String

        Public Sub New()
            PlayerEntityStateRecordId = Guid.NewGuid.ToString
        End Sub


        Public Property EntityId() As String
            Get
                Return _EntityId
            End Get
            Set(ByVal value As String)
                _EntityId = value
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


        Public Property PlayerId() As String
            Get
                Return _PlayerId
            End Get
            Set(ByVal value As String)
                _PlayerId = value
            End Set
        End Property


        Public Property PlayerEntityStateRecordId() As String
            Get
                Return _PlayerEntityStateRecordId
            End Get
            Set(ByVal value As String)
                _PlayerEntityStateRecordId = value
            End Set
        End Property

    End Class
End Namespace