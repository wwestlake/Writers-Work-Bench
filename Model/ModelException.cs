using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    public class ModelException : ApplicationException
    {
        public ModelException(string message) : base(message) { }
        public ModelException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}
