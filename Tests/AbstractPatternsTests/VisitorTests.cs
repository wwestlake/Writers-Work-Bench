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
using LagDaemon.WWB.AbstractPatterns;

namespace LagDaemon.WWB.AbstractPatternsTests
{
    [TestFixture]
    public class VisitorTests : VisitorAction, IVisitable
    {

        protected bool flag;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            flag = false;
        }

        [Test]
        public void Visits_This_Class_Calling_SomeAction()
        {
            Visitor<VisitorTests> visitor = new Visitor<VisitorTests>();
            VisitorTests tests = new VisitorTests();
            visitor.AddAction<VisitorTests>(typeof(VisitorTests), tests);
            visitor.Visit(tests);
            Assert.True(tests.flag);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        public void Accept(IVisitor<IVisitable> visitor)
        {
            visitor.Visit(this);
        }

        public void Visit(VisitorTests tests)
        {
            SetValue();
        }

        public void SetValue()
        {
            flag = true;
        }

    }
}
