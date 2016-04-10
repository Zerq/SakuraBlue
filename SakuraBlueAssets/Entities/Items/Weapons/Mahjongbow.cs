using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Agent.Stats;

namespace SakuraBlue.Entities.Items.Weapons {
    public class Mahjongbow : Weapon<NPCBase> {
 

        public Mahjongbow() {
            this.BoostType = typeof(DexterityStat);
            this.BoostValue = 1;
            this.Name = "Mahjongbow";
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

        public override double Damage(NPCBase me, NPCBase target) {
            return (me.Strenght.Current + (me.Stamina.Current/4));
        }

    

        public override WeaponTargetType TargetType {
            get {
                return WeaponTargetType.SingleAny;
            }
        }


    }
}