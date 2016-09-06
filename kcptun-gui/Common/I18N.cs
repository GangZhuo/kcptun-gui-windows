using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml;

using kcptun_gui.Properties;

namespace kcptun_gui
{
    public static class I18N
    {
        private static ReadOnlyDictionary<string, Lang> _langs;
        private static Lang _current;

        public static event EventHandler LangChanged;

        public static Lang Current
        {
            get
            {
                lock (_langs)
                    return _current;
            }
        }

        static I18N()
        {
            Dictionary<string, Lang> langs = new Dictionary<string, Lang>();
            Lang en = loadLang("en", "English", Resources.en);
            Lang zh_cn = loadLang("zh_CN", "Chinese (Simplified)", Resources.cn);
            langs.Add(en.name, en);
            langs.Add(zh_cn.name, zh_cn);

            _langs = new ReadOnlyDictionary<string, Lang>(langs);

            _current = en;

            if (CultureInfo.CurrentCulture.IetfLanguageTag.StartsWith("zh", StringComparison.OrdinalIgnoreCase))
                _current = zh_cn;
        }

        private static Lang loadLang(string name, string fullname, string content)
        {
            Dictionary<string, string> strings = new Dictionary<string, string>();

            using (var sr = new StringReader(content))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0 || line[0] == '#')
                        continue;

                    int pos = line.IndexOf('=');
                    if (pos < 1)
                        continue;
                    strings[line.Substring(0, pos)] = line.Substring(pos + 1);
                }
            }
            return new Lang(name, fullname, strings);
        }

        public static IList<Lang> GetLangList()
        {
            return new List<Lang>(_langs.Values);
        }

        public static Lang GetLang(string name)
        {
            if (name != null && _langs.ContainsKey(name))
                return _langs[name];
            return null;
        }

        public static void SetLang(string name)
        {
            if (name != null && _langs.ContainsKey(name))
            {
                Lang lang = _langs[name];
                bool fireEvent = false;
                if (_current != lang)
                {
                    lock (_langs)
                    {
                        if (_current != lang)
                        {
                            _current = lang;
                            fireEvent = true;
                        }
                    }
                }
                if (fireEvent && LangChanged != null)
                    LangChanged.Invoke(null, new EventArgs());
            }
            else
            {
                SetLang("en");
            }
        }

        public static string GetString(string key)
        {
            if (_current.strings.ContainsKey(key))
            {
                return _current.strings[key];
            }
            else
            {
                return key;
            }
        }

        public class Lang
        {
            public string name { get; private set; }

            public string fullname { get; private set; }

            public ReadOnlyDictionary<string, string> strings { get; private set; }

            public Lang(string name, string fullname, IDictionary<string, string> strings)
            {
                this.name = name;
                this.fullname = fullname;
                this.strings = new ReadOnlyDictionary<string, string>(strings);
            }
        }
    }

}
