using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;

namespace SakuraBlue.Entities.Agent.Race {
    public abstract class RaceBase {
        public RaceBase(LockToken token) { }
        public abstract Char Character { get;  }
        public abstract ConsoleColor Color { get;}
        public abstract string Name { get; }



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
    }
}