using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RS10启动
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取配置文件打开地址
            String file = getFile();
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            string url = reader.ReadLine();
            reader.Close();
            stream.Close();
            if (url != null && !"".Equals(url))
            {
                //System.Diagnostics.Process p = System.Diagnostics.Process.Start("IEXPLORE.EXE", url);
                //p.Close();

                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                startInfo.Arguments = url;
                Process.Start(startInfo);

                Hide();
                Application.Exit();
            }
        }

        private String getFile()
        {
            String local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            String folder = local + "/RS10";
            //判断是否存在RS10目录
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            String file = folder + "/config.properties";
            if (File.Exists(file) == false) 
            {
                FileStream stream = File.Create(file);
                stream.Close();
            }
            return file;
        }
    }
}
