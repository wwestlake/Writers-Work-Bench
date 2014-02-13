using LagDaemon.WWB.Model;
using LagDaemon.WWB.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.RepositoryTestSuite
{
#if DEBUG

    [TestFixture]
    public class ProjectManagerTests : ItemManagerTestsBase<Project>
    {

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
        }

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            itemManager = new ProjectManager(repo);
        }

    }

#endif
}
