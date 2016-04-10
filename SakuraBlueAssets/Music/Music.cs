using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraBlue.Media
{
    [Singleton]
    public class Music
    {
        public Music(LockToken lockToken){
            LockToken.Enforce<Music>(lockToken);
        }
        private WMPLib.WindowsMediaPlayer player;

        public void Play(string relativePath)
        {
            

            if (player == null)
            {
                player = new WMPLib.WindowsMediaPlayer();
               
            }
            else {
                if (player.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                    player.controls.stop();
                }
            }
      
            ended = false;
         
            player.PlayStateChange += Song_PlayStateChange; ;
            player.URL = AppDomain.CurrentDomain.BaseDirectory + relativePath;
            player.controls.play();
        }

        public void SetVolume(int v)
        {
            if (player == null)
            {
                player = new WMPLib.WindowsMediaPlayer();

            }
            player.settings.volume = v;
        }

        private bool ended = false;
        public void Stop() {
            ended = true;
            player.controls.stop();
        }
        private void Song_PlayStateChange(int NewState)
        {
            //repeat unless wraper class says so!
            if (player.playState == WMPLib.WMPPlayState.wmppsMediaEnded && !ended) {
                player.controls.play();
            }

        }
    }
}