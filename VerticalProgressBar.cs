using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    /// <summary>
    /// 垂直进度条控件
    /// 继承自标准ProgressBar控件，但以垂直方向显示进度
    /// 用于在沥青生产控制系统中显示垂直方向的进度或液位等信息
    /// </summary>
    public class VerticalProgressBar: ProgressBar
    {
        /// <summary>
        /// 重写CreateParams属性，修改控件的创建参数
        /// 通过添加PBS_VERTICAL样式标志(0x04)，使进度条垂直显示
        /// </summary>
        protected override CreateParams CreateParams
        {
            get 
            { 
                // 获取基类的创建参数
                CreateParams cp= base.CreateParams;
                // 添加PBS_VERTICAL样式标志(0x04)，使进度条垂直显示
                cp.Style |= 0x04;
                return cp;
            }
        }
       
    }
}
