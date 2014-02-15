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
    public interface IFactory
    {
        object Create(Type type, params object[] args);
    }

    public interface IAbstractFactory<T> : IFactory
    {
        IFactory Configure(params object[] args);
        T Create(params object[] args);
    }

    public class AbstractFactory<T> : IAbstractFactory<T>
    {

        protected List<object> config = new List<object>();
        protected Type type;

        public AbstractFactory() { }

        public AbstractFactory(Type type)
        {
            this.type = type;
        }


        public IFactory Configure(params object[] args)
        {
            foreach (object obj in args) config.Add(obj);
            return this;
        }

        public object Create(Type type, params object[] args)
        {
            List<object> fullArgs = new List<object>(config);
            fullArgs.AddRange(args);
            ConstructorInfo constructor = Constructor(fullArgs.ToArray());
            object result = constructor.Invoke(fullArgs.ToArray());
            return result;
        }

        public T Create(params object[] args)
        {
            return (T)Create(typeof(T), args);
        }

        private ConstructorInfo Constructor(object[] args)
        {
            Type myType;
            if (this.type != null) {
                myType = this.type;
            }
            else
            {
                myType = typeof(T);
            }
            Type[] types = new Type[args.Length];
            int i = 0;
            foreach (object obj in args)
            {
                types[i++] = obj.GetType();
            }
            return myType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);
        }


    }
}
