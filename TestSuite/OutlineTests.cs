﻿using LagDaemon.WWB.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.TestSuite
{
#if DEBUG

    [TestFixture]
    public class OutlineTests
    {
        OutlineElement entry;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void SetUp()
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

            int curOrder = 0;
            foreach (OutlineElement child in entry.ChildrenByOrder)
            {
                Assert.Greater(child.Order, curOrder);
                curOrder = child.Order;
            }
        }

        [TearDown]
        public void TearDown()
        {
            entry = null;
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            entry = null;
        }

    }

#endif
}