namespace SakuraBlue.Entities.Agent.Stats {
    public class AgilityStat : StatAssetBase {
        public AgilityStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Agent.Wind.Max;
            }
        }
    }
}
