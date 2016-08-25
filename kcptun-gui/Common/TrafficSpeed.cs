using System;

namespace kcptun_gui.Common
{
    public class TrafficSpeed : TrafficSize
    {
        public TrafficSpeed() : base() { }

        public TrafficSpeed(long n) : base(n) { }

        protected override string GetUnitName(int index)
        {
            return base.GetUnitName(index) + "/s";
        }
    }
}
