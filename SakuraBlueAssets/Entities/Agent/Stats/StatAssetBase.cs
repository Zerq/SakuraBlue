using System;

namespace SakuraBlue.Entities.Agent.Stats {

 
   public abstract class StatAssetBase : SakuraBlue.Entities.Agent.Stats.StatBase<NPCBase> {
        public StatAssetBase(NPCBase npc) : base(npc) { }

        public virtual int DerivedBase { get { return 0; } }
   
        public override int Max {
            get {
                var classBonus = 0;

                if (Agent.Class != null) {
                    classBonus = Agent.Class.StatBonusBonus(this.GetType());
                }

                var raceBonus = 0;

                if (Agent.Race != null) {
                    raceBonus = Agent.Race.StatBonusBonus(this.GetType());
                }
                return base.Max + DerivedBase + classBonus + raceBonus;
            }
        }
        public override double RegenerateRate {
            get;

            set;
        }

        protected override double RegenBonus() {
          return   ((NPCBase)Agent).Class.BonusRegen(this.GetType());
        }
    }
}
