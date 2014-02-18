using LagDaemon.WWB.Model;
using LagDaemon.WWB.ModelRepository;
using LagDaemon.WWB.Repository;
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
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.ModelTests
{
    [TestFixture]
    public abstract class ModelTestRepositoryBase<T> where T : new()
    {
        protected IRepository repo;
        protected MockRepository mocks;
        protected ItemManager<T> itemManager;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
        }

        [SetUp]
        public virtual void Setup()
        {
            mocks = new MockRepository();
            repo = MockRepository.GenerateMock<IRepository>();
            RepositoryAccess.Repository = repo;
        }

        [Test]
        public void RepositoryWorks()
        {
            T item = new T();
            repo.Expect(x => x.Store<T>(item)).Return(true);
            bool result = itemManager.Save(item);
            Assert.True(result);
            repo.VerifyAllExpectations();
        }


        [TearDown]
        public virtual void TearDown()
        {
            mocks = null;
            repo = null;
            RepositoryAccess.Repository = null;
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
        }
    }
}
