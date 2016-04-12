using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using SakuraBlue.Entities.Agent.Stats;
using SakuraBlueAbstractAndBase.Entities.Agent.Abilities;
using Omnicatz.AccessDenied;
using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Items.Weapons;

namespace SakuraBlueAssets.Entities.Agent.Abilities {
    public class Attack: AbilityBase<NPCBase>  {

      Dictionary<StatBase<NPCBase>, int> cost = new Dictionary<StatBase<NPCBase>, int>() { { Singleton<StaminaStat>.GetInstance(), 3 } };
      public override Dictionary<StatBase<NPCBase>,int> Cost {
            get {
                return cost;
            }
        }

        string description ="It's Clobering Time!";
        public override string Description {
            get {
                return description;
            }
        }

        string name = "attack";
        public override string Name {
            get {
               return name;
            }
        }

        public override bool IsActiv {
            get {
                return true;
            }
        }

        public override AbilityBase<NPCBase> OverRideAbility {
            get {
                return null;
            }
        }

        //alway root
        public override AbilityBase<NPCBase> Parent {
            get {
                return null;
            }
        }

        //may have some kind of limit breaker child ability later... not for now
        public override AbilityBase<NPCBase> Children {
            get {
                return null;
            }
        }

        public override bool DoEffect(NPCBase attacker, NPCBase target) {
            Weapon<NPCBase> weapon = attacker.Inventory.FirstOrDefault(n => typeof(Weapon<NPCBase>).IsAssignableFrom(n.GetType()) && n.IsEquiped) as Weapon<NPCBase>;
            if (weapon == null) {
                var damage = attacker.Strenght;
            } else {
                var damage = weapon.Damage(attacker, target);
            }
            return true;
        }

        public override bool Evaluate(NPCBase attacker, NPCBase target) {
            bool result = true;
            foreach (var item in cost) {
                var property = attacker.GetType().GetProperties().First(n => n.PropertyType == item.Key.GetType());
                if ((int)property.GetValue(attacker) < item.Value) { // not enught mp etc...
                    result = false;
                }
            }
            return result;
        }
    }
}
