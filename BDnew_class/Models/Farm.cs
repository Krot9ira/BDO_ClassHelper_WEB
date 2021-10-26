using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Farm
    {
        public int? WhatAClass { get; set; }
        public int? WhatASpot { get; set; }

        public virtual Class WhatAClassNavigation { get; set; }
        public virtual Spot WhatASpotNavigation { get; set; }
       
    }
}
