Imports Ape.EL.Misc.WebHelper

Friend Class Properties
#Region "Fields"
    Public Shared ReadOnly m_fvi As FileVersionInfo = Ape.EL.Utility.General.GetFileVersionInfo(Reflection.Assembly.GetExecutingAssembly)
    Public Shared ReadOnly m_AppTitle As String = String.Format("{0} Version {1}.{2}.{3}.{4}", My.Application.Info.Description, m_fvi.FileMajorPart, m_fvi.FileMinorPart, m_fvi.FileBuildPart, m_fvi.FilePrivatePart)
#End Region

#Region "Properties"
    ''' <summary>
    ''' Web hosted url.
    ''' </summary>
    Shared Property m_WebApiRootUrl As String

    ''' <summary>
    ''' ngrok / custom url.
    ''' </summary>
    Shared Property m_RootUrl As String

    ''' <summary>
    ''' Configuration setting.
    ''' </summary>
    Shared Property m_Config As New ConfigStructure

    ''' <summary>
    ''' Temporarily unused.
    ''' </summary>
    Shared Property m_Token As String
#End Region

#Region "Function"
    ''' <summary>
    ''' Call GetWebAPI to local root url.
    ''' </summary>
    Private Shared Function LocalGetWebAPI(ByVal ApiLink As String) As String
        Return GetWebAPI(m_WebApiRootUrl, ApiLink)
    End Function

    ''' <summary>
    ''' Call PostWebAPI to local root url.
    ''' </summary>
    Private Shared Function LocalPostWebAPI(ByVal ApiLink As String, ByVal JsonObj As String) As String
        Return PostWebAPI(m_WebApiRootUrl, ApiLink, JsonObj)
    End Function

    ''' <summary>
    ''' Check if connection to local webapi and url (ngrok) is still alive.
    ''' </summary>
    Public Shared Function IsConnectionAlive() As Boolean
        Dim res As Boolean = False
        res = IsWebAlive(m_WebApiRootUrl) 'check for WebAPI connection
        If res Then
            If m_Config.UseNgrokUrl Then
                'if URL is empty, that means use ngrok. when use ngrok, we check local ngrok connection instead of the ngrok public url (m_RootUrl)
                'Ari: i am assuming that if local ngrok connection is not down, that means the ngrok public url is not down either.
                res = IsWebAlive(String.Format("localhost:{0}", m_Config.NgrokPort))
            Else
                'user has set their own port forwarder. directly check the public url (m_RootUrl)
                res = IsWebAlive(m_RootUrl)
            End If
        End If

        Return res
    End Function
#End Region
End Class
