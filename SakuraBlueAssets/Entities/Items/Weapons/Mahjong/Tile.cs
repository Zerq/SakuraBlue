using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Items.Weapons.Mahjong {
    public class Tile {
        private Tile(char symbol, int? value = null, Direction? windDirection = null, ConsoleColor? color= null) {
            this.Symbol = symbol;
            this.Value = value;
            this.direction = windDirection;
        }
        public static Tile NewBamboo(int number) { return new Tile('|', number); }
        public static Tile NewCircles(int number) { return new Tile('O', number); }
        public static Tile NewKanji(int number) { return new Tile('¥', number); }
        public static Tile NewWinds(Direction windDirection) { return new Tile('W', null, windDirection); }
        public static Tile NewDragons(ConsoleColor color) { return new Tile('D',null,null,color); }
        public static Tile NewSeasons(int number) { return new Tile('S', number); }
        public char Symbol { get; set; }
        public int? Value { get; set; }
        public ConsoleColor? Color { get; set; }
        public Direction? direction { get; set; }
    }
}