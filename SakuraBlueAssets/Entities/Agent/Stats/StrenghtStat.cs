namespace SakuraBlue.Entities.Agent.Stats {
    public class StrenghtStat : StatAssetBase {
        public StrenghtStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
