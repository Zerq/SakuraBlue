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

namespace SakuraBlue.GameState.Menu {

    /// <summary>
    /// Character Creation Screen
    /// </summary>
    public class NewGame : GameMenuBaseState {
        public NewGame(LockToken token) : base(token) {}


        public string Name = null;
        public Entities.Agent.Gender? CharacterGender = null;
        public RaceBase Race = null;
        public AgentClassBase Class = null;

        int fireBonus => Race != null ? Race.StatBonusBonus<FireStat>() : 0;
        int waterBonus => Race != null ? Race.StatBonusBonus<WaterStat>() : 0;
        int earthBonus => Race != null ? Race.StatBonusBonus<EarthStat>() : 0;
        int windBonus => Race != null ? Race.StatBonusBonus<WindStat>() : 0;

        int chaosBonus => Race != null ? Race.StatBonusBonus<ChaosStat>() : 0;
        int orderBonus => Race != null ? Race.StatBonusBonus<Orderstat>() : 0;
        int lightBonus => Race != null ? Race.StatBonusBonus<LightStat>() : 0;
        int darkBonus => Race != null ? Race.StatBonusBonus<DarkStat>() : 0;


        int fire; /*vs*/ int water => 10 - fire;
        int chaos; /*vs*/ int order => 10 - chaos;
        int earth; /*vs*/ int wind => 10 - earth;
        int dark;  /*vs*/ int light => 10 - dark;


        //if null -> 0  if male -> 3 if female 0
        int genderStrenghtBonus => CharacterGender.HasValue ? CharacterGender.Value == Gender.Male ? 3 : 0 : 0;
        int strenght => (fire + fireBonus + earth + earthBonus) / 2 + genderStrenghtBonus;

        //bonus 1 for dex for females
        int genderDexterityBonus => CharacterGender.HasValue ? CharacterGender.Value == Gender.Male ? 0 : 1 : 0;
        int dexterity => water + waterBonus + genderDexterityBonus;

        int agility => wind + windBonus;
        int speed => agility + strenght;

        //bonus 2 cons for females 
        int genderConsitutionBonus => CharacterGender.HasValue ? CharacterGender.Value == Gender.Male ? 0 : 2 : 0;
        int constitution => earth + earthBonus + +genderConsitutionBonus;

        int Stealth => (dark + darkBonus + agility) / 2;
        int awarness => ((light + lightBonus + wind + windBonus) / 2) + 3;

        //may end up using this for summons
        int demonicAlignment => (earth + earthBonus + dark + darkBonus + fire + fireBonus + chaos + chaosBonus) / 4;
        int angelicAlignment => (order + orderBonus + water + waterBonus + light + lightBonus + wind + windBonus) / 4;
        int NaturalAlignment => (fire + fireBonus + chaos + chaosBonus + wind + windBonus + light + lightBonus) / 4;
        int TechnologicalAlignment => (dark + darkBonus + earth + earthBonus + order + orderBonus + water + waterBonus) / 4;


        int healthClassBonus => Class != null ? Class.StatBonusBonus<HealthPointsStat>() : 0;

        int HealthPoint => 15 + (constitution * 5) - chaos + chaosBonus + healthClassBonus;

        int stamina => (strenght + constitution) * 2;

        private void renderStatsBox(){
       

            DialogHelper.WriteDialog(ConsoleColor.Red, ConsoleColor.Black, 70, 20, 50,
            $"Strenght:{strenght}   Dexterity:{dexterity}",
            $"Agility:{agility}   Speed:{speed}",
            $"Consitution:{constitution}",
            $"Stealth:{Stealth}   Awarness:{awarness}",
            $"Hittpoints:{HealthPoint} Stamina{stamina}",
            "",
            "Summons Affinity",
            $"Demonic:{demonicAlignment}   Angelic:{angelicAlignment}",
            $"Natural:{NaturalAlignment}   Techological:{TechnologicalAlignment}",
            "",
           "Elemental",
           $"Fire:{fire + fireBonus}   Water:{water + waterBonus}",
           $"Earth:{earth +earthBonus}   Wind:{wind + windBonus}",
           $"Chaos:{chaos +chaosBonus}   Order:{order + orderBonus}",
           $"Dark:{dark + darkBonus}   Light:{light + lightBonus}"


                );
        }


