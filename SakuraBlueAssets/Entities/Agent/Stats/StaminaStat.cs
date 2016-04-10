namespace SakuraBlue.Entities.Agent.Stats {
    public class StaminaStat : StatAssetBase {
        public StaminaStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
