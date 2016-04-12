namespace SakuraBlue.Entities.Agent.Stats {
    public class DexterityStat : StatAssetBase {
        public DexterityStat(NPCBase owner) : base(owner) { }
        public override int DerivedBase {
            get {
                return Agent.Water.Max;
            }
        }
    }
}
