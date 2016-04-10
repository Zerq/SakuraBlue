using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Agent.Stats;

namespace SakuraBlue.Entities.Items.Weapons {
    public class LongSword : Weapon<NPCBase> {

        public LongSword() {
            this.BoostType = typeof(DexterityStat);
            this.BoostValue = -2;
            this.Name = "LongSword";
        }
        public override ItemType Type {
            get {
                return ItemType.Weapon;
            }
        }
        public override AllocationSlot Slot {
            get {
                return AllocationSlot.TwoHanded;
            }
        }

        public override WeaponTargetType TargetType {
            get {
                return WeaponTargetType.SingleFirstRow;
            }
        }

        public  override double Damage(NPCBase me, NPCBase target) {
            return me.Strenght.Current + 13;
        }


    }
}