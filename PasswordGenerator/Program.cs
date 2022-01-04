using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
/*
http 20.94.229.106 80
http 217.11.184.20 3128
https 31.173.94.93 43539
http 12.218.209.130 53281
http 118.70.109.148	55443
http 209.141.55.228	80
http 206.253.164.122 80
https 181.129.138.114 30838
http 37.57.15.43 33761
https 154.239.6.163	50800
http 52.78.172.171 80
http 157.119.234.50 80
*/