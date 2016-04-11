using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using SakuraBlue.Entities.Map;
using SakuraBlue.Entities.Tiles;
using SakuraBlue.Entities.Agent;
using Omnicatz.Engine.Entities;
using SakuraBlue.Entities.Agent.Race;
using Omnicatz.AccessDenied;
using SakuraBlue.Entities.Agent.Class;

namespace SakuraBlueUnitTest {
    [TestClass]
    public class BattleTest {


  

        [TestMethod]
        public void playerAdded() {
            testWorld testworld = new testWorld();


            PlayerInstanceManager.SetPlayer(testworld.AddAgent<Player>(Gender.Female, Singleton<Human>.GetInstance(), Singleton<MageClass>.GetInstance(), "NotInstantiated", 3, 5));
            Assert.IsTrue(testworld.agents.Count == 1);
        }


       // [TestMethod]
        public void EnemyAdded() {
        //    var name = "Hostile Djin female";
         //   enemy = map.AddAgent<NPCBase>(Gender.Female, Singleton<Djin>.GetInstance(), Singleton<WarriorClass>.GetInstance(), name, 8, 25);
            //enemy.AI = new Entities.Agent.AI.HostileAI(hostileDjin);
            //enemy.IsHostile = true;
            //enemy.ArmStarterGear();
            //enemy.AddPartyMember(Gender.Male, Singleton<Entities.Agent.Race.Narugan>.GetInstance(), Singleton<Entities.Agent.Class.MageClass>.GetInstance(), "Narugan Mage");


          //  Assert.IsTrue(map.Agents.Count == 2);
        //    Assert.IsTrue((map.Agents.FindLast(n => n.GetType() == typeof(NPCBase)) as NPCBase).Name == name);

        }

    }
}
