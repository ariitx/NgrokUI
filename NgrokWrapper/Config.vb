'read more on config at https://ngrok.com/docs

Friend Class Config
    Public Class ConfigTunnel
        ''' <summary>
        ''' Identify the tunnel by name.
        ''' </summary>
        Property Name As String

        ''' <summary>
        ''' tunnel protocol name, one of http, tcp, tls.
        ''' </summary>
        Property Proto As Protocols 'http
        ''' <summary>
        ''' forward traffic to this local port number or network address.
        ''' </summary>
        Property Addr As String '8888
        ''' <summary>
        ''' enable http request inspection.
        ''' </summary>
        Property Inspect As Boolean 'false
        ''' <summary>
        ''' 	HTTP basic authentication credentials to enforce on tunneled requests.
        ''' </summary>
        Property Auth As String 'bob:bobpassword
        ''' <summary>
        ''' Rewrite the HTTP Host header to this value, or preserve to leave it unchanged.
        ''' </summary>
        Property Host_Header As String '"myapp.dev"
        ''' <summary>
        ''' bind an HTTPS or HTTP endpoint or both true, false, or both.
        ''' </summary>
        Property Bind_TLS As Boolean 'true
        ''' <summary>
        ''' subdomain name to request. If unspecified, uses the tunnel name.
        ''' </summary>
        Property Subdomain As String 'myapp
        ''' <summary>
        ''' hostname to request (requires reserved name and DNS CNAME).
        ''' </summary>
        Property HostName As String 'demo.inconshreveable.com
        ''' <summary>
        ''' PEM TLS certificate at this path to terminate TLS traffic before forwarding locally.
        ''' </summary>
        Property CRT As String 'path//example.crt
        ''' <summary>
        ''' PEM TLS private key at this path to terminate TLS traffic before forwarding locally.
        ''' </summary>
        Property Key As String 'path//example.key
        ' ''' <summary>
        ' ''' PEM TLS certificate authority at this path will verify incoming TLS client connection certificates.
        ' ''' </summary>
        'Property Client_Cas
        ''' <summary>
        ''' bind the remote TCP port on the given address.
        ''' </summary>
        Property Remote_Addr As String '1.tcp.ngrok.io:12345
    End Class

    Property authtoken As String '4nq9771bPxe8ctg7LKr_2ClH7Y15Zqe4bWLWF9p
    Property region As Regions  'us
    Property console_ui As Boolean = True  'true
    Property compress_conn As Boolean = False 'false
    Property http_proxy As String
    Property inspect_db_size As Integer = -1 '50000000
    Property log_level As String 'info
    Property log_format As String 'json
    Property log As String '/var/log/ngrok.log
    Property metadata As String ''{"serial" As String '"00012xa-33rUtz9", "comment" As String '"For customer alan@example.com"}'
    Property root_cas As String 'trusted
    Property socks5_proxy As String '"socks5://localhost:9150"
    Property update As Boolean = False  'false
    Property update_channel As String 'stable
    Property web_addr As String 'localhost:4040
    Property tunnels As New List(Of ConfigTunnel) ':

    Public Sub New()
    End Sub

    Public Function GetConfig() As String
        Return GetConfig(Me)
    End Function

    Shared Function GetConfig(ByVal c As Config) As String
        Dim yml As New System.Text.StringBuilder

        If Not c.authtoken.IsEmpty Then yml.AppendLine(String.Format("authtoken: {0}", c.authtoken))
        If c.region <> Regions.none Then yml.AppendLine(String.Format("region: {0}", c.region.ToString))
        yml.AppendLine(String.Format("console_ui: {0}", c.console_ui))
        yml.AppendLine(String.Format("compress_conn: {0}", c.compress_conn))
        If Not c.http_proxy.IsEmpty Then yml.AppendLine(String.Format("http_proxy: {0}", c.http_proxy))
        If c.inspect_db_size > -1 Then yml.AppendLine(String.Format("inspect_db_size: {0}", c.inspect_db_size.ToString))
        If Not c.log_level.IsEmpty Then yml.AppendLine(String.Format("log_level: {0}", c.log_level))
        If Not c.log_format.IsEmpty Then yml.AppendLine(String.Format("log_format: {0}", c.log_format))
        If Not c.log.IsEmpty Then yml.AppendLine(String.Format("log: {0}", c.log))
        If Not c.metadata.IsEmpty Then yml.AppendLine(String.Format("metadata: {0}", c.metadata))
        If Not c.root_cas.IsEmpty Then yml.AppendLine(String.Format("root_cas: {0}", c.root_cas))
        If Not c.socks5_proxy.IsEmpty Then yml.AppendLine(String.Format("socks5_proxy: {0}", c.socks5_proxy))
        yml.AppendLine(String.Format("update: {0}", c.update))
        If Not c.update_channel.IsEmpty Then yml.AppendLine(String.Format("update_channel: {0}", c.update_channel))
        If Not c.web_addr.IsEmpty Then yml.AppendLine(String.Format("web_addr: {0}", c.web_addr))

        If c.tunnels IsNot Nothing Then
            yml.AppendLine("tunnels:")
            For Each t As ConfigTunnel In c.tunnels
                yml.AppendLine(String.Format("  {0}:", t.Name))
                yml.AppendLine(String.Format("    proto: {0}", t.Proto.ToString))
                yml.AppendLine(String.Format("    addr: {0}", t.Addr))
                yml.AppendLine(String.Format("    inspect: {0}", t.Inspect))
                If Not t.Auth.IsEmpty Then yml.AppendLine(String.Format("    auth: {0}", t.Auth))
                If Not t.Host_Header.IsEmpty Then yml.AppendLine(String.Format("    host_header: {0}", t.Host_Header))
                yml.AppendLine(String.Format("    bind_tls: {0}", t.Bind_TLS))
                If Not t.Subdomain.IsEmpty Then yml.AppendLine(String.Format("    subdomain: {0}", t.Subdomain))
                If Not t.HostName.IsEmpty Then yml.AppendLine(String.Format("    hostName: {0}", t.HostName))
                If Not t.CRT.IsEmpty Then yml.AppendLine(String.Format("    crt: {0}", t.CRT))
                If Not t.Key.IsEmpty Then yml.AppendLine(String.Format("    key: {0}", t.Key))
                If Not t.Remote_Addr.IsEmpty Then yml.AppendLine(String.Format("    remote_addr: {0}", t.Remote_Addr))
            Next
        End If



        Return yml.ToString
    End Function
End Class

Public Enum Protocols
    http
    tcp
    tls
End Enum

Public Enum Regions
    none 'dont set region
    us 'united states (ohio)
    eu 'europe (frankfurt)
    ap 'asia/pacific (singapore)
    au 'australia (sydney)
End Enum