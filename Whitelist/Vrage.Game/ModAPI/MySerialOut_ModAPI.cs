using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.ModAPI;
using VRage.Game.ModAPI.SerialOutput;
using VRage.Game.ModAPI;
using Serial.IO;

namespace VRage.Game.ModAPI.MySerialOut
{
    public class MySerialOut 
    {
        bool IMySerialOutAccess.SendMessageToSerial(String Message, String devicename)
        {
            return SerialOut.SendMessageToSerial(Message, devicename);
        }
        bool IMySerialOutAccess.SendMessageToSerial(String Message, int COMPortNumber, int baudRate)
        {
            return SerialOut.SendMessageToSerial(Message, COMPortNumber, baudRate);
        }


    }

}