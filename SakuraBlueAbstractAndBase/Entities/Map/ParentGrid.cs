using SakuraBlue.Entities.Agent;
using SakuraBlue.Entities.Tiles;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Omnicatz.Engine.Entities;
using System.Reflection;
using SakuraBlueAbstractAndBase.Entities.Map;

namespace SakuraBlue.Entities.Map
{
    /// <summary>
    /// this is the map grid object ment to be used to load grids and devide  part of into child grids
    /// </summary>
    public class ParentGrid : Grid,IReceptiveWorld {

        public ParentGrid(string path, TileBase[] pallet) : base(0, 0)/*disike this*/
        {

            this.Agents = new List<AgentBase>();

            if (pallet.Count() != 0)
            {
                var bmp = new Bitmap(Bitmap.FromFile(path));

                this.Tiles = new TileBase[bmp.Width, bmp.Height];

                GridTraverse(0, 0, bmp.Width, bmp.Height, (x, y) => {
                    var color = bmp.GetPixel(x, y);
                    Tiles[x, y] = pallet.First(n => NonAlphaColorCompare(n.ReferenceColor, color));
                });
            }

        }
        protected static bool NonAlphaColorCompare(Color referenceColor, Color color)
        {
            return referenceColor.R == color.R && referenceColor.G == color.G && referenceColor.B == color.B;
        }
        public static TileBase[] GetPallet(Assembly assembly)
        {
         
            return assembly.GetTypes()
        .Where(t => typeof(TileBase).IsAssignableFrom(t) && t != typeof(TileBase))
        .Select(t => (TileBase)Singleton.GetInstance(t)).ToArray();
        }


        public List<AgentBase> Agents { get; private set; }
        public AgentBase[,] GetAgentMap (){
                AgentBase[,] result = new AgentBase[Tiles.GetLength(0), Tiles.GetLength(1)];
            Agents.ForEach(n => result[n.X, n.Y] = n);
            return result;
            }
        public AgentBase GetAgent(int x, int y) {
            return Agents.FirstOrDefault(n => n.X == x && n.Y == y);
        }
        public T AddAgent<T>(params object[] parameters) where T : AgentBase
        {
            List<object> parameterList = new List<object>();
            parameterList.Add(this);
            parameterList.AddRange(parameters);

            var agent = Activator.CreateInstance(typeof(T), parameterList.ToArray()) as T;
            this.Agents.Add(agent);
            return agent;
        }
        public void Addplayer(AgentBase player) {

            if (player.GetType() == Omnicatz.Engine.Entities.PlayerInstanceManager.PlayerType) {
                if (Agents.Count(n => n.GetType() == player.GetType()) == 0) {
                    Agents.Add(player);
                } else {
                    throw new ApplicationException("Agent List allready has a player!"); // might handle this diffently later...
                }
            } else {
                throw new ApplicationException($"{player.GetType()} is not set as playerType for this game");
            }
        }

        public AgentBase GetPlayer() {
           return this.Agents.FirstOrDefault(n => n.GetType() == Omnicatz.Engine.Entities.PlayerInstanceManager.PlayerType);
        }

        public ChildGrid GetSubGrid(int startX, int startY, int width, int height, bool showAll)
        {

            ChildGrid result = new ChildGrid(width, height, startX, startY, this, showAll);

            var mappedAgents = GetAgentMap();
            GridTraverse(startX, startY, width + startX, height + startY, (x, y) => {

                if (!(x < 0 || y < 0))
                {
                    var tile = this.Tiles[x, y];
                   
                    result.Tiles[x - startX, y - startY] = tile;
                    result.VisibleAgents[x - startX, y - startY] = mappedAgents[x, y];
                }

            });

            return result;
        }


        public void Recive(AgentBase agent, object parameter=null) {
            this.Agents.Add(agent);
        }

        public void Transfer(IReceptiveWorld targetWorld, AgentBase agent, object parameter=null) {
            targetWorld.Recive(agent);
            this.Agents.Remove(agent);
        }
    }

}
