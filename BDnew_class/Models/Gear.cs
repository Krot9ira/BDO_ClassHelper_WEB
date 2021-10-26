using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Gear
    {
        public int IdGear { get; set; }
        public string GearClass { get; set; }
        public string GearDescription { get; set; }
        public byte[] GearGif { get; set; }
    }
}
