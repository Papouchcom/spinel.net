using System;
using System.IO;

namespace Papouch.Spinel
{
    enum SpinelFormat : byte
    {
        SpinelFormat97 = 97,
        SpinelFormat65 = 65
    }

    public class SpinelDeviceSN
    {
        public Boolean Valid { get; }
        public uint SerialNumber { get; }
        public uint DeviceType { get; }
        public uint FactoryData { get; }

        public SpinelDeviceSN(byte[] sdata)
        {
            this.Valid = false;
            if ((sdata!=null) && (sdata.Length == 8))
            {
                this.SerialNumber = (uint)(sdata[0] * 0x100 + sdata[1]);
                this.DeviceType = (uint)(sdata[2] * 0x100 + sdata[3]);
                for (int i = 4; i <= 7; i++)
                {
                    this.FactoryData = (this.FactoryData * 0x100) + sdata[i];
                }
                this.Valid = true;
            }
        }
    }

    public class SpinelDeviceVersion
    {
        private Boolean fValid;
        private string fDescription = "";
        private uint fProductId;
        private ushort fHardwareId;
        private ushort fSoftwareId;

        public SpinelDeviceVersion(string s)
        {
            ParseString(s);
        }

        public bool ParseString(string data)
        {
            this.fValid = false;

            string s;
            string[] ss = data.Split(';');

            if (ss.Length > 0)
            {
                this.fDescription = ss[0];

                for (int i = 1; i < ss.Length; i++)
                {
                    s = ss[i].Trim();
                    if (s.StartsWith("v"))
                    {
                        string[] sa = s.Trim('v').Split('.');

                        if (sa.Length == 3)
                        {
                            this.fProductId = uint.Parse(sa[0].Trim());
                            this.fHardwareId = ushort.Parse(sa[1].Trim());
                            this.fSoftwareId = ushort.Parse(sa[2].Trim());
                        }
                    } 
                }
                this.fValid = true;
            }
            
            return this.fValid;
        }

        public Boolean Valid
        {
            get {   return this.fValid;  }
        }
        public uint ProductId
        {
            get {   return this.fProductId;  }
        }
        public ushort HardwareId
        {
            get {   return this.fHardwareId; }
        }
        public ushort SoftwareId
        {
            get {   return this.fSoftwareId; }
        }
        public string Description
        {
            get {   return this.fDescription;    }

        }
    }
}
