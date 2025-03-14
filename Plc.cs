using HslCommunication;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asphalt
{
    /// <summary>
    /// PLC通信类，负责与西门子S7-200 Smart PLC设备建立通信
    /// 该类提供系统中所需的所有PLC连接实例
    /// </summary>
    internal class Plc
    {
        /// <summary>
        /// PLC1连接实例，负责主要的控制功能
        /// 使用西门子S7-200 Smart PLC，通过以太网连接到IP地址192.168.2.1
        /// </summary>
        public readonly static SiemensS7Net plc1 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.1");
        
        /// <summary>
        /// PLC2连接实例，负责辅助控制功能
        /// 使用西门子S7-200 Smart PLC，通过以太网连接到IP地址192.168.2.2
        /// </summary>
        public readonly static SiemensS7Net plc2 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.2");
        
        /// <summary>
        /// PLC3连接实例，负责额外的控制功能
        /// 使用西门子S7-200 Smart PLC，通过以太网连接到IP地址192.168.2.3
        /// </summary>
        public readonly static SiemensS7Net plc3 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.3");
    }
}
