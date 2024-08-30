using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
	public partial class SumSetting : Form
	{
		public SumSetting()
		{
			StartPosition = FormStartPosition.CenterScreen;
			InitializeComponent();
		}

		private void cssdz_TextChanged(object sender, EventArgs e)
		{

		}

		private void uiSymbolButton2_Click(object sender, EventArgs e)
		{
            // 停止-->启动
            Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content & 253 | 1));
            Index.flag2 = true;
			Index.setSum = sum.Text.ToString().ToInt();
            this.DialogResult = DialogResult.OK;
			Close();
		}

		private void uiSymbolButton3_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
