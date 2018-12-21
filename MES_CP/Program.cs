using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    static class Program
    {
        /*static void Main(string[] args)
        {
            while (true)
            {
                Grid grid = new Grid(@"..\..\data\initialData.json");

                Console.WriteLine(grid);
                grid.RunSimulation();
                Console.ReadKey();
                Console.Clear();
            }
        }*/

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