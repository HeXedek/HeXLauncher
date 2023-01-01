using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeXLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("HeXPLOIT.zip"))
            {
                File.Delete("HexPLOIT.zip");
            }

            if (File.Exists("versioninfo.txt"))
            {
                File.Delete("versioninfo.txt");
            }

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit"))
            {

                button4.Text = "Run";
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit\\versioninfo.txt"))
            {
                string contents = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit\\versioninfo.txt");
                string remoteUri = "https://github.com/HeXedek/HeXPLOIT/releases/download/release/";
                string fileName = "versioninfo.txt", myStringWebResource = null;
                WebClient myWebClient = new WebClient();
                myStringWebResource = remoteUri + fileName;
                myWebClient.DownloadFile(myStringWebResource, fileName);
                string contents2 = File.ReadAllText("versioninfo.txt");
                if(!contents.Equals(contents2))
                {
                    button4.Text = "Update";
                }
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            panel1.Visible = false;
            pictureBox1.Visible = true;
            button4.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "Download")
            {
                button4.Text = "Downloading";
                string remoteUri = "https://github.com/HeXedek/HeXPLOIT/releases/download/release/";
                string fileName = "HeXPLOIT.zip", myStringWebResource = null;
                WebClient myWebClient = new WebClient();
                myStringWebResource = remoteUri + fileName;
                myWebClient.DownloadFile(myStringWebResource, fileName);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit");
                string extractPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit";
                System.IO.Compression.ZipFile.ExtractToDirectory("HeXPLOIT.zip", extractPath);
                button4.Text = "Run";
            }

            if (button4.Text == "Update")
            {
                button4.Text = "Downloading";
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings"))
                {
                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings", true);
                }    
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit\\settings\\sautoattach.hexploit", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+ "\\hexpsettings\\sautoattach.hexploit");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\settings\\stransparency.hexploit", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings\\stransparency.hexploit");
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit", true);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\hexploit");
                string remoteUri = "https://github.com/HeXedek/HeXPLOIT/releases/download/release/";
                string fileName = "HeXPLOIT.zip", myStringWebResource = null;
                WebClient myWebClient = new WebClient();
                myStringWebResource = remoteUri + fileName;
                myWebClient.DownloadFile(myStringWebResource, fileName);
                string extractPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit";
                System.IO.Compression.ZipFile.ExtractToDirectory("HeXPLOIT.zip", extractPath);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\settings");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings\\sautoattach.hexploit", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\settings\\sautoattach.hexploit");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexpsettings\\stransparency.hexploit", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\settings\\stransparency.hexploit");
                button4.Text = "Run";
            }

            if (button4.Text == "Run")
            {
                Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\");
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\hexploit\\HeXPLOIT.exe");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            panel1.Visible = true;
            pictureBox1.Visible = false;
            button4.Visible = false;
        }
    }
}
