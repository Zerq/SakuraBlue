using SakuraBlue.Entities.Items;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;

namespace SakuraBlue.Entities.Agent.Class {

    public abstract class AgentClassBase {
        public abstract string Name { get; }
        public  abstract ConsoleColor Color { get;  }



        public AgentClassBase(LockToken token) { }

        protected Dictionary<Type, float> rates;
        protected Dictionary<Type, int> statBonuse;

        public virtual float BonusRegen(Type type) {
            return rates.ContainsKey(type) ? rates[type] : 0;
        }
        public virtual int StatBonusBonus(Type type) {
            return statBonuse.ContainsKey(type) ? statBonuse[type] : 0;
        }
        public virtual int StatBonusBonus<T>() {
            return StatBonusBonus(typeof(T));
        }
        public virtual float BonusRegen<T>() {
            return BonusRegen(typeof(T));
        }


        /// <summary>
        /// standard gear should be auto worn when added to the inventory on character creation
        /// </summary>
        public abstract List<ItemBase> StartingGear{get;}

    }
}