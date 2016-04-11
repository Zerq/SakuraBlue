using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Entities.Tiles {

    public  abstract  class TileBase: Renderable {
        public TileBase(LockToken lockToken) {
            LockToken.Enforce<TileBase>(lockToken);    
        }   

        public abstract string Description { get; }

        public abstract bool IsPassable { get; }

        /// <summary>
        /// Dont feel i need to make event listners for these at this point
        /// </summary>
        public virtual void WhenWalkingOver() { }
        public virtual void WhenAttemptingToLeave() { }
        public virtual void WhenLeaveing() { }

        public abstract Color ReferenceColor { get; }  //for getting Map from BMP
    }
}
