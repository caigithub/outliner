
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace outliner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            new ScopeDefinition().test();
            new TextFilter().test();

            new ContentRestructor().test();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length <= 0)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form1( args[0]));
            }
        }
    }
}
