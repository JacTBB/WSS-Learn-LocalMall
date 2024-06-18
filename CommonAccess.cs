using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMall
{
    //Step2:
    //This class is to store share variables and functions.
    //It should not be instantiated
    public static class CommonAccess
    {
        //This is to store the font used for all control
        // we can use Font.FontFamily.Name to find the Text for the Font
        public static Font myBaseFont = new Font("Baskerville Old Face", 12f, FontStyle.Regular);

        // this recursive function takes in the form pointer
        // and change all control within the form to follow myBaseFont
        public static void SetAllControlsFont(Control.ControlCollection ctrls)
        {
            //Console.WriteLine($"Setting control font to : {myBaseFont.FontFamily.Name}");
            //foreach (Control ctrl in ctrls)
            //{
            //    if (ctrl.Controls != null)
            //        SetAllControlsFont(ctrl.Controls);
            //    ctrl.Font = myBaseFont;
            //}
        }

        // filter extension
        // display Text | *.ext1 ; *.ext2 ...
        // 2 selections , display the selecetd one - "Text files (*.txt)|*.txt|CSV Files (*.csv)|*.csv" 
        // display both - "Text or csv files (*.txt;*.csv)|*.txt;*.csv"
        public static string getFilePath(string strFileTypes = "All file (*.*)|*.*")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";

            // Set the initial directory to the current project folder
            // Application.StartupPath is the Debug folder
            string projectFolder = Path.Combine(Application.StartupPath, "..", "..");
            string projectFolderFullPath = Path.GetFullPath(projectFolder);
            string DataFilePath = projectFolderFullPath + @"\Data_files";
            Console.WriteLine($"Application.StartupPath: {Application.StartupPath}");

            openFileDialog.InitialDirectory = DataFilePath;

            //Returns path + filename if selected, else, return "No file selected"
            openFileDialog.Filter = strFileTypes;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"Selected file: {openFileDialog.FileName}");
                return openFileDialog.FileName;
            }
            else
                return "No file selected";
        }
    }
}
