using SakuraBlue.Entities.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Engine.Entities {
    public sealed class PlayerInstanceManager {

        public interface IWorld {
            AgentBase GetPlayer();
            AgentBase[,] GetAgentMap();
            T AddAgent<T>(params object[] parameters) where T : AgentBase;
        }
  
        public static void SetPlayer(AgentBase player)  {
            //once set you may never use another player type
            if (PlayerType == null) {
                PlayerInstanceManager.player = player;
                PlayerInstanceManager.PlayerType = player.GetType();
            }
        }
        static AgentBase player;
        public static Type PlayerType { get; private set; }


        //return Player if the correct world is provided
        public static AgentBase GetPlayer(IWorld world) {
          return  world.GetPlayer();

            //if (player != null) {
            //    if (player.Grid == world) {
            //        return player;
            //    } else {
            //        return null;
            //    }
            //} else {
            //    return null;
            //}
        }
    }
}
