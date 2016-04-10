using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using SakuraBlue.Entities.Map;


namespace SakuraBlue.Entities.Agent
{
    public abstract class ArtificalInteligence<T> where T : AgentBase
    {
        public ArtificalInteligence(T me) {
            this.me = me;
        }

       protected T me;


        public abstract AIState State
        {
            get;
            set;
        }      

        /// <summary>
        /// if hunting calculate next step towards player if out of visual range calculate if hunt state should decay and how much (possible stealth stat involved)
        /// </summary>
        /// <param name="world"></param>
        /// <param name="me"></param>
        public abstract void TurnStep();

        private Tiles.TileBase GetDirection(Direction direction) {

            switch (direction) {
                case Direction.Up:
                    if (me.Y - 1 > 0)
                    {
                        return me.Grid.Tiles[me.X, me.Y - 1];
                    }
                    break;
                case Direction.Down:
                    if (me.Y + 1 < me.Grid.Tiles.GetLength(1))
                    {
                        return me.Grid.Tiles[me.X, me.Y + 1];
                    }
                    break;
                case Direction.Left:
                    if (me.X - 1 > 0)
                    {
                        return me.Grid.Tiles[me.X - 1, me.Y ];
                    }
                    break;
                case Direction.Right:
                    if (me.X + 1 < me.Grid.Tiles.GetLength(0))
                    {
                        return me.Grid.Tiles[me.X + 1, me.Y];
                    }
                    break;
            }
            return null;
        }

        Dictionary<Direction, Point> directionLookup = new Dictionary<Direction, Point>(){
            { Direction.Up, new Point(0,-1) },
            { Direction.Down, new Point(0, 1) },
            { Direction.Left, new Point(-1,0) },
            { Direction.Right, new Point(1,0) }};

        protected int Distance() {
            var target = Omnicatz.Engine.Entities.PlayerInstanceManager.GetPlayer(me.Grid);//  Player.GetPlayer(me.Grid);
            //var x = Math.Abs(me.X - target.X);
            //var y = System.Math.Abs(me.Y - target.Y);
            //return Convert.ToInt32(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            return    Distance(me.X, me.Y, target.X, target.Y);
        }



        public static int Distance(int meX, int meY, int targetX, int targetY) {         
            var x = Math.Abs(meX - targetX);
            var y = System.Math.Abs(meY - targetY);
            return Convert.ToInt32(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }

        protected void Huristics(Direction direction,  out int manhatan, out int straightline) {
            var target = Omnicatz.Engine.Entities.PlayerInstanceManager.GetPlayer(me.Grid);//   Player.GetPlayer(me.Grid);


            var passable = GetDirection(direction)?.IsPassable;      
            var myX = me.X + directionLookup[direction].X;
            var myY = me.Y + directionLookup[direction].Y;
            if (passable.HasValue)
            {
                if (passable.Value)
                {
                    var x = Math.Abs(myX - target.X);
                    var y = System.Math.Abs(myY - target.Y);
                    manhatan = x + y;
                    straightline = Convert.ToInt32(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
                } else {
                    manhatan = int.MaxValue;
                    straightline = int.MaxValue;
                }
            }
            else {
                manhatan = int.MaxValue;
                straightline = int.MaxValue;
            }
        }
        /// <summary>
        /// this implementation is a bit limited as it has no list of previously traveld cell to exclude but it might be best for this case... it rather simplicstic and probably prone to getting stuck..
        /// </summary>
        /// <param name="world"></param>
        /// <param name="me"></param>
        /// <param name="target"></param>
        /// <returns></returns>


        protected Agent.Direction? AStar() {
            var target = Omnicatz.Engine.Entities.PlayerInstanceManager.GetPlayer(me.Grid);//  Player.GetPlayer(me.Grid);

            int max = 0;
            Direction? best = null; // closed in
            foreach (Direction direction in Enum.GetValues(typeof(Direction))) {
                int manhatan = int.MaxValue;
                int straightline = int.MaxValue;
                Huristics(direction, out manhatan, out straightline);
                if (max < manhatan + straightline) {
                    max = manhatan + straightline;
                    best = direction;
                }

            }
            return best;
        }

        /// <summary>
        /// Detect any player in interaction distance and attack if hostile and within range and detect player in visual range and hunt
        /// should i maybe do ray casting to detect obstructions to target? hmmm....
        /// </summary>
        /// <param name="world"></param>
        /// <param name="me"></param>
        public abstract void Detect();

    }
}