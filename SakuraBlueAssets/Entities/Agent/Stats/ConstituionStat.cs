 namespace SakuraBlue.Entities.Agent.Stats {
    public class ConstitutuinStat : StatAssetBase {
        public ConstitutuinStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
