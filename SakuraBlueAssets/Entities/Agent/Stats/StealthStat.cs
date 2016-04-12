using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class StealthStat : StatAssetBase {
        public StealthStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Convert.ToInt32((Agent.Darkness.Max + Agent.Darkness.Current + Agent.Agility.Max) / 3);
            }
        }
    }
}
