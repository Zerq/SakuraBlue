using Omnicatz.AccessDenied;
using System;
using System.Drawing;

namespace SakuraBlue.Entities.Tiles {
    [Singleton]
    public class Bridge :TileBase {
        public Bridge(LockToken lockToken): base(lockToken) {

        }

        public override string Graphics {
            get {
                return "▓░";
            }
        }
        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.DarkRed;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.DarkRed;
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
                return "It's a wooden bridge looks stirdy.";
            }
        }

        public override bool IsPassable {
            get {
                return true;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(185, 122, 87);    
            }
        }
    }
}