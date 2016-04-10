namespace SakuraBlue.Entities.Agent.Stats {
    public class StealthStat : StatAssetBase {
        public StealthStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
