using System;
using System.ComponentModel;

namespace kcptun_gui.Model
{
    public enum kcptun_crypt
    {
        none,
        aes,
        [Description("aes-128")]
        aes_128,
        [Description("aes-192")]
        aes_192,
        blowfish,
        cast5,
        [Description("3des")]
        _3des,
        tea,
        xor,
    }
}
