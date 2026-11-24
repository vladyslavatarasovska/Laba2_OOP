using System;
using System.Windows.Forms;

namespace LR_2
{
    internal static class Program
    {
        /// <summary>
        /// Головна точка входу в застосунок.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
