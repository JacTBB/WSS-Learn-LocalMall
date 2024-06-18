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
    public partial class FrmViewStoresErrorDetails : Form
    {
        public FrmViewStoresErrorDetails(ViewModel_Stores_DataGrid_Row vmStoresPassedIn)
        {
            InitializeComponent();

            MessageBox.Show($" CatCode = {vmStoresPassedIn.StoreId}\n" +
                $" Name = {vmStoresPassedIn.Name}\n " +
                $"Remarks = {vmStoresPassedIn.getErrorDetails()}");
        }
    }
}
