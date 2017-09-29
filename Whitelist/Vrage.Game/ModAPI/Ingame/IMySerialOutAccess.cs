using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.SerialOutput;
using Serial.IO;


namespace VRage.Game.ModAPI
{

        public interface IMySerialOutAccess: VRage.Game.ModAPI.Ingame.IMySerialOutAccess
    {
         new bool SendMessageToSerial(String Message, String devicename);
         new bool SendMessageToSerial(String Message, int COMPortNumber, int baudRate);

        //VRage.SerialOutput.SerialOut Message = new VRage.SerialOutput.SerialOut();
        //bool MessageSuccess = SendMessageToSerial(String Message, int x);
    }

    }
