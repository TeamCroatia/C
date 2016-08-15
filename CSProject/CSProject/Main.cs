using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using CSProject.Properties;



namespace CSProject
{
    public partial class Main : MaterialForm
    {
        private static string version = "Croatia Update 160206 1016";
        private static string username;
        private static string accesstoken;
        private static string uuid;
        private static List<string> libsList = new List<string>();

        private Process process;


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
            javaDir.Enabled = false;
            arguments.Enabled = false;
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
                string json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";

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
            login();
            LoginButton.Enabled = false;
            UsernameField.Enabled = false;
            PasswordField.Enabled = false;

            username = UsernameField.Text;

            if (IsLoginSuccess(ref username, PasswordField.Text, ref accesstoken, ref uuid))
            {

            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다! 계정과 인터넷 연결상태를 확인하세요.");
                LoginButton.Enabled = true;
                UsernameField.Enabled = true;
                PasswordField.Enabled = true;
            }
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            MinecraftStart();
        }

        private void login()
        {
            if (UsernameField.Text == "") //만약 UsernameField에 아무것도 입력되지 않으면
            {
                MessageBox.Show("Username 필드가 입력되지 않았습니다!");
            }

            else if (PasswordField.Text == "") //만약 PasswordField에 아무것도 입력되지 않으면
            {
                MessageBox.Show("Password 필드가 입력되지 않았습니다!");
            }
        }

        private void StartMC()
        {
            string code = File.ReadAllText(@"AccessToken.txt");

            //이하 구글링으로 얻은 실행코드.
            ///string strCmdText;
            ///strCmdText = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "My Email" + " " + Code;
            ///Process.Start("CMD.exe", strCmdText);
            ///Application.Exit();

            ///Process.Start("cmd.exe");

            String mccmd;
            mccmd = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "" + UsernameField + " " + code;

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
            process.StandardInput.Write(@"" + mccmd + Environment.NewLine);
            // 명령어를 보낼때는 꼭 마무리를 해줘야 한다. 그래서 마지막에 NewLine가 필요하다
            process.StandardInput.Close();

            //MessageBox.Show("" + code, "Token");
        }

        private void MinecraftStart()  //코드제공: Winrobrin
        {
            if (!(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\natives")))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\natives");

            string arguments = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump " + this.arguments.Text + " -Djava.library.path=\"" + AppDomain.CurrentDomain.BaseDirectory + @"\natives"" -cp """;

            foreach (string item in libsList)
                arguments += item + ';';
            arguments += AppDomain.CurrentDomain.BaseDirectory + "version\\" + version + "\\" + version + ".jar\" net.minecraft.client.main.Main --username " + username + " --version " + version + " --gameDir \"" + Application.StartupPath + @""" --assetsDir """ + AppDomain.CurrentDomain.BaseDirectory + "assets\" --assetIndex 1.7.10 --accessToken " + accesstoken + " --uuid " + uuid + " --userProperties {}";

            process = new Process()
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo()
                {
                    FileName = (javaCheckBox.Checked) ? javaDir.Text : "java.exe",
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            console.Clear();

            process.OutputDataReceived += process_OutputDataReceived;
            process.Exited += process_Exited;
        }

        private void InitializeLibraries(string verDir)
        {
            StreamReader reader = new StreamReader(verDir + "\\" + version + ".json");
            JArray jArray = JArray.Parse(JObject.Parse(reader.ReadToEnd())["libraries"].ToString());
            reader.Close();
            int count = jArray.Count;
            foreach (JObject itemObj in jArray)
            {
                string pack = itemObj["name"].ToString().Split(':')[0];
                string name = itemObj["name"].ToString().Split(':')[1];
                string ver = itemObj["name"].ToString().Split(':')[2];
                string fileName = name + "-" + ver;

                if (itemObj.ToString().Contains("natives"))
                {
                    fileName += "-" + itemObj["natives"]["windows"];
                    fileName = fileName.Replace("${arch}", (Environment.Is64BitOperatingSystem) ? "64" : "32");
                }
                fileName += ".jar";

                string url = "https://libraries.minecraft.net/" + pack.Replace('.', '/') + "/" + name + "/" + ver + "/" + fileName;

                if (itemObj.ToString().Contains("rules"))
                {
                    foreach (JObject itemRules in itemObj["rules"])
                    {
                        if (itemRules.ToString().Contains("os"))
                        {
                            if ((itemRules["action"].ToString() == "allow" && itemRules["os"]["name"].ToString() == "windows") || (itemRules["action"].ToString() == "disallow" && itemRules["os"]["name"].ToString() != "windows"))
                            {
                                libsList.Add(AppDomain.CurrentDomain.BaseDirectory + "libraries\\" + fileName);
                            }
                        }
                    }
                }
                else
                {
                    libsList.Add(AppDomain.CurrentDomain.BaseDirectory + "libraries\\" + fileName);
                }
            }

            if (!(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "libraries")))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "libraries");
        }

        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            console.AppendText(Environment.NewLine + e.Data);
        }

        private void process_Exited(object sender, EventArgs e)
        {

        }

        private void arguCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            arguments.Enabled = arguCheckBox.Checked;
        }

        private void javaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            javaDir.Enabled = javaCheckBox.Checked;
        }
        private static bool IsLoginSuccess(ref string username, string password, ref string accesstoken, ref string uuid)
        {
            try
            {
                string request = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";

                SslStream stream = new SslStream(new TcpClient("authserver.mojang.com", 443).GetStream());
                stream.AuthenticateAsClient("authserver.mojang.com");

                List<string> http_request = new List<string>()
                {
                    "POST /authenticate HTTP/1.1",
                    "Host: authserver.mojang.com",
                    "Content-Type: application/json",
                    "Content-Length: " + Encoding.ASCII.GetBytes(request).Length,
                    "Connection: close",
                    "",
                    request
                };
                stream.Write(Encoding.ASCII.GetBytes(string.Join("\r\n", http_request.ToArray())));

                StreamReader reader = new StreamReader(stream);
                string raw_result = reader.ReadToEnd();
                reader.Close();

                if (raw_result.StartsWith("HTTP/1.1"))
                {
                    if (int.Parse(raw_result.Split(' ')[1]) == 200)
                    {
                        string result = raw_result.Substring(raw_result.IndexOf("\r\n\r\n") + 4);
                        string[] temp = result.Split(new string[] { "accessToken\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { accesstoken = temp[1].Split('"')[0]; }
                        temp = result.Split(new string[] { "name\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { username = temp[1].Split('"')[0]; }
                        temp = result.Split(new string[] { "availableProfiles\":[{\"id\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { uuid = temp[1].Split('"')[0]; }
                        return (result.Contains("availableProfiles\":[]}")) ? false : true;
                    }
                }
                return false;
            }
            catch { return false; }
        }

        private void javaCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (javaCheckBox.Checked == true)
            {
                javaDir.Enabled = true;
            }
            if (javaCheckBox.Checked == false)
            {
                javaDir.Enabled = false;
            }
        }

        private void arguCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (arguCheckBox.Checked == true)
            {
                arguments.Enabled = true;
            }
            if (arguCheckBox.Checked == false)
            {
                arguments.Enabled = false;
            }
        }
    }
}
