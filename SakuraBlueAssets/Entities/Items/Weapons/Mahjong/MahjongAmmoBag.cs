using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Items.Weapons.Mahjong {
    public class MahjongAmmoBag {
        public MahjongAmmoBag() {
          Tiles = new List<Tile>();
            for (int i = 1; i < 11; i++) {
                Tiles.Add(Tile.NewBamboo(i));
                Tiles.Add(Tile.NewCircles(i));
                Tiles.Add(Tile.NewKanji(i));
            }
            Tiles.Add(Tile.NewDragons(ConsoleColor.Red));
            Tiles.Add(Tile.NewDragons(ConsoleColor.Red));
            Tiles.Add(Tile.NewDragons(ConsoleColor.Red));
            Tiles.Add(Tile.NewDragons(ConsoleColor.Red));
            Tiles.Add(Tile.NewSeasons(1));
            Tiles.Add(Tile.NewSeasons(2));
            Tiles.Add(Tile.NewSeasons(3));
            Tiles.Add(Tile.NewSeasons(4));
            Tiles.Add(Tile.NewWinds(Direction.East));
            Tiles.Add(Tile.NewWinds(Direction.North));
            Tiles.Add(Tile.NewWinds(Direction.South));
            Tiles.Add(Tile.NewWinds(Direction.West));
            Random random = new Random(DateTime.Now.Millisecond);
            Tiles.OrderBy(n => random.Next());
        }
        public List<Tile> Tiles { get; }
    }
}
