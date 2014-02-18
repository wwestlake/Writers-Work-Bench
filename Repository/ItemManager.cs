/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/Writers-Work-Bench.git
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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
        public abstract bool Save(T item);
        public abstract int Save(IEnumerable<T> items);
        public abstract void Remove(T item);
        public abstract void Remove(IEnumerable<T> items);
        public abstract IEnumerable<T> Find(Predicate<T> predicate);


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
