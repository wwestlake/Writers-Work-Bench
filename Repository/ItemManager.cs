using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public abstract class ItemManager<T> : IItemManager<T>
    {
        protected IRepository repository;
        protected Predicate<T> allItemsPredicate;

        internal ItemManager(IRepository repository)
        {
            this.repository = repository;
        }

        public abstract IEnumerable<T> All();
        public abstract void Save(T item);
        public abstract void Save(IEnumerable<T> items);
        public abstract void Remove(T item);
        public abstract void Remove(IEnumerable<T> items);


        public Predicate<T> AllItemsPredicate
        {
            get
            {
                return allItemsPredicate;
            }
            set
            {
                this.allItemsPredicate = value;
            }
        }
    }
}
