namespace SakuraBlue.Entities.Agent.Stats {
    public class HealthPointsStat : StatAssetBase {
        public HealthPointsStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
