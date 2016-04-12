using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Agent;
using Omnicatz.AccessDenied;
using Omnicatz.Helper;
using SakuraBlue.Entities.Agent.Race;
using SakuraBlue.Entities.Agent.Class;
using SakuraBlue.Entities.Agent.Stats;
using SakuraBlue.Entities.Items;
using Omnicatz.Engine.Entities;
using SakuraBlueAbstractAndBase.Entities.Map;

namespace SakuraBlue.GameState.Menu {



    /// <summary>
    /// Character Creation Screen
    /// </summary>
    public class NewGame : GameMenuBaseState, IWorld {
        public NewGame(LockToken @lock) : base(@lock) {
            LockToken.Enforce<NewGame>(@lock);
            this.playerAsBase = this.AddAgent<Entities.Agent.Player>(Entities.Agent.Gender.Male, Singleton<Human>.GetInstance(), Singleton<WarriorClass>.GetInstance(), "John Doe", 3, 5);
            PlayerInstanceManager.SetPlayer(this.playerAsBase);
        }



        //public string Name = null;
        //public Entities.Agent.Gender? CharacterGender = null;
        //public RaceBase Race = null;
        //public AgentClassBase Class = null;

        //int fireBonus => Race != null ? Race.StatBonusBonus<FireStat>() : 0;
        //int waterBonus => Race != null ? Race.StatBonusBonus<WaterStat>() : 0;
        //int earthBonus => Race != null ? Race.StatBonusBonus<EarthStat>() : 0;
        //int windBonus => Race != null ? Race.StatBonusBonus<WindStat>() : 0;

        //int chaosBonus => Race != null ? Race.StatBonusBonus<ChaosStat>() : 0;
        //int orderBonus => Race != null ? Race.StatBonusBonus<Orderstat>() : 0;
        //int lightBonus => Race != null ? Race.StatBonusBonus<LightStat>() : 0;
        //int darkBonus => Race != null ? Race.StatBonusBonus<DarkStat>() : 0;


        //int fire; /*vs*/ int water => 10 - fire;
        //int chaos; /*vs*/ int order => 10 - chaos;
        //int earth; /*vs*/ int wind => 10 - earth;
        //int dark;  /*vs*/ int light => 10 - dark;


        private void CalculateStats() {
            //if (player.Gender == Gender.Male) {
            //    player.Strenght.MaxBase = ((player.Fire.Max  + player.Earth.Max) / 2) + 3;
            //} else {
            //    player.Strenght.MaxBase = ((player.Fire.Max + player.Earth.Max) / 2 );  //females are a tiny bit weaker initially
            //}

            //if (player.Gender == Gender.Female) {
            //    player.Dexterity.MaxBase = ((player.Water.Max) / 2) + 1; // females slight more dexterious
            //} else {
            //    player.Dexterity.MaxBase = ((player.Water.Max) / 2);  
            //}

            //player.Agility.MaxBase = player.Wind.MaxBase;


        }

        //if null -> 0  if male -> 3 if female 0
        // int genderStrenghtBonus => player.Gender.HasValue ? CharacterGender.Value == Gender.Male ? 3 : 0 : 0;
        //  int strenght => (fire + fireBonus + earth + earthBonus) / 2 + genderStrenghtBonus;

        //bonus 1 for dex for females
        // int genderDexterityBonus => CharacterGender.HasValue ? CharacterGender.Value == Gender.Male ? 0 : 1 : 0;
        //  int dexterity => water + waterBonus + genderDexterityBonus;

        //int agility => wind + windBonus;
        //int speed => agility + strenght;

        ////bonus 2 cons for females 
        //int genderConsit2utionBonus => CharacterGender.HasValue ? CharacterGender.Value == Gender.Male ? 0 : 2 : 0;
        //int constitution => earth + earthBonus + +genderConsitutionBonus;

        //int Stealth => (dark + darkBonus + agility) / 2;
        //int awarness => ((light + lightBonus + wind + windBonus) / 2) + 3;

        ////may end up using this for summons
        //int demonicAlignment => (earth + earthBonus + dark + darkBonus + fire + fireBonus + chaos + chaosBonus) / 4;
        //int angelicAlignment => (order + orderBonus + water + waterBonus + light + lightBonus + wind + windBonus) / 4;
        //int NaturalAlignment => (fire + fireBonus + chaos + chaosBonus + wind + windBonus + light + lightBonus) / 4;
        //int TechnologicalAlignment => (dark + darkBonus + earth + earthBonus + order + orderBonus + water + waterBonus) / 4;


        //int healthClassBonus => Class != null ? Class.StatBonusBonus<HealthPointsStat>() : 0;

        //int HealthPoint => 15 + (constitution * 5) - chaos + chaosBonus + healthClassBonus;

        //int stamina => (strenght + constitution) * 2;

