/*
    $programname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code: https://github.com/wwestlake/ExperimentalOS.git 
  
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using LagDaemon.WWB.AbstractPatterns;
using LagDaemon.WWB.Model;
using LagDaemon.WWB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.ModelRepository
{
    public class CharacterFactory : AbstractFactory<Character>
    {
        CharacterManager manager;

        public CharacterFactory(IRepository repository)
        {
            manager = new CharacterManager(repository);
        }

        public Character Create(string name)
        {
            IEnumerable<Character> items = manager.Find(x => x.Name == name);
            if (items != null && items.Count() > 0)
            {
                return items.First();
            }
            Character result = this.Create();
            result.Name = name;
            manager.Save(result);
            return result;
        }
    }
}
