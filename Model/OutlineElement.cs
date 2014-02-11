using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class OutlineElement : TreeBase<OutlineElement>
    {
        public OutlineElement() : base() { }
        public int Order { get; set; }
        public string EntryNumber
        {
            get
            {
                if (parent != null) return string.Format("{0}.{1}", parent.EntryNumber, Order);
                return Order.ToString();
            }
        }

        public IEnumerable<OutlineElement> ChildrenByOrder
        {
            get
            {
                return OrderedChildren( x => x.Order  );
            }
        }

    }
}
