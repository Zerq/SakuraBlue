using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.GameState.BattleState.Battlefields {
    public class Grasslands : Battlefield {
        static readonly string fields = $"{AppDomain.CurrentDomain.BaseDirectory}\\Assets\\BG\\bg01.png";
        static readonly string defaultBattleMusic = $"{AppDomain.CurrentDomain.BaseDirectory}\\Music\\Battle with the Circus Freaks.mp3";
        public Grasslands(LockToken @lock) : base(@lock, fields, defaultBattleMusic) {
            backgroundImage = new ConsoleBitmap(fields);
        }
        ConsoleBitmap backgroundImage;
        public override void Render() {
            backgroundImage.Draw();//draw att 0,0
        }
    }
}
