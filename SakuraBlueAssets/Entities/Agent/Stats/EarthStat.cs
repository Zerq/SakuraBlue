namespace SakuraBlue.Entities.Agent.Stats {
    public class EarthStat : StatAssetBase {
        public EarthStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
