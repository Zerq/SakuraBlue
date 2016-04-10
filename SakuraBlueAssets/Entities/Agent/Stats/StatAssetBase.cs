namespace SakuraBlue.Entities.Agent.Stats {
   public abstract class StatAssetBase : SakuraBlue.Entities.Agent.Stats.StatBase {
        public StatAssetBase(NPCBase npc) : base(npc) { }
        protected override double RegenBonus() {
          return   ((NPCBase)Agent).Class.BonusRegen(this.GetType());
        }
    }
}
