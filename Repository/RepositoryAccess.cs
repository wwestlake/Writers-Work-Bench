using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public static class RepositoryAccess
    {
        private static IRepositoryManager manager;
        private static IRepository defaultRepository = new Zip.ZipRepository();

        public static IRepository Repository { get; set; }

        public static IRepositoryManager RepositoryManager
        {
            get
            {
                return new RepositoryManager(Repository);
            }
        }

    }
}
