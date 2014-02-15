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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.AbstractPatterns
{

    public interface IVisitor<TtoVisit> 
    {
        void Visit(TtoVisit visitable);
    }

    public interface IVisitable
    {
        void Accept(IVisitor<IVisitable> visitor);
    }

    public abstract class VisitorAction 
    {
    }

    public class Visitor<TtoVisit> : IVisitor<TtoVisit>
    {
        private Dictionary<Type, VisitorAction> actions = new Dictionary<Type, VisitorAction>();
        private Dictionary<Type, MethodInfo> methods = new Dictionary<Type, MethodInfo>();

        public Visitor<TtoVisit> AddAction<Taction>(Type type, Taction action) where Taction : VisitorAction
        {
            if (!actions.ContainsKey(type))
            {
                actions.Add(type, action);
                methods.Add(type, action.GetType().GetMethod("Visit"));
            }
            return this;
        }

        public void Visit(TtoVisit visitable)
        {
            methods[visitable.GetType()].Invoke(actions[visitable.GetType()], new object[] { visitable });
        }
    }


}
