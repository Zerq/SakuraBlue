using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class  AwarnessStat : StatAssetBase {
        public AwarnessStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Convert.ToInt32( (Agent.Light.Max + Agent.Light.Current + Agent.Wind.Max + Agent.Wind.Current) / 4);
            }
        }
    }
}
