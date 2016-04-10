namespace SakuraBlue.Entities.Agent.Stats {
    public class DarkStat : StatAssetBase {
        public DarkStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
