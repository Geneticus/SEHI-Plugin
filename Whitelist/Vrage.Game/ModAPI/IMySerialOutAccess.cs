using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using VRage.Game.ModAPI;
using Serial.IO;
namespace VRage.Game.ModAPI.Ingame
{
        public interface IMySerialOutAccess
        {
            bool SendMessageToSerial(String Message, String devicename);
            bool SendMessageToSerial(String Message, int COMPortNumber, int baudRate);

            //VRage.SerialOutput.SerialOut Message = new VRage.SerialOutput.SerialOut();
            //bool MessageSuccess = SendMessageToSerial(String Message, int x);
        }
}