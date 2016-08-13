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

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"Login.infomation")) //만약 Login.information란 파일이 존재하면
            {
                File.Delete(@"Login.information"); //삭☆제☆
            }
            StreamWriter dw = new StreamWriter(@"Login.information");
            dw.WriteLine("0");
            dw.Close();
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

                if (File.Exists(@"AccessToken.txt")) //만약 먼저 저장된 액세스토큰이 존재하면
                {
                    File.Delete(@"AccessToken.txt"); //삭☆제☆
                }

                //엑세스토큰 정보 기록
                StreamWriter dw = new StreamWriter(@"AccessToken.txt");
                dw.WriteLine("" + Token);
                dw.Close();

                //로그인 여부 기록
                if (File.Exists(@"Login.infomation"))
                {
                    File.Delete(@"Login.information"); //삭☆제☆
                }
                StreamWriter login = new StreamWriter(@"Login.information");
                login.WriteLine("1");
                login.Close();

            }
        }

        private void CheckTokenButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"AccessToken.txt")) //만약 AccessToken.txt란 파일이 존재하면
            {
                string Token = File.ReadAllText(@"AccessToken.txt");
                MessageBox.Show("" + Token, "Token");
            }
            else
            {
                MessageBox.Show("컴퓨터에 저장된 토큰이 없습니다! 로그인을 해주세요.");
            }
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {

            string code = File.ReadAllText(@"AccessToken.txt");
            //이하 구글링으로 얻은 실행코드.
            ///string strCmdText;
            ///strCmdText = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "My Email" + " " + Code;
            ///Process.Start("CMD.exe", strCmdText);
            ///Application.Exit();

            ///Process.Start("cmd.exe");

            String mccmd;
            mccmd = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "" +UsernameField + " " + code;

            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = (@"cmd");
            cmd.WindowStyle = ProcessWindowStyle.Hidden;             // cmd창이 숨겨지도록 하기
            cmd.CreateNoWindow = true;                               // cmd창을 띄우지 안도록 하기

            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = true;          // cmd창으로 데이터 보내기

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write(@"" +mccmd + Environment.NewLine);
            // 명령어를 보낼때는 꼭 마무리를 해줘야 한다. 그래서 마지막에 NewLine가 필요하다
            process.StandardInput.Close();

            //MessageBox.Show("" + code, "Token");
        }

        private void DataDownloadButton_Click(object sender, EventArgs e)
        {
            WebClient Path = new WebClient();
            int a = 0;
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile22.uf@252BF13F56B6F7A42C9CE1.001", "GameLib.7z.001");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile6.uf@23205B3F56B6F7A634418E.002", "GameLib.7z.002");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile29.uf@2531B03F56B6F7AA26137D.003", "GameLib.7z.003");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile30.uf@2132A13F56B6F7AC26ACBE.004", "GameLib.7z.004");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile8.uf@24232C3F56B6F7AE332AB5.005", "GameLib.7z.005");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile6.uf@2425C73F56B6F7B230DD08.006", "GameLib.7z.006");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile30.uf@262C043F56B6F7C02C8982.007", "GameLib.7z.007");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile25.uf@2550583F56B6F7C4119D07.008", "GameLib.7z.008");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile5.uf@2538A73F56B6F7C622CD99.009", "GameLib.7z.009");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile8.uf@2427193F56B6F7C8300E1E.010", "GameLib.7z.010");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile3.uf@222B313F56B6F7CA2DDCBB.011", "GameLib.7z.011");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile25.uf@2752833F56B6F7CE0F29A8.012", "GameLib.7z.012");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile22.uf@272D053F56B6F7D02A6435.013", "GameLib.7z.013");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile3.uf@212D8A3F56B6F7D22AD137.014", "GameLib.7z.014");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile26.uf@23260A3F56B6F7D631AF9D.015", "GameLib.7z.015");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile6.uf@255DFA3F56B6F7D807941E.016", "GameLib.7z.016");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile3.uf@2332FC3F56B6F7E826ACC6.017", "GameLib.7z.017");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile6.uf@2721B53F56B6F7EC342793.018", "GameLib.7z.018");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile27.uf@234AFE3F56B6F7EE14D1A2.019", "GameLib.7z.019");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile6.uf@25283C3F56B6F7F02F5302.020", "GameLib.7z.020");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile1.uf@273C2A3F56B6F7F11F2EFB.021", "GameLib.7z.021");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile7.uf@252DB73F56B6F7F32BE362.022", "GameLib.7z.022");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile21.uf@2631B03F56B6F7F527CF54.023", "GameLib.7z.023");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile22.uf@2232A13F56B6F7F72786F3.024", "GameLib.7z.024");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile29.uf@22653F3F56B6F7F901762F.025", "GameLib.7z.025");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile2.uf@2225D93F56B6F7FB3355F4.026", "GameLib.7z.026");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile29.uf@2734BF3F56B6F7FC247639.027", "GameLib.7z.027");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile5.uf@2525BB3F56B6F7FF3279A0.028", "GameLib.7z.028");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile21.uf@262CBB3F56B6F8002C1243.029", "GameLib.7z.029");
            a++;
            DownloadInfor.Text = ("Downloading..." + a + "/30");
            Path.DownloadFile("http://hoparkgo9ma.tistory.com/attachment/cfile24.uf@2341043F56B6F802172E26.030", "GameLib.7z.030");
            DownloadInfor.Text = ("Download Done!");
        }
    }
}
