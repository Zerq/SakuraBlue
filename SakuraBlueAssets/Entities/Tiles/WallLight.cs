using Omnicatz.AccessDenied;
using System;
using System.Drawing;

namespace SakuraBlue.Entities.Tiles {
    public class WallLight : TileBase {
        public WallLight(LockToken singletonLock): base(singletonLock) {}
        public override string Graphics {
            get {
                return "░░";
            }
        }
        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.Gray;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.Gray;
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
            return    false;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(127, 127, 127);
            }
        }
    }
}