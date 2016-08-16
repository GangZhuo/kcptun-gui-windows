using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace kcptun_gui.Model
{
    public enum kcptun_crypt
    {
        none, aes, tea, xor, 
    }

    public enum kcptun_mode
    {
        normal, fast3, fast2, fast, manual,
    }

    public static class PropertyCategories
    {
        public const string Base = "Base";
        public const string Security = "Security";
        public const string Options = "Options";
        public const string ReedSolomon = "Reed-Solomon";
        public const string WindowSize = "Window Size";
        public const string Advanced = "Advanced";
    }

    [Serializable]
    [DefaultProperty("remoteaddr")]
    public class Server
    {
        [Category(PropertyCategories.Base)]
        [Description("local listen address")]
        public string localaddr { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("kcp server address")]
        public string remoteaddr { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("mode for communication")]
        public kcptun_mode mode { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("remarks specify by user")]
        public string remarks { get; set; }

        [Category(PropertyCategories.Security)]
        [Description("key for communcation, must be the same as kcptun server")]
        public string key { get; set; }

        [Category(PropertyCategories.Security)]
        [Description("methods for encryption")]
        public kcptun_crypt crypt { get; set; }

        [Category(PropertyCategories.WindowSize)]
        [Description("set send window size(num of packets)")]
        public int sndwnd { get; set; }

        [Category(PropertyCategories.WindowSize)]
        [Description("set receive window size(num of packets)")]
        public int rcvwnd { get; set; }

        [Category(PropertyCategories.ReedSolomon)]
        [Description("set reed-solomon erasure coding - datashard")]
        public int datashard { get; set; }

        [Category(PropertyCategories.ReedSolomon)]
        [Description("set reed-solomon erasure coding - parityshard")]
        public int parityshard { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("establish N physical connections as specified by 'conn' to server")]
        public int conn { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("set MTU of UDP packets, suggest 'tracepath' to discover path mtu")]
        public int mtu { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("disable compression")]
        public bool nocomp { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("set DSCP(6bit)")]
        public int dscp { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("")]
        public int nodelay { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("")]
        public int resend { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("")]
        public int nc { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("")]
        public int interval { get; set; }

        [Category(PropertyCategories.Advanced)]
        [DisplayName("Other Arguments")]
        [Description("")]
        public string other_arguments { get; set; }

        public override int GetHashCode()
        {
            return remoteaddr.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Server o2 = (Server)obj;
            return remoteaddr == o2.remoteaddr;
        }

        public string FriendlyName()
        {
            return $"{remarks} ({remoteaddr})";
        }

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
        }

        public string Identifier()
        {
            return remoteaddr;
        }
    }
}
