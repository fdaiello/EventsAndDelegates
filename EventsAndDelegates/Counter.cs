using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

    class Counter
    {
        private readonly int Threshold;

        public Counter( int threshold)
        {
            Threshold = threshold;
        }

        //public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        public event ThresholdReachedEventHandler ThresholdReached;

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            //EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            ThresholdReachedEventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }

        public int Value { get; set; }

        public void Increment()
        {
            Value++;
            if (Value == Threshold)
            {
                ThresholdReachedEventArgs e = new ThresholdReachedEventArgs()
                {
                    Threshold = Threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(e);
            }
        }
    }
}
