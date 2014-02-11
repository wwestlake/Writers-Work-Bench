using LagDaemon.WWB.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.TestSuite
{
    [TestFixture]
    public class TimeLineTests
    {
        TimeLine timeline;


        [SetUp]
        public void Init()
        {
            timeline = new TimeLine();
        }

        [Test]
        public void TimeLine_Adds_Entries()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                timeline.AddChild(new TimeLineEntry { Start = DateTime.Now });
            }
            Assert.AreEqual(timeline.ChildCount, iter);
        }

        [Test]
        public void TimeLine_Removess_Entries()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                timeline.AddChild(new TimeLineEntry { Start = DateTime.Now });
            }
            foreach (TimeLineEntry entry in timeline.Children)
            {
                timeline.Remove(entry);
            }
            Assert.AreEqual(timeline.ChildCount, 0);
        }

        [Test]
        public void TimeLine_Clears_Entries()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                timeline.AddChild(new TimeLineEntry { Start = DateTime.Now });
            }
            timeline.Clear();
            Assert.AreEqual(timeline.ChildCount, 0);
        }
    }
}
