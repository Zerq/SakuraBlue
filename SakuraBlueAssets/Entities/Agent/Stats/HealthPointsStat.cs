using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class HealthPointsStat : StatAssetBase {
        public HealthPointsStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Convert.ToInt32((Agent.Constitution.Max + Agent.Constitution.Current) * 2 + Agent.Earth.Max);
            }
        }
    }
}
