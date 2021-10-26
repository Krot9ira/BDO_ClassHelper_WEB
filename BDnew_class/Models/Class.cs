using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Class
    {
        public Class()
        {
            Spell = new HashSet<Spell>();
            SpellClass = new HashSet<SpellClass>();
        }

        public int IdClass { get; set; }
        public string NameClass { get; set; }
        public string ClassDescription { get; set; }
        public string ClassVid { get; set; }

        public virtual ICollection<Spell> Spell { get; set; }
        public virtual ICollection<SpellClass> SpellClass { get; set; }

       
    }
}
