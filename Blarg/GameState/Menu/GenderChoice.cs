using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using SakuraBlue.Entities.Agent;

namespace SakuraBlue.GameState.Menu {

    //Character creation gender selection state
    [Singleton]
    public class GenderChoice : GameMenuBaseState {
        public GenderChoice(LockToken token) : base(token) {

        }




        List<string> options => Enum.GetNames(typeof(Entities.Agent.Gender)).ToList(); // new List<string> { "Male", "Female"};
        public override List<string> GetOptions() {
            return options;
    }

        public override void Action() {


            Exit();
            Program.currentState = Singleton<NewGame>.GetInstance();
            ((NewGame)Program.currentState).CharacterGender = (Gender) Enum.Parse(typeof(Gender), options[Selected]);
            Console.Clear();
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
