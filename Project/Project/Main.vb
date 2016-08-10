Public Class Main
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        If TextFieldUsername.Text = "" Or TextFieldPasword.Text = "" Then
            MsgBox("Error: 로그인 정보가 부정확합니다.", MsgBoxStyle.Critical, Title:="Error")
        End If
    End Sub
End Class
