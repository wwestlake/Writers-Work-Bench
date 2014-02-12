using LagDaemon.WWB.Repository;
using LagDaemon.WWB.Repository.Zip;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.TestSuite
{
#if DEBUG

    [TestFixture]
    public class RepositoryTests
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
        public void Repository_Factory_Creates_Repository()
        {
            IRepository repo = RepositoryFactory<ZipRepository>.Factory.CreateRepository("TestRepo");
            Assert.NotNull(repo);
        }

        [Test]
        [ExpectedException(typeof(RepositoryException))]
        public void Repository_Factory_Throws_Exception_When_Name_Is_Used_Second_Time()
        {
            RepositoryFactory<ZipRepository>.Factory.CreateRepository("TestRepo");
            RepositoryFactory<ZipRepository>.Factory.CreateRepository("TestRepo");
        }

        [TearDown]
        public void TearDown()
        {
            RepositoryFactory<ZipRepository>.Factory.Clear();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

   }

#endif
}
