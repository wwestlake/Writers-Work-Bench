﻿/*
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

    public abstract class ChainOfResponsibility<T>
    {
        private ISpecification<T> specification = null;
        private ChainOfResponsibility<T> next = null;

        public ChainOfResponsibility(ISpecification<T> specification, ChainOfResponsibility<T> next) 
        {
            this.specification = specification;
            this.next = next;
        }

        public void Action(T dataItem)
        {
            if (null == specification) PerformAction(dataItem);
            else if (specification.IsSatisfiedBy(dataItem))
            {
                PerformAction(dataItem);
            }
            if (null != next)
            {
                next.Action(dataItem);
            }
        }

        protected abstract void PerformAction(T dataItem);
            
    }
}
