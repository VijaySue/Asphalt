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
    internal class Plc
    {
        public readonly static SiemensS7Net plc1 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.1");
        public readonly static SiemensS7Net plc2 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.2");
        public readonly static SiemensS7Net plc3 = new SiemensS7Net(SiemensPLCS.S200Smart, "192.168.2.3");
    }
}
