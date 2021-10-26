using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Spell
    {
        public Spell()
        {
            SpellClass = new HashSet<SpellClass>();
        }

        public int IdSpell { get; set; }
        public string NameSpell { get; set; }
        public string SpellDescription { get; set; }
        public string SpellVid { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<SpellClass> SpellClass { get; set; }
    }
}
