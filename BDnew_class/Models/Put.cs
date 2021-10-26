using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Put
    {
        public int? WhatAClass { get; set; }
        public int? WhatACrystal { get; set; }

        public virtual Class WhatAClassNavigation { get; set; }
        public virtual Crystal WhatACrystalNavigation { get; set; }
    }
}
