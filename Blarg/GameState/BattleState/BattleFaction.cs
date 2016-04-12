using SakuraBlue.Entities.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.GameState.BattleState {
    public class BattleFaction {
        public BattleFaction(NPCBase leader) {
            Leader = leader;
            this.Enemies = new List<BattleFaction>();
            this.Allies = new List<BattleFaction>();

        }
        public NPCBase Leader { get; private set; }
        public List<BattleFaction> Enemies { get; set; }
        public List<BattleFaction> Allies { get; set; }
        public bool IsPlayer {
            get {
                return Leader.GetType() == typeof(Player);
            }
        }
    }
}
