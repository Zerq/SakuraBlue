using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;

namespace SakuraBlue.GameState {
    public  class GameMenuBaseState : GameStateBase {
        public GameMenuBaseState(LockToken token) : base(token) {
       
        }


        public virtual List<string> GetOptions() {
            return null;
        } 
        public int Selected { get; private set; }



        KeyInterface keyInterface;
        protected override void Initiate() {
            Console.Clear();
            RedrawNext();
            keyInterface = new KeyInterface(
                new KeyHook(ConsoleKey.UpArrow, () => {
                    Selected--;
                    RedrawNext();
                }), 
                new KeyHook(ConsoleKey.DownArrow, () => {
                    Selected++;
                    RedrawNext();
                }), 
                new KeyHook(ConsoleKey.Enter, () => {
                    Action();
                }),
                          new KeyHook(ConsoleKey.LeftArrow, () => {
                              Decrement();
                          }),

                                   new KeyHook(ConsoleKey.RightArrow, () => {
                                       Increment();
                                   }),


                                new KeyHook(ConsoleKey.Escape, () => {
                                    Back();
                                })




            );
        }

        protected virtual void Increment() {

        }

        protected virtual void Decrement() {

        }

        protected virtual void Back() { }
        protected override void Render() {
            foreach (var item in GetOptions()) {
                if (GetOptions().ToList().IndexOf(item) == Selected) {
                    ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
                    ConsoleHelper.WriteLine(item, ConsoleColor.Red, ConsoleColor.Black);


                } else {
                    ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
                    ConsoleHelper.WriteLine(item, ConsoleColor.White, ConsoleColor.Black);
                }

            }
        }

        public override void Exit() {

        }

        public virtual void Action() {

        }

        public override void Update() {
            keyInterface.Listen();

            if (Selected >= GetOptions().Count()) {
                Selected = 0;
            }

            if (Selected < 0) {
                Selected = GetOptions().Count();
            }

        }
    }





}
