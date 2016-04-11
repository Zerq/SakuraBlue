using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;

namespace SakuraBlue.Entities.Agent.Race {
    public class Narugan : RaceBase {
        public Narugan(LockToken token) : base(token) {
            rates = new Dictionary<Type, float>() {
            { typeof(Stats.DarkStat),  1f },
            { typeof(Stats.LightStat), 1f },
            { typeof(Stats.ChaosStat), 1f },
            { typeof(Stats.Orderstat), 1f },
            { typeof(Stats.FireStat),  1.1f },
            { typeof(Stats.WaterStat), 1f },
            { typeof(Stats.EarthStat), 1.3f },
            { typeof(Stats.WindStat),  1f },
            };

            statBonuse = new Dictionary<Type, int>() {
            { typeof(Stats.DarkStat), 1},
            { typeof(Stats.LightStat),0},
            { typeof(Stats.ChaosStat),0},
            { typeof(Stats.Orderstat),0},
            { typeof(Stats.FireStat), 1},
            { typeof(Stats.WaterStat),0},
            { typeof(Stats.EarthStat),3},
            { typeof(Stats.WindStat), 0},
        };
        }
            

        public override char Character {
            get {
                return 'N';
            }
        }

        public override ConsoleColor Color {
            get {
                return ConsoleColor.DarkYellow;
            }
        }

        public override string Name {
            get {
                return "Narugan";
            }
        }
    }
}
