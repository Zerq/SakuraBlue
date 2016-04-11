using SakuraBlue.Entities.Agent.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakuraBlue.Entities.Map;
using SakuraBlue.Entities.Agent.Class;
using SakuraBlue.Entities.Items;
using SakuraBlue.Entities.Agent.Stats;

namespace SakuraBlue.Entities.Agent {
    public class NPCBase : AgentBase {

        /// <summary>
        ///  Create Minion
        /// </summary>
        /// 
 

        private NPCBase(Gender gender, RaceBase race, Class.AgentClassBase @class, string name, NPCBase Leader) :this(Leader.Grid,gender,race,@class,name,0,0) {
            if (Leader.PartyMembers == null) {
                Leader.PartyMembers = new List<NPCBase>();
            }
            IsPartyMember = true;
            Leader.PartyMembers.Add(this); /// DA DA DA DA! X joined y's party :p
        }


        /// <summary>
        /// Create Leader
        /// </summary>
        public NPCBase(ParentGrid grid, Gender gender, RaceBase race, Class.AgentClassBase @class, string name, int x, int y) : base(grid) {
            this.X = x;
            this.Y = y;
            this.Race = race;
            this.Name = name;
            this.Gender = gender; 
            this.Class = @class;


            Strenght = new StrenghtStat(this);
            HP = new HealthPointsStat(this);   
            constitution = new ConstitutuinStat(this);
            Stamina = new StaminaStat(this);
            Awareness = new AwarnessStat(this);
            Stealth = new StealthStat(this);
            Fire = new FireStat(this);
            Water = new WaterStat(this);
            Wind = new WindStat(this);
            Earth = new EarthStat(this);
            Chaos = new ChaosStat(this);
            Order = new Orderstat(this);
            Light = new LightStat(this);
            Darkness = new DarkStat(this);


            //change later baced on race maybe?
            this.HP.MaxBase = 5;
            this.HP.Current = this.HP.Max;

            this.Stamina.MaxBase = 5;
            this.Stamina.Current = this.Stamina.Max;

            this.Awareness.MaxBase = 5;
            this.Awareness.Current = this.Awareness.Max;        

        }
       
       

        public void AddPartyMember(Gender gender, RaceBase race, Class.AgentClassBase @class, string name) {
            new NPCBase( gender,  race, @class,  name, this);
        }

        public bool IsFrontRow { get; set; }

       public  List<NPCBase> PartyMembers { get;  private set; }

        public bool IsPartyMember { get; private set; }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public RaceBase Race { get; set; }
        public AgentClassBase Class { get; set; }

        public Stats.StrenghtStat Strenght { get; set; }
        public Stats.HealthPointsStat HP { get; set; }
        public Stats.ConstitutuinStat constitution { get; set; }
        public Stats.StaminaStat Stamina { get; set; }
        public Stats.AwarnessStat Awareness { get; set; }
        public Stats.StealthStat Stealth { get; set; }

        public Stats.FireStat Fire { get; set; }
        public Stats.WaterStat Water { get; set; }
        public Stats.WindStat Wind { get; set; }
        public Stats.EarthStat Earth { get; set; }
        public Stats.ChaosStat Chaos { get; set; }
        public Stats.Orderstat Order { get; set; }
        public Stats.LightStat Light { get; set; }
        public Stats.DarkStat Darkness { get; set; }



        public void ArmStarterGear() {
            foreach (Gear gear in this.Inventory) {
                gear.Equip(this); // equip starting equipment
            }
        }



        public bool IsHostile { get; set; }
        public override string Graphics {
            get {
                if (Gender == Gender.Male) {
                    return $"{Race.Character}m";
                } else {
                    return $"{Race.Character}f";
                }
            }
        }
        public override ConsoleColor ColorA {
            get {
                return Race.Color;
            }
        }
        public override ConsoleColor ColorB {
            get {
                return ConsoleColor.White;
            }
        }
        public override ConsoleColor ColorA2 {
            get {

                return Class.Color;
            }
        }
        public override ConsoleColor ColorB2 {
            get {
                if (IsHostile) {
                    return ConsoleColor.DarkRed;
                } else {
                    return ConsoleColor.DarkGreen;
                }
            }
        }
        public virtual ArtificalInteligence<NPCBase> AI { get; set; }
    }
}
