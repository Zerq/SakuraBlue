using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class StrenghtStat : StatAssetBase {
        public StrenghtStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                if (Agent.Gender == Gender.Male) {
                    return Convert.ToInt32((Agent.Earth.Max + Agent.Fire.Max) / 2) +3;
                } else {
                    return Convert.ToInt32((Agent.Earth.Max + Agent.Fire.Max) / 2);
                }
            }
        }
    }
}
