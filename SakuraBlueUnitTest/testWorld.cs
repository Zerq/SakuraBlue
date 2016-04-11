using Omnicatz.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;

namespace SakuraBlueUnitTest {
    internal class testWorld : PlayerInstanceManager.IWorld {
         public List<AgentBase> agents = new List<AgentBase>();

        /// <summary>
        /// simplified testing world
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T AddAgent<T>(params object[] parameters) where T : AgentBase {
           T newInstance = Activator.CreateInstance(typeof(T), parameters) as T;
            agents.Add(newInstance);
            return newInstance;
        }

        public AgentBase[,] GetAgentMap() {
            throw new NotImplementedException();
        }

        public AgentBase GetPlayer() {
            return this.agents.FirstOrDefault(n => n.GetType() == Omnicatz.Engine.Entities.PlayerInstanceManager.PlayerType);
        }
    }
}
