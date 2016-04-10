using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using SakuraBlue.Media;
using SakuraBlue.Entities.Agent;
using Omnicatz.Engine.Entities;

namespace SakuraBlue.GameState.Menu {
    [Singleton]
    public class TopMenu : GameMenuBaseState {
        public TopMenu(LockToken token) : base(token) {

        }


        private List<string> options = new List<string> { "New Game", "Continue","option", "Exit" };
     
        public override List<string> GetOptions() {
            return options;
        }
        protected override void Initiate()
        {
            var music = Singleton<Media.Music>.GetInstance();
            music.SetVolume(7);
            music.Play(@"Music\Stratosphere.mp3");
            base.Initiate();
            RedrawNext();
        }

        public override void Action() {
            switch (Selected) {
                case 0:
                    Exit();
                    Program.currentState = Singleton<NewGame>.GetInstance();
                    Program.currentState.RedrawNext();
                 
                break;

                case 1:
                    Console.Clear();
 

                    if ((PlayerInstanceManager.GetPlayer(Singleton<GameState.Map>.GetInstance().map) as Player).Name!= "NotInstantiated")
                    {
                        Exit();
                        Program.currentState = Singleton<Map>.GetInstance();
                        Program.currentState.RedrawNext();
                    }
                    else {
                        Exit();
                        Console.Clear();
                        ConsoleHelper.WriteLine("No Game Started", ConsoleColor.White, ConsoleColor.Black);
                        Console.ReadLine();
                        Render();
                    }
         
                    break;
                case 2:
                    Exit();        
                    Program.currentState = Singleton<Options>.GetInstance();
                    Program.currentState.RunInitiate();
                    Program.currentState.RedrawNext();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;

            }


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
             

            base.Render();
      
        }

   




    }





}
