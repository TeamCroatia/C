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

            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMczdsV1cxYkpmR2M&export=download", "7za.exe");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMekVmdno4bzhiM00&export=download", "Extract.cmd");
            Path.DownloadFile("https://docs.google.com/uc?export=download&confirm=aAY9&id=0B5i3uwQXjFjMcUJha2VrdkdKTXM", "assets.7z");
            Path.DownloadFile("https://docs.google.com/uc?export=download&confirm=gSFe&id=0B5i3uwQXjFjMQmVlc2U1Z3M3WTg", "libraries.7z");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMRTl5VzkzdW0zTjQ&export=download", "userdata.7z");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMLVNCMHFta0l0OEE&export=download", "versions.7z");
            DirectoryInfo modir = new DirectoryInfo(@"mods\");
            if (modir.Exists == false)
            {
                modir.Create();
            }
            DirectoryInfo modir2 = new DirectoryInfo(@"mods\1.7.10\");
            if (modir2.Exists == false)
            {
                modir2.Create();
            }
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMRUI4TUNnTkdpYms&export=download", modir + "Armourers-Workshop-1.7.10-0.38.1.98.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMZTgyQmdTMEJPM3M&export=download", modir + "b77_1710f.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMTFd1YkRaRnViNms&export=download", modir + "Chisel-1.7.10-1.5.6.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMbWttakkxVnhFVGs&export=download", modir + "CodeChickenCore-1.7.10-1.0.7.46-universal.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMNGRnNUk5U01Zejg&export=download", modir + "CraftGuide-Mod-1.7.10.zip");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMbWpETXhUcFQ4M00&export=download", modir + "CustomMobSpawner 3.3.0.zip");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMcEtsMlNyZTRxT28&export=download", modir + "CustomNPCs_1.7.10d.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMaC1nYWtQcEZPdlU&export=download", modir + "DrZharks MoCreatures Mod v6.3.1.zip");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMYzg1MklGNVRmdU0&export=download", modir + "OptiFine_1.7.10_HD_U_C1.jar");
            Path.DownloadFile("https://docs.google.com/uc?export=download&confirm=gD_r&id=0B5i3uwQXjFjMc1VmZVNNcFl4dVk", modir + "Project.Zagerb-0.1.2.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMWFpScFB4Ymd6UVk&export=download", modir + "Reis-Minimap-Mod-1.7.10.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMNzh1VTVXUFNyRW8&export=download", modir + "ShadersModCore-v2.3.31-mc1.7.10-f.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMTjhmWDRSSTg1Z2s&export=download", modir + "Thaumcraft-1.7.10-4.2.3.5.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMNEZPQUxoc09VWU0&export=download", modir + "TooManyItems2014_07_15_1.7.10_Forge.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMN0hzc3N0R2pMR1E&export=download", modir2 + "Baubles-1.7.10-1.0.1.10.jar");
            Path.DownloadFile("https://docs.google.com/uc?id=0B5i3uwQXjFjMd0NGVy1YYUpFeWc&export=download", modir2 + "CodeChickenLib-1.7.10-1.1.3.138-universal.jar");

            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = (@"Extract.cmd");
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = true;

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

        }
    }
}
