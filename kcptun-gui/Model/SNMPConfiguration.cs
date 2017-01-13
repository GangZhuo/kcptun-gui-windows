using System;

namespace kcptun_gui.Model
{
    public class SNMPConfiguration
    {
        public bool enabled;

        public string snmplog;

        public int snmpperiod;

        public SNMPConfiguration()
        {
            enabled = false;
            snmplog = "";
            snmpperiod = 60;
        }

        public override int GetHashCode()
        {
            return $"{enabled},{snmplog},{snmpperiod}".GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is SNMPConfiguration)
            {
                SNMPConfiguration a = obj as SNMPConfiguration;
                return a.enabled == this.enabled &&
                    a.snmplog == this.snmplog &&
                    a.snmpperiod == this.snmpperiod;
            }
            return false;
        }
    }
}
