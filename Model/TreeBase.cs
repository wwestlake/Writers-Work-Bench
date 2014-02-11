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

        internal void AddChild(T element)
        {
            elements.Add(element);
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


        internal void Remove(T element)
        {
            elements.Remove(element);
        }

        internal void Clear()
        {
            elements.Clear();
        }
    }
}
