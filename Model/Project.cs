using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class Project : ModelBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }
        public string Synopsis { get; set; }
    }


}
