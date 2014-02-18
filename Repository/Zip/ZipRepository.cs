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

namespace LagDaemon.WWB.Repository.Zip
{
    public class ZipRepository : IRepository
    {
        public bool Store<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public int Store<T>(IEnumerable<T> objs)
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
