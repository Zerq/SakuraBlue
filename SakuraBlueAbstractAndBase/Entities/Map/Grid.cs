using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Tiles;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.Engine.Entities;

namespace SakuraBlue.Entities.Map {

  
    /// <summary>
    /// this containts the basics of a grid object
    /// </summary>
    public abstract class Grid {

        public Grid(int width, int height) { Tiles = new TileBase[width, height]; }

        public TileBase[,] Tiles { get; set; }
 

        protected static void GridTraverse(int startX, int startY, int width, int height, Action<int, int> action, Action RowAction = null) {
            for (int x = startX; x < width; x++) {
                for (int y = startY; y < height; y++) {
                    action(x, y);
                }
                RowAction?.Invoke();
            }


        }

 
    }
}
