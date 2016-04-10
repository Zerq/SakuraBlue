using SakuraBlue.Entities.Agent;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.Engine.Entities;

namespace SakuraBlue.GameState.BattleState
{
    class BattleState : GameStateBase
    {
        public BattleState(LockToken lockToken, NPCBase enemy) : base(lockToken) {
            this.enemy = enemy;
            Initiate();
           
        }

        public NPCBase enemy { get; set; }


        public override void Exit()
        {

        }

        public override void Update()
        {

        }
        ConsoleBitmap bgArt;
        ConsoleBitmap enemyArt;
        protected override void Initiate()
        {
            if (enemy != null)
            {
                bgArt = new ConsoleBitmap($"{AppDomain.CurrentDomain.BaseDirectory}Assets\\BG\\bg01.png");
                enemyArt = new ConsoleBitmap($"{AppDomain.CurrentDomain.BaseDirectory}Assets\\Enemy\\femaleDjin01.png", ConsoleColor.Magenta);
                DialogHelper.WriteDialog(ConsoleColor.Red, ConsoleColor.Black, 90, 3, 50, enemy.Name, $"{enemy.Race.Name} {enemy.Class.Name}");
                Singleton<Media.Music>.GetInstance().Play(@"Music\Battle with the Circus Freaks.mp3");
            }
        }
        bool drawArt = true;
        protected override void Render()
        {
            if (drawArt) {
                Player player = PlayerInstanceManager.GetPlayer(Singleton<Map>.GetInstance().map) as Player;
                bgArt.Draw(0, 0);
                enemyArt.Draw(10, 10);
                DialogHelper.WriteDialog(ConsoleColor.Yellow, ConsoleColor.Black, 130, 0, 54, $"{enemy.Name}:");
                int i = 1;
                enemy.PartyMembers?.ForEach(n => {

                    DialogHelper.WriteDialog(ConsoleColor.Red, ConsoleColor.Black, 130, (i *5), 54, $"{n.Name}:");
                    i++;
                }
                );

                DialogHelper.WriteDialog(ConsoleColor.Blue, ConsoleColor.Black, 184, 0, 54, 
                    $"{player.Name} ({player.Race.Name} {player.Class.Name})",
                    $"Hp:{player.HP.Current} Stamina {player.Stamina.Current}",
                   "Magic--------------",
                    $"Fire:{player.Fire.Current} Water:{player.Water.Current}",
                    $"Earth:{player.Earth.Current} Wind:{player.Wind.Current}",
                    $"Chaos:{player.Chaos.Current} Order:{player.Order.Current}",
                    $"Dark:{player.Darkness.Current} Light:{player.Light.Current}"
                    );
                drawArt = false;
            }

        }
    }
}
