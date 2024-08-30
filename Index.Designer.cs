using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
namespace Asphalt
{
    partial class Index
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("用户权限管理", 0, 6);
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("系统参数设置", 1, 2);
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("系统管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("参数设置", 2, 2);
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("配方设置", 3, 3);
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("运行管理", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("温度曲线");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("电流曲线");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("重量曲线");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("历史曲线", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("日报表");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("周报表");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("月报表");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("年报表");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("历史报表", 14, 5, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("数据管理", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode15});
			this.panel1 = new System.Windows.Forms.Panel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.uiPanel1 = new Sunny.UI.UIPanel();
			this.uiNavBar1 = new Sunny.UI.UINavBar();
			this.auto = new HslCommunication.Controls.UserSwitch();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.min = new System.Windows.Forms.PictureBox();
			this.start = new System.Windows.Forms.PictureBox();
			this.inStop = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.back = new System.Windows.Forms.PictureBox();
			this.close = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uiPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inStop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
			this.panel1.Location = new System.Drawing.Point(0, 85);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1280, 675);
			this.panel1.TabIndex = 38;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "用户权限 (1).png");
			this.imageList1.Images.SetKeyName(1, "系统设置.png");
			this.imageList1.Images.SetKeyName(2, "参数设置.png");
			this.imageList1.Images.SetKeyName(3, "配方方案.png");
			this.imageList1.Images.SetKeyName(4, "曲线对比.png");
			this.imageList1.Images.SetKeyName(5, "报表.png");
			this.imageList1.Images.SetKeyName(6, "用户权限.png");
			this.imageList1.Images.SetKeyName(7, "系统管理.png");
			this.imageList1.Images.SetKeyName(8, "运行.png");
			this.imageList1.Images.SetKeyName(9, "配方方案.png");
			this.imageList1.Images.SetKeyName(10, "曲线对比 (1).png");
			this.imageList1.Images.SetKeyName(11, "报表.png");
			this.imageList1.Images.SetKeyName(12, "工控业设备.png");
			this.imageList1.Images.SetKeyName(13, "运行管理 (1).png");
			this.imageList1.Images.SetKeyName(14, "数据报表 (1).png");
			// 
			// uiPanel1
			// 
			this.uiPanel1.BackgroundImage = global::Asphalt.Properties.Resources.nav_men2;
			this.uiPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.uiPanel1.Controls.Add(this.uiNavBar1);
			this.uiPanel1.Controls.Add(this.auto);
			this.uiPanel1.Controls.Add(this.pictureBox1);
			this.uiPanel1.Controls.Add(this.min);
			this.uiPanel1.Controls.Add(this.start);
			this.uiPanel1.Controls.Add(this.inStop);
			this.uiPanel1.Controls.Add(this.label2);
			this.uiPanel1.Controls.Add(this.back);
			this.uiPanel1.Controls.Add(this.close);
			this.uiPanel1.Controls.Add(this.pictureBox2);
			this.uiPanel1.Controls.Add(this.label1);
			this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiPanel1.Location = new System.Drawing.Point(0, 0);
			this.uiPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
			this.uiPanel1.Name = "uiPanel1";
			this.uiPanel1.RectColor = System.Drawing.Color.Transparent;
			this.uiPanel1.Size = new System.Drawing.Size(1280, 85);
			this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
			this.uiPanel1.TabIndex = 48;
			this.uiPanel1.Text = null;
			this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.uiPanel1.Click += new System.EventHandler(this.uiPanel1_Click);
			// 
			// uiNavBar1
			// 
			this.uiNavBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.uiNavBar1.DropMenuFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiNavBar1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiNavBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.uiNavBar1.ImageList = this.imageList1;
			this.uiNavBar1.Location = new System.Drawing.Point(335, 19);
			this.uiNavBar1.MenuSelectedColorUsed = true;
			this.uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
			this.uiNavBar1.Name = "uiNavBar1";
			this.uiNavBar1.NodeAlignment = System.Drawing.StringAlignment.Center;
			treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(34)))), ((int)(((byte)(67)))));
			treeNode1.ForeColor = System.Drawing.Color.White;
			treeNode1.ImageIndex = 0;
			treeNode1.Name = "节点0";
			treeNode1.SelectedImageIndex = 6;
			treeNode1.Text = "用户权限管理";
			treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(34)))), ((int)(((byte)(67)))));
			treeNode2.ForeColor = System.Drawing.Color.White;
			treeNode2.ImageIndex = 1;
			treeNode2.Name = "节点1";
			treeNode2.SelectedImageIndex = 2;
			treeNode2.Text = "系统参数设置";
			treeNode3.ImageIndex = -2;
			treeNode3.Name = "节点0";
			treeNode3.Text = "系统管理";
			treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(34)))), ((int)(((byte)(67)))));
			treeNode4.ForeColor = System.Drawing.Color.White;
			treeNode4.ImageIndex = 2;
			treeNode4.Name = "节点0";
			treeNode4.SelectedImageIndex = 2;
			treeNode4.Text = "参数设置";
			treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(3)))), ((int)(((byte)(67)))));
			treeNode5.ForeColor = System.Drawing.Color.White;
			treeNode5.ImageIndex = 3;
			treeNode5.Name = "节点1";
			treeNode5.SelectedImageIndex = 3;
			treeNode5.Text = "配方设置";
			treeNode6.ImageIndex = -2;
			treeNode6.Name = "节点1";
			treeNode6.Text = "运行管理";
			treeNode7.Name = "节点0";
			treeNode7.Text = "温度曲线";
			treeNode8.Name = "节点1";
			treeNode8.Text = "电流曲线";
			treeNode9.Name = "节点2";
			treeNode9.Text = "重量曲线";
			treeNode10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(34)))), ((int)(((byte)(67)))));
			treeNode10.ForeColor = System.Drawing.Color.White;
			treeNode10.ImageIndex = 4;
			treeNode10.Name = "节点2";
			treeNode10.SelectedImageIndex = 4;
			treeNode10.Text = "历史曲线";
			treeNode11.Name = "节点0";
			treeNode11.Text = "日报表";
			treeNode12.Name = "节点0";
			treeNode12.Text = "周报表";
			treeNode13.Name = "节点2";
			treeNode13.Text = "月报表";
			treeNode14.Name = "节点3";
			treeNode14.Text = "年报表";
			treeNode15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(34)))), ((int)(((byte)(67)))));
			treeNode15.ForeColor = System.Drawing.Color.White;
			treeNode15.ImageIndex = 14;
			treeNode15.Name = "节点3";
			treeNode15.SelectedImageIndex = 5;
			treeNode15.Text = "历史报表";
			treeNode16.ImageIndex = -2;
			treeNode16.Name = "节点2";
			treeNode16.Text = "数据管理";
			this.uiNavBar1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode16});
			this.uiNavBar1.Size = new System.Drawing.Size(441, 48);
			this.uiNavBar1.Style = Sunny.UI.UIStyle.Custom;
			this.uiNavBar1.TabIndex = 45;
			this.uiNavBar1.Text = "uiNavBar1";
			this.uiNavBar1.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.uiNavBar1_MenuItemClick);
			// 
			// auto
			// 
			this.auto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.auto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.auto.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.auto.ForeColor = System.Drawing.Color.White;
			this.auto.Location = new System.Drawing.Point(1075, 8);
			this.auto.Margin = new System.Windows.Forms.Padding(0);
			this.auto.Name = "auto";
			this.auto.Size = new System.Drawing.Size(68, 68);
			this.auto.SwitchForeground = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
			this.auto.SwitchStatusDescription = new string[] {
        "手动",
        "自动"};
			this.auto.TabIndex = 47;
			this.auto.Click += new System.EventHandler(this.auto_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.pictureBox1.Image = global::Asphalt.Properties.Resources.窗口最大化_操作_jurassic;
			this.pictureBox1.Location = new System.Drawing.Point(1209, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(25, 25);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 46;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.max_click);
			this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
			// 
			// min
			// 
			this.min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.min.Image = global::Asphalt.Properties.Resources.最小化;
			this.min.Location = new System.Drawing.Point(1179, 2);
			this.min.Name = "min";
			this.min.Size = new System.Drawing.Size(30, 30);
			this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.min.TabIndex = 47;
			this.min.TabStop = false;
			this.min.Click += new System.EventHandler(this.min_Click);
			this.min.MouseHover += new System.EventHandler(this.min_MouseHover);
			// 
			// start
			// 
			this.start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.start.Cursor = System.Windows.Forms.Cursors.Hand;
			this.start.Image = global::Asphalt.Properties.Resources.红色按钮3D;
			this.start.Location = new System.Drawing.Point(1017, 23);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(38, 38);
			this.start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.start.TabIndex = 0;
			this.start.TabStop = false;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// inStop
			// 
			this.inStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.inStop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.inStop.Image = global::Asphalt.Properties.Resources.红色按钮3D;
			this.inStop.Location = new System.Drawing.Point(889, 23);
			this.inStop.Name = "inStop";
			this.inStop.Size = new System.Drawing.Size(38, 38);
			this.inStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.inStop.TabIndex = 0;
			this.inStop.TabStop = false;
			this.inStop.Click += new System.EventHandler(this.stop_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.label2.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(951, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 24);
			this.label2.TabIndex = 35;
			this.label2.Text = "启动";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// back
			// 
			this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.back.Image = global::Asphalt.Properties.Resources.返回__2_;
			this.back.Location = new System.Drawing.Point(1150, 0);
			this.back.Name = "back";
			this.back.Size = new System.Drawing.Size(35, 35);
			this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.back.TabIndex = 46;
			this.back.TabStop = false;
			this.back.Click += new System.EventHandler(this.back_Click);
			this.back.MouseHover += new System.EventHandler(this.back_MouseHover);
			// 
			// close
			// 
			this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.close.Image = global::Asphalt.Properties.Resources.关闭2;
			this.close.Location = new System.Drawing.Point(1234, 1);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(32, 33);
			this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.close.TabIndex = 46;
			this.close.TabStop = false;
			this.close.Click += new System.EventHandler(this.close_Click);
			this.close.MouseHover += new System.EventHandler(this.close_MouseHover);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.pictureBox2.Image = global::Asphalt.Properties.Resources.logo1;
			this.pictureBox2.Location = new System.Drawing.Point(32, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(245, 61);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(39)))), ((int)(((byte)(67)))));
			this.label1.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(823, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 24);
			this.label1.TabIndex = 35;
			this.label1.Text = "急停";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// Index
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
			this.ClientSize = new System.Drawing.Size(1280, 760);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.uiPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Index";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "沥青生产工艺控制系统";
			this.Load += new System.EventHandler(this.index_Load);
			this.uiPanel1.ResumeLayout(false);
			this.uiPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inStop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox close;
        private Sunny.UI.UINavBar uiNavBar1;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ImageList imageList1;
        private PictureBox pictureBox1;
        public PictureBox inStop;
        public PictureBox start;
        public Panel panel1;
        private HslCommunication.Controls.UserSwitch auto;
	}
}