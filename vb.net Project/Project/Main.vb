Imports System.Net
Imports System.IO


Public Class Main
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        If TextFieldUsername.Text = "" Or TextFieldPasword.Text = "" Then
            MsgBox("Error: 로그인 정보가 부정확합니다.", MsgBoxStyle.Critical, Title:="Error")
        End If
        ObtainAccessToken("kpjhg0124@naver.com", "Swamp.2684")
        Dim code As String = GetAccessToken()
        Dim strCmdText As String
        strCmdText = Convert.ToString("java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp ""minecraft.jar; lwjgl.jar; lwjgl_util.jar"" net.minecraft.client.Minecraft " + "My Email" + " ") & code
        Process.Start("CMD.exe", strCmdText)
        Application.[Exit]()
    End Sub

    Private ACCESS_TOKEN As String
    Public Function GetAccessToken() As String
        Return ACCESS_TOKEN
    End Function
    Public Sub ObtainAccessToken(username As String, password As String)
        Dim httpWebRequest = DirectCast(WebRequest.Create("https://authserver.mojang.com/authenticate"), HttpWebRequest)
        httpWebRequest.ContentType = "application/json"
        httpWebRequest.Method = "POST"

        Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
            Dim json As String = (Convert.ToString((Convert.ToString("{""agent"":{""name"":""Minecraft"",""version"":1},""username"":""") & username) + """,""password"":""") & password) + """,""clientToken"":""6c9d237d-8fbf-44ef-b46b-0b8a854bf391""}"

            streamWriter.Write(json)
            streamWriter.Flush()
            streamWriter.Close()

            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                ACCESS_TOKEN = result
            End Using
        End Using
    End Sub
End Class



Public Class ACESS_TOKEN
    Public Overridable Property ContentType As String
    Dim request As WebRequest = WebRequest.Create("https://authserver.mojang.com/authenticate")

End Class
