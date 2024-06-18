using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMall
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

            // Set DPI awareness
            // You may also need to change the AutoScaleMode. Add it below your form's InitializeComponent();
            // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            SetProcessDPIAware();

            Application.Run(new ImportData());
        }

        // Form at runtime may differs from Desginer
        // this ensures your DPI (dots per inch) settings are consistent between the design time and runtime
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
