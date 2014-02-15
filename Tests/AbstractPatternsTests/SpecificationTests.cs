using LagDaemon.WWB.AbstractPatterns;
/*
    $programname$ Copyright (C) 2014  William W. Westlake Jr.
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
    public class SpecificationTests
    {

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("Running Specification Tests");
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Specification_And_Validates_TestClass()
        {
            LessThanTenSpecification lessThanTen = new LessThanTenSpecification();
            GreaterThanFiveSpecificat greaterThanFive = new GreaterThanFiveSpecificat();
            SpecTest specTest = new SpecTest { TestProp = 7 };
            ISpecification<SpecTest> test = lessThanTen.And(greaterThanFive);
            Assert.True(test.IsSatisfiedBy(specTest));
            specTest.TestProp = 3;
            Assert.False(test.IsSatisfiedBy(specTest));
        }

        [Test]
        public void Specification_Or_Validates_TestClass()
        {
            GreaterThanTenSpecification greaterThanTen = new GreaterThanTenSpecification();
            LessThanFiveSpecificat lessThanFive = new LessThanFiveSpecificat();
            SpecTest specTest1 = new SpecTest { TestProp = 3 };
            SpecTest specTest2 = new SpecTest { TestProp = 14 };
            SpecTest specTest3 = new SpecTest { TestProp = 7 };
            ISpecification<SpecTest> test = greaterThanTen.Or(lessThanFive);
            Assert.True(test.IsSatisfiedBy(specTest1));
            Assert.True(test.IsSatisfiedBy(specTest2));
            Assert.False(test.IsSatisfiedBy(specTest3));
        }

        [Test]
        public void Specification_Not_Validates_TestClass()
        {
            GreaterThanTenSpecification greaterThanTen = new GreaterThanTenSpecification();
            SpecTest specTest = new SpecTest { TestProp = 7 };

            ISpecification<SpecTest> test = greaterThanTen.Not();

            Assert.True(test.IsSatisfiedBy(specTest));
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
