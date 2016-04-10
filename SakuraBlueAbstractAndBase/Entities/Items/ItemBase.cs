using SakuraBlue.Entities.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Items {
    public class ItemBase {
        private bool equiped = false;

        private bool TestAllocation(AgentBase me, AllocationSlot slot) {
            if (me.Inventory.Count(n => n.equiped == true && n.Slot == slot) > 0) {
                equiped = false;
                return equiped;
            } else {
                equiped = true;
                return equiped;
            }
        }

        /// <summary>
        /// verify if you allowed to equip this item
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public virtual bool Equip(AgentBase me) {
            if (this.Slot == AllocationSlot.None) {
                equiped = false;
                return equiped;
            } else
                  if (this.Slot == AllocationSlot.Inventory) {
                return true; // counts as equiped by simply picking it up :p
            } else {
                return TestAllocation(me, this.Slot);
            }
        }


        public bool IsEquiped {
            get {
                if (Slot == AllocationSlot.Inventory) {
                    return true;
                } else {
                    return equiped;
                }
            }
        }

        public string Name { get; set; }
        public virtual ItemType Type { get; } = ItemType.Junk;
        public virtual Func<bool> Ability { get; }
        public virtual AllocationSlot Slot { get; }

    }
}
