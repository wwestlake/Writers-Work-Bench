using LagDaemon.WWB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public class ProjectManager : ItemManager<Project>
    {

        public ProjectManager(IRepository repository) : base(repository) 
        {
            allItemsPredicate = new Predicate<Project>(x => true);
        }

        public override IEnumerable<Project> All()
        {
            return repository.Query<Project>(allItemsPredicate);
        }

        public override void Save(Project item)
        {
            repository.Store<Project>(item);
        }

        public override void Save(IEnumerable<Project> items)
        {
            repository.Store<Project>(items);
        }

        public override void Remove(Project item)
        {
            repository.Delete<Project>(item);
        }

        public override void Remove(IEnumerable<Project> items)
        {
            repository.Delete<Project>(items);
        }
    }
}
