using System;
using System.IO;

namespace Papouch.Spinel
{
    enum SpinelFormat : byte
    {
        SpinelFormat97 = 97,
        SpinelFormat65 = 65
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
            fValid = false;

            string s;
            string[] ss = data.Split(';');

            if (ss.Length > 0)
            {
                fDescription = ss[0];

                for (int i = 1; i < ss.Length; i++)
                {
                    s = ss[i].Trim();
                    if (s.StartsWith("v"))
                    {
                        string[] sa = s.Trim('v').Split('.');

                        if (sa.Length == 3)
                        {
                            fProductId = uint.Parse(sa[0].Trim());
                            fHardwareId = ushort.Parse(sa[1].Trim());
                            fSoftwareId = ushort.Parse(sa[2].Trim());
                        }
                    } 
                }
                fValid = true;
            }
            
            return this.fValid;
        }

        public Boolean Valid
        {
            get {   return fValid;  }
        }
        public uint ProductId
        {
            get {   return fProductId;  }
        }
        public ushort HardwareId
        {
            get {   return fHardwareId; }
        }
        public ushort SoftwareId
        {
            get {   return fSoftwareId; }
        }
        public string Description
        {
            get {   return fDescription;    }

        }
    }
}
