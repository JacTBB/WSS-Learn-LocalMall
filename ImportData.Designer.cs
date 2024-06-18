namespace LocalMall
{
    partial class ImportData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMalls = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMalls = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblResultMalls = new System.Windows.Forms.Label();
            this.btnPreviewMalls = new System.Windows.Forms.Button();
            this.txtPathMalls = new System.Windows.Forms.TextBox();
            this.btnLoadMalls = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveMalls = new System.Windows.Forms.Button();
            this.lblMallProcess = new System.Windows.Forms.Label();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblResultUser = new System.Windows.Forms.Label();
            this.btnPreviewUser = new System.Windows.Forms.Button();
            this.txtPathUser = new System.Windows.Forms.TextBox();
            this.btnLoadUser = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.lblUserProcess = new System.Windows.Forms.Label();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblResultCategories = new System.Windows.Forms.Label();
            this.btnPreviewCategories = new System.Windows.Forms.Button();
            this.txtPathCategories = new System.Windows.Forms.TextBox();
            this.btnLoadCategories = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSaveCategories = new System.Windows.Forms.Button();
            this.lblCategoriesProcess = new System.Windows.Forms.Label();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgvStores = new System.Windows.Forms.DataGridView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblResultStores = new System.Windows.Forms.Label();
            this.btnPreviewStores = new System.Windows.Forms.Button();
            this.txtPathStores = new System.Windows.Forms.TextBox();
            this.btnLoadStores = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnSaveStores = new System.Windows.Forms.Button();
            this.lblStoresProcess = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabMalls.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalls)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabStore.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxLogo.ImageLocation = "C:\\Users\\jackie\\Development\\WorldSkills\\Learning\\LocalMall\\Data_Files\\Images\\logo" +
    ".png";
            this.picBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.picBoxLogo.MaximumSize = new System.Drawing.Size(220, 55);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.picBoxLogo.Size = new System.Drawing.Size(220, 55);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogo.TabIndex = 0;
            this.picBoxLogo.TabStop = false;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabMalls);
            this.tabControlMain.Controls.Add(this.tabUser);
            this.tabControlMain.Controls.Add(this.tabCategories);
            this.tabControlMain.Controls.Add(this.tabStore);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 55);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 458);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabMalls
            // 
            this.tabMalls.BackColor = System.Drawing.SystemColors.Control;
            this.tabMalls.Controls.Add(this.panel3);
            this.tabMalls.Controls.Add(this.panel2);
            this.tabMalls.Controls.Add(this.panel1);
            this.tabMalls.Location = new System.Drawing.Point(4, 25);
            this.tabMalls.Name = "tabMalls";
            this.tabMalls.Padding = new System.Windows.Forms.Padding(3);
            this.tabMalls.Size = new System.Drawing.Size(792, 429);
            this.tabMalls.TabIndex = 0;
            this.tabMalls.Text = "Malls";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMalls);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 263);
            this.panel3.TabIndex = 9;
            // 
            // dgvMalls
            // 
            this.dgvMalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMalls.Location = new System.Drawing.Point(0, 0);
            this.dgvMalls.Name = "dgvMalls";
            this.dgvMalls.RowHeadersWidth = 51;
            this.dgvMalls.RowTemplate.Height = 24;
            this.dgvMalls.Size = new System.Drawing.Size(786, 263);
            this.dgvMalls.TabIndex = 4;
            this.dgvMalls.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMalls_CellFormatting);
            this.dgvMalls.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMalls_CellMouseDoubleClick);
            this.dgvMalls.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMalls_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblResultMalls);
            this.panel2.Controls.Add(this.btnPreviewMalls);
            this.panel2.Controls.Add(this.txtPathMalls);
            this.panel2.Controls.Add(this.btnLoadMalls);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 100);
            this.panel2.TabIndex = 8;
            // 
            // lblResultMalls
            // 
            this.lblResultMalls.AutoSize = true;
            this.lblResultMalls.Location = new System.Drawing.Point(3, 76);
            this.lblResultMalls.Name = "lblResultMalls";
            this.lblResultMalls.Size = new System.Drawing.Size(121, 16);
            this.lblResultMalls.TabIndex = 3;
            this.lblResultMalls.Text = "Found XXX records";
            // 
            // btnPreviewMalls
            // 
            this.btnPreviewMalls.BackColor = System.Drawing.Color.LightGray;
            this.btnPreviewMalls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewMalls.Location = new System.Drawing.Point(0, 40);
            this.btnPreviewMalls.Name = "btnPreviewMalls";
            this.btnPreviewMalls.Size = new System.Drawing.Size(84, 29);
            this.btnPreviewMalls.TabIndex = 2;
            this.btnPreviewMalls.Text = "Preview";
            this.btnPreviewMalls.UseVisualStyleBackColor = false;
            this.btnPreviewMalls.Click += new System.EventHandler(this.btnPreviewMalls_Click);
            // 
            // txtPathMalls
            // 
            this.txtPathMalls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathMalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathMalls.Location = new System.Drawing.Point(0, 0);
            this.txtPathMalls.Name = "txtPathMalls";
            this.txtPathMalls.Size = new System.Drawing.Size(513, 30);
            this.txtPathMalls.TabIndex = 0;
            // 
            // btnLoadMalls
            // 
            this.btnLoadMalls.BackColor = System.Drawing.Color.LightGray;
            this.btnLoadMalls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMalls.Location = new System.Drawing.Point(512, 0);
            this.btnLoadMalls.Name = "btnLoadMalls";
            this.btnLoadMalls.Size = new System.Drawing.Size(83, 30);
            this.btnLoadMalls.TabIndex = 1;
            this.btnLoadMalls.Text = "Browse";
            this.btnLoadMalls.UseVisualStyleBackColor = false;
            this.btnLoadMalls.Click += new System.EventHandler(this.btnLoadMalls_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveMalls);
            this.panel1.Controls.Add(this.lblMallProcess);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 60);
            this.panel1.TabIndex = 7;
            // 
            // btnSaveMalls
            // 
            this.btnSaveMalls.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSaveMalls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMalls.Location = new System.Drawing.Point(5, 6);
            this.btnSaveMalls.Name = "btnSaveMalls";
            this.btnSaveMalls.Size = new System.Drawing.Size(84, 29);
            this.btnSaveMalls.TabIndex = 5;
            this.btnSaveMalls.Text = "Save";
            this.btnSaveMalls.UseVisualStyleBackColor = false;
            this.btnSaveMalls.Click += new System.EventHandler(this.btnSaveMalls_Click);
            // 
            // lblMallProcess
            // 
            this.lblMallProcess.AutoSize = true;
            this.lblMallProcess.Location = new System.Drawing.Point(95, 12);
            this.lblMallProcess.Name = "lblMallProcess";
            this.lblMallProcess.Size = new System.Drawing.Size(92, 16);
            this.lblMallProcess.TabIndex = 6;
            this.lblMallProcess.Text = "Awaiting Save";
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.panel6);
            this.tabUser.Controls.Add(this.panel4);
            this.tabUser.Controls.Add(this.panel5);
            this.tabUser.Location = new System.Drawing.Point(4, 25);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(792, 429);
            this.tabUser.TabIndex = 1;
            this.tabUser.Text = "User";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvUser);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 103);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 263);
            this.panel6.TabIndex = 11;
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.Size = new System.Drawing.Size(786, 263);
            this.dgvUser.TabIndex = 4;
            this.dgvUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUser_CellFormatting);
            this.dgvUser.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUser_CellMouseDoubleClick);
            this.dgvUser.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUser_RowPostPaint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblResultUser);
            this.panel4.Controls.Add(this.btnPreviewUser);
            this.panel4.Controls.Add(this.txtPathUser);
            this.panel4.Controls.Add(this.btnLoadUser);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 100);
            this.panel4.TabIndex = 10;
            // 
            // lblResultUser
            // 
            this.lblResultUser.AutoSize = true;
            this.lblResultUser.Location = new System.Drawing.Point(3, 76);
            this.lblResultUser.Name = "lblResultUser";
            this.lblResultUser.Size = new System.Drawing.Size(121, 16);
            this.lblResultUser.TabIndex = 3;
            this.lblResultUser.Text = "Found XXX records";
            // 
            // btnPreviewUser
            // 
            this.btnPreviewUser.BackColor = System.Drawing.Color.LightGray;
            this.btnPreviewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewUser.Location = new System.Drawing.Point(0, 40);
            this.btnPreviewUser.Name = "btnPreviewUser";
            this.btnPreviewUser.Size = new System.Drawing.Size(84, 29);
            this.btnPreviewUser.TabIndex = 2;
            this.btnPreviewUser.Text = "Preview";
            this.btnPreviewUser.UseVisualStyleBackColor = false;
            this.btnPreviewUser.Click += new System.EventHandler(this.btnPreviewUser_Click);
            // 
            // txtPathUser
            // 
            this.txtPathUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathUser.Location = new System.Drawing.Point(0, 0);
            this.txtPathUser.Name = "txtPathUser";
            this.txtPathUser.Size = new System.Drawing.Size(513, 30);
            this.txtPathUser.TabIndex = 0;
            // 
            // btnLoadUser
            // 
            this.btnLoadUser.BackColor = System.Drawing.Color.LightGray;
            this.btnLoadUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadUser.Location = new System.Drawing.Point(512, 0);
            this.btnLoadUser.Name = "btnLoadUser";
            this.btnLoadUser.Size = new System.Drawing.Size(83, 30);
            this.btnLoadUser.TabIndex = 1;
            this.btnLoadUser.Text = "Browse";
            this.btnLoadUser.UseVisualStyleBackColor = false;
            this.btnLoadUser.Click += new System.EventHandler(this.btnLoadUser_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSaveUser);
            this.panel5.Controls.Add(this.lblUserProcess);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 366);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(786, 60);
            this.panel5.TabIndex = 9;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUser.Location = new System.Drawing.Point(5, 6);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(84, 29);
            this.btnSaveUser.TabIndex = 5;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // lblUserProcess
            // 
            this.lblUserProcess.AutoSize = true;
            this.lblUserProcess.Location = new System.Drawing.Point(95, 12);
            this.lblUserProcess.Name = "lblUserProcess";
            this.lblUserProcess.Size = new System.Drawing.Size(92, 16);
            this.lblUserProcess.TabIndex = 6;
            this.lblUserProcess.Text = "Awaiting Save";
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.panel7);
            this.tabCategories.Controls.Add(this.panel8);
            this.tabCategories.Controls.Add(this.panel9);
            this.tabCategories.Location = new System.Drawing.Point(4, 25);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(792, 429);
            this.tabCategories.TabIndex = 2;
            this.tabCategories.Text = "Store Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvCategories);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 103);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(786, 263);
            this.panel7.TabIndex = 14;
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(0, 0);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 24;
            this.dgvCategories.Size = new System.Drawing.Size(786, 263);
            this.dgvCategories.TabIndex = 4;
            this.dgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            this.dgvCategories.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategories_CellMouseDoubleClick);
            this.dgvCategories.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCategories_RowPostPaint);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblResultCategories);
            this.panel8.Controls.Add(this.btnPreviewCategories);
            this.panel8.Controls.Add(this.txtPathCategories);
            this.panel8.Controls.Add(this.btnLoadCategories);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(786, 100);
            this.panel8.TabIndex = 13;
            // 
            // lblResultCategories
            // 
            this.lblResultCategories.AutoSize = true;
            this.lblResultCategories.Location = new System.Drawing.Point(3, 76);
            this.lblResultCategories.Name = "lblResultCategories";
            this.lblResultCategories.Size = new System.Drawing.Size(121, 16);
            this.lblResultCategories.TabIndex = 3;
            this.lblResultCategories.Text = "Found XXX records";
            // 
            // btnPreviewCategories
            // 
            this.btnPreviewCategories.BackColor = System.Drawing.Color.LightGray;
            this.btnPreviewCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewCategories.Location = new System.Drawing.Point(0, 40);
            this.btnPreviewCategories.Name = "btnPreviewCategories";
            this.btnPreviewCategories.Size = new System.Drawing.Size(84, 29);
            this.btnPreviewCategories.TabIndex = 2;
            this.btnPreviewCategories.Text = "Preview";
            this.btnPreviewCategories.UseVisualStyleBackColor = false;
            this.btnPreviewCategories.Click += new System.EventHandler(this.btnPreviewCategories_Click);
            // 
            // txtPathCategories
            // 
            this.txtPathCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathCategories.Location = new System.Drawing.Point(0, 0);
            this.txtPathCategories.Name = "txtPathCategories";
            this.txtPathCategories.Size = new System.Drawing.Size(513, 30);
            this.txtPathCategories.TabIndex = 0;
            // 
            // btnLoadCategories
            // 
            this.btnLoadCategories.BackColor = System.Drawing.Color.LightGray;
            this.btnLoadCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCategories.Location = new System.Drawing.Point(512, 0);
            this.btnLoadCategories.Name = "btnLoadCategories";
            this.btnLoadCategories.Size = new System.Drawing.Size(83, 30);
            this.btnLoadCategories.TabIndex = 1;
            this.btnLoadCategories.Text = "Browse";
            this.btnLoadCategories.UseVisualStyleBackColor = false;
            this.btnLoadCategories.Click += new System.EventHandler(this.btnLoadCategories_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnSaveCategories);
            this.panel9.Controls.Add(this.lblCategoriesProcess);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(3, 366);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(786, 60);
            this.panel9.TabIndex = 12;
            // 
            // btnSaveCategories
            // 
            this.btnSaveCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSaveCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCategories.Location = new System.Drawing.Point(5, 6);
            this.btnSaveCategories.Name = "btnSaveCategories";
            this.btnSaveCategories.Size = new System.Drawing.Size(84, 29);
            this.btnSaveCategories.TabIndex = 5;
            this.btnSaveCategories.Text = "Save";
            this.btnSaveCategories.UseVisualStyleBackColor = false;
            this.btnSaveCategories.Click += new System.EventHandler(this.btnSaveCategories_Click);
            // 
            // lblCategoriesProcess
            // 
            this.lblCategoriesProcess.AutoSize = true;
            this.lblCategoriesProcess.Location = new System.Drawing.Point(95, 12);
            this.lblCategoriesProcess.Name = "lblCategoriesProcess";
            this.lblCategoriesProcess.Size = new System.Drawing.Size(92, 16);
            this.lblCategoriesProcess.TabIndex = 6;
            this.lblCategoriesProcess.Text = "Awaiting Save";
            // 
            // tabStore
            // 
            this.tabStore.Controls.Add(this.panel10);
            this.tabStore.Controls.Add(this.panel11);
            this.tabStore.Controls.Add(this.panel12);
            this.tabStore.Location = new System.Drawing.Point(4, 25);
            this.tabStore.Name = "tabStore";
            this.tabStore.Padding = new System.Windows.Forms.Padding(3);
            this.tabStore.Size = new System.Drawing.Size(792, 429);
            this.tabStore.TabIndex = 3;
            this.tabStore.Text = "Store";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dgvStores);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 103);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(786, 263);
            this.panel10.TabIndex = 14;
            // 
            // dgvStores
            // 
            this.dgvStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStores.Location = new System.Drawing.Point(0, 0);
            this.dgvStores.Name = "dgvStores";
            this.dgvStores.RowHeadersWidth = 51;
            this.dgvStores.RowTemplate.Height = 24;
            this.dgvStores.Size = new System.Drawing.Size(786, 263);
            this.dgvStores.TabIndex = 4;
            this.dgvStores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStores_CellFormatting);
            this.dgvStores.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStores_CellMouseDoubleClick);
            this.dgvStores.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStores_RowPostPaint);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lblResultStores);
            this.panel11.Controls.Add(this.btnPreviewStores);
            this.panel11.Controls.Add(this.txtPathStores);
            this.panel11.Controls.Add(this.btnLoadStores);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(786, 100);
            this.panel11.TabIndex = 13;
            // 
            // lblResultStores
            // 
            this.lblResultStores.AutoSize = true;
            this.lblResultStores.Location = new System.Drawing.Point(3, 76);
            this.lblResultStores.Name = "lblResultStores";
            this.lblResultStores.Size = new System.Drawing.Size(121, 16);
            this.lblResultStores.TabIndex = 3;
            this.lblResultStores.Text = "Found XXX records";
            // 
            // btnPreviewStores
            // 
            this.btnPreviewStores.BackColor = System.Drawing.Color.LightGray;
            this.btnPreviewStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewStores.Location = new System.Drawing.Point(0, 40);
            this.btnPreviewStores.Name = "btnPreviewStores";
            this.btnPreviewStores.Size = new System.Drawing.Size(84, 29);
            this.btnPreviewStores.TabIndex = 2;
            this.btnPreviewStores.Text = "Preview";
            this.btnPreviewStores.UseVisualStyleBackColor = false;
            this.btnPreviewStores.Click += new System.EventHandler(this.btnPreviewStores_Click);
            // 
            // txtPathStores
            // 
            this.txtPathStores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathStores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathStores.Location = new System.Drawing.Point(0, 0);
            this.txtPathStores.Name = "txtPathStores";
            this.txtPathStores.Size = new System.Drawing.Size(513, 30);
            this.txtPathStores.TabIndex = 0;
            // 
            // btnLoadStores
            // 
            this.btnLoadStores.BackColor = System.Drawing.Color.LightGray;
            this.btnLoadStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadStores.Location = new System.Drawing.Point(512, 0);
            this.btnLoadStores.Name = "btnLoadStores";
            this.btnLoadStores.Size = new System.Drawing.Size(83, 30);
            this.btnLoadStores.TabIndex = 1;
            this.btnLoadStores.Text = "Browse";
            this.btnLoadStores.UseVisualStyleBackColor = false;
            this.btnLoadStores.Click += new System.EventHandler(this.btnLoadStores_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnSaveStores);
            this.panel12.Controls.Add(this.lblStoresProcess);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(3, 366);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(786, 60);
            this.panel12.TabIndex = 12;
            // 
            // btnSaveStores
            // 
            this.btnSaveStores.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSaveStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveStores.Location = new System.Drawing.Point(5, 6);
            this.btnSaveStores.Name = "btnSaveStores";
            this.btnSaveStores.Size = new System.Drawing.Size(84, 29);
            this.btnSaveStores.TabIndex = 5;
            this.btnSaveStores.Text = "Save";
            this.btnSaveStores.UseVisualStyleBackColor = false;
            this.btnSaveStores.Click += new System.EventHandler(this.btnSaveStores_Click);
            // 
            // lblStoresProcess
            // 
            this.lblStoresProcess.AutoSize = true;
            this.lblStoresProcess.Location = new System.Drawing.Point(95, 12);
            this.lblStoresProcess.Name = "lblStoresProcess";
            this.lblStoresProcess.Size = new System.Drawing.Size(92, 16);
            this.lblStoresProcess.TabIndex = 6;
            this.lblStoresProcess.Text = "Awaiting Save";
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFooter.Location = new System.Drawing.Point(0, 492);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.lblFooter.Size = new System.Drawing.Size(316, 21);
            this.lblFooter.TabIndex = 2;
            this.lblFooter.Text = "Copyright 2015. Local Malls Ltd. All rights reserved.";
            // 
            // ImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.picBoxLogo);
            this.Name = "ImportData";
            this.Text = "Import Data";
            this.Load += new System.EventHandler(this.ImportData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabMalls.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalls)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabCategories.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tabStore.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMalls;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabStore;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblMallProcess;
        private System.Windows.Forms.Button btnSaveMalls;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblResultMalls;
        private System.Windows.Forms.Button btnPreviewMalls;
        private System.Windows.Forms.TextBox txtPathMalls;
        private System.Windows.Forms.Button btnLoadMalls;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblResultUser;
        private System.Windows.Forms.Button btnPreviewUser;
        private System.Windows.Forms.TextBox txtPathUser;
        private System.Windows.Forms.Button btnLoadUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label lblUserProcess;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvMalls;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblResultCategories;
        private System.Windows.Forms.Button btnPreviewCategories;
        private System.Windows.Forms.TextBox txtPathCategories;
        private System.Windows.Forms.Button btnLoadCategories;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnSaveCategories;
        private System.Windows.Forms.Label lblCategoriesProcess;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dgvStores;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblResultStores;
        private System.Windows.Forms.Button btnPreviewStores;
        private System.Windows.Forms.TextBox txtPathStores;
        private System.Windows.Forms.Button btnLoadStores;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnSaveStores;
        private System.Windows.Forms.Label lblStoresProcess;
    }
}

