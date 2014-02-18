using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.AbstractPatterns
{
    public class BuilderBase<T, P> where T: BuilderBase<T, P> where P : class, new()
    {
        protected P obj = null;

        protected BuilderBase()
        {
        }

        public T New()
        {
            obj = new P();
            return (T)this;
        }

        public P Build()
        {
            P result = obj;
            obj = null;
            return result;
        }
    }




}
