using System;
using System.Windows.Forms;

namespace MES_CP
{
    static class Program
    {
        public static MainForm MainForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm();
            Application.Run(MainForm);
        }
    }
}