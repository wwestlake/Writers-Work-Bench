using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public interface IItemManager<T>
    {
        IEnumerable<T> All();
        void Save(T item);
        void Save(IEnumerable<T> items);
        void Remove(T item);
        void Remove(IEnumerable<T> items);
        Predicate<T> AllItemsPredicate { get; set; }
    }
}
