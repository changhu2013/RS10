using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RS10配置
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //关闭应用程序
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存配置信息
            String url = textBox1.Text;
            if (url == null || url.Trim().Equals(""))
            {
                MessageBox.Show("服务器地址(或域名)不能为空!");
                return;
            }
            else
            {
                String file = this.getFile();
                FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(url);
                writer.Close();
                stream.Close();
            }

            MessageBox.Show("配置信息保存成功");
        }

        //读取配置文件
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
            //判断文件是否存在，如果不存在，则创建一个该文件
            if (File.Exists(file) == false)
            {
                FileStream stream = File.Create(file);
                stream.Close();
            }
            return file;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String file = getFile();
            //读取配置文件打开地址
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            string url = reader.ReadLine();
            reader.Close();
            stream.Close();
            textBox1.Text = url;
        }

    }
}
