using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;

namespace SakuraBlue.Entities.Items.Weapons {
    public class ShortSword : Weapon<NPCBase> {

        public ShortSword() {
            this.Name = "ShortSword";
        }

        public override ItemType Type {
            get {
                return ItemType.Weapon;
            }
        }
        public override AllocationSlot Slot {
            get {
                return AllocationSlot.EitherHand;
            }
        }

        public override double Damage(NPCBase me, NPCBase target) {
            return me.Strenght.Current + 5;
        }
        public override WeaponTargetType TargetType {
            get {
                return WeaponTargetType.SingleFirstRow;
            }
        }

    }
}
