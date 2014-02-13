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
    public class CharacterManagerTests : ItemManagerTestsBase<Character>
    {

        public override void Setup()
        {
            base.Setup();
            itemManager = new CharacterManager(repo);
        }

    }

#endif
}