        private string Slider(int value, string end, string start) {

            var result = "░░░░░░░░░░".ToCharArray();

            result[value] = '▓';

            return $"{start} {string.Join("", result)} {end}";
           
        }
        public override List<string> GetOptions() {
            return new List<string> {  $"Select Name: {Name}",
            $"Select Gender:{CharacterGender}",
            $"Select Race: {Race?.Name}",
            $"Select Class: {Class?.Name}",
            Slider(fire,"Fire","Water"),
            Slider(chaos,"Chaos","Order"),
            Slider(earth,"Earth","Wind "),
            Slider(dark,"Dark","Light"),
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
                    if (Name != null)
                    {
                        ConsoleHelper.Write("".PadRight(Name.Length, 'X'), ConsoleColor.Black, ConsoleColor.Black);
                        Console.SetCursorPosition(18, 19);
                    }
                    Console.CursorVisible = true;
                        Name = Console.ReadLine();
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
                   
                    if (this.Name != null && this.Race != null && this.CharacterGender != null && this.Class != null) {
                        Exit();
                        Console.Clear();

                        Program.currentState = Singleton<Map>.GetInstance();
                        Program.currentState.RunInitiate();
                        var game = ((GameState.Map)Program.currentState);

                        var player = PlayerInstanceManager.GetPlayer(game.map) as NPCBase;
                        player.Class = Class;
                        player.Name = Name;
                        player.Race = Race;
                        player.Gender = CharacterGender.Value;
                        player.Inventory.AddRange(Class.StartingGear);


                        player.Awareness.MaxBase = awarness;
                        player.Strenght.MaxBase = strenght;


                        player.Strenght.Current = strenght;
                        player.HP.Current = healthClassBonus;
                        player.constitution.Current = constitution;
                        //   player.Stamina.Current = 
                        player.Awareness.Current = awarness;
                        player.Stealth.Current = Stealth;
                        player.Fire.Current = fire;
                        player.Water.Current = water;
                        player.Wind.Current = wind;
                        player.Earth.Current = earth;
                        player.Chaos.Current = chaos;
                        player.Order.Current = order;
                        player.Light.Current = light;
                        player.Darkness.Current = dark;



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
        void renderFireSlider() { RerenderSlider(fire, "Fire", "Water", 23); renderFireSliderFlag = false; }

        bool RenderChaosSliderFlag = false;
        void RenderChaosSlider() { RerenderSlider(chaos, "Chaos", "Order", 24); RenderChaosSliderFlag = false; }

        bool RenderEarthSliderFlag = false;
        void RenderEarthSlider() { RerenderSlider(chaos, "Earth", "Wind", 25); RenderEarthSliderFlag = false; }

        bool RenderDarkSliderFlag = false;
        void RenderDarkSlider() { RerenderSlider(chaos, "Dark", "Light", 26); RenderDarkSliderFlag = false; }

        protected override void Decrement() {
            switch (Selected) {
                case 4:
                    if (fire > 0) {
                        fire--;
                        renderFireSliderFlag = true;
                    }
                    break;
                case 5:
                    if (chaos > 0) {
                        chaos--;
                        RenderChaosSliderFlag = true;
                    }
                    break;
                case 6:
                    if (earth > 0) {
                        earth--;
                        RenderEarthSliderFlag = true;
                    }
                    break;
                case 7:
                    if (dark > 0) {
                        dark--;
                        RenderDarkSliderFlag = true;
                    }
                    break;
            }
            RedrawNext();
        }

   

        protected override void Increment() {
            switch (Selected) {
                case 4:
                    if (fire < 9) {
                        fire++;
                        renderFireSliderFlag = true;
                    }
                    break;
                case 5:
                    if (chaos < 9) {
                        chaos++;
                        RenderChaosSliderFlag = true;
                    }
                    break;
                case 6:
                    if (earth < 9) {
                        earth++;
                        RenderEarthSliderFlag = true;
                    }
                    break;
                case 7:
                    if (dark < 9) {
                        dark++;
                        RenderDarkSliderFlag = true;
                    }
                    break;
            }
            RedrawNext();
        }


        protected override void Back()
        {
            Program.currentState = Singleton<TopMenu>.GetInstance();
            Console.Clear();
            bigTextRendered = false;
            Program.currentState.RedrawNext();
        }

        public override void Exit()
        {
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

            if (!bigTextRendered)
            {
               
                ConsoleHelper.AltClear();
                ConsoleHelper.WTF_WriteLine(Program.GameTitle);
                bigTextRendered = true;
                //ConsoleHelper.Write("xxxxx", ConsoleColor.Black, ConsoleColor.Black);
                Console.CursorLeft += 5;

                ConsoleHelper.WriteLine("CharacterCreation Options", ConsoleColor.Cyan);
                renderStatsBox();
            }
            else {
                Console.SetCursorPosition(0, 19);
            }

            
            base.Render();
         
        }






    }





}
