namespace Asphalt
{
    partial class Manual
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manual));
			this.label1 = new System.Windows.Forms.Label();
			this.uiSwitch2 = new Sunny.UI.UISwitch();
			this.btn = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
			this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(8, 33);
			this.label1.MinimumSize = new System.Drawing.Size(300, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 21);
			this.label1.TabIndex = 7;
			this.label1.Text = "手动开关";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// uiSwitch2
			// 
			this.uiSwitch2.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
			this.uiSwitch2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiSwitch2.BackgroundImage")));
			this.uiSwitch2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.uiSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uiSwitch2.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.uiSwitch2.Location = new System.Drawing.Point(43, 71);
			this.uiSwitch2.MinimumSize = new System.Drawing.Size(1, 1);
			this.uiSwitch2.Name = "uiSwitch2";
			this.uiSwitch2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
			this.uiSwitch2.Size = new System.Drawing.Size(129, 34);
			this.uiSwitch2.Style = Sunny.UI.UIStyle.Custom;
			this.uiSwitch2.TabIndex = 120;
			this.uiSwitch2.Text = "uiSwitch2";
			// 
			// btn
			// 
			this.btn.BackgroundImage = global::Asphalt.Properties.Resources.切换;
			this.btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn.Location = new System.Drawing.Point(198, 71);
			this.btn.Name = "btn";
			this.btn.Size = new System.Drawing.Size(74, 34);
			this.btn.TabIndex = 5;
			this.btn.UseVisualStyleBackColor = true;
			this.btn.Click += new System.EventHandler(this.btn_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::Asphalt.Properties.Resources.关闭;
			this.pictureBox2.Location = new System.Drawing.Point(296, 10);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(20, 20);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 6;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Asphalt.Properties.Resources.input;
			this.pictureBox1.Location = new System.Drawing.Point(1, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(322, 164);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Manual_MouseDown);
			// 
			// Manual
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
			this.ClientSize = new System.Drawing.Size(325, 166);
			this.Controls.Add(this.uiSwitch2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Manual";
			this.Text = "info";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Manual_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISwitch uiSwitch2;
    }
}