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
using System.Reflection;

namespace LagDaemon.WWB.AbstractPatterns
{
    /// <summary>
    /// Represents a factory
    /// </summary>
    public interface IFactory
    {
        object Create(Type type, params object[] args);
    }

    /// <summary>
    /// Represents a generic abstract factory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAbstractFactory<T> : IFactory
    {
        IFactory Configure(params object[] args);
        T Create(params object[] args);
    }

    /// <summary>
    /// An abstract factory that produces objects of type T
    /// or any subclass of T
    /// </summary>
    /// <typeparam name="T">The type of object to produce</typeparam>
    public class AbstractFactory<T> : IAbstractFactory<T>
    {

        protected List<object> config = new List<object>();
        protected Type type;

        /// <summary>
        /// Constructs an abstract factory
        /// </summary>
        public AbstractFactory() { }

        /// <summary>
        /// Constructs an abstract factory on a specific type
        /// </summary>
        /// <param name="type"></param>
        public AbstractFactory(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Configure the abstract factory for producing
        /// objects with a set of parameters
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IFactory Configure(params object[] args)
        {
            foreach (object obj in args) config.Add(obj);
            return this;
        }

        /// <summary>
        /// Create an object of the specified type with the 
        /// arguments specified.  If other arguments are configured
        /// they will be used in conjunction with the supplied arguments.
        /// </summary>
        /// <param name="type">The type of object to create</param>
        /// <param name="args">The constructor arguments to use</param>
        /// <returns>An object of the specified type</returns>
        public object Create(Type type, params object[] args)
        {
            List<object> fullArgs = new List<object>(config);
            fullArgs.AddRange(args);
            ConstructorInfo constructor = Constructor(fullArgs.ToArray());
            object result = constructor.Invoke(fullArgs.ToArray());
            return result;
        }

        /// <summary>
        /// Creates an object of type T
        /// </summary>
        /// <param name="args">The constructor arguments to use</param>
        /// <returns>An object of type T</returns>
        public T Create(params object[] args)
        {
            return (T)Create(typeof(T), args);
        }

        /// <summary>
        /// Obtains a constructor for the specied type and arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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
