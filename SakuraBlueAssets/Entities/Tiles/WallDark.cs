using Omnicatz.AccessDenied;
using System;
using System.Drawing;

namespace SakuraBlue.Entities.Tiles {
    [Singleton]
    public class WallDark: TileBase {
        public WallDark(LockToken singletonLock): base(singletonLock) {}

        public override string Graphics {
            get {
                return "▓▓";
            }
        }
        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.DarkGray;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.DarkGray;
            }
        }
        public override ConsoleColor ColorA2 {
            get {

                return ConsoleColor.Black;
            }
        }

        public override ConsoleColor ColorB2 {
            get {
                return ConsoleColor.Black;
            }
        }
        public override string Description {
            get {
                return "The Wall stands firm!";
            }
        }

        public override bool IsPassable {
            get {
                return false;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(0,0,0);
            }
        }
    }
}