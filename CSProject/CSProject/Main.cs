using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;

namespace CSProject
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();

            //머티리얼 디자인 연결
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        //액세스 토큰 불러오기
        string ACCESS_TOKEN;
        public string GetAccessToken()
        {
            return ACCESS_TOKEN;
        }
        public void ObtainAccessToken(string username, string password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"clientToken\":\"6c9d237d-8fbf-44ef-b46b-0b8a854bf391\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ACCESS_TOKEN = result;
                }
            }
        }

        //
        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            if (UsernameField.Text == "") //만약 UsernameField에 아무것도 입력되지 않으면
            {
                MessageBox.Show("Username 필드가 입력되지 않았습니다!");
            }

            else if (PasswordField.Text == "") //만약 PasswordField에 아무것도 입력되지 않으면
            {
                MessageBox.Show("Password 필드가 입력되지 않았습니다!");
            }

            else
            {
                //액세스토큰 받아오기
                ObtainAccessToken(UsernameField.Text, PasswordField.Text);
                string Token = GetAccessToken();

                MessageBox.Show("" + Token, "Token"); //액세스토큰 정보 띄우기

                if (Directory.Exists(@"AccessToken.txt")) //만약 먼저 저장된 액세스토큰이 존재하면
                {
                    File.Delete(@"AccessToken.txt"); //삭☆제☆
                }

                //엑세스토큰 정보 기록
                StreamWriter dw = new StreamWriter(@"AccessToken.txt");
                dw.WriteLine("" + Token);
                dw.Close();

                ///string strCmdText;
                ///strCmdText = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "My Email" + " " + code;
                ///Process.Start("CMD.exe", strCmdText);
                ///Application.Exit();
            }
        }

        private void CheckTokenButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"AccessToken.txt")) //만약 AccessToken.txt란 파일이 존재하면
            {
                string path = @"AccessToken.txt";
                string Token = File.ReadAllText(path);
                MessageBox.Show("" + Token, "Token");
            }
            else
            {
                MessageBox.Show("컴퓨터에 저장된 토큰이 없습니다! 로그인을 해주세요.");
            }
        }
    }
}
