using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using SakuraBlue.Entities.Map;
using SakuraBlue.Entities.Tiles;

namespace SakuraBlueUnitTest {
    [TestClass]
    public class GridTests {      

        public static void GetTestMap(out Bitmap bmp, out SakuraBlue.Entities.Map.ParentGrid grid ) {
            TileBase[]  pallet = SakuraBlue.Entities.Map.ParentGrid.GetPallet(typeof(SakuraBlue.Entities.Tiles.Bridge).Assembly);
            var path =  $"{AppDomain.CurrentDomain.BaseDirectory}\\Maps\\map1.bmp";
            bmp =  new Bitmap(path);
            grid = new ParentGrid(path, pallet);       
        }

        [TestMethod]
        public void ParentGrid_GetPalletTest() {
           var  pallet = SakuraBlue.Entities.Map.ParentGrid.GetPallet(typeof(SakuraBlue.Entities.Tiles.Bridge).Assembly);
            Assert.IsTrue(pallet.Length > 0);
        }

        [TestMethod]
        public void ParentGrid_LoadsMapOfRightSizeTest() {
            Bitmap bmp;
            ParentGrid grid;
    
            GetTestMap(out bmp, out grid);
            Assert.IsTrue(grid.Tiles.GetLength(0) == bmp.Width && grid.Tiles.GetLength(1) == bmp.Height);
        }

        [TestMethod]
        public void ParentGrid_ChildInstantiationTest() {
            Bitmap bmp;
            ParentGrid grid;
            GetTestMap(out bmp, out grid);
            var childgrid = grid.GetSubGrid(0, 0, 30, 30, true);
            Assert.IsTrue(childgrid != null);
        }

        [TestMethod]
        public void ParentGridErroniousChildInstantiotionTest() {

            try {
                var child = new ChildGrid(30, 30, 0, 0, null, true);
            } catch (ArgumentNullException ex) {
                Assert.IsTrue(ex.Message == "Value cannot be null.\r\nParameter name: Parent parameter may not be null!");
            } 
        }



    }
}
