/*
    $programname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code: https://github.com/wwestlake/ExperimentalOS.git 
  
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.AbstractPatternsTests
{
    [TestFixture]
    public class ChainOfResponsibilityTests
    {

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ChainOfReponsibility_Process()
        {
            CoR_DataClass data1 = new CoR_DataClass { SomeValue = 1 };
            CoR_DataClass data2 = new CoR_DataClass { SomeValue = 4 };
            CoR_DataClass data3 = new CoR_DataClass { SomeValue = 6 };

            CorTestClass_Level_1 level1 = new CorTestClass_Level_1();

            level1.Action(data1);
            level1.Action(data2);
            level1.Action(data3);

            Assert.True(data1.Flag && data2.Flag && data3.Flag);

        }

        [TearDown]
        public void TearDown()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }
    }
}
