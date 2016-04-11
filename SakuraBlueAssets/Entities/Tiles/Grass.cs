using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Tiles {
    public class Grass : TileBase {

        public Grass(LockToken singletonLock): base(singletonLock) {

        }
        public override string Graphics {
            get {
                return "░░";
            }
        }

        public override ConsoleColor ColorA {
            get {

                return ConsoleColor.Green;
            }
        }

        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.Green;
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
                return "It's grass, slightly moist from the morning dew.";
            }
        }

        public override bool IsPassable {
            get {
                return true;
            }
        }

        public override Color ReferenceColor {
            get {
                return Color.FromArgb(0, 255, 0);
            }
        }
    }
}
