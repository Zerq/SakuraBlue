using System;
using System.Collections.Generic;
using SakuraBlue.Entities.Map;
using SakuraBlue.Entities.Items;
using SakuraBlueAbstractAndBase.Entities.Map;

namespace SakuraBlue.Entities.Agent {
    public abstract class AgentBase : Renderable {
        public AgentBase(IWorld grid) {
            this.World = grid;
            this.Inventory = new List<ItemBase>();
        }

        public int X { get; set; }
        public int Y { get; set; }



        public event EventHandler OnRegenerate;
        public virtual void Regenerate() {
            if (this.OnRegenerate != null) {
                this.OnRegenerate(this, new EventArgs());
            }
        }


        public  virtual string AgentMove(ParentGrid grid, Direction direction) {
            var result = "";
            switch (direction) {
                case Direction.Up:
                    if (Y - 1 >= 0) {
                        if (grid.Tiles[X, Y - 1].IsPassable) {
                            Y--;
                            result= grid.Tiles[X, Y].Description;
                        } else {
                            result = grid.Tiles[X, Y - 1].Description;
                        }
                    } else {
                        result = null;
                    }
                    break;

                case Direction.Down:
                    if (Y + 1 <= grid.Tiles.GetLength(1)) {
                        if (grid.Tiles[X, Y + 1].IsPassable) {
                            Y++;
                            result = grid.Tiles[X, Y].Description;
                        } else {
                            result = grid.Tiles[X, Y + 1].Description;
                        }
                    } else {
                        result = null;
                    }
                    break;

                case Direction.Left:
                    if (X - 1 >= 0) {
                        if (grid.Tiles[X - 1, Y].IsPassable) {
                            X--;
                            result = grid.Tiles[X, Y].Description;
                        } else {
                            result = grid.Tiles[X - 1, Y].Description;
                        }
                    } else {
                        result = null;
                    }
                    break;

                case Direction.Right:
                    if (X + 1 <= grid.Tiles.GetLength(0)) {
                        if (grid.Tiles[X + 1, Y].IsPassable) {
                            X++;
                            result = grid.Tiles[X, Y].Description;
                        } else {
                            result = grid.Tiles[X + 1, Y].Description;
                        }
                    } else {
                        result = null;
                    }
                    break;

                default:
                    result = null;
                    break;
            }

      
            return result;


        }

        public virtual List<ItemBase> Inventory { get; set; }
 
        public IWorld World { get; private set; }

    }

    public enum Direction {
        Up,Down,Left,Right
    }
}