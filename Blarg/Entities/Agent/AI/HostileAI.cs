using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Map;
using Omnicatz.AccessDenied;
using Omnicatz.Engine.Entities;

namespace SakuraBlue.Entities.Agent.AI {
    public class HostileAI : GridAI<NPCBase> {

        public HostileAI(NPCBase me) : base(me) {

        }

        public override AIState State {
            get;

            set;
        } = AIState.Normal;

        public override void Detect() {
            var target = PlayerInstanceManager.GetPlayer(me.World) as NPCBase;

            if (this.Distance()<2) {
                Console.Clear();
                Program.currentState = Singleton<GameState.BattleState.BattleState>.GetInstance(me);
             
                Program.currentState.RunInitiate();
                Program.currentState.RedrawNext();
            }

            switch (this.State) {
                case AIState.Aware:
                    if (me.Awareness.Current * 2 > Distance()) {//this might change later but oh well
                        this.State = AIState.Hunting;
                    }
                    break;

                case AIState.Normal:
                    if (me.Awareness.Current > Distance()) {//this might change later but oh well
                        this.State = AIState.Hunting;
                    }
                    break;

                case AIState.Sleeping:
              
                        if (me.Stamina.Current == me.Stamina.Max) {
                            this.State = AIState.Normal;
                        } else {
                            me.Regenerate(); //sleeping soundly
                        }

                       
                    
                    break;


                case AIState.Dead:
                    //WTF do you want i am dead!!!
                    break;

                case AIState.Hunting:
                    this.me.Stamina.Current--;
                    if (me.Stamina.Current <= 0) {
                        this.State = AIState.Sleeping; // he got exausted
                    }

                    break;


            }




        }


        private void TakeStep() {

            if (this.State == AIState.Hunting) {
                switch (this.AStar()) {
                    case Direction.Up:
                        me.Y++;
                        break;
                    case Direction.Down:
                        me.Y--;
                        break;
                    case Direction.Left:
                        me.X++;
                        break;
                    case Direction.Right:
                        me.X--;
                        break;
                }
            }
        }

        public override void TurnStep() {
            TakeStep();
            TakeStep();

        }
    }
}
