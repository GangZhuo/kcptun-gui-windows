using Newtonsoft.Json;

namespace kcptun_gui.Model
{
    public class TrafficLog
    {
        public Traffic raw;
        public Traffic kcp;

        [JsonIgnore]
        public Traffic rawSpeed;
        [JsonIgnore]
        public Traffic kcpSpeed;

        public TrafficLog()
        {
            raw = new Traffic();
            rawSpeed = new Traffic();
            kcp = new Traffic();
            kcpSpeed = new Traffic();
        }

        public TrafficLog(Traffic raw, Traffic rawspeed, Traffic kcp, Traffic kcpspeed)
        {
            this.raw = raw;
            this.rawSpeed = rawspeed;
            this.kcp = kcp;
            this.kcpSpeed = kcpspeed;
        }


    }
}
