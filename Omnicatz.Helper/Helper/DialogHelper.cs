using Omnicatz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper
    {
    public static class DialogHelper
    {
        public static void WriteDialog(ConsoleColor fore, ConsoleColor back, int x, int y, int? size, params string[] lines)
        {

            int widest;

            if (size.HasValue)
            { widest = size.Value; }
            else
            { widest = lines.Max(n => n.Length); }

            StringBuilder builder = new StringBuilder();

            var empty = "║ ".PadRight(widest - 1, ' ') + "║";
            ConsoleHelper.WriteOffset("╔".PadRight(widest - 1, '═') + "╗", fore, back, x, y);//start
            ConsoleHelper.WriteOffset(empty, fore, back, x, y + 1);//start

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                ConsoleHelper.WriteOffset($"║  {line}".PadRight(widest - 1, ' ') + "║", fore, back, x, y + 2 + i);
            }
            ConsoleHelper.WriteOffset(empty, fore, back, x, y + 2 + lines.Count());//start
            ConsoleHelper.WriteOffset("╚".PadRight(widest - 1, '═') + "╝", fore, back, x, y + 3 + lines.Count());//end



        }
        public static void WriteDialog(ConsoleColor fore, ConsoleColor back, ConsoleColor foreFrame, ConsoleColor BackFrame, int x, int y, int? size, params string[] lines) {

            int widest;

            if (size.HasValue) { widest = size.Value; } else { widest = lines.Max(n => n.Length); }

            StringBuilder builder = new StringBuilder();

            var empty = "║ ".PadRight(widest - 1, ' ') + "║";
            ConsoleHelper.WriteOffset("╔".PadRight(widest - 1, '═') + "╗", foreFrame, BackFrame, x, y);
            ConsoleHelper.WriteOffset(empty, foreFrame, BackFrame, x, y + 1);

            for (int i = 0; i < lines.Count(); i++) {
                var line = lines[i];

         
                ConsoleHelper.WriteOffset($"║  {line}".PadRight(widest - 1, ' ') + "║", fore, back, x, y + 2 + i);
            }
            ConsoleHelper.WriteOffset(empty, foreFrame, BackFrame, x, y + 1);
            ConsoleHelper.WriteOffset("╚".PadRight(widest - 1, '═') + "╝", foreFrame, BackFrame, x, y + 3 + lines.Count());//end

            throw new NotImplementedException("Need to change this so the frame can have a diffent color... maybe toss out back color entierly");

        }

    }
}
