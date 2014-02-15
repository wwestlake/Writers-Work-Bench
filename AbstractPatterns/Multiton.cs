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
    public class Multiton : IMultiton
    {
        protected Dictionary<Type, IAbstractFactory<object> > factories = new Dictionary<Type, IAbstractFactory<object>>();
        protected Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public Multiton() { }

        public void Add(Type type)
        {
            if (factories.ContainsKey(type)) throw new MultitonException("Key {0} already exists", type);
            factories.Add(type, new AbstractFactory<object>(type));
        }

        public void Configure<T>(params object[] args)
        {
            if (factories.ContainsKey(typeof(T)))
            {
                factories[typeof(T)] = new AbstractFactory<object>(typeof(T));
            }
            else
            {
                factories.Add(typeof(T), new AbstractFactory<object>(typeof(T)));
            }
            factories[typeof(T)].Configure(args);
        }

        public T Instance<T>()
        {
            if (!instances.ContainsKey(typeof(T)))
            {
                instances.Add(typeof(T), factories[typeof(T)].Create());
            }
            return (T)instances[typeof(T)];
        }

    }
}
