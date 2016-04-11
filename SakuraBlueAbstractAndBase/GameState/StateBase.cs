using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.GameState {
 
    public abstract class GameStateBase {
        public GameStateBase(LockToken token) {
            LockToken.Enforce<GameStateBase>(token);
            RunInitiate();
        }

        private bool draw = false;
        public void RedrawNext() {
            draw = true;
        }
        public bool ReadyToDraw {
            get { return draw; }
        }


        protected abstract void Initiate();
        private bool initiated = false;
        public void RunInitiate() {
            initiated = true;
            Initiate();
        }

        public abstract void Update();
        public void RunRender() {
            if (draw) {
                Render();
            }
            draw = false;
        }
        protected abstract void Render();
        public abstract void Exit();
    }
}
