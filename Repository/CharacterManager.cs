using LagDaemon.WWB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Repository
{
    public class CharacterManager : ItemManager<Character>
    {

        public CharacterManager(IRepository repository)
            : base(repository)
        {
            allItemsPredicate = new Predicate<Character>(x => true);
        }

        public override IEnumerable<Character> All()
        {
            return repository.Query<Character>(allItemsPredicate);
        }

        public override void Save(Character item)
        {
            repository.Store<Character>(item);
        }

        public override void Save(IEnumerable<Character> items)
        {
            repository.Store<Character>(items);
        }

        public override void Remove(Character item)
        {
            repository.Delete<Character>(item);
        }

        public override void Remove(IEnumerable<Character> items)
        {
            repository.Delete<Character>(items);
        }
    }
}
