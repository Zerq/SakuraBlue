using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;

namespace SakuraBlue.Entities.Items.Weapons {
    public class BroadSword: Weapon<NPCBase> {
        public BroadSword() {
            this.Name = "BroadSword";
        }


        public override ItemType Type {
            get {
                return ItemType.Weapon;
            }
        }
        public override AllocationSlot Slot {
            get {
                return AllocationSlot.PrimaryHand;
            }
        }

        public override double Damage(NPCBase me, NPCBase target) {
            return me.Strenght.Current + 8;
        }

        public override WeaponTargetType TargetType {
            get {
                return WeaponTargetType.SingleFirstRow;
            }
        }
    }
}
