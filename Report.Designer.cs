using System;

namespace Asphalt
{
    partial class Report
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.label1 = new System.Windows.Forms.Label();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.uiNavMenuEx1 = new Sunny.UI.UINavMenu();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiSymbolButton26 = new Sunny.UI.UISymbolButton();
            this.uiPagination2 = new Sunny.UI.UIPagination();
            this.uiDataGridView2 = new Sunny.UI.UIDataGridView();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.datePicker = new Sunny.UI.UIDatePicker();
            this.monthPicker = new Sunny.UI.UIDatePicker();
            this.yearPicker = new Sunny.UI.UIDatePicker();
            this.weekPicker = new Sunny.UI.UIDatePicker();
            this.weekLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(963, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择日期：";
            // 
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer1.Location = new System.Drawing.Point(0, 46);
            this.uiSplitContainer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.uiNavMenuEx1);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiPanel2);
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiPanel1);
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiPagination2);
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiDataGridView2);
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiPagination1);
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiDataGridView1);
            this.uiSplitContainer1.Size = new System.Drawing.Size(1280, 573);
            this.uiSplitContainer1.SplitterDistance = 171;
            this.uiSplitContainer1.SplitterWidth = 30;
            this.uiSplitContainer1.TabIndex = 49;
            this.uiSplitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.uiSplitContainer1_SplitterMoved);
            // 
            // uiNavMenuEx1
            // 
            this.uiNavMenuEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uiNavMenuEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNavMenuEx1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenuEx1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiNavMenuEx1.FullRowSelect = true;
            this.uiNavMenuEx1.ItemHeight = 50;
            this.uiNavMenuEx1.Location = new System.Drawing.Point(0, 0);
            this.uiNavMenuEx1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavMenuEx1.Name = "uiNavMenuEx1";
            this.uiNavMenuEx1.ShowLines = false;
            this.uiNavMenuEx1.Size = new System.Drawing.Size(171, 573);
            this.uiNavMenuEx1.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavMenuEx1.TabIndex = 3;
            this.uiNavMenuEx1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenuEx1.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.uiNavMenuEx1_MenuItemClick);
            // 
            // uiPanel2
            // 
            this.uiPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.uiPanel2.Controls.Add(this.uiSymbolButton1);
            this.uiPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.uiPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiPanel2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.ForeColor = System.Drawing.Color.White;
            this.uiPanel2.Location = new System.Drawing.Point(543, 3);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.uiPanel2.Size = new System.Drawing.Size(532, 38);
            this.uiPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel2.TabIndex = 61;
            this.uiPanel2.Text = "出料登记表";
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.BackgroundImage = global::Asphalt.Properties.Resources.打印;
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiSymbolButton1.Image = global::Asphalt.Properties.Resources.打印;
            this.uiSymbolButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton1.Location = new System.Drawing.Point(440, 3);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.uiSymbolButton1.Size = new System.Drawing.Size(93, 34);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.Symbol = 61530;
            this.uiSymbolButton1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton1.TabIndex = 117;
            this.uiSymbolButton1.Text = "打印";
            this.uiSymbolButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.uiPanel1.Controls.Add(this.uiSymbolButton26);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.uiPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.ForeColor = System.Drawing.Color.White;
            this.uiPanel1.Location = new System.Drawing.Point(3, 2);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.uiPanel1.Size = new System.Drawing.Size(535, 38);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 60;
            this.uiPanel1.Text = "进料登记表";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // uiSymbolButton26
            // 
            this.uiSymbolButton26.BackgroundImage = global::Asphalt.Properties.Resources.打印;
            this.uiSymbolButton26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton26.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton26.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiSymbolButton26.Image = global::Asphalt.Properties.Resources.打印;
            this.uiSymbolButton26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton26.Location = new System.Drawing.Point(439, 3);
            this.uiSymbolButton26.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton26.Name = "uiSymbolButton26";
            this.uiSymbolButton26.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.uiSymbolButton26.Size = new System.Drawing.Size(93, 34);
            this.uiSymbolButton26.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton26.StyleCustomMode = true;
            this.uiSymbolButton26.Symbol = 61530;
            this.uiSymbolButton26.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(87)))));
            this.uiSymbolButton26.TabIndex = 117;
            this.uiSymbolButton26.Text = "打印";
            this.uiSymbolButton26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiSymbolButton26.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton26.Click += new System.EventHandler(this.uiSymbolButton26_Click);
            // 
            // uiPagination2
            // 
            this.uiPagination2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination2.Location = new System.Drawing.Point(543, 536);
            this.uiPagination2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination2.Name = "uiPagination2";
            this.uiPagination2.PagerCount = 5;
            this.uiPagination2.PageSize = 30;
            this.uiPagination2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination2.ShowText = false;
            this.uiPagination2.Size = new System.Drawing.Size(535, 35);
            this.uiPagination2.TabIndex = 59;
            this.uiPagination2.Text = null;
            this.uiPagination2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination2.TotalCount = 2000;
            this.uiPagination2.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination2_PageChanged);
            // 
            // uiDataGridView2
            // 
            this.uiDataGridView2.AllowUserToAddRows = false;
            this.uiDataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView2.EnableHeadersVisualStyles = false;
            this.uiDataGridView2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView2.Location = new System.Drawing.Point(543, 40);
            this.uiDataGridView2.Name = "uiDataGridView2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView2.RowHeadersWidth = 82;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView2.RowTemplate.Height = 28;
            this.uiDataGridView2.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView2.SelectedIndex = -1;
            this.uiDataGridView2.Size = new System.Drawing.Size(533, 499);
            this.uiDataGridView2.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView2.TabIndex = 57;
            this.uiDataGridView2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiDataGridView2_ColumnHeaderMouseClick);
            // 
            // uiPagination1
            // 
            this.uiPagination1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination1.Location = new System.Drawing.Point(3, 536);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.PagerCount = 5;
            this.uiPagination1.PageSize = 30;
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.ShowText = false;
            this.uiPagination1.Size = new System.Drawing.Size(535, 35);
            this.uiPagination1.TabIndex = 56;
            this.uiPagination1.Text = null;
            this.uiPagination1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination1.TotalCount = 2000;
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_PageChanged);
            this.uiPagination1.Click += new System.EventHandler(this.uiPagination1_Click_1);
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(4, 40);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.uiDataGridView1.RowHeadersWidth = 82;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uiDataGridView1.RowTemplate.Height = 28;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(534, 499);
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView1.TabIndex = 54;
            this.uiDataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiDataGridView1_ColumnHeaderMouseClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printDocument3
            // 
            this.printDocument3.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument3_PrintPage);
            // 
            // datePicker
            // 
            this.datePicker.CanEmpty = true;
            this.datePicker.FillColor = System.Drawing.Color.White;
            this.datePicker.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.datePicker.Location = new System.Drawing.Point(1079, 13);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datePicker.MaxLength = 10;
            this.datePicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.datePicker.ShowToday = true;
            this.datePicker.Size = new System.Drawing.Size(150, 29);
            this.datePicker.SymbolDropDown = 61555;
            this.datePicker.SymbolNormal = 61555;
            this.datePicker.TabIndex = 76;
            this.datePicker.Text = "2020-04-16";
            this.datePicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.datePicker.Value = new System.DateTime(2020, 4, 16, 0, 0, 0, 0);
            this.datePicker.Watermark = "";
            this.datePicker.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.datePicker_ValueChanged);
            // 
            // monthPicker
            // 
            this.monthPicker.CanEmpty = true;
            this.monthPicker.DateFormat = "yyyy-MM";
            this.monthPicker.FillColor = System.Drawing.Color.White;
            this.monthPicker.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.monthPicker.Location = new System.Drawing.Point(1079, 13);
            this.monthPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.monthPicker.MaxLength = 7;
            this.monthPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.monthPicker.Name = "monthPicker";
            this.monthPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.monthPicker.ShowToday = true;
            this.monthPicker.ShowType = Sunny.UI.UIDateType.YearMonth;
            this.monthPicker.Size = new System.Drawing.Size(150, 29);
            this.monthPicker.Style = Sunny.UI.UIStyle.Custom;
            this.monthPicker.SymbolDropDown = 61555;
            this.monthPicker.SymbolNormal = 61555;
            this.monthPicker.TabIndex = 75;
            this.monthPicker.Text = "2020-04";
            this.monthPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.monthPicker.Value = new System.DateTime(2020, 4, 16, 0, 0, 0, 0);
            this.monthPicker.Watermark = "";
            this.monthPicker.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.monthPicker_ValueChanged);
            // 
            // yearPicker
            // 
            this.yearPicker.CanEmpty = true;
            this.yearPicker.DateFormat = "yyyy";
            this.yearPicker.FillColor = System.Drawing.Color.White;
            this.yearPicker.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.yearPicker.Location = new System.Drawing.Point(1079, 13);
            this.yearPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yearPicker.MaxLength = 4;
            this.yearPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.yearPicker.ShowToday = true;
            this.yearPicker.ShowType = Sunny.UI.UIDateType.Year;
            this.yearPicker.Size = new System.Drawing.Size(150, 29);
            this.yearPicker.SymbolDropDown = 61555;
            this.yearPicker.SymbolNormal = 61555;
            this.yearPicker.TabIndex = 73;
            this.yearPicker.Text = "2020";
            this.yearPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.yearPicker.Value = new System.DateTime(2020, 4, 16, 0, 0, 0, 0);
            this.yearPicker.Watermark = "";
            this.yearPicker.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.yearPicker_ValueChanged);
            // 
            // weekPicker
            // 
            this.weekPicker.CanEmpty = true;
            this.weekPicker.FillColor = System.Drawing.Color.White;
            this.weekPicker.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.weekPicker.Location = new System.Drawing.Point(1079, 12);
            this.weekPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weekPicker.MaxLength = 10;
            this.weekPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.weekPicker.Name = "weekPicker";
            this.weekPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.weekPicker.ShowToday = true;
            this.weekPicker.Size = new System.Drawing.Size(150, 29);
            this.weekPicker.SymbolDropDown = 61555;
            this.weekPicker.SymbolNormal = 61555;
            this.weekPicker.TabIndex = 77;
            this.weekPicker.Text = "2020-04-16";
            this.weekPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.weekPicker.Value = new System.DateTime(2020, 4, 16, 0, 0, 0, 0);
            this.weekPicker.Watermark = "";
            this.weekPicker.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.weekPicker_ValueChanged);
            // 
            // weekLabel
            // 
            this.weekLabel.AutoSize = true;
            this.weekLabel.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.weekLabel.ForeColor = System.Drawing.Color.Transparent;
            this.weekLabel.Location = new System.Drawing.Point(465, 12);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(356, 21);
            this.weekLabel.TabIndex = 78;
            this.weekLabel.Text = "xxxx年xx月xx日至xxxx年xx月xx日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(234, 631);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 16);
            this.label2.TabIndex = 79;
            this.label2.Text = "合计:xx.xx 沥青:xx.xx 胶粉:xx.xx 添加剂:xx.xx T4:xx.xx";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(977, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "合计:xx.xx";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.weekPicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.monthPicker);
            this.Controls.Add(this.yearPicker);
            this.Controls.Add(this.uiSplitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "Report";
            this.Size = new System.Drawing.Size(1280, 675);
            this.Load += new System.EventHandler(this.Report_Load);
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private Sunny.UI.UINavMenu uiNavMenuEx1;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIPagination uiPagination1;
        private Sunny.UI.UIDataGridView uiDataGridView2;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPanel uiPanel2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Sunny.UI.UISymbolButton uiSymbolButton26;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Drawing.Printing.PrintDocument printDocument3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private Sunny.UI.UIPagination uiPagination2;
        private Sunny.UI.UIDatePicker datePicker;
        private Sunny.UI.UIDatePicker monthPicker;
        private Sunny.UI.UIDatePicker yearPicker;
        private Sunny.UI.UIDatePicker weekPicker;
        private System.Windows.Forms.Label weekLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
