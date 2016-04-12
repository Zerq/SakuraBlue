using SakuraBlue.Entities.Agent;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.Helper;

namespace SakuraBlue.Entities.Map
{
  /// <summary>
  /// Only allowed to be Instantiated From the parent this class represent a subsection 
  /// of the parent grid and may have no life independant of that role.
  /// Only this class is allowed to render a grid.
  /// </summary>
    public class ChildGrid : Grid
    {
        static ChildGrid lastRender;
        public int XOffset { get; private set; }
        public int YOffset { get; private set; }
        public ParentGrid Parrent { get; private set; }
        public AgentBase[,] VisibleAgents { get; private set; }
        public ChildGrid(int width, int height, int xOffset, int yOffset, ParentGrid parent, bool showAll) : base(width, height)
        {
            if (parent == null) {
                throw new ArgumentNullException("Parent parameter may not be null!");
            }
 
            this.XOffset = xOffset;
            this.YOffset = yOffset;
            this.Parrent = parent;
            this.VisibleAgents = new AgentBase[width, height];
            this.showAll = showAll;
           

        }
        bool showAll;
        public void Render()
        {
            GridTraverse(0, 0, Tiles.GetLength(0), Tiles.GetLength(1), (y, x) => {//:todo i have no idea why i had to invert the traverse... y and x should be x,y....

                var player = Omnicatz.Engine.Entities.PlayerInstanceManager.GetPlayer(this.Parrent);// Entities.Agent.Player.GetPlayer(this.Parrent);
                var distance = GridAI<AgentBase>.Distance(Tiles.GetLength(0) / 2, Tiles.GetLength(1) / 2, x, y);
               // if (distance < player.Awareness.Current*2 || showAll) { //InSight


                    var visibletile = Tiles[x, y];
                    var visibleAgent = VisibleAgents[x, y];
                    //same tile as last render and not an agent
                    bool firstPass = lastRender == null;
                    bool unchanged;

                    if (firstPass) {
                        unchanged = false;
                    } else {
                        var lastvisibleAgent = lastRender.VisibleAgents[x, y];
                        unchanged = lastRender.Tiles[x, y] == visibletile && visibleAgent == null && lastvisibleAgent == null;
                    }

                    if (unchanged) {
                        Console.CursorLeft += 2; //skip if we have done this before!
                    } else {
                        if (visibleAgent != null) // change and we have a agent to render which takes priority over tile
                        {

                         // var npc = visibleAgent as NPCBase;
                        //  var hostilityColor = npc.IsHostile ? ConsoleColor.DarkRed : ConsoleColor.Black;


                            //if (npc.AI != null) { <--- Breaking out this to make the game engine more generic
                            //    switch (npc.AI.State) {
                            //        case AIState.Dead:
                            //            Console.Write("DD");
                            //            break;
                            //        case AIState.Sleeping:
                            //            Console.Write("ZZ");
                            //            break;
                            //        default:
                                        ConsoleHelper.Write(visibleAgent.Graphics[0], visibleAgent.ColorA);
                                        ConsoleHelper.Write(visibleAgent.Graphics[1], visibleAgent.ColorB, visibleAgent.ColorB2);
                                     //   break;
                              //  }

                           // } else {
                          //    ConsoleHelper.Write(visibleAgent.Graphics[0], visibleAgent.ColorA);
                          //     ConsoleHelper.Write(visibleAgent.Graphics[1], visibleAgent.ColorB, hostilityColor);
                          //  }



                        } else if (visibletile != null) { // the change was a regular tile that fine render that!
                           ConsoleHelper.Write(visibletile.Graphics[0], visibletile.ColorA);
                            ConsoleHelper.Write(visibletile.Graphics[1], visibletile.ColorB);
                        } else { // out of bounds and stuff                   
                           ConsoleHelper.Write("xx", ConsoleColor.Black, ConsoleColor.Black);
                        }
                    }


                //} //InSight
                //else {
                //    Console.CursorLeft += 2;
                //}

                    }, () => { Console.WriteLine(); });   
          lastRender = this;
        }
    }
}
