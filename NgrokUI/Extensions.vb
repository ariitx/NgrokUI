Imports System.Runtime.CompilerServices

Module Extensions
    <Extension>
    Public Sub SetRegex(txtbox As TextBox, ByVal regex As String)
        txtbox.SetExProperty("regex", regex)
        RemoveHandler txtbox.TextChanged, AddressOf SetRegexHandler_TextChanged
        AddHandler txtbox.TextChanged, AddressOf SetRegexHandler_TextChanged
    End Sub

    Private Sub SetRegexHandler_TextChanged(sender As Object, e As EventArgs)
        Static loading As Boolean
        If loading Then Exit Sub
        loading = True

        Dim t As TextBox = CType(sender, TextBox)
        Dim oldValue As String = t.GetExPropertyStr("oldValue")

        Dim r As New System.Text.RegularExpressions.Regex(t.GetExPropertyStr("regex"))
        Dim s As Integer = t.SelectionStart

        If Not t.Text.IsEmpty AndAlso Not r.IsMatch(t.Text) Then
            t.Text = oldValue
            t.SelectionStart = If(s > 0, s - 1, 0)
        Else
            t.SetExProperty("oldValue", t.Text)
        End If

        loading = False
    End Sub
End Module
