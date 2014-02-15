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
using LagDaemon.WWB.AbstractPatterns;

namespace LagDaemon.WWB.AbstractPatternsTests
{
    [TestFixture]
    public class MultitonTests
    {

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("Running Multiton Tests");
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Multiton_Creates_ParameterlessClass_Instance()
        {
            IMultiton multiton = new Multiton();
            multiton.Add(typeof(ParameterlessTestClass));
            ParameterlessTestClass testClass = multiton.Instance<ParameterlessTestClass>();
            Assert.True(testClass.TestProp);
        }

        [Test]
        public void Multiton_Produces_Singletons_For_Type()
        {
            IMultiton multiton = new Multiton();
            multiton.Add(typeof(TestClassWithParameters));
            multiton.Configure<TestClassWithParameters>(2, 3);
            TestClassWithParameters testClass1 = multiton.Instance<TestClassWithParameters>();
            TestClassWithParameters testClass2 = multiton.Instance<TestClassWithParameters>();
            Assert.AreSame(testClass1, testClass2);
        }

        [Test]
        public void Multiton_Creates_ClassWithParameters_Instance()
        {
            IMultiton multiton = new Multiton();
            multiton.Add(typeof(TestClassWithParameters));
            multiton.Configure<TestClassWithParameters>(2, 3);
            TestClassWithParameters testClass = multiton.Instance<TestClassWithParameters>();
            Assert.AreEqual(testClass.A, 2);
            Assert.AreEqual(testClass.B, 3);
        }

        [Test]
        [ExpectedException(typeof(MultitonException))]
        public void Multiton_Throws_MultitonException_When_Type_added_second_Time()
        {
            IMultiton multiton = new Multiton();
            multiton.Add(typeof(TestClassWithParameters));
            multiton.Add(typeof(TestClassWithParameters));
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
