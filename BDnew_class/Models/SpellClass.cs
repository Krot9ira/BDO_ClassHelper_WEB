using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class SpellClass
    {
        public int ClassId { get; set; }
        public int SpellId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Spell Spell { get; set; }
    }
}
