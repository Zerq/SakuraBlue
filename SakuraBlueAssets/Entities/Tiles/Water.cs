using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Tiles {
    public class Water : TileBase {

        public Water(LockToken singletonLock): base(singletonLock) {}

        public override string Graphics {
            get {
                return "░░"; 
            }
        }

        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.Blue;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.Blue;
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
                return "You cant swim!";
            }
        }

        public override bool IsPassable {
            get {
                return false;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(0, 0, 255);
            }
        }
    }
}
