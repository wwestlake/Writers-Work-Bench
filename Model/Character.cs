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

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class Character : ModelBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Build { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public IList<string> Goals { get; set; }
        public string FacialFeatures { get; set; }
        public string General { get; set; }
        public Character Mother { get; set; }
        public Character Father { get; set; }
        public IList<Character> Children { get; set; }
        public IList<Character> Friends { get; set; }
        public IList<Character> Enemies { get; set; }
        public IList<Character> Associates { get; set; }
        public Character Spouse { get; set; }
        public IList<Character> ExSpouses { get; set; }
    }
}
