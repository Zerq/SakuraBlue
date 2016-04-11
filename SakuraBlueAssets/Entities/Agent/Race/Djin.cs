using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;

namespace SakuraBlue.Entities.Agent.Race {
    public class Djin : RaceBase {
        public Djin(LockToken token) : base(token){

            rates = new Dictionary<Type, float>() {
            { typeof(Stats.DarkStat),  1.1f },
            { typeof(Stats.LightStat), 1f },
            { typeof(Stats.ChaosStat), 1.1f },
            { typeof(Stats.Orderstat), 1f },
            { typeof(Stats.FireStat),  1.2f },
            { typeof(Stats.WaterStat), 1f },
            { typeof(Stats.EarthStat), 1f },
            { typeof(Stats.WindStat),  1f },
            };

            statBonuse = new Dictionary<Type, int>() {
            { typeof(Stats.DarkStat), 1},
            { typeof(Stats.LightStat),0},
            { typeof(Stats.ChaosStat),1},
            { typeof(Stats.Orderstat),0},
            { typeof(Stats.FireStat), 2},
            { typeof(Stats.WaterStat),0},
            { typeof(Stats.EarthStat),0},
            { typeof(Stats.WindStat), 0},

        };
        }

        public override char Character {
            get {
                return 'D';
            }
        }

        public override ConsoleColor Color {
            get {
                return ConsoleColor.Red;
            }
        }

        public override string Name {
            get {
                return "Djin";
            }
        }


   
    }
}
