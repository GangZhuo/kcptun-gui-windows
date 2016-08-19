using System;
using System.ComponentModel;

namespace kcptun_gui.Model
{
    public enum kcptun_mode
    {
        normal, fast3, fast2, fast,
        manual,
        [Description("manual-all")]
        manual_all,
    }
}
