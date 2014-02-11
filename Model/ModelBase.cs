using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public abstract class ModelBase
    {
        public ModelBase()
        {
            Ident = Guid.NewGuid();
        }

        public Guid Ident { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}
