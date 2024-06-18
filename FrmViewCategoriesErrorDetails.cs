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
    public partial class FrmViewCategoriesErrorDetails : Form
    {
        public FrmViewCategoriesErrorDetails(ViewModel_Categories_DataGrid_Row vmCategoriesPassedIn)
        {
            InitializeComponent();

            MessageBox.Show($" CatCode = {vmCategoriesPassedIn.CatCode}\n" +
                $" Name = {vmCategoriesPassedIn.Name}\n " +
                $"Remarks = {vmCategoriesPassedIn.getErrorDetails()}");
        }
    }
}
