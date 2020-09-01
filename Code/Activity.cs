using System;

namespace Competitive.Code
{
    public abstract class ActivityTemplate<T> where T : IComparable
    {
        public T Start { get; }
        public T End { get; }
        public ActivityTemplate(T start, T end)
        {
            if (start.CompareTo(end) == 1)
                throw new ArgumentOutOfRangeException("Start is greater or equal than end");
            this.End = end;
            this.Start = start;
        }
    }
    public class Activity : ActivityTemplate<int>, IComparable<Activity>
    {
        public Activity(int start, int end) : base(start, end)
        {
            if (start >= end)
                throw new ArgumentOutOfRangeException("Start is greater or equal than end");
        }
        public int CompareTo(Activity other)
        {
            return End.CompareTo(other.End);
        }
    }
    public class ScheduleActivity : ActivityTemplate<double>, IComparable<ScheduleActivity>
    {
        public ScheduleActivity(double start, double end) : base(start, end)
        {
            if (start >= end)
                throw new ArgumentOutOfRangeException("Start is greater or equal than end");
        }
        public int CompareTo(ScheduleActivity other)
        {
            return End.CompareTo(other.End);
        }
    }     
}