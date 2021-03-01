
namespace ProjectWorkshop4_CMPP248_Group4
{
    partial class frmAddModifySuppliers
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
            System.Windows.Forms.Label supNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            System.Windows.Forms.Label prodNameLabel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.suppliersTypeOfProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppliersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.supNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierIdTextBox = new System.Windows.Forms.TextBox();
            this.productsSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prodNameToAddCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.currentProdCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.pnlModify = new System.Windows.Forms.Panel();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.availableCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            supNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            prodNameLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersTypeOfProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsSuppliersBindingSource)).BeginInit();
            this.pnlModify.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Location = new System.Drawing.Point(26, 72);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(79, 13);
            supNameLabel.TabIndex = 12;
            supNameLabel.Text = "Supplier Name:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Location = new System.Drawing.Point(26, 32);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(60, 13);
            supplierIdLabel.TabIndex = 14;
            supplierIdLabel.Text = "Supplier Id:";
            // 
            // prodNameLabel1
            // 
            prodNameLabel1.AutoSize = true;
            prodNameLabel1.Location = new System.Drawing.Point(14, 12);
            prodNameLabel1.Name = "prodNameLabel1";
            prodNameLabel1.Size = new System.Drawing.Size(97, 13);
            prodNameLabel1.TabIndex = 15;
            prodNameLabel1.Text = "Products Provided:";
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataSource = typeof(SuppliersData.Suppliers);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(56, 349);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(98, 38);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "&Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(56, 349);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 38);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // suppliersTypeOfProductsBindingSource
            // 
            this.suppliersTypeOfProductsBindingSource.DataSource = typeof(Products_SuppliersData.SuppliersTypeOfProducts);
            // 
            // suppliersBindingSource1
            // 
            this.suppliersBindingSource1.DataSource = typeof(SuppliersData.Suppliers);
            // 
            // supNameTextBox
            // 
            this.supNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppliersBindingSource, "SupName", true));
            this.supNameTextBox.Location = new System.Drawing.Point(140, 69);
            this.supNameTextBox.Name = "supNameTextBox";
            this.supNameTextBox.Size = new System.Drawing.Size(187, 20);
            this.supNameTextBox.TabIndex = 13;
            // 
            // supplierIdTextBox
            // 
            this.supplierIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppliersBindingSource, "SupplierId", true));
            this.supplierIdTextBox.Location = new System.Drawing.Point(140, 29);
            this.supplierIdTextBox.Name = "supplierIdTextBox";
            this.supplierIdTextBox.ReadOnly = true;
            this.supplierIdTextBox.Size = new System.Drawing.Size(187, 20);
            this.supplierIdTextBox.TabIndex = 15;
            // 
            // productsSuppliersBindingSource
            // 
            this.productsSuppliersBindingSource.DataSource = typeof(Products_SuppliersData.Products_Suppliers);
            // 
            // prodNameToAddCheckedListBox
            // 
            this.prodNameToAddCheckedListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "ProdName", true));
            this.prodNameToAddCheckedListBox.FormattingEnabled = true;
            this.prodNameToAddCheckedListBox.Location = new System.Drawing.Point(128, 12);
            this.prodNameToAddCheckedListBox.Name = "prodNameToAddCheckedListBox";
            this.prodNameToAddCheckedListBox.Size = new System.Drawing.Size(187, 199);
            this.prodNameToAddCheckedListBox.TabIndex = 16;
            // 
            // currentProdCheckedListBox
            // 
            this.currentProdCheckedListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "ProdName", true));
            this.currentProdCheckedListBox.FormattingEnabled = true;
            this.currentProdCheckedListBox.Location = new System.Drawing.Point(128, 13);
            this.currentProdCheckedListBox.Name = "currentProdCheckedListBox";
            this.currentProdCheckedListBox.Size = new System.Drawing.Size(188, 79);
            this.currentProdCheckedListBox.TabIndex = 17;
            // 
            // pnlModify
            // 
            this.pnlModify.Controls.Add(label2);
            this.pnlModify.Controls.Add(label1);
            this.pnlModify.Controls.Add(this.availableCheckedListBox);
            this.pnlModify.Controls.Add(this.currentProdCheckedListBox);
            this.pnlModify.Location = new System.Drawing.Point(12, 104);
            this.pnlModify.Name = "pnlModify";
            this.pnlModify.Size = new System.Drawing.Size(330, 226);
            this.pnlModify.TabIndex = 18;
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(prodNameLabel1);
            this.pnlAdd.Controls.Add(this.prodNameToAddCheckedListBox);
            this.pnlAdd.Location = new System.Drawing.Point(12, 104);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(330, 226);
            this.pnlAdd.TabIndex = 19;
            // 
            // availableCheckedListBox
            // 
            this.availableCheckedListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "ProdName", true));
            this.availableCheckedListBox.FormattingEnabled = true;
            this.availableCheckedListBox.Location = new System.Drawing.Point(128, 112);
            this.availableCheckedListBox.Name = "availableCheckedListBox";
            this.availableCheckedListBox.Size = new System.Drawing.Size(188, 94);
            this.availableCheckedListBox.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 17;
            label1.Text = "Products Provided:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 112);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(98, 13);
            label2.TabIndex = 19;
            label2.Text = "Available Products:";
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataSource = typeof(ProductsData.Products);
            // 
            // frmAddModifySuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 402);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.pnlModify);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.supNameTextBox);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.supplierIdTextBox);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Name = "frmAddModifySuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddModifySuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersTypeOfProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsSuppliersBindingSource)).EndInit();
            this.pnlModify.ResumeLayout(false);
            this.pnlModify.PerformLayout();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox supNameTextBox;
        private System.Windows.Forms.TextBox supplierIdTextBox;
        private System.Windows.Forms.BindingSource suppliersBindingSource1;
        private System.Windows.Forms.BindingSource suppliersTypeOfProductsBindingSource;
        private System.Windows.Forms.BindingSource productsSuppliersBindingSource;
        private System.Windows.Forms.CheckedListBox prodNameToAddCheckedListBox;
        private System.Windows.Forms.CheckedListBox currentProdCheckedListBox;
        private System.Windows.Forms.Panel pnlModify;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.CheckedListBox availableCheckedListBox;
    }
}