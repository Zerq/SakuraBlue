using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Items;
using SakuraBlue.Entities.Items.Weapons;

namespace SakuraBlue.Entities.Agent.Class {

    public class WarriorClass : AgentClassBase {
        public WarriorClass(LockToken token): base(token) {
        rates = new Dictionary<Type, float>() {
            { typeof(Stats.HealthPointsStat), 3f },
            { typeof(Stats.StaminaStat), 4f },
            { typeof(Stats.AwarnessStat), 5f },
        };
         statBonuse = new Dictionary<Type, int>() {
            { typeof(Stats.HealthPointsStat), 15 },
            { typeof(Stats.StaminaStat), 10 },
            { typeof(Stats.AwarnessStat), 5 },
        };
    }


    public override string Name {
            get {
                return "Warrior";
            }
        }

        public override ConsoleColor Color {
            get {
                return ConsoleColor.DarkCyan;
            }
        }

        public override List<ItemBase> StartingGear {
            get {
                return new List<ItemBase>() { new ShortSword() };
            }
        }
    }
}
