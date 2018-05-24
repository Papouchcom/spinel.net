using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papouch.Utils
{
    public class PapUtils
    {
        public static string ConvertBinToText(byte[] data)
        {
            string result = null;
            foreach (byte b in data)
            {
                if (b < 32)
                {
                    result = result + "{0x" + String.Format("{0:X2}", (int)b) + "}";
                }
                else if (b > 127)
                {
                    result = result + "{0x" + String.Format("{0:X2}", (int)b) + "}";
                }
                else
                {
                    result = result + (char)b;
                }
            }
            return result;
        }

        public static string ConvertBinToHex(byte[] data, string delimeter = " ", string hexPrefix = "", string hexSuffix = "")
        {
            string result = "";
            foreach (byte b in data)
            {
                result = result + hexPrefix + string.Format("{0:X2}", b) + hexSuffix + delimeter;
            }
            return result.Substring(0, result.Length - delimeter.Length);
        }
    }
}
