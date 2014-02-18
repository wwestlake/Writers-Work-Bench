/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/Writers-Work-Bench.git
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using LagDaemon.WWB.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.ModelTests
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
