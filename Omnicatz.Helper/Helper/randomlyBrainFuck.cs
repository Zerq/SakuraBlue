using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper.Helper {

    //planing on doing a easteregg type blade weapon known as the fuck blade that can be upgrade by finding and rearanging operators (i.e mystical glyths from a by gone era)
    // ++++[>++++++++++<-]>  would do 40 damage 
    // where as ++[>++++<-]> would do 8 damage
    // and ++[>---<-]> would heal for 6 points on target
    // it's a silly idea i know and mostly i am just showing of my funny little brainfuck interpreter :p

    public class BrainFuck {
        static byte[] ary;
        static int pointer = 0;
        static int ExecPosition = 0;
        static Stack<int> Loop = new Stack<int>();

        private static void PointerRight() {
            if (pointer < 1000) {
                pointer++;
            }
        }
        private static void PointerLeft() {
            if (pointer > 0) {
                pointer--;
            }
        }
        private static void Increment() {
            if (ary[pointer] < 255) {
                ary[pointer]++;
            }
        }
        private static void Decrement() {
            if (ary[pointer] > 0) {
                ary[pointer]--;
            }
        }
        private static void Write() {

            var txt = System.Text.Encoding.ASCII.GetString(new byte[] { ary[pointer] });


            Console.Write(txt);
        }
        private static void Read() {
            ary[pointer] = Convert.ToByte(Console.Read());
        }

        static Dictionary<char, Action> operators = new Dictionary<char, Action>() {
                    {'<', () => { PointerLeft(); ExecPosition++; } },
                    {'>', () => { PointerRight(); ExecPosition++; } },
                    {'+', () => { Increment(); ExecPosition++; } },
                    {'-', () => { Decrement(); ExecPosition++; } },
                    {',', () => { Read();  ExecPosition++;} },
                    {'.' ,() => {

                        Write();  ExecPosition++;

                    } },
                    {'|', ()=> {
                        Console.Write(ary[pointer]); ExecPosition++;
                    } }, // my own custom operator to write numeric rather then character



                    { '[', ()=> {
                        Loop.Push(ExecPosition+1);  ExecPosition++;
                    } },
                    {']', ()=> {
                        if (ary[pointer]!= 0) {
                             ExecPosition = Loop.Peek();
                        }else {
                            Loop.Pop();
                            ExecPosition++;
                        }
                    }




                    }
                };

        public static void Execute(string code) {

            ary = new byte[1000];
            pointer = 0;
            ExecPosition = 0;




            while (ExecPosition != code.Length) {

                if (operators.ContainsKey(code[ExecPosition])) { // is this an operator or just comment
                    var action = operators[code[ExecPosition]];
                    if (action != null) {
                        action();
                    }

                } else {
                    ExecPosition++;//was just a comment ignore move on
                }

            }





        }
    }
}
