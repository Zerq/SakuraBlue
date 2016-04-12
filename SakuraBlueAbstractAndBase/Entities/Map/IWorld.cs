using SakuraBlue.Entities.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlueAbstractAndBase.Entities.Map {

    public interface IReceptiveWorld: IWorld {
        void Recive(AgentBase agent, object parameter=null);
    }
    public interface IWorld {
        AgentBase GetPlayer();
        T AddAgent<T>(params object[] parameters) where T : AgentBase;
        void Addplayer(AgentBase player);
        void Transfer(IReceptiveWorld targetWorld, AgentBase agent, object parameter=null);
    }
}
