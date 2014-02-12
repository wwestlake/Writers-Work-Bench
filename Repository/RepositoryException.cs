using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LagDaemon.WWB.Repository
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string format, params object[] args) : base(string.Format(format, args)) { }
        public RepositoryException(Exception ex, string format, params object[] args) : base(string.Format(format, args), ex) { }
    }
}
