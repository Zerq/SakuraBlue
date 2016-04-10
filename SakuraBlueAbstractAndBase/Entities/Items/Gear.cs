using SakuraBlue.Entities.Agent;
using System;

namespace SakuraBlue.Entities.Items {
    public class Gear : ItemBase
    {     


        public int BoostValue { get; set; }
        public Type BoostType { get; set; }
      
    }
}