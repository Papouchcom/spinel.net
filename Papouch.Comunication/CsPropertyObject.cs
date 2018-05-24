using System;
using System.Reflection;

namespace Papouch.Communication
{
    #region CsPropertyArrtibute
    // create CsPropertyAttribute for CiProperites access system
    [AttributeUsageAttribute(AttributeTargets.Property, Inherited = false)]
    public class CsPropertyAttribute : System.Attribute
    {
        public delegate object ParseMethod(string value);
        private string name;
        private object _default_value = null;
        private ParseMethod parseMethod = null;
        public CsPropertyAttribute(string name)
        {
            this.name = name;
        }

        public CsPropertyAttribute(string name, object default_value)
        {
            this.name = name;
            this._default_value = default_value;
        }

        public CsPropertyAttribute(string name, object default_value, ParseMethod parseMethod)
        {
            this.name = name;
            this._default_value = default_value;
            this.parseMethod = parseMethod;
        }

        public override string ToString()
        {
            return String.Format("CiProperty(name={0},default_value={1})", name, _default_value);
        }

        public object default_value
        {
            get { return this._default_value; }
        }

        public bool HaveDefaultValue
        {
            get { return (_default_value != null); }
        }

        public object Parse(string svalue)
        {
            if (parseMethod != null)
            {
                return parseMethod(svalue);
            }
            else
            {
                return svalue;
            }
        }
    }
    #endregion

    public interface ICsPropertyInterface
    {
        string ConfigString { get; set; }
        string GetConfigString(bool AllParams);
    }

    public class CsPropertyObject : ICsPropertyInterface
    {
        #region ConfigString support
        public string GetConfigString(bool AllParams)
        {
            string result = "";
            PropertyInfo[] pi = this.GetType().GetProperties();
            foreach (PropertyInfo p in pi)
            {
                object[] oa = p.GetCustomAttributes(true);

                for (int i = 0; i < oa.Length; i++)
                {
                    if (oa[i] is CsPropertyAttribute)
                    {
                        object value = p.GetValue(this, null);
                        CsPropertyAttribute cpa = (oa[i] as CsPropertyAttribute);
                        object default_value = cpa.default_value;
                        if (AllParams | (default_value == null) | !Object.Equals(default_value, value))
                        {
                            string[] paramval = new string[2];
                            paramval[0] = p.Name;
                            paramval[1] = value.ToString();

                            result += String.Join("=", paramval) + ";";
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public string ConfigString
        {
            set { ParseCs(value); }
            get { return GetConfigString(false); }
        }

        protected void SetCsItem(string param, string value)
        {
            PropertyInfo pi = this.GetType().GetProperty(param);
            if ((pi != null) && pi.CanWrite)
            {
                if (pi.PropertyType.Name == "Byte")
                {
                    byte o;
                    if (value.StartsWith("0x", true, System.Globalization.CultureInfo.CurrentCulture))
                    {
                        o = Byte.Parse(value.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        o = Byte.Parse(value);
                    }
                    pi.SetValue(this, o, null);
                }
                else
                {
                    object o = Convert.ChangeType(value, pi.PropertyType);
                    pi.SetValue(this, o, null);
                }
            }
        }

        private void ParseCsItem(string s)
        {
            string[] sa = s.Split('=');
            SetCsItem(sa[0], sa[1]);
        }

        protected void ParseCs(string cs)
        {
            string[] sa = cs.Split(';');
            foreach (string s in sa)
            {
                if (s != "")
                {
                    ParseCsItem(s);
                }
            }
        }
        #endregion
    }

}
