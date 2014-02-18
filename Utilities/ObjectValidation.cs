using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Utilities
{
    public static class ObjectValidation
    {
        public static bool IsNotNull(object obj) { return null != obj; }
        public static bool IsNull(object obj) { return null == obj; }
    }
}
