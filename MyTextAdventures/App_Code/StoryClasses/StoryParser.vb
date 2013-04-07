Imports Microsoft.VisualBasic

Namespace MTATools
    <Serializable()> _
    Public Class StoryParser
        Private genericwords As ArrayList

        Public Sub New()
            genericwords = New ArrayList
            genericwords.Add("Look")
            genericwords.Add("Open")
            genericwords.Add("Go")
            genericwords.Add("Hint")
        End Sub

        Public Function ParseString(ByVal input As String) As StringCollection
            Dim strcoll As New StringCollection
            If input <> String.Empty Then
                'add a space to allow delimitation of last word for split
                Dim temparray As String()
                temparray = input.Split(" ")

                For Each value As String In temparray
                    strcoll.Add(value)
                Next
            End If
            Return strcoll
        End Function

        Public Function isgenerickeyword(ByVal input As String) As Boolean
            '**currently unused
            For Each value As String In genericwords
                If String.Compare(value, input, True) = 0 Then
                    Return True
                End If
            Next
            Return False
        End Function


    End Class
End Namespace