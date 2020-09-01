using System;

namespace Competitive.Code
{
    class ScheduleNode : IComparable
    {
        public bool Arriving { get; }
        public double Time { get; }
        public ScheduleNode(double time, bool arriving)
        {
            this.Time = time;
            this.Arriving = arriving;
        }
        public int CompareTo(object other)
        {
            var obj = (ScheduleNode)other;
            int ret = this.Time.CompareTo(obj.Time);
            if (ret == 0)
            {
                //The departing train should have priority
                if (this.Arriving && !obj.Arriving)
                    ret = -1;
                else if (!this.Arriving && obj.Arriving)
                    ret = 1;
            }
            return ret;
        }
    }
}