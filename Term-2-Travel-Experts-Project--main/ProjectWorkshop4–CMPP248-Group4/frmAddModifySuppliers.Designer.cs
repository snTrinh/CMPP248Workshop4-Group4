
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
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.suppliersTypeOfProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppliersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.supNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierIdTextBox = new System.Windows.Forms.TextBox();
            this.productsSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prodNameCheckedListBox = new System.Windows.Forms.CheckedListBox();
            supNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            prodNameLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersTypeOfProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsSuppliersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Location = new System.Drawing.Point(26, 59);
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
            prodNameLabel1.Location = new System.Drawing.Point(26, 84);
            prodNameLabel1.Name = "prodNameLabel1";
            prodNameLabel1.Size = new System.Drawing.Size(78, 13);
            prodNameLabel1.TabIndex = 15;
            prodNameLabel1.Text = "Product Name:";
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataSource = typeof(SuppliersData.Suppliers);
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataSource = typeof(ProductsData.Products);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(58, 200);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(98, 38);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "&Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(204, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(58, 200);
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
            this.supNameTextBox.Location = new System.Drawing.Point(114, 56);
            this.supNameTextBox.Name = "supNameTextBox";
            this.supNameTextBox.Size = new System.Drawing.Size(187, 20);
            this.supNameTextBox.TabIndex = 13;
            // 
            // supplierIdTextBox
            // 
            this.supplierIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppliersBindingSource, "SupplierId", true));
            this.supplierIdTextBox.Location = new System.Drawing.Point(114, 29);
            this.supplierIdTextBox.Name = "supplierIdTextBox";
            this.supplierIdTextBox.ReadOnly = true;
            this.supplierIdTextBox.Size = new System.Drawing.Size(187, 20);
            this.supplierIdTextBox.TabIndex = 15;
            // 
            // productsSuppliersBindingSource
            // 
            this.productsSuppliersBindingSource.DataSource = typeof(Products_SuppliersData.Products_Suppliers);
            // 
            // prodNameCheckedListBox
            // 
            this.prodNameCheckedListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "ProdName", true));
            this.prodNameCheckedListBox.FormattingEnabled = true;
            this.prodNameCheckedListBox.Location = new System.Drawing.Point(114, 84);
            this.prodNameCheckedListBox.Name = "prodNameCheckedListBox";
            this.prodNameCheckedListBox.Size = new System.Drawing.Size(187, 94);
            this.prodNameCheckedListBox.TabIndex = 16;
            // 
            // frmAddModifySuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 257);
            this.Controls.Add(prodNameLabel1);
            this.Controls.Add(this.prodNameCheckedListBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersTypeOfProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsSuppliersBindingSource)).EndInit();
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
        private System.Windows.Forms.CheckedListBox prodNameCheckedListBox;
    }
}