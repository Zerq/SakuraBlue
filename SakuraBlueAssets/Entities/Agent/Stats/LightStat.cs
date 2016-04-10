namespace SakuraBlue.Entities.Agent.Stats {
    public class LightStat : StatAssetBase {
        public LightStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
