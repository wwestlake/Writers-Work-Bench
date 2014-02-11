using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model.UnitTests
{
#if DEBUG

    [TestFixture]
    public class OutlineTests
    {
        OutlineElement entry;

        [SetUp]
        public void Init()
        {
            entry = new OutlineElement();
        }


        [Test]
        public void Outline_Produces_Dot_Notation_Entry_Numbers_Based_On_Parents()
        {
            entry.Order = 2;
            for (int i = 1; i <= 10; i++)
            {
                OutlineElement child = new OutlineElement { Order = i};
                entry.AddChild(child);
                Assert.True(child.EntryNumber.Equals(string.Format("2.{0}", i)), "{0}.{1} = {2}", 2, i, child.EntryNumber);
            }
        }

        [Test]
        public void OutlineEntry_produces_ordered_children()
        {
            entry.Order = 2;
            for (int i = 10; i >= 1; i--)
            {
                OutlineElement child = new OutlineElement { Order = i };
                entry.AddChild(child);
            }

            int curOrder = 0;
            foreach (OutlineElement child in entry.ChildrenByOrder)
            {
                Assert.Greater(child.Order, curOrder);
                curOrder = child.Order;
            }

        }

    }

#endif
}
