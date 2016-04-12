 namespace SakuraBlue.Entities.Agent.Stats {
    public class ConstitutuinStat : StatAssetBase {
        public ConstitutuinStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                if (Agent.Gender == Gender.Female) {
                    return 2 + Agent.Earth.Max;
                } else {
                    return Agent.Earth.Max;
                }
            }
        }
    }
}
