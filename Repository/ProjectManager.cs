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
