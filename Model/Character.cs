using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class Character : ModelBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Build { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public IList<string> Goals { get; set; }
        public string FacialFeatures { get; set; }
        public string General { get; set; }
        public Character Mother { get; set; }
        public Character Father { get; set; }
        public IList<Character> Children { get; set; }
        public IList<Character> Friends { get; set; }
        public IList<Character> Enemies { get; set; }
        public IList<Character> Associates { get; set; }
        public Character Spouse { get; set; }
        public IList<Character> ExSpouses { get; set; }
    }
}
