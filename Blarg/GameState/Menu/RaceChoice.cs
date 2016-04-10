using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Agent.Class;

namespace SakuraBlue.GameState.Menu {

    //character creation Race selector state
    [Singleton]
    public class RaceChoice : GameMenuBaseState {
        public RaceChoice(LockToken token) : base(token) {

        }




        Type[] types = typeof(Entities.Agent.Race.Human).Assembly.GetTypes().Where(n => typeof(Entities.Agent.Race.RaceBase).IsAssignableFrom(n) && n != typeof(Entities.Agent.Race.RaceBase)).ToArray();

        List<string> options => types.Select(n => n.Name).ToList();
        public override List<string> GetOptions() {
            return options;
    }

        public override void Action() {


            Exit();
            Program.currentState = Singleton<NewGame>.GetInstance();
            Console.Clear();
            ((NewGame)Program.currentState).Race = (Entities.Agent.Race.RaceBase) Singleton.GetInstance(types[Selected]) ;
            Program.currentState.RedrawNext();
       






        }

        public override void Exit()
        {
            bigTextRendered = false;
            base.Exit();
        }

        bool bigTextRendered = false;
        protected override void Render() {
            if (!bigTextRendered)
            {
                ConsoleHelper.AltClear();
                ConsoleHelper.WTF_WriteLine(Program.GameTitle);
                bigTextRendered = true;
            }
            else {
                Console.CursorTop = 18;
            }
            ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
            ConsoleHelper.WriteLine("CharacterCreation Options", ConsoleColor.Cyan);


            base.Render();
      
        }

   




    }





}
