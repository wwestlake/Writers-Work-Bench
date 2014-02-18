/*
    $projectname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
     
    source code: https://github.com/wwestlake/Writers-Work-Bench.git 
 
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
    public class StrategyTests
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
        public void AddStrategy_Is_Called_By_Context()
        {
            IntegerContext context = new IntegerContext(new AddStrategy());
            int result = context.Execute(3, 4, 5);
            Console.WriteLine("AddStrategy result = {0}", result);
            Assert.AreEqual(result, 3 + 4 + 5);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void AddStrategy_Throws_Exception()
        {
            IntegerContext context = new IntegerContext(new AddStrategy());
            int result = context.Execute(3, 4, "This should throw an exception");
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