        private void renderStatsBox() {

            if (player != null) {
                DialogHelper.WriteDialog(ConsoleColor.Red, ConsoleColor.Black, 70, 20, 50,
                $"Strenght:{player.Strenght.Max}   Dexterity:{player.Dexterity.Max}",
                $"Agility:{player.Agility.Max}   Speed:{player.Speed.Max}",
                $"Consitution:{player.Constitution.Max}",
                $"Stealth:{player.Stealth.Max}   Awarness:{player.Awareness.Max}",
                $"Hittpoints:{player.HP.Max} Stamina{player.Stamina.Max}",
                "",
                //   "Summons Affinity",
                //   $"Demonic:{demonicAlignment}   Angelic:{angelicAlignment}",
                //   $"Natural:{NaturalAlignment}   Techological:{TechnologicalAlignment}",
                "",
               "Elemental",
               $"Fire:{player.Fire.Max}   Water:{player.Water.Max}",
               $"Earth:{player.Earth.Max}   Wind:{player.Wind.Max}",
               $"Chaos:{player.Chaos.Max}   Order:{player.Order.Max}",
               $"Dark:{player.Darkness.Max}   Light:{player.Light.Max}"


                    );
            }
        }


        private string Slider(int value, string end, string start) {

            var result = "░░░░░░░░░░".ToCharArray();

            result[value] = '▓';

            return $"{start} {string.Join("", result)} {end}";

        }
        public override List<string> GetOptions() {
            return new List<string> {  $"Select Name: {player.Name}",
            $"Select Gender:{player.Gender}",
            $"Select Race: {player.Race?.Name}",
            $"Select Class: {player.Class?.Name}",
            Slider(player.Fire.MaxBase,"Fire","Water"),
            Slider(player.Chaos.MaxBase,"Chaos","Order"),
            Slider(player.Earth.MaxBase,"Earth","Wind "),
            Slider(player.Darkness.MaxBase,"Dark","Light"),
            "Begin",
              "Back" };
        }


        //  '▓', musicVolume).PadRight(10, '░'
        public override void Action() {



            switch (Selected) {
                case 0:
                    // ConsoleHelper.Write("TypeName:", ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(18, 19);
                    if (player.Name != null) {
                        ConsoleHelper.Write("".PadRight(player.Name.Length, 'X'), ConsoleColor.Black, ConsoleColor.Black);
                        Console.SetCursorPosition(18, 19);
                    }
                    Console.CursorVisible = true;
                    player.Name = Console.ReadLine();
                    Console.CursorVisible = false;
                    Console.CursorTop--;
                    Console.CursorLeft = 0;
                    ConsoleHelper.Write("XXXXXXxxxxxxxxxxxxxxxxXXXXXX", ConsoleColor.Black, ConsoleColor.Black);

                    RedrawNext();

                    break;

                case 1:
                    Exit();
                    Program.currentState = Singleton<GenderChoice>.GetInstance();
                    Console.Clear();
                    Program.currentState.RedrawNext();
                    break;

                case 2:
                    Exit();
                    Program.currentState = Singleton<RaceChoice>.GetInstance();
                    Console.Clear();
                    Program.currentState.RedrawNext();

                    break;

                case 3:
                    Exit();
                    Program.currentState = Singleton<ClassChoice>.GetInstance();

                    Console.Clear();
                    Program.currentState.RunInitiate();//.RedrawNext();

                    break;

                case 4:
                    //fire
                    break;
                case 5:
                    //fire
                    break;
                case 6:
                    //fire
                    break;
                case 7:
                    //fire
                    break;

                case 8:

                    if (player.Name != null && player.Race != null && player.Gender != null && player.Class != null) {
                        Exit();
                        Console.Clear();

                        Program.currentState = Singleton<Map>.GetInstance();
                        Program.currentState.RunInitiate();
                        var game = ((GameState.Map)Program.currentState);

                        player.Inventory.AddRange(player.Class.StartingGear);

                        player.Water.MaxBase = 10 - player.Water.MaxBase;
                        player.Wind.MaxBase = 10 - player.Earth.MaxBase;

                        player.Order.MaxBase = 10 - player.Chaos.MaxBase;
                        player.Light.MaxBase = 10 - player.Darkness.MaxBase;

                        player.ArmStarterGear();
                        Program.currentState.RedrawNext();
                    } else {
                        Console.Clear();
                        ConsoleHelper.WTF_WriteLine("NOPE!");
                        ConsoleHelper.WriteLine("Finish your character build!!!");
                        Console.Read();

                        RedrawNext();
                    }
                    break;
                case 9:

                    Back();

                    break;

            }



        }


