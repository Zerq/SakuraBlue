using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Agent.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlueAbstractAndBase.Entities.Agent.Abilities {
    /// <summary>
    ///  abstract base for all abilaties
    /// </summary>
    /// <typeparam name="T">AgentBase implementation for the given game with what ever stat system it specifically uses.. the generic argument is here to avoid circular dependencies</typeparam>
    public abstract class AbilityBase<T> where T : AgentBase {
       
        /// <summary>
        /// the abilityeffect i.e the removal of hp on enemy and effects if this is a attack.. that sort of thing..
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Target"></param>
        /// <returns>boolian representing success.. a enemy might evade an attack</returns>
        public abstract bool DoEffect(T Attacker, T Target);
        
        //evaluation before calling DoEffect
        public abstract bool Evaluate(T Attacker, T Target);

        public abstract string Name { get; }
        public abstract string Description { get; }
       
        //cost in various consumable stats
        public abstract Dictionary<StatBase, int> Cost { get; }

          /// <summary>
          /// Must be manually triggered in UI
          /// not being active could mean it's pasive or that its a parent node like magic under which other abilaties may be ordered
          /// </summary>
         public abstract bool IsActiv{ get; }
        
        /// <summary>
        /// if not null this will override other abilaties once i implemenbt that logic...
        /// this is for stuff like say items that might replace Attack with Dual Attack of Quad Attack and stuff like that or change magic casts to Dual Magic casts
        /// </summary>
        public abstract  AbilityBase<T> OverRideAbility { get; }

        //for ordering menus
        public abstract AbilityBase<T> Parent { get; }
        public abstract AbilityBase<T> Children { get; }
    }
}
