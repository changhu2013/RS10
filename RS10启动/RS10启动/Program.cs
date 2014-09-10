using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RS10启动
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            { 
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                Application.Exit();
            }
            
        }
    }
}
