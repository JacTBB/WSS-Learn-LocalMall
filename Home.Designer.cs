namespace LocalMall
{
    partial class Home
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
            this.btnImportMall = new System.Windows.Forms.Button();
            this.btmImportUser = new System.Windows.Forms.Button();
            this.btnImportCategories = new System.Windows.Forms.Button();
            this.btnImportStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportMall
            // 
            this.btnImportMall.Location = new System.Drawing.Point(181, 26);
            this.btnImportMall.Name = "btnImportMall";
            this.btnImportMall.Size = new System.Drawing.Size(200, 200);
            this.btnImportMall.TabIndex = 0;
            this.btnImportMall.Text = "Import Malls Data";
            this.btnImportMall.UseVisualStyleBackColor = true;
            this.btnImportMall.Click += new System.EventHandler(this.button1_Click);
            // 
            // btmImportUser
            // 
            this.btmImportUser.Location = new System.Drawing.Point(396, 26);
            this.btmImportUser.Name = "btmImportUser";
            this.btmImportUser.Size = new System.Drawing.Size(200, 200);
            this.btmImportUser.TabIndex = 1;
            this.btmImportUser.Text = "Import User Data";
            this.btmImportUser.UseVisualStyleBackColor = true;
            // 
            // btnImportCategories
            // 
            this.btnImportCategories.Location = new System.Drawing.Point(181, 238);
            this.btnImportCategories.Name = "btnImportCategories";
            this.btnImportCategories.Size = new System.Drawing.Size(200, 200);
            this.btnImportCategories.TabIndex = 2;
            this.btnImportCategories.Text = "Import Store Categories";
            this.btnImportCategories.UseVisualStyleBackColor = true;
            // 
            // btnImportStore
            // 
            this.btnImportStore.Location = new System.Drawing.Point(396, 238);
            this.btnImportStore.Name = "btnImportStore";
            this.btnImportStore.Size = new System.Drawing.Size(200, 200);
            this.btnImportStore.TabIndex = 3;
            this.btnImportStore.Text = "Import Stores Data";
            this.btnImportStore.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImportStore);
            this.Controls.Add(this.btnImportCategories);
            this.Controls.Add(this.btmImportUser);
            this.Controls.Add(this.btnImportMall);
            this.Name = "Home";
            this.Text = "Local Mall Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportMall;
        private System.Windows.Forms.Button btmImportUser;
        private System.Windows.Forms.Button btnImportCategories;
        private System.Windows.Forms.Button btnImportStore;
    }
}

