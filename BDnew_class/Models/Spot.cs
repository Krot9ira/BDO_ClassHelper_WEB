using System;
using System.Collections.Generic;

namespace BDnew_class.Models
{
    public partial class Spot
    {
        
        public int IdSpot { get; set; }
        public string NameSpot { get; set; }
        public string SpotDescription { get; set; }
        public byte[] SpotGif { get; set; }
        public int? Ap { get; set; }
        public int? Dp { get; set; }

       
    }
}
