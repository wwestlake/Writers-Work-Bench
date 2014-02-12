using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LagDaemon.WWB.Repository
{
    public class RepositoryFactory<T> where T: IRepository
    {
        private Dictionary<string, IRepository> repositories = new Dictionary<string, IRepository>();
        private static RepositoryFactory<T> factory;

        private RepositoryFactory() { }

        public static RepositoryFactory<T> Factory 
        { 
            get 
            { 
                if (null == factory) factory = new RepositoryFactory<T>(); 
                return factory; 
            } 
        }

        public void Clear()
        {
            repositories.Clear();
        }

        /// <summary>
        /// Creates a repository based on the supplied T for this factory
        /// </summary>
        /// <param name="p">The name of this repository</param>
        /// <returns>An IRepository interface for this repository</returns>
        public IRepository CreateRepository(string p)
        {
            if (repositories.ContainsKey(p)) throw new RepositoryException("Repository {0} already exists!", p);
            IRepository result = Activator.CreateInstance(typeof(T)) as IRepository;
            repositories.Add(p, result);
            return result;
        }
    }
}
