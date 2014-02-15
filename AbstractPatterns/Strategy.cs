/*
    $projectname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
     
    source code: https://github.com/wwestlake/Writers-Work-Bench.git 
 
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

using System;
using System.Collections.Generic;

namespace LagDaemon.WWB.AbstractPatterns
{

    public interface IStrategy<T>
    {
        T Execute(params object[] args);
    }

    public class Context<T> 
    {
        private IStrategy<T> strategy;

        public Context(IStrategy<T> strategy)
        {
            this.strategy = strategy;
        }

        public virtual T Execute(params object[] args)
        {
            return strategy.Execute(args);
        }
    }

}
