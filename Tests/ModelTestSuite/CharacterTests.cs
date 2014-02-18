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
using LagDaemon.WWB.Model;
using LagDaemon.WWB.ModelRepository;
using LagDaemon.WWB.Repository;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LagDaemon.WWB.ModelTests
{
    [TestFixture]
    public class CharacterTests : ModelTestRepositoryBase<Character>
    {
        CharacterBuilder builder;

        public override void Setup()
        {
            base.Setup();
            itemManager = new CharacterManager(repo);
            builder = new CharacterBuilder();
        }

        [Test]
        public void CharacterFactory_Creates_CharacterWithName()
        {
            var characters = new List<Character> 
            { 
                builder.New()
                    .Name("Bill")
                    .Build(),
                builder.New()
                    .Name("Ken")
                    .Build()
            };
            var mock = MockRepository.GenerateMock<IRepository>();

            mock.Stub(m => m.Query<Character>(x => x == x)).Return(characters);

            CharacterFactory factory = new CharacterFactory(mock);
            Character testChar = factory.Create("Bill");
            Assert.AreEqual(testChar.Name, "Bill");
        }

        [Test]
        public void CharacterExctensions_SetProperties()
        {
            Character testChar = builder.New()
                .Name("Bill")
                .FirstName("Bill")
                .Build();
            testChar.FirstName = "Bill";
            Assert.AreEqual(testChar.FirstName, "Bill");
        }


        [Test]
        public void CharacterFactory_Creates_And_Saves_Character()
        {
            var name = "Bill";
            var mocks = new MockRepository();
            var mock = MockRepository.GenerateMock<IRepository>();
            CharacterFactory factory = new CharacterFactory(mock);
            Character testChar = factory.Create(name);
            Assert.AreEqual(testChar.Name, name);
        }

    }
}
