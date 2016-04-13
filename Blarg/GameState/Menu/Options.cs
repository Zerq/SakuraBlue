using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using SakuraBlue.Entities.Agent;

namespace SakuraBlue.GameState.Menu
{
    public class Options : GameStateBase
    {
        public Options(LockToken token) : base(token)
        {
            LockToken.Enforce<Options>(token);
        }
        public int selected = 0;
        const string textToSpeechLabel = "Voice Volume: ";
        const string musicVolumeLabel = "Music volume: ";
        const string soundVolumeLabel = "Sound volume: ";
        public int musicVolume = 7;
        public int soundVolume = 10;
        public int speechVolume = 0;
        private string[] options = new string[] { musicVolumeLabel, soundVolumeLabel, textToSpeechLabel, "Back" };

        KeyInterface keyInterface;
        protected override void Initiate()
        {
            Console.Clear();
            keyInterface = new KeyInterface(
                new KeyHook(ConsoleKey.UpArrow, () =>
                {
                    selected--;
                    RedrawNext();
                }),
                new KeyHook(ConsoleKey.DownArrow, () =>
                {
                    selected++;
                    RedrawNext();
                }),
                new KeyHook(ConsoleKey.LeftArrow, () =>
                {
                    if (options[selected] == textToSpeechLabel) {
                        speechVolume--;
                        if (speechVolume < 0) {
                            speechVolume = 0;
                        }
                        RedrawNext();
                    } else
               if (options[selected] == musicVolumeLabel)
                    {
                        musicVolume--;
                        if (musicVolume < 0)
                        {
                            musicVolume = 0;
                        }
                        RedrawNext();
                    }else
                    if (options[selected] == soundVolumeLabel)
                    {
                        soundVolume--;
                        if (soundVolume < 0)
                        {
                            soundVolume = 0;
                        }
                        RedrawNext();
                    }
                }),
                new KeyHook(ConsoleKey.RightArrow, () =>
                {

                    if (options[selected] == textToSpeechLabel) {
                        speechVolume++;
                        if (speechVolume > 10) {
                            speechVolume = 10;
                        }
                        RedrawNext(); ;
                    } else
        if (options[selected] == musicVolumeLabel)
                    {
                        musicVolume++;
                        if (musicVolume > 10)
                        {
                            musicVolume = 10;
                        }
                        RedrawNext();
                    }else
                    if (options[selected] == soundVolumeLabel)
                    {
                        soundVolume++;
                        if (soundVolume > 10)
                        {
                            soundVolume = 10;
                        }
                        RedrawNext();
                    }
                }),
                new KeyHook(ConsoleKey.Enter, () =>
                {
                    if (options[selected] == "Back")
                    {
                        Back();
                    }
                }),

                new KeyHook(ConsoleKey.Escape, () => { Back(); })

                );
        }
        public void Back()
        {
            Program.currentState = Singleton<TopMenu>.GetInstance();
            bigTextRendered = false;
            Console.Clear();
          
            Program.currentState.RedrawNext();
        }
        public override void Exit()
        {
            bigTextRendered = true;
        }
        public override void Update()
        {

            keyInterface.Listen();
            if (selected >= options.Count())
            {
                selected = 0;
            }
            if (selected < 0)
            {
                selected = options.Count();
            }

            Singleton<Media.Music>.GetInstance().SetVolume(musicVolume);
        }
        bool bigTextRendered = false;
        protected override void Render()
        {
            if (!bigTextRendered)
            {
                ConsoleHelper.AltClear();
                ConsoleHelper.WTF_WriteLine(Program.GameTitle);
                bigTextRendered = true;
            }
            else
            {
                Console.CursorTop = 18;
            }

            ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
            ConsoleHelper.WriteLine("Game Options", ConsoleColor.Cyan);
            int index = 0;
            foreach (var option in options)
            {
                ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);

                if (selected == index)
                {
                    ConsoleHelper.Write(option, ConsoleColor.Red, ConsoleColor.Black);
                }
                else
                {
                    ConsoleHelper.Write(option, ConsoleColor.Gray, ConsoleColor.Black);
                }
                //▓░
                if (option == musicVolumeLabel)
                {
                    var gauge = new string('▓', musicVolume).PadRight(10, '░');
                    ConsoleHelper.Write(gauge, ConsoleColor.Red, ConsoleColor.Black);
                }

                if (option == soundVolumeLabel)
                {
                    var gauge = new string('▓', soundVolume).PadRight(10, '░');
                    ConsoleHelper.Write(gauge, ConsoleColor.Red, ConsoleColor.Black);
                }

                if (option == textToSpeechLabel) {
                    var gauge = new string('▓', speechVolume).PadRight(10, '░');
                    ConsoleHelper.Write(gauge, ConsoleColor.Red, ConsoleColor.Black);
                }


                Console.WriteLine();
                index++;
            }






        }
    }





}
