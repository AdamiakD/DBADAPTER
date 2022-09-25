using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Collections;

[assembly: CLSCompliant(true)]
namespace Dbadapter
{
    static class Program
    {
        const string FileType = "*";
        const string KeyName = "Dbadapter";
        const string MenuText = "Dbadapter";

        [STAThread]
        static void Main(string[] args)
        {
            //ProcessCommand(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(args));
        }

        static bool ProcessCommand(string[] args)
        {
            if (args.Length == 0 || string.Compare(args[0], "-register", true) == 0)
            {
                string menuCommand = string.Format(
                    "\"{0}\" \"%L\"", Application.ExecutablePath);
                SHL.Register(Program.FileType,
                    Program.KeyName, Program.MenuText,
                    menuCommand);
                return true;
            }	
            if (string.Compare(args[0], "-unregister", true) == 0)
            {
                SHL.Unregister(Program.FileType, Program.KeyName);
                return true;
            }
            return false;
        }
    }
}
