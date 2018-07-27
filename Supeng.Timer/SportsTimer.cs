using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supeng.Timer
{
    public class SportsTimer : ISportsTimer
    {
        private readonly bool _increase;
        private readonly long _totalSeconds;
        protected System.Threading.Timer Timer;

        public SportsTimer(bool increase, long totalSeconds)
        {
            _increase = increase;
            _totalSeconds = totalSeconds;
            CurrentSeconds = totalSeconds;
        }


        public void Start()
        {
            var start = DateTime.Now;
            Timer = new System.Threading.Timer(state => Run(start), null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }

        protected long StopSeconds;
        public void Stop()
        {
            StopSeconds = CurrentSeconds;
            Timer?.Dispose();
        }

        public void Reset()
        {
            Stop();
            CurrentSeconds = _totalSeconds;
            StopSeconds = 0;
            Start();
        }

        public long CurrentSeconds { get; protected set; }


        protected virtual void Run(DateTime start)
        {
            var elapsed = DateTime.Now - start;
            if (_increase)
            {
                CurrentSeconds = StopSeconds > 0 ? StopSeconds + elapsed.Seconds + 1 : _totalSeconds + elapsed.Seconds + 1;
            }
            else
            {
                CurrentSeconds = StopSeconds > 0 ? StopSeconds - elapsed.Seconds - 1 : _totalSeconds - elapsed.Seconds - 1;
            }
            Display?.Invoke();
        }

        public Action Display { get; set; }
    }
}
