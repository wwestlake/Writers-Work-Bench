using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository.Zip
{
    public class ZipRepository : IRepository
    {
        public void Store<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Store<T>(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }

        public void Activate<T>(T obj, int depth)
        {
            throw new NotImplementedException();
        }
    }
}
