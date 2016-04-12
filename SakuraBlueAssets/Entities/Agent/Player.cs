using SakuraBlue.Entities.Agent.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Map;
using SakuraBlueAbstractAndBase.Entities.Map;

namespace SakuraBlue.Entities.Agent {


    public class Player : NPCBase {


        public Player(IWorld grid, Gender gender, RaceBase race, Class.AgentClassBase @class, string name, int x, int y) : base(grid, gender, race, @class, name, x, y) {
          this.AI = null;
        }



        public override string AgentMove(ParentGrid grid, Direction direction) {
            var result =  base.AgentMove(grid, direction);
            foreach (Agent.NPCBase npc in ((ParentGrid)this.World).Agents) {
                if (npc.GetType() != typeof(Player)) {
                    if (npc.AI != null) {
                        npc.AI.Detect();
                        npc.AI.TurnStep();
                    }
                }
            }

            return result;
        }
    }
}