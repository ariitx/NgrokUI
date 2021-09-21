Public Class Utility
    ''' <summary>
    ''' Get public IP address from service provider. This can be used to determine for internet connection as well.
    ''' </summary>
    Public Shared Function GetPublicIP() As String
        Static services As List(Of String) = New String() {"https://api.ipify.org", "https://icanhazip.com/"}.ToList
        Static strIP As String = ""
        If Not strIP.IsEmpty Then Return strIP
        For Each service In services
            Try
                strIP = Ape.EL.Misc.WebHelper.GetWebAPI(service, "")
            Catch ex As Exception
                'ignore error
            End Try

            'if ip address is retrieved, exit for.
            If Not strIP.IsEmpty Then Exit For
        Next

        'return the ip address regardless successful or not.
        Return strIP
    End Function

    Public Shared Function MiliSecondToMinuteAndSeconds(ByVal value As Integer) As String
        value = value \ 1000
        If value <= 60 Then
            Return value & " s"
        Else
            Return value \ 60 & " m " & value Mod 60 & " s"
        End If
    End Function
End Class
