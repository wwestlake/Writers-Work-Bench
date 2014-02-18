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
    public abstract class TreeBase<T> : ModelBase where T: TreeBase<T>
    {
        protected IList<T> elements;
        protected T parent;

        public TreeBase() : base()
        {
            elements = new List<T>();
        }

        public void AddChild(T element)
        {
            elements.Add(element);
            if (element.parent != null) element.Parent.Remove(element);
            element.parent = this as T;
        }

        public int ChildCount { get { return elements.Count(); } }

        public T Parent { get { return parent; } }

        public IEnumerable<T> Children 
        {
            get
            {
                List<T> copy = elements.ToList<T>();
                foreach (T element in copy) yield return element;
            }
        }

        public IEnumerable<T> OrderedByName
        {
            get
            {
                return OrderedChildren(x => x.Name);
            }
        }

        public IEnumerable<T> OrderedChildren(Func<T, bool> pred)
        {
            List<T> copy = elements
                .OrderBy(n =>  pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, string> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, int> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, float> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, double> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, char> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, byte> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }

        public IEnumerable<T> OrderedChildren(Func<T, DateTime> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }


        public IEnumerable<T> OrderedChildren(Func<T, TimeSpan> pred)
        {
            List<T> copy = elements
                .OrderBy(n => pred(n))
                .ToList<T>();
            foreach (T element in copy) yield return element;
        }


        public void Remove(T element)
        {
            elements.Remove(element);
        }

        public void Clear()
        {
            elements.Clear();
        }
    }
}
