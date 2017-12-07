using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTG_AI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MagicAIGUI Gui = new MagicAIGUI();
            //AI intel = new AI(Gui);
            //Gui.setAI(intel);
            Application.Run(Gui);
        }
    }
}
