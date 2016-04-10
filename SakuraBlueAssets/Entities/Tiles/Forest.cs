using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Tiles {
    [Singleton]
    public class Forest : TileBase {

        public Forest(LockToken singletonLock): base(singletonLock) {
        }



        public override string Graphics {
            get {
                return "░░";
            }
        }

        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.DarkGreen;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.DarkGreen;
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
                return "You sand in a dark ominous forest.";
            }
        }

        public override bool IsPassable {
            get {
                return true;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(34, 177, 76);
            }
        }
    }
}
