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

 

    public class Producer
    {
        private Dictionary<Type, Type> registry = new Dictionary<Type, Type>();
        private Dictionary<Type, IFactory> factories = new Dictionary<Type, IFactory>();

        public Producer() { }

        public Producer RegisterType<Tiface, Tconcrete>()
        {
            if (!registry.ContainsKey(typeof(Tiface))) registry.Add(typeof(Tiface), typeof(Tconcrete));
            return this;
        }

        public Producer RegisterFactory<Tconcrete>(IFactory factory)
        {
            if (!factories.ContainsKey(typeof(Tconcrete))) factories.Add(typeof(Tconcrete), factory);
            return this;
        }

        public Tiface Instance<Tiface>()
        {
            return (Tiface) Instance(typeof(Tiface));
        }

        private object Instance(Type iface)
        {
            List<object> buildParams = new List<object>();
            List<Type> types = new List<Type>();
            Type concrete = registry[iface];
            ConstructorInfo[] constructors = concrete.GetConstructors();
            foreach (ConstructorInfo info in constructors)
            {
                ParameterInfo[] parameters = info.GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.ParameterType.IsInterface || parameter.ParameterType.IsClass)
                    {
                        types.Add(parameter.ParameterType);
                    }
                    else break;
                }
                ConstructorInfo constructor = concrete.GetConstructor(types.ToArray());
                if (null != constructor)
                {
                    foreach (Type type in types)
                    {
                        object instance;
                        if (factories.ContainsKey(type))
                        {
                            instance = factories[type].Create(type);
                        }
                        else
                        {
                            instance = Instance(type);
                        }
                        buildParams.Add(instance);
                    }
                    return constructor.Invoke(buildParams.ToArray());
                }
                buildParams.Clear();
                types.Clear();
            }
            throw new InvalidOperationException(string.Format("The specified object could not be constructed. {0}", iface.ToString()));
        }


    }
}
