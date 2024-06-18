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
    public partial class FrmViewUserErrorDetails : Form
    {
        public FrmViewUserErrorDetails(ViewModel_User_DataGrid_Row vmUserPassedIn)
        {
            InitializeComponent();

            MessageBox.Show($" Name = {vmUserPassedIn.UserId}\n" +
                $" Role = {vmUserPassedIn.Role}\n " +
                $"Remarks = {vmUserPassedIn.getErrorDetails()}");
        }
    }
}
