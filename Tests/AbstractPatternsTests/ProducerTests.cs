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
    public class ProducerTests
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
        public void ProducerBuildsClassFromRegisteredTypes()
        {
            Producer producer = new Producer();
            producer.RegisterType<ProducerInterface_A, ProducerClass_A>()
                .RegisterType<ProducerInterface_B, ProducerClass_B>()
                .RegisterType<ProducerInterface_C, ProducerClass_C>()
                .RegisterFactory<ConcreteClass>(
                    new AbstractFactory<ConcreteClass>().Configure(3)
                 );

            ProducerInterface_C testClass = producer.Instance<ProducerInterface_C>();

            Assert.NotNull(testClass);
            Assert.AreEqual(testClass.ConcreteClass.Value, 3);
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
