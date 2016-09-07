using System;
using System.ComponentModel;
using kcptun_gui.Common;

namespace kcptun_gui.Model
{
    [Serializable]
    [DefaultProperty("remoteaddr")]
    public class Server
    {
        #region Properties

        #region General

        [MyCategory(PropertyCategories.General)]
        [MyDescription("mnemonic-name for server")]
        public string remarks { get; set; }

        [MyCategory(PropertyCategories.General)]
        [MyDescription("local listen address")]
        public string localaddr { get; set; }

        [MyCategory(PropertyCategories.General)]
        [MyDescription("kcp server address")]
        public string remoteaddr { get; set; }

        [MyCategory(PropertyCategories.General)]
        [MyDescription("set num of UDP connections to server")]
        public int conn { get; set; }

        #endregion

        #region Security

        [MyCategory(PropertyCategories.Security)]
        [MyDescription("method for encryption")]
        [TypeConverter(typeof(MyEnumConverter))]
        public kcptun_crypt crypt { get; set; }

        [MyCategory(PropertyCategories.Security)]
        [MyDescription("key for communcation")]
        public string key { get; set; }

        [MyCategory(PropertyCategories.Security)]
        [MyDescription("disable compression")]
        [TypeConverter(typeof(MyBooleanConverter))]
        public bool nocomp { get; set; }

        #endregion

        #region Mode

        [MyCategory(PropertyCategories.Mode)]
        [MyDescription("mode for communication. Ignore all other parameters exclude 'extend arguments', when select 'manual-all'")]
        [TypeConverter(typeof(MyEnumConverter))]
        public kcptun_mode mode { get; set; }

        [MyCategory(PropertyCategories.Mode)]
        [MyDescription("enabled on 'manual' mode, ref https://github.com/xtaci/kcptun")]
        public int nodelay { get; set; }

        [MyCategory(PropertyCategories.Mode)]
        [MyDescription("enabled on 'manual' mode, ref https://github.com/xtaci/kcptun")]
        public int resend { get; set; }

        [MyCategory(PropertyCategories.Mode)]
        [MyDescription("enabled on 'manual' mode, ref https://github.com/xtaci/kcptun")]
        public int nc { get; set; }

        [MyCategory(PropertyCategories.Mode)]
        [MyDescription("enabled on 'manual' mode, ref https://github.com/xtaci/kcptun")]
        public int interval { get; set; }

        #endregion

        #region Error-correcting

        [MyCategory(PropertyCategories.ErrorCorrecting)]
        [MyDescription("Reed-solomon erasure coding - datashard")]
        public int datashard { get; set; }

        [MyCategory(PropertyCategories.ErrorCorrecting)]
        [MyDescription("Reed-solomon erasure coding - parityshard")]
        public int parityshard { get; set; }

        #endregion

        #region Window size

        [MyCategory(PropertyCategories.WindowSize)]
        [MyDescription("send window size (num of packets)")]
        public int sndwnd { get; set; }

        [MyCategory(PropertyCategories.WindowSize)]
        [MyDescription("receive window size (num of packets)")]
        public int rcvwnd { get; set; }

        #endregion

        #region Advance

        [MyCategory(PropertyCategories.Advance)]
        [MyDescription("set maximum transmission unit for UDP packets")]
        public int mtu { get; set; }

        [MyCategory(PropertyCategories.Advance)]
        [MyDescription("DSCP(6bit). Ref https://en.wikipedia.org/wiki/Differentiated_services#Commonly_used_DSCP_values")]
        public int dscp { get; set; }

        [MyCategory(PropertyCategories.Advance)]
        [MyDescription("set auto expiration time(in seconds) for a single UDP connection, 0 to disable")]
        public int autoexpire { get; set; }

        [MyCategory(PropertyCategories.Advance)]
        [MyDisplayName("extend arguments")]
        [MyDescription("extend arguments which are append to end of command line")]
        public string extend_arguments { get; set; }

        #endregion

        #endregion

        public Server()
        {
            localaddr = ":12948";
            remoteaddr = "192.168.1.1:29900";
            key = "it's a secrect";
            crypt = kcptun_crypt.aes;
            mode = kcptun_mode.fast;
            conn = 1;
            mtu = 1350;
            sndwnd = 128;
            rcvwnd = 1024;
            nocomp = false;
            datashard = 10;
            parityshard = 3;
            dscp = 0;

            nodelay = 1;
            resend = 2;
            nc = 1;
            interval = 20;

            remarks = "";

            autoexpire = 0;
        }

        public string FriendlyName()
        {
            if (string.IsNullOrEmpty(remarks))
                return remoteaddr;
            else
                return $"{remarks} ({remoteaddr})";
        }

        public override int GetHashCode()
        {
            return remoteaddr.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Server o2 = (Server)obj;
            return remoteaddr == o2.remoteaddr;
        }

        public override string ToString()
        {
            return FriendlyName();
        }

        public class MyCategoryAttribute: CategoryAttribute
        {
            public MyCategoryAttribute() { }

            public MyCategoryAttribute(string category)
                : base(category) { }

            protected override string GetLocalizedString(string value)
            {
                return I18N.GetString(value);
            }
        }

        public class MyDescriptionAttribute: DescriptionAttribute
        {
            public MyDescriptionAttribute() { }

            public MyDescriptionAttribute(string description)
                : base(description) { }

            public override string Description
            {
                get
                {
                    return I18N.GetString(DescriptionValue);
                }
            }
        }

        public class MyDisplayNameAttribute : DisplayNameAttribute
        {
            public MyDisplayNameAttribute() { }

            public MyDisplayNameAttribute(string displayName)
                : base(displayName) { }

            public override string DisplayName
            {
                get
                {
                    return I18N.GetString(DisplayNameValue);
                }
            }
        }
    }
}
