namespace SakuraBlue.Entities.Agent.Stats {
    public class ChaosStat : StatAssetBase {
        public ChaosStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
