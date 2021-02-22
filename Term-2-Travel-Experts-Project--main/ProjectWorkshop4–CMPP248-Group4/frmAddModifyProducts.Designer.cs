
namespace ProjectWorkshop4_CMPP248_Group4
{
    partial class frmAddModifyProducts
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
            System.Windows.Forms.Label productIdLabel;
            System.Windows.Forms.Label prodNameLabel;
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.prodNameTextBox = new System.Windows.Forms.TextBox();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            productIdLabel = new System.Windows.Forms.Label();
            prodNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productIdLabel
            // 
            productIdLabel.AutoSize = true;
            productIdLabel.Location = new System.Drawing.Point(47, 27);
            productIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            productIdLabel.Name = "productIdLabel";
            productIdLabel.Size = new System.Drawing.Size(76, 17);
            productIdLabel.TabIndex = 9;
            productIdLabel.Text = "Product Id:";
            // 
            // prodNameLabel
            // 
            prodNameLabel.AutoSize = true;
            prodNameLabel.Location = new System.Drawing.Point(47, 65);
            prodNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            prodNameLabel.Name = "prodNameLabel";
            prodNameLabel.Size = new System.Drawing.Size(97, 17);
            prodNameLabel.TabIndex = 7;
            prodNameLabel.Text = "Product Type:";
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataSource = typeof(ProductsData.Products);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(33, 110);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 47);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 110);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 47);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(33, 110);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(131, 47);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "&Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "ProductId", true));
            this.productIdTextBox.Location = new System.Drawing.Point(153, 23);
            this.productIdTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.ReadOnly = true;
            this.productIdTextBox.Size = new System.Drawing.Size(160, 22);
            this.productIdTextBox.TabIndex = 10;
            // 
            // prodNameTextBox
            // 
            this.prodNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productsBindingSource, "ProdName", true));
            this.prodNameTextBox.Location = new System.Drawing.Point(153, 62);
            this.prodNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prodNameTextBox.Name = "prodNameTextBox";
            this.prodNameTextBox.Size = new System.Drawing.Size(160, 22);
            this.prodNameTextBox.TabIndex = 8;
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataSource = typeof(SuppliersData.Suppliers);
            // 
            // frmAddModifyProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 176);
            this.Controls.Add(prodNameLabel);
            this.Controls.Add(this.prodNameTextBox);
            this.Controls.Add(productIdLabel);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddModifyProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddModifyProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.TextBox prodNameTextBox;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
    }
}