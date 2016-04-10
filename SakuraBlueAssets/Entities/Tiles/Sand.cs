using Omnicatz.AccessDenied;
using System;
using System.Drawing;

namespace SakuraBlue.Entities.Tiles {
    [Singleton]
    internal class Sand: TileBase {
        public Sand(LockToken singletonLock): base(singletonLock) {}

        public override string Graphics {
            get {
                return "░░";
            }
        }
        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.DarkYellow;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.DarkYellow;
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
                return "Beach sand of the type you inevetalby end up getting in your boots.";
            }
        }

        public override bool IsPassable {
            get {
                return true;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(255, 201, 14);
           
            }
        }
    }
}