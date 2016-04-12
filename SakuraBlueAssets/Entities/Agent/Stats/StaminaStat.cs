using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class StaminaStat : StatAssetBase {
        public StaminaStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Convert.ToInt32((Agent.Strenght.Max + Agent.Constitution.Max) / 2);
            }
        }
    }
}
