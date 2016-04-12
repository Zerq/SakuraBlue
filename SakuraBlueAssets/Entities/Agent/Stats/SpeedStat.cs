using System;

namespace SakuraBlue.Entities.Agent.Stats {
    public class speedStat : StatAssetBase {
        public speedStat(NPCBase owner) : base(owner) { }
    

        public override int DerivedBase {
            get {
                //base is derived based on related stats
                var optimal = Convert.ToInt32(Agent.Strenght.Current + Agent.Agility.Current);
                var fatigue = Convert.ToInt32(Agent.Stamina.Current) / Agent.Stamina.Max;

                if (fatigue > .5) {
                    return optimal; //  feeling fine
                }

                if (fatigue > .3) {
                    return optimal / 2;
                }

                return 0;
            }
        }
     
    }
}
