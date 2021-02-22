
namespace ProjectWorkshop4_CMPP248_Group4
{
    partial class frmModifyPackage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label packageIdLabel;
            System.Windows.Forms.Label pkgAgencyCommissionLabel;
            System.Windows.Forms.Label pkgBasePriceLabel;
            System.Windows.Forms.Label pkgDescLabel;
            System.Windows.Forms.Label pkgEndDateLabel;
            System.Windows.Forms.Label pkgNameLabel;
            System.Windows.Forms.Label pkgStartDateLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.packagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.packageIdTextBox = new System.Windows.Forms.TextBox();
            this.pkgAgencyCommissionTextBox = new System.Windows.Forms.TextBox();
            this.pkgBasePriceTextBox = new System.Windows.Forms.TextBox();
            this.pkgDescTextBox = new System.Windows.Forms.TextBox();
            this.pkgEndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pkgNameTextBox = new System.Windows.Forms.TextBox();
            this.pkgStartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkListExistingProdSupplier = new System.Windows.Forms.CheckedListBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.checkListAddProductSupplier = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlModify = new System.Windows.Forms.Panel();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.checkListAddNewProductSupplier = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            packageIdLabel = new System.Windows.Forms.Label();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgDescLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).BeginInit();
            this.pnlModify.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Location = new System.Drawing.Point(31, 50);
            packageIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(80, 17);
            packageIdLabel.TabIndex = 1;
            packageIdLabel.Text = "Package ID";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(31, 598);
            pkgAgencyCommissionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(193, 17);
            pkgAgencyCommissionLabel.TabIndex = 3;
            pkgAgencyCommissionLabel.Text = "Package Agency Commission";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(31, 567);
            pkgBasePriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(135, 17);
            pkgBasePriceLabel.TabIndex = 5;
            pkgBasePriceLabel.Text = "Package Base Price";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Location = new System.Drawing.Point(31, 113);
            pkgDescLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new System.Drawing.Size(138, 17);
            pkgDescLabel.TabIndex = 7;
            pkgDescLabel.Text = "Package Description";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(31, 535);
            pkgEndDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(126, 17);
            pkgEndDateLabel.TabIndex = 9;
            pkgEndDateLabel.Text = "Package End Date";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(31, 81);
            pkgNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(104, 17);
            pkgNameLabel.TabIndex = 11;
            pkgNameLabel.Text = "Package Name";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(31, 502);
            pkgStartDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(131, 17);
            pkgStartDateLabel.TabIndex = 13;
            pkgStartDateLabel.Text = "Package Start Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(33, 12);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(195, 17);
            label1.TabIndex = 23;
            label1.Text = "Products Included In Package";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 191);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(332, 17);
            label2.TabIndex = 24;
            label2.Text = "Products Not Included In Package (No duplications)";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // packagesBindingSource
            // 
            this.packagesBindingSource.DataSource = typeof(PackagesData.Packages);
            // 
            // packageIdTextBox
            // 
            this.packageIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PackageId", true));
            this.packageIdTextBox.Location = new System.Drawing.Point(245, 45);
            this.packageIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.packageIdTextBox.Name = "packageIdTextBox";
            this.packageIdTextBox.ReadOnly = true;
            this.packageIdTextBox.Size = new System.Drawing.Size(357, 22);
            this.packageIdTextBox.TabIndex = 2;
            // 
            // pkgAgencyCommissionTextBox
            // 
            this.pkgAgencyCommissionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgAgencyCommission", true));
            this.pkgAgencyCommissionTextBox.Location = new System.Drawing.Point(245, 593);
            this.pkgAgencyCommissionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pkgAgencyCommissionTextBox.Name = "pkgAgencyCommissionTextBox";
            this.pkgAgencyCommissionTextBox.Size = new System.Drawing.Size(357, 22);
            this.pkgAgencyCommissionTextBox.TabIndex = 4;
            // 
            // pkgBasePriceTextBox
            // 
            this.pkgBasePriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgBasePrice", true));
            this.pkgBasePriceTextBox.Location = new System.Drawing.Point(245, 562);
            this.pkgBasePriceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pkgBasePriceTextBox.Name = "pkgBasePriceTextBox";
            this.pkgBasePriceTextBox.Size = new System.Drawing.Size(357, 22);
            this.pkgBasePriceTextBox.TabIndex = 6;
            // 
            // pkgDescTextBox
            // 
            this.pkgDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgDesc", true));
            this.pkgDescTextBox.Location = new System.Drawing.Point(245, 108);
            this.pkgDescTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pkgDescTextBox.Name = "pkgDescTextBox";
            this.pkgDescTextBox.Size = new System.Drawing.Size(357, 22);
            this.pkgDescTextBox.TabIndex = 8;
            // 
            // pkgEndDateDateTimePicker
            // 
            this.pkgEndDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packagesBindingSource, "PkgEndDate", true));
            this.pkgEndDateDateTimePicker.Location = new System.Drawing.Point(245, 529);
            this.pkgEndDateDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.pkgEndDateDateTimePicker.Name = "pkgEndDateDateTimePicker";
            this.pkgEndDateDateTimePicker.Size = new System.Drawing.Size(357, 22);
            this.pkgEndDateDateTimePicker.TabIndex = 10;
            // 
            // pkgNameTextBox
            // 
            this.pkgNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgName", true));
            this.pkgNameTextBox.Location = new System.Drawing.Point(245, 76);
            this.pkgNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pkgNameTextBox.Name = "pkgNameTextBox";
            this.pkgNameTextBox.Size = new System.Drawing.Size(357, 22);
            this.pkgNameTextBox.TabIndex = 12;
            // 
            // pkgStartDateDateTimePicker
            // 
            this.pkgStartDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packagesBindingSource, "PkgStartDate", true));
            this.pkgStartDateDateTimePicker.Location = new System.Drawing.Point(245, 496);
            this.pkgStartDateDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.pkgStartDateDateTimePicker.Name = "pkgStartDateDateTimePicker";
            this.pkgStartDateDateTimePicker.Size = new System.Drawing.Size(357, 22);
            this.pkgStartDateDateTimePicker.TabIndex = 14;
            // 
            // checkListExistingProdSupplier
            // 
            this.checkListExistingProdSupplier.FormattingEnabled = true;
            this.checkListExistingProdSupplier.Location = new System.Drawing.Point(36, 39);
            this.checkListExistingProdSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.checkListExistingProdSupplier.Name = "checkListExistingProdSupplier";
            this.checkListExistingProdSupplier.Size = new System.Drawing.Size(357, 140);
            this.checkListExistingProdSupplier.TabIndex = 15;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(153, 652);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(131, 50);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "&Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click_1);
            // 
            // checkListAddProductSupplier
            // 
            this.checkListAddProductSupplier.FormattingEnabled = true;
            this.checkListAddProductSupplier.Location = new System.Drawing.Point(36, 221);
            this.checkListAddProductSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.checkListAddProductSupplier.Name = "checkListAddProductSupplier";
            this.checkListAddProductSupplier.Size = new System.Drawing.Size(357, 123);
            this.checkListAddProductSupplier.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(405, 652);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 50);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // pnlModify
            // 
            this.pnlModify.Controls.Add(label2);
            this.pnlModify.Controls.Add(label1);
            this.pnlModify.Controls.Add(this.checkListExistingProdSupplier);
            this.pnlModify.Controls.Add(this.checkListAddProductSupplier);
            this.pnlModify.Location = new System.Drawing.Point(209, 140);
            this.pnlModify.Margin = new System.Windows.Forms.Padding(4);
            this.pnlModify.Name = "pnlModify";
            this.pnlModify.Size = new System.Drawing.Size(478, 348);
            this.pnlModify.TabIndex = 20;
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(label3);
            this.pnlAdd.Controls.Add(this.checkListAddNewProductSupplier);
            this.pnlAdd.Location = new System.Drawing.Point(209, 134);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(431, 350);
            this.pnlAdd.TabIndex = 21;
            // 
            // checkListAddNewProductSupplier
            // 
            this.checkListAddNewProductSupplier.FormattingEnabled = true;
            this.checkListAddNewProductSupplier.Location = new System.Drawing.Point(30, 45);
            this.checkListAddNewProductSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.checkListAddNewProductSupplier.Name = "checkListAddNewProductSupplier";
            this.checkListAddNewProductSupplier.Size = new System.Drawing.Size(363, 276);
            this.checkListAddNewProductSupplier.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(153, 652);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 50);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 14);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(373, 17);
            label3.TabIndex = 23;
            label3.Text = "Choose Products To Include in Package (No Duplications)";
            // 
            // frmModifyPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 759);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(packageIdLabel);
            this.Controls.Add(this.packageIdTextBox);
            this.Controls.Add(pkgAgencyCommissionLabel);
            this.Controls.Add(this.pkgAgencyCommissionTextBox);
            this.Controls.Add(pkgBasePriceLabel);
            this.Controls.Add(this.pkgBasePriceTextBox);
            this.Controls.Add(pkgDescLabel);
            this.Controls.Add(this.pkgDescTextBox);
            this.Controls.Add(pkgEndDateLabel);
            this.Controls.Add(this.pkgEndDateDateTimePicker);
            this.Controls.Add(pkgNameLabel);
            this.Controls.Add(this.pkgNameTextBox);
            this.Controls.Add(pkgStartDateLabel);
            this.Controls.Add(this.pkgStartDateDateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmModifyPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmModifyPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).EndInit();
            this.pnlModify.ResumeLayout(false);
            this.pnlModify.PerformLayout();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource packagesBindingSource;
        private System.Windows.Forms.TextBox packageIdTextBox;
        private System.Windows.Forms.TextBox pkgAgencyCommissionTextBox;
        private System.Windows.Forms.TextBox pkgBasePriceTextBox;
        private System.Windows.Forms.TextBox pkgDescTextBox;
        private System.Windows.Forms.DateTimePicker pkgEndDateDateTimePicker;
        private System.Windows.Forms.TextBox pkgNameTextBox;
        private System.Windows.Forms.DateTimePicker pkgStartDateDateTimePicker;
        private System.Windows.Forms.CheckedListBox checkListExistingProdSupplier;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.CheckedListBox checkListAddProductSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlModify;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.CheckedListBox checkListAddNewProductSupplier;
        private System.Windows.Forms.Button btnAdd;
    }
}