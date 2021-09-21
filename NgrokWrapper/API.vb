Namespace Ngrok
    Public Class API
#Region "GET /api/tunnels"
        Public Class GET_API_Tunnels
            Property Tunnels As List(Of Tunnel_Detail)
            Property URI As String
        End Class

        Public Class Tunnel_Detail
            Property Name As String
            Property URI As String
            Property Public_URL As String
            Property Proto As String
            Property Config As TD_Config
            Property Metrics As TD_Metrics
        End Class

        Public Class TD_Config
            Property Addr As String
            Property Inspect As Boolean
        End Class

        Public Class TD_Metrics
            Property Conns As Metrics_Detail
            Property Http As Metrics_Detail
        End Class

        Public Class Metrics_Detail
            Property Count As Integer
            Property Gauge As Integer
            Property Rate1 As Integer
            Property Rate5 As Integer
            Property Rate15 As Integer
            Property P50 As Integer
            Property P90 As Integer
            Property P95 As Integer
            Property P99 As Integer
        End Class
#End Region

    End Class
End Namespace
