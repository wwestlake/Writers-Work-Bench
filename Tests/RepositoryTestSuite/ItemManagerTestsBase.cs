/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/Writers-Work-Bench.git
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using LagDaemon.WWB.Model;
using LagDaemon.WWB.Repository;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.RepositoryTestSuite
{
    [TestFixture]
    public abstract class ItemManagerTestsBase<T> where T: new()
    {
        protected IRepository repo;
        protected MockRepository mocks;
        protected IItemManager<T> itemManager;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
        }

        [SetUp]
        public virtual void Setup()
        {
            mocks = new MockRepository();
            repo = mocks.DynamicMock<IRepository>();
            RepositoryAccess.Repository = repo;
        }


        [Test]
        public void _1_ItemManager_CallsRepository_AllProjects()
        {

            using (mocks.Record())
            {
                repo.Query<T>(itemManager.AllItemsPredicate);
            }

            IEnumerable<T> result = itemManager.All();
            mocks.Verify(repo);
        }

        [Test]
        public void _2_ItemManager_CallsRepository_Save()
        {
            T item = new T();
            using (mocks.Record())
            {
                repo.Store<T>(item);
            }

            itemManager.Save(item);
            mocks.Verify(repo);
        }


        [Test]
        public void _3_ItemManager_CallsRepository_SaveEnumerable()
        {
            IEnumerable<T> list = new List<T>();
            using (mocks.Record())
            {
                repo.Store<T>(list);
            }

            itemManager.Save(list);
            mocks.Verify(repo);

        }

        [Test]
        public void _4_ItemManager_CallsRepository_Remove()
        {
            T item = new T();
            using (mocks.Record())
            {
                repo.Delete<T>(item);
            }

            itemManager.Remove(item);
            mocks.Verify(repo);

        }


        [Test]
        public void _5_ItemManager_CallsRepository_RemoveEnumerable()
        {
            IEnumerable<T> list = new List<T>();
            using (mocks.Record())
            {
                repo.Delete<T>(list);
            }

            itemManager.Remove(list);
            mocks.Verify(repo);
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
