using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using System;
using SakuraBlue.Media;
using SakuraBlue.Entities.Map;
using SakuraBlue.Entities.Agent;
using Omnicatz.Engine.Entities;

namespace SakuraBlue.GameState {
    public class Map : GameStateBase {



        public ParentGrid map;
        KeyInterface keyInterface;
        int fps = 30;
        int fpsFracton => 1000 / fps;
        string desciription = "";
        DateTime last = DateTime.Now;
        private bool redrawCharacterInfo = true;
        bool isDay = true;


        public Map(LockToken token) : base(token) {

        }

 



        protected override void Initiate() {
            Console.Clear();
            var pallet = ParentGrid.GetPallet(typeof(SakuraBlue.Entities.Tiles.Forest).Assembly);
            map = new ParentGrid($"{AppDomain.CurrentDomain.BaseDirectory}\\Maps\\map1.bmp", pallet);

            //Player.SetPlayer(fromCharacterCreaton);

          PlayerInstanceManager.SetPlayer(map.AddAgent<Entities.Agent.Player>(Entities.Agent.Gender.Female, Singleton<Entities.Agent.Race.Human>.GetInstance(), Singleton<Entities.Agent.Class.MageClass>.GetInstance(), "NotInstantiated", 3, 5));
            var hostileDjin = map.AddAgent<Entities.Agent.NPCBase>(Entities.Agent.Gender.Female, Singleton<Entities.Agent.Race.Djin>.GetInstance(), Singleton<Entities.Agent.Class.WarriorClass>.GetInstance(), "Hostile Djin female", 8, 25);
            hostileDjin.AI = new Entities.Agent.AI.HostileAI(hostileDjin);
            hostileDjin.IsHostile = true;
            hostileDjin.ArmStarterGear();
            hostileDjin.AddPartyMember(Gender.Male, Singleton<Entities.Agent.Race.Narugan>.GetInstance(), Singleton<Entities.Agent.Class.MageClass>.GetInstance(), "Narugan Mage");



            Singleton<Music>.GetInstance().Play(@"\Music\Good Night.mp3");

            keyInterface = new KeyInterface(
       new KeyHook(ConsoleKey.UpArrow, () => { desciription = PlayerInstanceManager.GetPlayer(map)?.AgentMove(map, Entities.Agent.Direction.Up); if (desciription != null) { RedrawNext(); } }),
       new KeyHook(ConsoleKey.DownArrow, () => { desciription = PlayerInstanceManager.GetPlayer(map)?.AgentMove(map, Entities.Agent.Direction.Down); if (desciription != null) { RedrawNext(); } }),
       new KeyHook(ConsoleKey.LeftArrow, () => { desciription = PlayerInstanceManager.GetPlayer(map)?.AgentMove(map, Entities.Agent.Direction.Left); if (desciription != null) { RedrawNext(); } }),
       new KeyHook(ConsoleKey.RightArrow, () => { desciription = PlayerInstanceManager.GetPlayer(map)?.AgentMove(map, Entities.Agent.Direction.Right); if (desciription != null) { RedrawNext(); } }),
       new KeyHook(ConsoleKey.Escape, () => {

           Program.currentState = Singleton<Menu.TopMenu>.GetInstance();
           Console.Clear();
           Program.currentState.RedrawNext();

       }));


        }


     

        protected override void Render() {
            var player = PlayerInstanceManager.GetPlayer(map) as NPCBase;
            if (player != null) {

                ConsoleHelper.AltClear();
                map.GetSubGrid(player.X - 25, player.Y - 25, 50, 50, isDay).Render();


                ConsoleHelper.Write(desciription, ConsoleColor.White, ConsoleColor.Black);
                ConsoleHelper.Write("".PadRight(90 - desciription.Length, '#'), ConsoleColor.Black, ConsoleColor.Black);
                Console.WriteLine();
                RedrawNext();

                if (redrawCharacterInfo) {

                    DialogHelper.WriteDialog(ConsoleColor.Red, ConsoleColor.Black, 102, 0, 50, $"Name: {player?.Name}", $"Race: {player?.Race.Name}", $"Gender: {player?.Gender}", $"Class: {player?.Class.Name}");

                    redrawCharacterInfo = false;
                }
                foreach (Entities.Agent.NPCBase npc in map.Agents) {
                    ConsoleHelper.Write("XXXXXXXXXXXXXXXXXXXX", ConsoleColor.Black, ConsoleColor.Black);
                    Console.CursorLeft = 0;
                    Console.Write($"{npc.Name}: x={npc.X},y={npc.Y}");
                    Console.WriteLine();
                }



            }
        }

        public override void Exit() {
           // map = null;
           // Player.SetPlayer(null);
        }

   


        public override void Update() {
            desciription = "";

            if (!ReadyToDraw){ // wait for drawing before allowing further input
                keyInterface.Listen();
            }

        }
    }
}
