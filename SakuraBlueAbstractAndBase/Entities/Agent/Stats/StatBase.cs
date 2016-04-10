using SakuraBlue.Entities.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Agent.Stats {
    public abstract class StatBase {
        public StatBase(AgentBase agent) {
            Agent = agent;
            agent.OnRegenerate += Agent_OnRegenerate;
        }


        protected abstract double RegenBonus();
        protected void Agent_OnRegenerate(object sender, EventArgs e) {


            if (Agent.GetType() == typeof(AgentBase)) {
                Current += (RegenerateRate + RegenBonus());// 
            } else {
                Current += RegenerateRate;
            }


            if (Current > Max) {
                Current = Max;
            }
        }
        public abstract double RegenerateRate { get; set; }
        public double Current { get; set; }
        public int MaxBase { get; set; }
        public virtual int Max {
            get {
                var result = MaxBase;
                foreach (Entities.Items.Gear gear in this.Agent.Inventory) {
                    if (gear.BoostType == this.GetType()) {
                        result += gear.BoostValue;
                    }
                }
                // MaxBase + this.Agent.Inventory.Where(n => n.BoostType == this.GetType()).Select(n => n.BoostValue).Sum();  
                return result;
            }
        }
        public AgentBase Agent { get; private set; }
    }
}