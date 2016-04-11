using Omnicatz.AccessDenied;
using SakuraBlue.Entities.Agent;
using SakuraBlueAbstractAndBase.Entities.Agent.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.GameState.BattleState {

    public class BattleFaction {
        public BattleFaction(NPCBase leader) {
            Leader = leader;

        }
        public NPCBase Leader { get; private set; }
        public List<NPCBase> Enemies { get; set; }
        public List<NPCBase> Allies { get; set; }
        public bool IsPlayer {
            get {
                return Leader.GetType() == typeof(Player);
            }
        }
    }

    public class Battle {
        /// <summary>
        /// singleton since fuck it there is only one player view..... this gives me easy access to the battle object so i can referece it for events and calculations relating to abilaties 
        /// </summary>
        /// <param name="lock"></param>
        public Battle(LockToken @lock) {
            LockToken.Enforce<Battle>(@lock);
        }
        public void ClearOld() {

        }



        public void NewBattle(BattleField battleField, params BattleFaction[] parties) {
            ClearOld();
            this.battleField = battleField;
            factions.AddRange(parties);
        }

        //a leader or single opponen which may have a group at his command

        private List<BattleFaction> factions = new List<BattleFaction>();

        public BattleField battleField { get; private set; }

        //not set in constructor because it optional and i dont want to put an optional argument in a constructor with params... that get screwy
        public BattleEventScripts Scripts { get; set; }

        //either faction based on stats... 
        public NPCBase Turn { get; private set; }

        public class DoActionEventArgs : EventArgs {
            public NPCBase Source { get; set; }
            public NPCBase Target { get; set; }
            public AbilityBase<NPCBase> Ability { get; set; }
        }

        //ment as a way of hooking up events that might interact with passive abilaties... like if any action takes a npc bellow a certain hp.. that might also trigger script events like boss dialog.
        public delegate bool DoActionHandler(object sender, DoActionEventArgs e);
        public event DoActionHandler OnDoAction;
        //turns?

        //render method

    }
}
