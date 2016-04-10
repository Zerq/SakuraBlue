namespace SakuraBlue.Entities.Agent.Stats {
    public class  AwarnessStat : StatAssetBase {
        public AwarnessStat(NPCBase owner) : base(owner) { }
        public override double RegenerateRate {
            get;
            set;
        }
    }
}
