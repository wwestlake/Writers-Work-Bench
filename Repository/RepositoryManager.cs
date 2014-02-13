
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagDaemon.WWB.Model;
using System.Runtime.CompilerServices;

namespace LagDaemon.WWB.Repository
{
    internal class RepositoryManager : IRepositoryManager
    {
        protected IRepository repository;
        protected ProjectManager projectManager;

        protected Predicate<Project> allProjectsPredicate = new Predicate<Project>(x => true);
        
        internal RepositoryManager(IRepository repository)
        {
            this.repository = repository;
        }

        public Predicate<Project> AllProjectsPredicate
        {
            get
            {
                return allProjectsPredicate;
            }
            set
            {
                allProjectsPredicate = value;
            }
        }

        public IItemManager<Project> ProjectManager
        {
            get 
            {
                return new ProjectManager(repository);
            }
        }


        public IItemManager<Character> CharacterManager
        {
            get { return new CharacterManager(repository); }
        }
    }
}
