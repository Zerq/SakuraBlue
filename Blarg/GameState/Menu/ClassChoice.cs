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

    /// <summary>
    /// chracterCreation class selection state
    /// </summary>
    [Singleton]
    public class ClassChoice : GameMenuBaseState {
        public ClassChoice(LockToken token) : base(token) {

        }




        Type[] types = typeof(WarriorClass).Assembly.GetTypes().Where(n => typeof(AgentClassBase).IsAssignableFrom(n) && n != typeof(AgentClassBase)).ToArray();

        AgentClassBase[] getclasses() {
            return types.Select(n => Singleton.GetInstance(n)).Cast<AgentClassBase>().ToArray();
        }  

        List<string> options => getclasses().Select(n=> n.Name).ToList();
        public override List<string> GetOptions() {
            return options;
    }

        public override void Action() {


            Exit();
            Program.currentState = Singleton<NewGame>.GetInstance();
            ((NewGame)Program.currentState).Class = getclasses()[Selected];
            Console.Clear();
            Program.currentState.RedrawNext();

        

        



        }
        public override void Exit()
        {
            bigTextRendered = false;
            base.Exit();
        }
        bool bigTextRendered = false;
        protected override void Render()
        {
            if (!bigTextRendered)
            {
                ConsoleHelper.AltClear();
                ConsoleHelper.WTF_WriteLine(Program.GameTitle);
                bigTextRendered = true;
            }
            else
            {
                Console.CursorTop = 18;
            }
            ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
            ConsoleHelper.WriteLine("CharacterCreation Options", ConsoleColor.Cyan);


            base.Render();
      
        }

   




    }





}
