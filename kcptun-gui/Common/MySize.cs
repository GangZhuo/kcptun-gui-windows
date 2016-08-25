using System;

namespace kcptun_gui.Common
{
    public class MySize
    {
        private readonly static string[] units = new string[] { "B", "K", "M", "G", "T" };

        private long _rawValue;

        public long rawValue
        {
            get { return _rawValue; }
            set { SetRawValue(value); }
        }

        public long scale { get; private set; }
        public float value { get; private set; }
        public string unit { get; private set; }

        public MySize() { }

        public MySize(long n)
        {
            SetRawValue(n);
        }

        private void SetRawValue(long n)
        {
            _rawValue = n;
            long scale = 1;
            float f = n;
            int unit = 0;
            while(f > 1024 && unit < units.Length)
            {
                f = f / 1024;
                scale <<= 10;
                unit++;
            }
            this.scale = scale;
            this.value = f;
            this.unit = units[unit];
        }

        public override string ToString()
        {
            return value.ToString("F2") + " " + unit;
        }
    }
}
