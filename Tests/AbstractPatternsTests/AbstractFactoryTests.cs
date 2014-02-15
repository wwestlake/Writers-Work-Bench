/*
    $programname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code:  https://github.com/wwestlake/Writers-Work-Bench.git
  
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
    public class AbstractFactoryTests
    {


        


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("Running AbstractFactory Tests");
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AbstractFactory_Creates_ParameterlessTestClassInstance()
        {
            IAbstractFactory<ParameterlessTestClass> factory = new AbstractFactory<ParameterlessTestClass>();
            ParameterlessTestClass testClass = factory.Create();
            Assert.True(testClass.TestProp);
        }

        [Test]
        public void AbstractFactory_Creates_ClassWithParametersInstance()
        {
            IAbstractFactory<TestClassWithParameters> factory = new AbstractFactory<TestClassWithParameters>();
            TestClassWithParameters testClass = factory.Create(2, 3);
            Assert.AreEqual(testClass.A, 2);
            Assert.AreEqual(testClass.B, 3);
        }

        [Test]
        public void AbstractFactory_Creates_ClassWithPredefinedConfig()
        {
            IAbstractFactory<TestClassWithParameters> factory = new AbstractFactory<TestClassWithParameters>();
            factory.Configure(2, 3);
            TestClassWithParameters testClass = factory.Create();
            Assert.AreEqual(testClass.A, 2);
            Assert.AreEqual(testClass.B, 3);
        }

        [Test]
        public void AbstractFactory_Creates_ClassWithPartialPredefinedConfig()
        {
            IAbstractFactory<TestClassWithParameters> factory = new AbstractFactory<TestClassWithParameters>();
            factory.Configure(2);
            TestClassWithParameters testClass = factory.Create(3);
            Assert.AreEqual(testClass.A, 2);
            Assert.AreEqual(testClass.B, 3);
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
