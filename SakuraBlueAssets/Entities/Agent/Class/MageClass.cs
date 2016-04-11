using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Items;
using SakuraBlue.Entities.Items.Weapons;

namespace SakuraBlue.Entities.Agent.Class {
    public class MageClass : AgentClassBase {
        public MageClass(LockToken token) : base(token) {
            rates = new Dictionary<Type, float>() {
            { typeof(Stats.HealthPointsStat), 1f },
            { typeof(Stats.StaminaStat), 2f },
            { typeof(Stats.AwarnessStat), 7f },
            };

            statBonuse = new Dictionary<Type, int>() {
            { typeof(Stats.HealthPointsStat), 12 },
            { typeof(Stats.StaminaStat), 12 },
            { typeof(Stats.AwarnessStat), 10 },

        };
        }


        public override string Name {
            get {
                return "Mage";
            }
        }

        public override ConsoleColor Color {
            get {
                return ConsoleColor.DarkMagenta;
            }
        }

        public override List<ItemBase> StartingGear {
            get {
                return new List<ItemBase>() { new Staff() };
            }
        }
    }
}