        /// <summary>
        /// Rendering helper for slider... may never be called outside render block!!! dispbedience will be punished with firey doom!
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="yOffset"></param>
        private void RerenderSlider(int value, string start, string end, int yOffset) {
            Console.SetCursorPosition(5, yOffset);
            ConsoleHelper.Write(Slider(value, start, end), ConsoleColor.Red);
        }

        bool renderFireSliderFlag = false;
        void renderFireSlider() { RerenderSlider(player.Fire.MaxBase, "Fire", "Water", 23); renderFireSliderFlag = false; }

        bool RenderChaosSliderFlag = false;
        void RenderChaosSlider() { RerenderSlider(player.Chaos.MaxBase, "Chaos", "Order", 24); RenderChaosSliderFlag = false; }

        bool RenderEarthSliderFlag = false;
        void RenderEarthSlider() { RerenderSlider(player.Earth.MaxBase, "Earth", "Wind", 25); RenderEarthSliderFlag = false; }

        bool RenderDarkSliderFlag = false;
        void RenderDarkSlider() { RerenderSlider(player.Darkness.MaxBase, "Dark", "Light", 26); RenderDarkSliderFlag = false; }

        protected override void Decrement() {
            switch (Selected) {
                case 4:
                    if (player.Fire.MaxBase > 0) {
                        player.Fire.MaxBase--;
                        renderFireSliderFlag = true;
                    }
                    break;
                case 5:
                    if (player.Chaos.MaxBase > 0) {
                        player.Chaos.MaxBase--;
                        RenderChaosSliderFlag = true;
                    }
                    break;
                case 6:
                    if (player.Earth.MaxBase > 0) {
                        player.Earth.MaxBase--;
                        RenderEarthSliderFlag = true;
                    }
                    break;
                case 7:
                    if (player.Darkness.MaxBase > 0) {
                        player.Darkness.MaxBase--;
                        RenderDarkSliderFlag = true;
                    }
                    break;
            }
            RedrawNext();
        }



        protected override void Increment() {
            switch (Selected) {
                case 4:
                    if (player.Fire.MaxBase < 9) {
                        player.Fire.MaxBase++;
                        renderFireSliderFlag = true;
                    }
                    break;
                case 5:
                    if (player.Chaos.MaxBase < 9) {
                        player.Chaos.MaxBase++;
                        RenderChaosSliderFlag = true;
                    }
                    break;
                case 6:
                    if (player.Earth.MaxBase < 9) {
                        player.Earth.MaxBase++;
                        RenderEarthSliderFlag = true;
                    }
                    break;
                case 7:
                    if (player.Darkness.MaxBase < 9) {
                        player.Darkness.MaxBase++;
                        RenderDarkSliderFlag = true;
                    }
                    break;
            }
            RedrawNext();
        }


        protected override void Back() {
            Program.currentState = Singleton<TopMenu>.GetInstance();
            Console.Clear();
            bigTextRendered = false;
            Program.currentState.RedrawNext();
        }

        public override void Exit() {
            bigTextRendered = false;
            base.Exit();
        }


        bool bigTextRendered = false;


        /// <summary>
        /// never allow Rendering outside the render function PERIOD!!! i did that earlier and it caused me no end of problems...
        /// This structure is LAW violations will be punished with firey doom!
        /// Only Render flags are allowd!
        /// </summary>
        protected override void Render() {

            if (renderFireSliderFlag) {
                renderFireSlider();
                renderStatsBox();
            }
            if (RenderEarthSliderFlag) {
                RenderEarthSlider();
                renderStatsBox();
            }
            if (RenderChaosSliderFlag) {
                RenderChaosSlider();
                renderStatsBox();
            }
            if (RenderDarkSliderFlag) {
                RenderDarkSlider();
                renderStatsBox();
            }

            if (!bigTextRendered) {

                ConsoleHelper.AltClear();
                ConsoleHelper.WTF_WriteLine(Program.GameTitle);
                bigTextRendered = true;
                //ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
                Console.CursorLeft += 5;

                ConsoleHelper.WriteLine("CharacterCreation Options", ConsoleColor.Cyan);
                renderStatsBox();
            } else {
                Console.SetCursorPosition(0, 19);
            }


            base.Render();

        }

        Player player => playerAsBase as Player;
        AgentBase playerAsBase;


        public AgentBase GetPlayer() {
            return playerAsBase;
        }

        public T AddAgent<T>(params object[] parameters) where T : AgentBase {
            List<object> parameterList = new List<object>();
            parameterList.Add(this);
            parameterList.AddRange(parameters);

            playerAsBase = Activator.CreateInstance(typeof(T), parameterList.ToArray()) as T;
            return (T)playerAsBase;
        }

        public void Addplayer(AgentBase player) {
            this.playerAsBase = player;
        }
        
        public void Transfer(IReceptiveWorld targetWorld, AgentBase agent, object parameter = null) {
            throw new NotImplementedException();
        }
    }





}
