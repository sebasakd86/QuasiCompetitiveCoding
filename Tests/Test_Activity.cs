using System;
using System.Collections.Generic;
using Competitive.Code;
using Xunit;

namespace Competitive.Tests
{
    public class Test_Activity
    {
        [Fact]
        [Trait("Category","Activity")]
        public void Activity_StartGreaterValue_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = new Activity(5, 1);
            });
        }

        [Fact]
        [Trait("Category","Activity")]
        public void Activity_StartEqualValue_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = new Activity(5, 5);
            });
        }
        [Fact]
        [Trait("Category","Activity")]
        public void Activity_CorrectValue()
        {
            int start = 5;
            int end = 10;
            var a = new Activity(start, end);
            Assert.Equal(start, a.Start);
            Assert.Equal(end, a.End);
        }

        [Fact]
        [Trait("Category","Activity")]
        public void Activity_IsSorted()
        {
            var l = new List<Activity>()
            {
                new Activity(1,2),
                new Activity(2,3),
                new Activity(0,1)
            };
            l.Sort();
            for (int i = 0; i < l.Count; i++)
                Assert.Equal(i + 1, l[i].End);
        }
    }
}