using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class Scene : ModelBase
    {
        [Description("The title of the scene.")]
        public string Title { get; set; }

        [Description("LIst of characters involved in this scene.")]
        public IList<Character> Characters { get; set; }

    }
}
