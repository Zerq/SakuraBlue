namespace SakuraBlue.Entities.Agent.Stats {
    public class FireStat : StatAssetBase {
        public FireStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
