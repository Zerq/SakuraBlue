using Omnicatz.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;
using SakuraBlueAbstractAndBase.Entities.Map;

namespace SakuraBlueUnitTest {
    internal class testWorld : IWorld {
         public List<AgentBase> Agents = new List<AgentBase>();

 

        public AgentBase GetPlayer() {
            return this.Agents.FirstOrDefault(n => n.GetType() == Omnicatz.Engine.Entities.PlayerInstanceManager.PlayerType);
        }





        public T AddAgent<T>(params object[] parameters) where T : AgentBase {
            List<object> parameterList = new List<object>();
            parameterList.Add(this);
            parameterList.AddRange(parameters);

            var agent = Activator.CreateInstance(typeof(T), parameterList.ToArray()) as T;
            this.Agents.Add(agent);
            return agent;
        }
        public void Addplayer(AgentBase player) {

            if (player.GetType() == Omnicatz.Engine.Entities.PlayerInstanceManager.PlayerType) {
                if (Agents.Count(n => n.GetType() == player.GetType()) == 0) {
                    Agents.Add(player);
                } else {
                    throw new ApplicationException("Agent List allready has a player!"); // might handle this diffently later...
                }
            } else {
                throw new ApplicationException($"{player.GetType()} is not set as playerType for this game");
            }
        }





    }
}
