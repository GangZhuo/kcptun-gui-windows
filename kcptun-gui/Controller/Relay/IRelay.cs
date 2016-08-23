using System;
using System.Net;

namespace kcptun_gui.Controller
{
    public interface IRelay
    {
        event EventHandler<RelayEventArgs> Inbound;
        event EventHandler<RelayEventArgs> Outbound;

        void Start();
        void Stop();

        void onInbound(long n);
        void onOutbound(long n);
    }

    public class RelayEventArgs : EventArgs
    {
        public long Value { get; private set; }

        public RelayEventArgs(long value)
        {
            Value = value;
        }
    }
}