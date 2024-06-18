using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMall
{
    public partial class FrmViewMallErrorDetails : Form
    {
        public FrmViewMallErrorDetails(ViewModel_Mall_DataGrid_Row vmMallPassedIn)
        {
            InitializeComponent();

            MessageBox.Show($" Name = {vmMallPassedIn.Name}\n" +
                $" Desc = {vmMallPassedIn.Description}\n " +
                $"Remarks = {vmMallPassedIn.getErrorDetails()}");
        }
    }
}
