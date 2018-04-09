namespace eShopWinForms
{
    partial class CatalogView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.MainCatalog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.catalogBrandComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typeFilter = new System.Windows.Forms.Label();
            this.catalogTypeComboBox = new System.Windows.Forms.ComboBox();
            this.catalogItemDataGridView = new System.Windows.Forms.DataGridView();
            this.Preview = new System.Windows.Forms.DataGridViewImageColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.searchAvailabilityButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Availability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.productIdInput = new System.Windows.Forms.ComboBox();
            this.addAvailabilityButton = new System.Windows.Forms.Button();
            this.arrivalDateInput = new System.Windows.Forms.TextBox();
            this.arrivalDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityInput = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.discountBanner = new System.Windows.Forms.Label();
            this.catalogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogBrandBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.catalogTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogItemBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.MainCatalog.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBrandBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.43439F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.56561F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1060F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1332, 1373);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.MainCatalog);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(4, 260);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1324, 1052);
            this.tabControl.TabIndex = 0;
            // 
            // MainCatalog
            // 
            this.MainCatalog.Controls.Add(this.tableLayoutPanel2);
            this.MainCatalog.Location = new System.Drawing.Point(8, 44);
            this.MainCatalog.Margin = new System.Windows.Forms.Padding(4);
            this.MainCatalog.Name = "MainCatalog";
            this.MainCatalog.Padding = new System.Windows.Forms.Padding(4);
            this.MainCatalog.Size = new System.Drawing.Size(1308, 1000);
            this.MainCatalog.TabIndex = 0;
            this.MainCatalog.Text = "Main Catalog ";
            this.MainCatalog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.catalogItemDataGridView, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.866953F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.13305F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1301, 993);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4375F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5625F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 757F));
            this.tableLayoutPanel3.Controls.Add(this.catalogBrandComboBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.typeFilter, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.catalogTypeComboBox, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1293, 52);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // catalogBrandComboBox
            // 
            this.catalogBrandComboBox.DisplayMember = "Brand";
            this.catalogBrandComboBox.FormattingEnabled = true;
            this.catalogBrandComboBox.Location = new System.Drawing.Point(539, 4);
            this.catalogBrandComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.catalogBrandComboBox.Name = "catalogBrandComboBox";
            this.catalogBrandComboBox.Size = new System.Drawing.Size(198, 38);
            this.catalogBrandComboBox.TabIndex = 3;
            this.catalogBrandComboBox.ValueMember = "Brand";
            this.catalogBrandComboBox.SelectedIndexChanged += new System.EventHandler(this.catalogBrandComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brand";
            // 
            // typeFilter
            // 
            this.typeFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeFilter.AutoSize = true;
            this.typeFilter.Location = new System.Drawing.Point(34, 11);
            this.typeFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeFilter.Name = "typeFilter";
            this.typeFilter.Size = new System.Drawing.Size(56, 30);
            this.typeFilter.TabIndex = 0;
            this.typeFilter.Text = "Type";
            // 
            // catalogTypeComboBox
            // 
            this.catalogTypeComboBox.DisplayMember = "Type";
            this.catalogTypeComboBox.FormattingEnabled = true;
            this.catalogTypeComboBox.Location = new System.Drawing.Point(128, 4);
            this.catalogTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.catalogTypeComboBox.Name = "catalogTypeComboBox";
            this.catalogTypeComboBox.Size = new System.Drawing.Size(189, 38);
            this.catalogTypeComboBox.TabIndex = 2;
            this.catalogTypeComboBox.ValueMember = "Id";
            this.catalogTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.catalogTypeComboBox_SelectedIndexChanged);
            // 
            // catalogItemDataGridView
            // 
            this.catalogItemDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.catalogItemDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.catalogItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Preview,
            this.Id,
            this.ItemName,
            this.Description,
            this.Price});
            this.catalogItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogItemDataGridView.Location = new System.Drawing.Point(4, 72);
            this.catalogItemDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.catalogItemDataGridView.Name = "catalogItemDataGridView";
            this.catalogItemDataGridView.ReadOnly = true;
            this.catalogItemDataGridView.RowTemplate.Height = 33;
            this.catalogItemDataGridView.Size = new System.Drawing.Size(1293, 917);
            this.catalogItemDataGridView.TabIndex = 1;
            // 
            // Preview
            // 
            this.Preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Preview.FillWeight = 101F;
            this.Preview.HeaderText = "Preview";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 76;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 114;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 163;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 103;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(8, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1308, 1000);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Inventory";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.monthCalendar1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.24064F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.75936F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1293, 985);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(122, 65);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.searchAvailabilityButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 449);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(638, 532);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a product below and click \"Search\" to find the stock availability on a cer" +
    "tain day.";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(73, 78);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(482, 304);
            this.listBox1.TabIndex = 5;
            // 
            // searchAvailabilityButton
            // 
            this.searchAvailabilityButton.Location = new System.Drawing.Point(206, 413);
            this.searchAvailabilityButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchAvailabilityButton.Name = "searchAvailabilityButton";
            this.searchAvailabilityButton.Size = new System.Drawing.Size(202, 88);
            this.searchAvailabilityButton.TabIndex = 7;
            this.searchAvailabilityButton.Text = "Search";
            this.searchAvailabilityButton.UseVisualStyleBackColor = true;
            this.searchAvailabilityButton.Click += new System.EventHandler(this.searchAvailabilityButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(650, 449);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(639, 532);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.ItemId,
            this.Availability});
            this.listView1.Location = new System.Drawing.Point(77, 78);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(488, 423);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            // 
            // ItemId
            // 
            this.ItemId.Text = "Id";
            // 
            // Availability
            // 
            this.Availability.Text = "Availability";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.productIdInput);
            this.groupBox3.Controls.Add(this.addAvailabilityButton);
            this.groupBox3.Controls.Add(this.arrivalDateInput);
            this.groupBox3.Controls.Add(this.arrivalDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.quantityInput);
            this.groupBox3.Location = new System.Drawing.Point(685, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(569, 417);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add new shipments here:";
            // 
            // productIdInput
            // 
            this.productIdInput.FormattingEnabled = true;
            this.productIdInput.Location = new System.Drawing.Point(366, 96);
            this.productIdInput.Name = "productIdInput";
            this.productIdInput.Size = new System.Drawing.Size(121, 38);
            this.productIdInput.TabIndex = 7;
            // 
            // addAvailabilityButton
            // 
            this.addAvailabilityButton.Location = new System.Drawing.Point(215, 286);
            this.addAvailabilityButton.Name = "addAvailabilityButton";
            this.addAvailabilityButton.Size = new System.Drawing.Size(184, 89);
            this.addAvailabilityButton.TabIndex = 6;
            this.addAvailabilityButton.Text = "Add Shipment";
            this.addAvailabilityButton.UseVisualStyleBackColor = true;
            this.addAvailabilityButton.Click += new System.EventHandler(this.addAvailabilityButton_Click);
            // 
            // arrivalDateInput
            // 
            this.arrivalDateInput.Location = new System.Drawing.Point(366, 202);
            this.arrivalDateInput.Name = "arrivalDateInput";
            this.arrivalDateInput.Size = new System.Drawing.Size(121, 35);
            this.arrivalDateInput.TabIndex = 5;
            // 
            // arrivalDate
            // 
            this.arrivalDate.AutoSize = true;
            this.arrivalDate.Location = new System.Drawing.Point(107, 205);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(216, 30);
            this.arrivalDate.TabIndex = 4;
            this.arrivalDate.Text = "Shipment Arrival Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Id";
            // 
            // quantityInput
            // 
            this.quantityInput.Location = new System.Drawing.Point(366, 149);
            this.quantityInput.Name = "quantityInput";
            this.quantityInput.Size = new System.Drawing.Size(121, 35);
            this.quantityInput.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::eShopWinForms.Properties.Resources.main_banner;
            this.pictureBox3.Location = new System.Drawing.Point(4, 66);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1324, 186);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::eShopWinForms.Properties.Resources.main_footer_text;
            this.pictureBox2.Location = new System.Drawing.Point(4, 1320);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(532, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.discountBanner, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1326, 56);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::eShopWinForms.Properties.Resources.brand;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // discountBanner
            // 
            this.discountBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discountBanner.Font = new System.Drawing.Font("Segoe UI", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountBanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.discountBanner.Location = new System.Drawing.Point(666, 0);
            this.discountBanner.Name = "discountBanner";
            this.discountBanner.Size = new System.Drawing.Size(657, 56);
            this.discountBanner.TabIndex = 1;
            this.discountBanner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CatalogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1346, 1398);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CatalogView";
            this.Text = "eShop WinForms";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.MainCatalog.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBrandBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource catalogItemBindingSource;
        private System.Windows.Forms.BindingSource catalogBrandBindingSource;
        private System.Windows.Forms.BindingSource catalogBrandBindingSource1;
        private System.Windows.Forms.BindingSource catalogTypeBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox catalogBrandComboBox;
        private System.Windows.Forms.ComboBox catalogTypeComboBox;
        private System.Windows.Forms.Label typeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage MainCatalog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxBrand;
        private System.Windows.Forms.Button searchAvailabilityButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView catalogItemDataGridView;
        private System.Windows.Forms.BindingSource catalogItemBindingSource3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button addAvailabilityButton;
        private System.Windows.Forms.TextBox arrivalDateInput;
        private System.Windows.Forms.Label arrivalDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantityInput;
        private System.Windows.Forms.ComboBox productIdInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label discountBanner;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader ItemId;
        private System.Windows.Forms.ColumnHeader Availability;
    }
}

