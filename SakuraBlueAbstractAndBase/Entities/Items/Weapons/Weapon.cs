using SakuraBlue.Entities.Agent;
using System;

namespace SakuraBlue.Entities.Items.Weapons {
    public abstract class Weapon<T> : Gear where T : AgentBase
    {
        public abstract double Damage(T me, T target);
        public abstract WeaponTargetType TargetType { get; }
    }
}