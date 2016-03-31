using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1_Timer
{

    public class TimerEventArgs : EventArgs
    {
        public string Message { get; set; }
        public int TimeOut { get; set; }
    }

    public class Timer
    {
        public event EventHandler<TimerEventArgs> TimerTick = delegate { };
        private string message = "Wake up!!!";

        protected virtual void OnTimerTick(int milliseconds)
        {
            if (TimerTick != null)
                TimerTick(this, new TimerEventArgs() {Message = message, TimeOut = milliseconds});
        }

        public void SetTimer(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            OnTimerTick(milliseconds);
        }
    }
}
