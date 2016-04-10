namespace SakuraBlue.Entities.Agent.Stats {
    public class Orderstat : StatAssetBase {
        public Orderstat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
