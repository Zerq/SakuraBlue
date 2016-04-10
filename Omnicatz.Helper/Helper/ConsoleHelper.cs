using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
namespace Omnicatz.Helper {
    //Curses! cant make this an extension method! oh well...
    public static class ConsoleHelper {



        public static void AltClear() {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }
        public static void Write(string text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black) {
                Console.BackgroundColor = backColor;      
                Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void Write(char text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black) {
            Console.BackgroundColor = backColor;       
            Console.ForegroundColor = color;       
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black) {
                Console.BackgroundColor = backColor;
                Console.ForegroundColor = color;  
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteOffset(string text, ConsoleColor color, ConsoleColor back, int xOffset, int yOffset) {
            Point oldPosition = new Point(Console.CursorLeft, Console.CursorTop);
            Console.CursorLeft = xOffset;
            Console.CursorTop = yOffset;
            Write(text, color, back);
            Console.CursorLeft = oldPosition.X;
            Console.CursorTop = oldPosition.Y;
        }

        public static void DramaticWriteLine(String text) {
           var chars = text.ToCharArray();
            for (int i = 0; i<chars.Count(); i++) {             
                    Console.Write(chars[i]);
                    System.Threading.Thread.Sleep(300);  
            }
            Console.WriteLine("");
        }

        private static Dictionary<ConsoleColor, ConsoleColor> colorContrast = new Dictionary<ConsoleColor, ConsoleColor>() {
            {ConsoleColor.Red, ConsoleColor.Green },
            { ConsoleColor.Yellow, ConsoleColor.Cyan },
            { ConsoleColor.Green, ConsoleColor.Blue},
            { ConsoleColor.Cyan, ConsoleColor.Magenta},
            { ConsoleColor.Blue, ConsoleColor.Red},
            { ConsoleColor.Magenta, ConsoleColor.Yellow}
        };  
   
       private static  List<ConsoleColor> colors = new List<ConsoleColor>() {
                ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta
            };

    

        public static void WTF_WriteLine(string message, int frame = 0, int amplitude = 0)
        {
          

            var stretchedout = string.Join(" ", message.ToCharArray()); // space it out for readability

            Bitmap bmp = new Bitmap(500, 500);
            RectangleF rectf = new RectangleF(0, 0, 500, 500);

            Graphics g = Graphics.FromImage(bmp);
            var font = new Font("Tahoma", 10);
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.Low;
            g.PixelOffsetMode = PixelOffsetMode.None;
            g.DrawString(stretchedout, font, Brushes.Black, rectf);
            var size = g.MeasureString(stretchedout, font);
            g.Flush();

            var width = Convert.ToInt32(size.Width);
            var height = Convert.ToInt32(size.Height);
            //if (frame != 0 && amplitude != 0)
            //{
            //  bmp = sinusDistort(bmp, frame, amplitude,width, height );
            //}


            Random random = new Random(DateTime.Now.Millisecond);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var color = bmp.GetPixel(x, y);  
                    if (color == Color.FromArgb(0, 0, 0, 0))
                    {
                        ConsoleHelper.Write("X", ConsoleColor.Black, ConsoleColor.Black);                      
                    }
                    else
                    {
                        var colorNr = colors[random.Next(colors.Count())];


                   
                        ConsoleHelper.Write(message.ToCharArray()[random.Next(message.Count())], colorNr, colorContrast[colorNr]);
                    }
     
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleHelper.WriteLine(" ", ConsoleColor.Black, ConsoleColor.Black);
            }



        }

       

    }
}