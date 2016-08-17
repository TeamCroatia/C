using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private static string ACCESS_TOKEN;
        private static string uuid;
        private static string accesstokendata;
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
                MessageBox.Show("로그인에 실패했습니다! 계정 문제일 수 있습니다.");
                LoginButton.Enabled = true;
                UsernameField.Enabled = true;
                PasswordField.Enabled = true;
            }
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            //MinecraftStart();
            StartMC();
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
            string code = ACCESS_TOKEN;

            //이하 구글링으로 얻은 실행코드.
            ///string strCmdText;
            ///strCmdText = "java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft " + "My Email" + " " + Code;
            ///Process.Start("CMD.exe", strCmdText);
            ///Application.Exit();

            ///Process.Start("cmd.exe");

            String mccmd;
            mccmd = "\"C:\\Program Files (x86)\\Minecraft\\runtime\\jre-x64\\1.8.0_25\\bin\\javaw.exe\" - XX:HeapDumpPath = MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump - Xmx1G - XX:+UseConcMarkSweepGC - XX:+CMSIncrementalMode - XX:-UseAdaptiveSizePolicy - Xmn128M \"-Dos.name=Windows 10\" - Dos.version = 10.0 \"-Djava.library.path=C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\versions\\Croatia Update 160206 1016\\Croatia Update 160206 1016-natives-222206811236533\" - cp C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\minecraftforge\\forge\\1.7.10 - 10.13.4.1558 - 1.7.10\\forge - 1.7.10 - 10.13.4.1558 - 1.7.10.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\minecraft\\launchwrapper\\1.12\\launchwrapper - 1.12.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\ow2\\asm\\asm - all\\5.0.3\\asm - all - 5.0.3.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\typesafe\\akka\\akka - actor_2.11\\2.3.3\\akka - actor_2.11 - 2.3.3.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\typesafe\\config\\1.2.1\\config - 1.2.1.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala - lang\\scala - actors - migration_2.11\\1.1.0\\scala - actors - migration_2.11 - 1.1.0.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala - lang\\scala - compiler\\2.11.1\\scala - compiler - 2.11.1.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala - lang\\plugins\\scala - continuations - library_2.11\\1.0.2\\scala - continuations - library_2.11 - 1.0.2.jar; C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\plugins\\scala-continuations-plugin_2.11.1\\1.0.2\\scala-continuations-plugin_2.11.1-1.0.2.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\scala-library\\2.11.1\\scala-library-2.11.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\scala-parser-combinators_2.11\\1.0.1\\scala-parser-combinators_2.11-1.0.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\scala-reflect\\2.11.1\\scala-reflect-2.11.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\scala-swing_2.11\\1.0.1\\scala-swing_2.11-1.0.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\scala-lang\\scala-xml_2.11\\1.0.2\\scala-xml_2.11-1.0.2.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\lzma\\lzma\\0.0.1\\lzma-0.0.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\4.5\\jopt-simple-4.5.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\google\\guava\\guava\\17.0\\guava-17.0.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\commons\\commons-lang3\\3.3.2\\commons-lang3-3.3.2.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\mojang\\netty\\1.6\\netty-1.6.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\mojang\\realms\\1.3.5\\realms-1.3.5.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\commons\\commons-compress\\1.8.1\\commons-compress-1.8.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\httpcomponents\\httpclient\\4.3.3\\httpclient-4.3.3.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\commons-logging\\commons-logging\\1.1.3\\commons-logging-1.1.3.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\httpcomponents\\httpcore\\4.3.2\\httpcore-4.3.2.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\java3d\\vecmath\\1.3.1\\vecmath-1.3.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\sf\\trove4j\\trove4j\\3.0.3\\trove4j-3.0.3.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\ibm\\icu\\icu4j-core-mojang\\51.2\\icu4j-core-mojang-51.2.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\4.5\\jopt-simple-4.5.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\io\\netty\\netty-all\\4.0.10.Final\\netty-all-4.0.10.Final.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\google\\guava\\guava\\15.0\\guava-15.0.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\commons\\commons-lang3\\3.1\\commons-lang3-3.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\commons-io\\commons-io\\2.4\\commons-io-2.4.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\commons-codec\\commons-codec\\1.9\\commons-codec-1.9.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\google\\code\\gson\\gson\\2.2.4\\gson-2.2.4.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\com\\mojang\\authlib\\1.5.21\\authlib-1.5.21.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\logging\\log4j\\log4j-api\\2.0-beta9\\log4j-api-2.0-beta9.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\apache\\logging\\log4j\\log4j-core\\2.0-beta9\\log4j-core-2.0-beta9.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.1\\lwjgl-2.9.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.1\\lwjgl_util-2.9.1.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\libraries\\tv\\twitch\\twitch\\5.16\\twitch-5.16.jar;C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\versions\\1.7.10\\1.7.10.jar net.minecraft.launchwrapper.Launch --username "+ username +" --version \"Croatia Update 160206 1016\" --gameDir C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft --assetsDir C:\\Users\\Administrator\\AppData\\Roaming\\.minecraft\\assets --assetIndex 1.7.10 --uuid "+ uuid +" --accessToken "+ accesstoken +" --userProperties {} --userType legacy --tweakClass cpw.mods.fml.common.launcher.FMLTweaker --nativeLauncherVersion 307";

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

        private async void DownloadButton_Click_1(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            try
            {
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMczdsV1cxYkpmR2M&export=download"), @"7za.exe");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMajFZbE45ZGMxTTA&export=download"), @"Extract.cmd");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMSmM0dmlhZkhDX28&export=download"), @"assets.7z.001");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMRDZaTVY0clcySzA&export=download"), @"assets.7z.002");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMbUZDTXdZQVNSTFk&export=download"), @"assets.7z.003");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMa0F3MTJDNEVwSmM&export=download"), @"assets.7z.004");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMVDhXSnR1RWJ6QWc&export=download"), @"assets.7z.005");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMMGtYZmFjV0x4Yk0&export=download"), @"libraries.7z.001");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMS3ZiYjlsUFB1c0E&export=download"), @"libraries.7z.002");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMQnd2dDhzZ2s1enM&export=download"), @"libraries.7z.003");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMRTl5VzkzdW0zTjQ&export=download"), @"userdata.7z");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMLVNCMHFta0l0OEE&export=download"), @"versions.7z");
                Progress.Value++;
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
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMRUI4TUNnTkdpYms&export=download"), modir + @"Armourers-Workshop-1.7.10-0.38.1.98.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMZTgyQmdTMEJPM3M&export=download"), modir + @"b77_1710f.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMTFd1YkRaRnViNms&export=download"), modir + @"Chisel-1.7.10-1.5.6.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMbWttakkxVnhFVGs&export=download"), modir + @"CodeChickenCore-1.7.10-1.0.7.46-universal.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMNGRnNUk5U01Zejg&export=download"), modir + @"CraftGuide-Mod-1.7.10.zip");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMbWpETXhUcFQ4M00&export=download"), modir + @"CustomMobSpawner 3.3.0.zip");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMcEtsMlNyZTRxT28&export=download"), modir + @"CustomNPCs_1.7.10d.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMaC1nYWtQcEZPdlU&export=download"), modir + @"DrZharks MoCreatures Mod v6.3.1.zip");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMYzg1MklGNVRmdU0&export=download"), modir + @"OptiFine_1.7.10_HD_U_C1.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMNmFWQlQ1ZUhUdHM&export=download"), modir + @"Project.Zagerb-0.1.2.jar.001");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMMjJFeUxkNTY5NkE&export=download"), modir + @"Project.Zagerb-0.1.2.jar.002");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMMENURGdnMmU1WGs&export=download"), modir + @"Project.Zagerb-0.1.2.jar.003");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMR0RpLWdOcnJXNzA&export=download"), modir + @"Project.Zagerb-0.1.2.jar.004");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMRzgyb2xveXozdlk&export=download"), modir + @"Project.Zagerb-0.1.2.jar.005");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMYzJvTFB1SkhtZjQ&export=download"), modir + @"Project.Zagerb-0.1.2.jar.006");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMWFpScFB4Ymd6UVk&export=download"), modir + @"Reis-Minimap-Mod-1.7.10.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMNzh1VTVXUFNyRW8&export=download"), modir + @"ShadersModCore-v2.3.31-mc1.7.10-f.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMTjhmWDRSSTg1Z2s&export=download"), modir + @"Thaumcraft-1.7.10-4.2.3.5.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMNEZPQUxoc09VWU0&export=download"), modir + @"TooManyItems2014_07_15_1.7.10_Forge.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMN0hzc3N0R2pMR1E&export=download"), modir2 + @"Baubles-1.7.10-1.0.1.10.jar");
                Progress.Value++;
                await SSG((@"https://docs.google.com/uc?id=0B5i3uwQXjFjMd0NGVy1YYUpFeWc&export=download"), modir2 + @"CodeChickenLib-1.7.10-1.1.3.138-universal.jar");
                Progress.Value++;

                ProcessStartInfo cmd = new ProcessStartInfo();
                Process process = new Process();
                cmd.FileName = (@"Extract.cmd");
                cmd.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.CreateNoWindow = true;

                Progress.Value++;

                cmd.UseShellExecute = false;
                cmd.RedirectStandardInput = true;
                cmd.RedirectStandardOutput = true;

                process.EnableRaisingEvents = false;
                process.StartInfo = cmd;
                process.Start();

                Progress.Value = 100;
                MessageBox.Show("완료");
                Progress.Value = 0;
            }
            catch
            {
                MessageBox.Show("오류 발생\n데이터파일 다운로드에 실패하였습니다.");
                DownloadButton.Enabled = true;
            }
            DownloadButton.Enabled = true;
        }

        private async Task SSG(string url, string des)
        {
            using (WebClient wc = new WebClient())
            {
                await wc.DownloadFileTaskAsync(url, des);
            }
        }
    }
}
