using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO; // for TextFieldParser

namespace LocalMall
{
    public partial class ImportData : Form
    {
        //Step4: 
        private MyDBContext dbContext = new MyDBContext();

        //View Models
        ViewModel_Mall_DataGrid mallsVM = new ViewModel_Mall_DataGrid();
        ViewModel_User_DataGrid userVM = new ViewModel_User_DataGrid();
        ViewModel_Categories_DataGrid categoriesVM = new ViewModel_Categories_DataGrid();
        ViewModel_Stores_DataGrid storesVM = new ViewModel_Stores_DataGrid();

        // Preview Ok means, data read ok and diaplyed on gridview, able to proceed to save to DB
        bool PreviewOkMalls = false;
        bool PreviewOkUser = false;
        bool PreviewOkCategories = false;
        bool PreviewOkStores = false;

        public ImportData()
        {
            InitializeComponent();

            dgvMalls.DataSource = mallsVM.vmDatagrid;
            dgvUser.DataSource = userVM.vmDatagrid;
            dgvCategories.DataSource = categoriesVM.vmDatagrid;
            dgvStores.DataSource = storesVM.vmDatagrid;

            //Pass in our Form pointer to change the font of everything inside
            CommonAccess.SetAllControlsFont(this.Controls);

            // Hide the Tab Pages header during runtime using properties
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.ItemSize = new Size(0, 1);
            tabControlMain.SizeMode = TabSizeMode.Fixed;

            dgvMalls.RowHeadersVisible = false;
            dgvMalls.AllowUserToAddRows = false;
            dgvMalls.ReadOnly = true;

            dgvUser.RowHeadersVisible = false;
            dgvUser.AllowUserToAddRows = false;
            dgvUser.ReadOnly = true;
            
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.ReadOnly = true;
            
            dgvStores.RowHeadersVisible = false;
            dgvStores.AllowUserToAddRows = false;
            dgvStores.ReadOnly = true;
        }

        private void ImportData_Load(object sender, EventArgs e)
        {
            // Choose page to Display
            tabControlMain.SelectedIndex = 3;
        }

        private void DrawRedRectangle(DataGridView dgvDrawBox, DataGridViewRowPostPaintEventArgs e)
        {
            // e.RowIndex is the row number
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvDrawBox.Rows[rowIndex];

            using (Pen pen = new Pen(Color.Red, 2.0f)) // 2.0 is the line thickness
            {
                int rowHeight = row.Height;
                int rowLeft = e.RowBounds.Left;
                int rowTop = e.RowBounds.Top;
                int rowBottom = e.RowBounds.Bottom - 1; // Subtract 1 to prevent overlapping with the next row
                int lastColumnIndex = dgvDrawBox.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                                        DataGridViewElementStates.None).Index;
                int lastColumnRight = dgvDrawBox.GetCellDisplayRectangle(lastColumnIndex, rowIndex, false).Right;

                // Draw the top border of the row
                e.Graphics.DrawLine(pen, rowLeft, rowTop, lastColumnRight - 1, rowTop);

                // Draw the bottom border of the row
                e.Graphics.DrawLine(pen, rowLeft, rowBottom, lastColumnRight - 1, rowBottom);

                // Draw the left border of the row
                e.Graphics.DrawLine(pen, rowLeft, rowTop, rowLeft, rowBottom);

                // Draw the right border of the row
                e.Graphics.DrawLine(pen, lastColumnRight - 1, rowTop, lastColumnRight - 1, rowBottom);
            }
        }

        // Malls //
        private void btnLoadMalls_Click(object sender, EventArgs e)
        {
            // calls file diaglog with file extension to display
            txtPathMalls.Text = CommonAccess.getFilePath("Text or csv files (*.txt;*.csv)|*.txt;*.csv");
            PreviewOkMalls = false;
        }

