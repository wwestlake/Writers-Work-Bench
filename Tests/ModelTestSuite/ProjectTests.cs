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
    public class ProjectTests : ModelTestRepositoryBase<Project>
    { 
        ProjectBuilder builder;

        public override void Setup()
        {
            base.Setup();
            itemManager = new ProjectManager(repo);
            builder = new ProjectBuilder();
        }

        [Test]
        public void ProjectFactory_Creates_ProjectWithName()
        {
            var projects = new List<Project> 
            { 
                builder.New()
                    .Name("Project 1")
                    .Build(),
                builder.New()
                    .Name("Project 2")
                    .Build()
            };
            var mock = MockRepository.GenerateMock<IRepository>();

            mock.Stub(m => m.Query<Project>(x => x == x)).Return(projects);

            CharacterFactory factory = new CharacterFactory(mock);
            Character testChar = factory.Create("Project 1");
            Assert.AreEqual(testChar.Name, "Project 1");
        }

        [Test]
        public void ProjectExctensions_SetProperties()
        {
            Project testProj = builder.New()
                .Name("Project 1")
                .Author("Bill")
                .Build();
            Assert.AreEqual(testProj.Author, "Bill");
        }


        [Test]
        public void ProjectFactory_Creates_And_Saves_Character()
        {
            var name = "Project 1";
            var mocks = new MockRepository();
            var mock = MockRepository.GenerateMock<IRepository>();
            ProjectFactory factory = new ProjectFactory(mock);
            Project testProj = factory.Create(name);
            Assert.AreEqual(testProj.Name, name);
        }

    }
}
