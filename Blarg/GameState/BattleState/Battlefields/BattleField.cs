using Omnicatz.AccessDenied;

namespace SakuraBlue.GameState.BattleState.Battlefields{
    public abstract class Battlefield {
        public Battlefield(LockToken @lock, string backgroundImagePath, string musicPath) {
        LockToken.Enforce<Battlefield>(@lock);
            this.BackgroundImagePath = backgroundImagePath;
            this.MusicPath = musicPath;

        }
        public string BackgroundImagePath { get; private set; }
        public string MusicPath { get; private set; }
        public abstract void Render();
    }
}