namespace SakuraBlue.Entities.Agent.Stats {
    public class DexterityStat : StatAssetBase {
        public DexterityStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
