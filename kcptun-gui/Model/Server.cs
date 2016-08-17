using System;
using System.ComponentModel;

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
        #region Properties

        [Category(PropertyCategories.Base)]
        [Description("Local listen address.")]
        public string localaddr { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("KCP server address.")]
        public string remoteaddr { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("Mode for communication.")]
        public kcptun_mode mode { get; set; }

        [Category(PropertyCategories.Base)]
        [Description("Mnemonic-name for server.")]
        public string remarks { get; set; }

        [Category(PropertyCategories.Security)]
        [Description("Key for communcation. Must be same as KCP server.")]
        public string key { get; set; }

        [Category(PropertyCategories.Security)]
        [Description("Method for encryption. Must be same as KCP server.")]
        public kcptun_crypt crypt { get; set; }

        [Category(PropertyCategories.WindowSize)]
        [Description("Send window size (num of packets).")]
        public int sndwnd { get; set; }

        [Category(PropertyCategories.WindowSize)]
        [Description("Receive window size (num of packets).")]
        public int rcvwnd { get; set; }

        [Category(PropertyCategories.ReedSolomon)]
        [Description("Reed-solomon erasure coding - datashard. Must be same as KCP server.")]
        public int datashard { get; set; }

        [Category(PropertyCategories.ReedSolomon)]
        [Description("Reed-solomon erasure coding - parityshard. Must be same as KCP server.")]
        public int parityshard { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("Establish N physical connections as specified by 'conn' to server.")]
        public int conn { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("MTU of UDP packets, suggest 'tracepath' to discover path mtu.")]
        public int mtu { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("No snappy compression. Must be same as KCP server.")]
        public bool nocomp { get; set; }

        [Category(PropertyCategories.Options)]
        [Description("DSCP(6bit). Ref https://en.wikipedia.org/wiki/Differentiated_services#Commonly_used_DSCP_values .")]
        public int dscp { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("Ref https://github.com/xtaci/kcptun .")]
        public int nodelay { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("Ref https://github.com/xtaci/kcptun .")]
        public int resend { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("Ref https://github.com/xtaci/kcptun .")]
        public int nc { get; set; }

        [Category(PropertyCategories.Advanced)]
        [Description("Ref https://github.com/xtaci/kcptun .")]
        public int interval { get; set; }

        [Category(PropertyCategories.Advanced)]
        [DisplayName("extend arguments")]
        [Description("Extend arguments append to end.")]
        public string extend_arguments { get; set; }

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
    }
}