        private void btnPreviewMalls_Click(object sender, EventArgs e)
        {
            if ("No file selected" == txtPathMalls.Text)
            {
                lblResultMalls.Text = "No file to Preview";
                PreviewOkMalls = false;
            }
            else
            {
                try
                {
                    int totalRec = 0;
                    int errRecNo = 0;
                    mallsVM.vmDatagrid.Clear(); //clear view model, which will clear grid as well

                    using (TextFieldParser parser = new TextFieldParser(txtPathMalls.Text))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");

                        // escape quotes. if data has double quotes,
                        // setting to false will create problem in splitting the fields
                        parser.HasFieldsEnclosedInQuotes = true;

                        // Read the header (in csv file, 1st row contain the header, not data
                        string[] headers = parser.ReadFields();
                        //mallId    name    street    postalCode    website    lat    lng    tel    description    numOfLikes

                        bool validCsv = false;

                        //verify in case wrong csv file
                        if (headers.Length == 10 && headers[9] == "numOfLikes")
                            validCsv = true;

                        if (validCsv)
                        {
                            while (!parser.EndOfData)
                            {
                                totalRec++;
                                string[] fields = parser.ReadFields();
                                Console.WriteLine(fields.Length);

                                // This is one row of the Gridview entries
                                // use view model constructor to update fields and perform error checking
                                ViewModel_Mall_DataGrid_Row vmd = new ViewModel_Mall_DataGrid_Row(fields);

                                // Add 1 row of data to the List
                                mallsVM.vmDatagrid.Add(vmd); //for display

                                if (null == vmd.getDBData())
                                    errRecNo++;
                            }

                            // Remove the blue highlighting of the first cell, may not be necessary 
                            //dgvMalls.CurrentCell = null;
                            lblResultMalls.Text = $"Found {totalRec} records, {errRecNo} error records";
                            PreviewOkMalls = true;
                        }
                        else
                        {
                            lblResultMalls.Text = $"Please select the correct csv";
                            MessageBox.Show("Please select the correct csv");
                        }
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Invalid file Path. Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnSaveMalls_Click(object sender, EventArgs e)
        {
            if (!PreviewOkMalls)
                btnPreviewMalls.PerformClick(); //in case save button is clicked before Preview button is clicked
            if (PreviewOkMalls)
            {

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Console.WriteLine($"Calling Task.Run(() => updataAsyncDBLoopMall());");
                    // Call the asynchronous method and return immediately,
                    Task.Run(() => updataAsyncDBLoopMall());

                }
                catch (Exception ex)
                {
                    // Perform UI-related actions on the UI thread
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        this.Cursor = Cursors.Default;
                    }));
                }
            }
        }

        // Create as a Task as we want to run it in a seperate Thread
        // Need Task.Run() to run it in Background
        private async Task updataAsyncDBLoopMall() // need the asyn so we can use await  Task.Delay(1); 
        {
            try
            {
                int totalRec = mallsVM.vmDatagrid.Count;
                int curRec = 0;

                //Loop through all rows of GridView
                foreach (var mallVm in mallsVM.vmDatagrid)
                {
                    Mall oMall = mallVm.getDBData();
                    if (oMall != null) // null means gor error, then don't save
                    {
                        //if can find means current row existed in DB, we need to update instead of add
                        // Default will return null if cannot find
                        Mall existingMall = dbContext.Malls.SingleOrDefault(x => x.MallId == oMall.MallId);

                        // can't find in DB, so we need to add in
                        if (existingMall == null)
                        {
                            dbContext.Malls.Add(oMall); // add new record
                        }
                        else // DB has this record
                        {
                            mallVm.updateExistingDBRecord(existingMall); //update values to existingMall                    
                        }

                        //SaveChanges() will update the EF entities data to DB
                        int affectedRecords = dbContext.SaveChanges();
                    }

                    curRec++;

                    // Task.Run() cause this to run in background (Non UI Thread), thus we need to use Invoke to 
                    // Queue this UI update for UI Thread to perform
                    // This updates how many records processed so far
                    Invoke(new Action(() =>
                    {
                        lblMallProcess.Text = $"Process record {curRec} of {totalRec}";

                    }));
                    await Task.Delay(1); //the update is very fast. This is just for UI to show the label changing
                }

                //Inform when all records saved
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Mall data has been successfully imported into the database.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception : {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvMalls_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // e.RowIndex is the current row number
            if (null == mallsVM.vmDatagrid[e.RowIndex].getDBData()) // draw when this row has error
                DrawRedRectangle(dgvMalls, e);
        }

        private void dgvMalls_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (null == mallsVM.vmDatagrid[e.RowIndex].getDBData())
            {
                // Cell: Set the text color to red for this particular cell
                e.CellStyle.ForeColor = Color.Red;

                // Whole Row: set the BG color of the whole row 
                dgvMalls.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dgvMalls_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // only show when there is error
                if (null == mallsVM.vmDatagrid[e.RowIndex].getDBData())
                    new FrmViewMallErrorDetails(mallsVM.vmDatagrid[e.RowIndex]).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in dgvMalls_CellMouseDoubleClick() : {ex.ToString()}");
            }
        }

        // User //
        private void btnLoadUser_Click(object sender, EventArgs e)
        {
            // calls file diaglog with file extension to display
            txtPathUser.Text = CommonAccess.getFilePath("Text or csv files (*.txt;*.csv)|*.txt;*.csv");
            PreviewOkMalls = false;
        }

        private void btnPreviewUser_Click(object sender, EventArgs e)
        {
            if ("No file selected" == txtPathUser.Text)
            {
                lblResultUser.Text = "No file to Preview";
                PreviewOkMalls = false;
            }
            else
            {
                try
                {
                    int totalRec = 0;
                    int errRecNo = 0;
                    userVM.vmDatagrid.Clear(); //clear view model, which will clear grid as well

                    using (TextFieldParser parser = new TextFieldParser(txtPathUser.Text))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");

                        // escape quotes. if data has double quotes,
                        // setting to false will create problem in splitting the fields
                        parser.HasFieldsEnclosedInQuotes = true;

                        // Read the header (in csv file, 1st row contain the header, not data
                        string[] headers = parser.ReadFields();
                        //mallId    name    street    postalCode    website    lat    lng    tel    description    numOfLikes

                        bool validCsv = false;

                        //verify in case wrong csv file
                        if (headers.Length == 3 && headers[2] == "Role")
                            validCsv = true;

                        if (validCsv)
                        {
                            while (!parser.EndOfData)
                            {
                                totalRec++;
                                string[] fields = parser.ReadFields();
                                Console.WriteLine(fields.Length);

                                // This is one row of the Gridview entries
                                // use view model constructor to update fields and perform error checking
                                ViewModel_User_DataGrid_Row vmd = new ViewModel_User_DataGrid_Row(fields);

                                // Add 1 row of data to the List
                                userVM.vmDatagrid.Add(vmd); //for display

                                if (null == vmd.getDBData())
                                    errRecNo++;
                            }

                            // Remove the blue highlighting of the first cell, may not be necessary 
                            //dgvMalls.CurrentCell = null;
                            lblResultUser.Text = $"Found {totalRec} records, {errRecNo} error records";
                            PreviewOkUser = true;
                        }
                        else
                        {
                            lblResultUser.Text = $"Please select the correct csv";
                            MessageBox.Show("Please select the correct csv");
                        }
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Invalid file Path. Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!PreviewOkUser)
                btnPreviewUser.PerformClick(); //in case save button is clicked before Preview button is clicked
            if (PreviewOkUser)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Console.WriteLine($"Calling Task.Run(() => updataAsyncDBLoopUser());");
                    Task.Run(() => updataAsyncDBLoopUser());
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        this.Cursor = Cursors.Default;
                    }));
                }
            }
        }

        private async Task updataAsyncDBLoopUser() // need the asyn so we can use await  Task.Delay(1); 
        {
            try
            {
                int totalRec = userVM.vmDatagrid.Count;
                int curRec = 0;

                //Loop through all rows of GridView
                foreach (var userVm in userVM.vmDatagrid)
                {
                    User oUser = userVm.getDBData();
                    if (oUser != null)
                    {
                        User existingUser = dbContext.Users.SingleOrDefault(x => x.UserId == oUser.UserId);

                        if (existingUser == null)
                        {
                            dbContext.Users.Add(oUser);
                        }
                        else 
                        {
                            userVm.updateExistingDBRecord(existingUser);                 
                        }

                        int affectedRecords = dbContext.SaveChanges();
                    }

                    curRec++;

                    Invoke(new Action(() =>
                    {
                        lblUserProcess.Text = $"Process record {curRec} of {totalRec}";

                    }));
                    await Task.Delay(1);
                }

                Invoke(new Action(() =>
                {
                    MessageBox.Show("User data has been successfully imported into the database.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception : {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // e.RowIndex is the current row number
            if (null == userVM.vmDatagrid[e.RowIndex].getDBData()) // draw when this row has error
                DrawRedRectangle(dgvUser, e);
        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (null == userVM.vmDatagrid[e.RowIndex].getDBData())
            {
                // Cell: Set the text color to red for this particular cell
                e.CellStyle.ForeColor = Color.Red;

                // Whole Row: set the BG color of the whole row 
                dgvUser.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dgvUser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // only show when there is error
                if (null == userVM.vmDatagrid[e.RowIndex].getDBData())
                    new FrmViewUserErrorDetails(userVM.vmDatagrid[e.RowIndex]).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in dgvUser_CellMouseDoubleClick() : {ex.ToString()}");
            }
        }

        // Categories //
        private void btnLoadCategories_Click(object sender, EventArgs e)
        {
            txtPathCategories.Text = CommonAccess.getFilePath("XML files (*.xml;)|*.xml");
            PreviewOkCategories = false;
        }

        private void btnPreviewCategories_Click(object sender, EventArgs e)
        {
            if ("No file selected" == txtPathCategories.Text)
            {
                lblResultCategories.Text = "No file to Preview";
                PreviewOkCategories = false;
            }
            else
            {
                try
                {
                    int totalRec = 0;
                    int errRecNo = 0;
                    categoriesVM.vmDatagrid.Clear();

                    XElement dataXML = XElement.Load(txtPathCategories.Text);

                    bool validXml = false;
                    if (dataXML.Elements().First().Elements().Count() == 2 && dataXML.Elements().First().Elements().First().Name.LocalName == "catCode")
                        validXml = true;

                    if (validXml)
                    {
                        foreach (var element in dataXML.Elements())
                        {
                            totalRec++;
                            var elements = element.Elements();
                            Console.WriteLine(elements.Count());

                            // This is one row of the Gridview entries
                            // use view model constructor to update fields and perform error checking
                            ViewModel_Categories_DataGrid_Row vmd = new ViewModel_Categories_DataGrid_Row(elements);

                            // Add 1 row of data to the List
                            categoriesVM.vmDatagrid.Add(vmd); //for display

                            if (null == vmd.getDBData())
                                errRecNo++;
                        }

                        lblResultCategories.Text = $"Found {totalRec} records, {errRecNo} error records";
                        PreviewOkCategories = true;
                    }
                    else
                    {
                        lblResultCategories.Text = $"Please select the correct xml";
                        MessageBox.Show("Please select the correct xml");
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Invalid file Path. Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnSaveCategories_Click(object sender, EventArgs e)
        {
            if (!PreviewOkCategories)
                btnPreviewCategories.PerformClick(); //in case save button is clicked before Preview button is clicked
            if (PreviewOkCategories)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Console.WriteLine($"Calling Task.Run(() => updataAsyncDBLoopCategories());");
                    Task.Run(() => updataAsyncDBLoopCategories());
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        this.Cursor = Cursors.Default;
                    }));
                }
            }
        }

        private async Task updataAsyncDBLoopCategories() // need the asyn so we can use await  Task.Delay(1); 
        {
            try
            {
                int totalRec = categoriesVM.vmDatagrid.Count;
                int curRec = 0;

                //Loop through all rows of GridView
                foreach (var categoryVm in categoriesVM.vmDatagrid)
                {
                    StoreCategory oCategory = categoryVm.getDBData();
                    if (oCategory != null)
                    {
                        StoreCategory existingCategory = dbContext.StoreCategories.SingleOrDefault(x => x.CatCode == oCategory.CatCode);

                        if (existingCategory == null)
                        {
                            dbContext.StoreCategories.Add(oCategory);
                        }
                        else
                        {
                            categoryVm.updateExistingDBRecord(existingCategory);
                        }

                        int affectedRecords = dbContext.SaveChanges();
                    }

                    curRec++;

                    Invoke(new Action(() =>
                    {
                        lblCategoriesProcess.Text = $"Process record {curRec} of {totalRec}";

                    }));
                    await Task.Delay(1);
                }

                Invoke(new Action(() =>
                {
                    MessageBox.Show("Store Category data has been successfully imported into the database.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception : {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvCategories_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (null == categoriesVM.vmDatagrid[e.RowIndex].getDBData()) // draw when this row has error
                DrawRedRectangle(dgvCategories, e);
        }

        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (null == categoriesVM.vmDatagrid[e.RowIndex].getDBData())
            {
                e.CellStyle.ForeColor = Color.Red;
                dgvCategories.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dgvCategories_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (null == categoriesVM.vmDatagrid[e.RowIndex].getDBData())
                    new FrmViewCategoriesErrorDetails(categoriesVM.vmDatagrid[e.RowIndex]).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in dgvCategories_CellMouseDoubleClick() : {ex.ToString()}");
            }
        }

        // Stores //
        private void btnLoadStores_Click(object sender, EventArgs e)
        {
            txtPathStores.Text = CommonAccess.getFilePath("XML files (*.xml;)|*.xml");
            PreviewOkStores = false;
        }

        private void btnPreviewStores_Click(object sender, EventArgs e)
        {
            if ("No file selected" == txtPathStores.Text)
            {
                lblResultStores.Text = "No file to Preview";
                PreviewOkStores = false;
            }
            else
            {
                try
                {
                    int totalRec = 0;
                    int errRecNo = 0;
                    storesVM.vmDatagrid.Clear();

                    XElement dataXML = XElement.Load(txtPathStores.Text);

                    bool validXml = false;
                    if (dataXML.Elements().First().Elements().Count() == 8 && dataXML.Elements().First().Elements().First().Name.LocalName == "storeId")
                        validXml = true;

                    if (validXml)
                    {
                        foreach (var element in dataXML.Elements())
                        {
                            totalRec++;
                            var elements = element.Elements();
                            Console.WriteLine(elements.Count());

                            // This is one row of the Gridview entries
                            // use view model constructor to update fields and perform error checking
                            ViewModel_Stores_DataGrid_Row vmd = new ViewModel_Stores_DataGrid_Row(elements);

                            // Add 1 row of data to the List
                            storesVM.vmDatagrid.Add(vmd); //for display

                            if (null == vmd.getDBData())
                                errRecNo++;
                        }

                        lblResultStores.Text = $"Found {totalRec} records, {errRecNo} error records";
                        PreviewOkStores = true;
                    }
                    else
                    {
                        lblResultStores.Text = $"Please select the correct xml";
                        MessageBox.Show("Please select the correct xml");
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Invalid file Path. Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnSaveStores_Click(object sender, EventArgs e)
        {
            if (!PreviewOkStores)
                btnPreviewStores.PerformClick(); //in case save button is clicked before Preview button is clicked
            if (PreviewOkStores)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Console.WriteLine($"Calling Task.Run(() => updataAsyncDBLoopStores());");
                    Task.Run(() => updataAsyncDBLoopStores());
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        this.Cursor = Cursors.Default;
                    }));
                }
            }
        }

        private async Task updataAsyncDBLoopStores() // need the asyn so we can use await  Task.Delay(1); 
        {
            try
            {
                int totalRec = storesVM.vmDatagrid.Count;
                int curRec = 0;

                //Loop through all rows of GridView
                foreach (var storeVm in storesVM.vmDatagrid)
                {
                    Store oStore = storeVm.getDBData();
                    if (oStore != null)
                    {
                        Store existingStore = dbContext.Stores.SingleOrDefault(x => x.StoreId == oStore.StoreId);

                        if (existingStore == null)
                        {
                            dbContext.Stores.Add(oStore);
                        }
                        else
                        {
                            storeVm.updateExistingDBRecord(existingStore);
                        }

                        int affectedRecords = dbContext.SaveChanges();
                    }

                    curRec++;

                    Invoke(new Action(() =>
                    {
                        lblStoresProcess.Text = $"Process record {curRec} of {totalRec}";

                    }));
                    //await Task.Delay(1);
                }

                Invoke(new Action(() =>
                {
                    MessageBox.Show("Stores data has been successfully imported into the database.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception : {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvStores_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (null == storesVM.vmDatagrid[e.RowIndex].getDBData()) // draw when this row has error
                DrawRedRectangle(dgvStores, e);
        }

        private void dgvStores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (null == storesVM.vmDatagrid[e.RowIndex].getDBData())
            {
                e.CellStyle.ForeColor = Color.Red;
                dgvStores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dgvStores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (null == storesVM.vmDatagrid[e.RowIndex].getDBData())
                    new FrmViewStoresErrorDetails(storesVM.vmDatagrid[e.RowIndex]).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in dgvStores_CellMouseDoubleClick() : {ex.ToString()}");
            }
        }
    }
}
