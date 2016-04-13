using Omnicatz.Helper;
using Omnicatz.Helper.ConsoleStrings;
using Omnicatz.Helper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper {
    public static class DialogHelper {
        public static int WriteDialogBase(ConsoleColor fore, ConsoleColor back, int x, int y, int? size, params string[] lines) {

            int widest;

            if (size.HasValue) { widest = size.Value; } else { widest = lines.Max(n => n.Length); }

            StringBuilder builder = new StringBuilder();

            var empty = "║ ".PadRight(widest - 1, ' ') + "║";
            ConsoleHelper.WriteOffset("╔".PadRight(widest - 1, '═') + "╗", fore, back, x, y);//start
            ConsoleHelper.WriteOffset(empty, fore, back, x, y + 1);//start

            for (int i = 0; i < lines.Count(); i++) {
                var line = lines[i];
                ConsoleHelper.WriteOffset($"║  {line}".PadRight(widest - 1, ' ') + "║", fore, back, x, y + 2 + i);
            }
            ConsoleHelper.WriteOffset(empty, fore, back, x, y + 2 + lines.Count());//start

            return widest;


        }
        public static void WriteDialog(ConsoleColor fore, ConsoleColor back, int x, int y, int? size, params string[] lines) {

             var widest =  WriteDialogBase(fore, back, x, y, size, lines);
            ConsoleHelper.WriteOffset("╚".PadRight(widest - 1, '═') + "╝", fore, back, x, y + 3 + lines.Count());//end

      
        }

        public static void WriteDialogMore(ConsoleColor fore, ConsoleColor back, int x, int y, int? size, params string[] lines) {

            var widest = WriteDialogBase(fore, back, x, y, size, lines);
            ConsoleHelper.WriteOffset("╚".PadRight(widest - 3, '═') + "++╝", fore, back, x, y + 3 + lines.Count());//end


        }
        public static void WriteLongVoicedDialog(string text, ConsoleColor fore, Rectangle box, ConsoleColor back = ConsoleColor.Black, int volum =0) {

            SpeechSynthesizer voice = null;
            if (volum != 0) {
                voice = new SpeechSynthesizer();
                voice.Volume = volum;
            }

           var groups = text.WidthWrap(box.Width-5).HeightWrap(box.Height);

            if (groups.Count > 1) {
                for (int i = 0; i < groups.Count; i++) {
                    voice?.SpeakAsync(string.Join("", groups[i].lines));
                    WriteDialogMore (fore, back, box.X, box.Y, box.Width, groups[i].lines.ToArray());
                    Console.ReadKey();
                    System.Threading.Thread.Sleep(100);
                    voice?.SpeakAsyncCancelAll();
                }
            } else {
                voice?.SpeakAsync(string.Join("", groups[0].lines));
                WriteDialog(fore, back, box.X, box.Y, box.Width, groups[0].lines.ToArray());
            }

        }

        private static void WriteDialogMore(ConsoleColor fore, ConsoleColor back, object x, object y, int? width, string[] v) {
            throw new NotImplementedException();
        }

        private static void WriteDialogMore(ConsoleColor fore, ConsoleColor back, object x, object y, object width, string[] v) {
            throw new NotImplementedException();
        }
    }
}

namespace Omnicatz.Helper.Helper {
  public  struct Rectangle {
       public Rectangle(int x, int y, int height, int width) {
            this.Height = height;
            this.Width = width;
            this.X = x;
            this.Y = y;
        }
        public int Height { get;  set; }
        public int Width { get;  set; }
        public int X { get;  set; }
        public int Y { get; set; }
    }
}