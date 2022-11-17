using Giao_Dien_Dang_Nhap.Main;
using Giao_Dien_Dang_Nhap.View.Librarian;
using Giao_Dien_Dang_Nhap.View.Librarian.frmCon;
using Giao_Dien_Dang_Nhap.View.Reader;
using Giao_Dien_Dang_Nhap.View.Reader.frmConReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien_Dang_Nhap
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

        }
    }
}
