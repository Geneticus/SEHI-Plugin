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

namespace VRage.Game.ModAPI.SerialOutput
{

    //Serial String Format (StartBit)(DataType,Item,CurrentValue,MaxValue)(StopBit)
    //StartBit = "\x02"
    //DataType = Integer value starting from 1. Indicates if values are Int, Float, Bool, etc.                      
    //Item = Number begining with 1. Indicates what the value is i.e. Health, speed, dampers.
    //CurrentValue = can be any type as indicated by DataType
    //MaxValue = can be any numeric as indicated by DataType
    //StopBit = "\x03"

    /*public class ControllerMapper
    {
        public static List<Microcontroller> AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            try
            {
                List<Microcontroller> mc = null;
                foreach (ManagementObject item in searcher.Get())
                {
                    string name = item["Name"].ToString();
                    string uname = item["UName"].ToString();
                    string description = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();
                    string PNPdeviceId = item["PNPDeviceID"].ToString();
                    if (description.Contains("Arduino Due") || description.Contains("Arduino Mega 2560") || description.Contains("Arduino One"))
                    //Temp Check. Needs to compare each return against Text file list when moved to VRAGE.
                    {
                        var mcItem = new Microcontroller(name, description, deviceId, PNPdeviceId,11520);
                        mc.Add(mcItem);
                    }
                }
                return mc; 
            }
            catch (ManagementException e)
            {
                /* Do Nothing 
            }
            return null;
        }
    }*/
    public class Microcontroller
    {
        public Microcontroller(string name, string description, string deviceID, string PNPdeviceID, int baudRate)
        {
            Name = name; Description = description; DeviceID = deviceID; PNPDeviceID = PNPdeviceID; BaudRate = baudRate;

            //check to see if all variables are filled before creating port, if no , error.
            //createSerialPort(); //This needs to be moved to form ok, click action.
        }
        public string Name { get; set; }
        public string UName { get; set; }
        public string Description { get; set; }
        public string DeviceID { get; set; }
        public string PNPDeviceID { get; set; }
        public int BaudRate { get; set; }

        public SerialPort serialPort;

        public void createSerialPort()
        {
            serialPort = new SerialPort(DeviceID, BaudRate);
            serialPort.Open();
        }
    }
    //public class SerialOut
    //{
    //    string Uname = string.Empty;
    //        List <Microcontroller> Microcontrollers = new List<Microcontroller>();            
    //        Microcontrollers = ArduinoController.AutodetectArduinoPort();
    //         if (Microcontrollers.Count() == 0 )
    //        {
    //            //var Options_Mockup = new Options_Mockup();
    //            //Options_Mockup.Show();
    //        }

    // else
    //        {
    //            //foreach(DropdownList in Form Start, Position blah blah)
    //            //var mc = Microcontrollers.Where(p => p.UName == "something from a TextBox").First();
    //            //string SerialPortName = mc.serialPort.ToString();        
    //            //serialPort1.DataReceived += serialPort1_DataReceived; // threading problems?
    //            //serialPort1.Open();
    //        }
    //}
    
    public class SerialOut
    {
        private static System.IO.Ports.SerialPort serialPort1 = new SerialPort();

        ///<summary>
        ///This is or Normal API/Programming Block Use
        ///</summary>
        public static bool SendMessageToSerial(String Message, String devicename)//Change Bool for routing to SE log file.
        {
            bool success = false;



            return success;
        }
        ///<summary>
        ///This will send a string message straight to the COM port. (For Debug use)
        ///</summary>
        public static bool SendMessageToSerial(String Message, int COMPortNumber, int baudRate)//Change Bool for routing to SE log file.
        {
            bool success = false;
            //string textToSend = string.Format("\x02{0}\x03", Message);
            string textToSend = string.Format("<{0}>", Message);
            serialPort1.BaudRate = baudRate;
            serialPort1.PortName = "COM" + COMPortNumber;

            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(textToSend);
                success = true;
            }
            else
            {
                serialPort1.Open();
                serialPort1.WriteLine(textToSend);
                success = true;

            }
            serialPort1.Close();
            return success;
        }
    }



}