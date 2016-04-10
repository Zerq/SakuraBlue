namespace SakuraBlue.Entities.Agent.Stats {
    public class WindStat : StatAssetBase {
        public WindStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
