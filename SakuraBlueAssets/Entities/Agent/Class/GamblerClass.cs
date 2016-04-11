using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Items;
using SakuraBlue.Entities.Items.Weapons;

namespace SakuraBlue.Entities.Agent.Class {
    public class GamblerClass : AgentClassBase {
        public GamblerClass(LockToken token): base(token) {
        rates = new Dictionary<Type, float>() {
            { typeof(Stats.HealthPointsStat), 4f },
            { typeof(Stats.StaminaStat), 5f },
            { typeof(Stats.AwarnessStat), 3f },
        };
         statBonuse = new Dictionary<Type, int>() {
            { typeof(Stats.HealthPointsStat), 15 },
            { typeof(Stats.ChaosStat), 7 },
 

            { typeof(Stats.AwarnessStat), 7 },
        };
    }


    public override string Name {
            get {
                return "Gambler";
            }
        }

        public override ConsoleColor Color {
            get {
                return ConsoleColor.DarkGreen;
            }
        }

        public override List<ItemBase> StartingGear {
            get {
                return new List<ItemBase>() { new Mahjongbow() };
            }
        }
    }
}
