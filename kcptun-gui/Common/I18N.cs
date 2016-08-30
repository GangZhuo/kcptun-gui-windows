using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml;

using kcptun_gui.Properties;

namespace kcptun_gui
{
    public class I18N
    {
        protected static Dictionary<string, string> Strings;
        static I18N()
        {
            Strings = new Dictionary<string, string>();

            if (CultureInfo.CurrentCulture.IetfLanguageTag.StartsWith("zh", StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StringReader(Resources.cn))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        if (line.Length == 0 || line[0] == '#')
                            continue;

                        int pos = line.IndexOf('=');
                        if (pos < 1)
                            continue;
                        Strings[line.Substring(0, pos)] = line.Substring(pos + 1);
                    }
                }
            }
        }

        public static string GetString(string key)
        {
            if (Strings.ContainsKey(key))
            {
                return Strings[key];
            }
            else
            {
                return key;
            }
        }
    }

}
