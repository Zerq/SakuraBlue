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
using SakuraBlue.Entities.Agent.AI;
using SakuraBlue.GameState.BattleState;
using SakuraBlue.GameState.BattleState.Battlefields;

namespace SakuraBlueUnitTest {
    [TestClass]
    public class BattleTest {


  

        [TestMethod]
        public void playerAdded() {
            testWorld testworld = new testWorld();
            PlayerInstanceManager.SetPlayer(testworld.AddAgent<Player>(Gender.Female, Singleton<Human>.GetInstance(), Singleton<MageClass>.GetInstance(), "NotInstantiated", 3, 5));
            Assert.IsTrue(testworld.Agents.Count == 1);
        }


        [TestMethod]
        public void EnemyAdded() {

            testWorld testworld = new testWorld();
            PlayerInstanceManager.SetPlayer(testworld.AddAgent<Player>(Gender.Female, Singleton<Human>.GetInstance(), Singleton<MageClass>.GetInstance(), "NotInstantiated", 3, 5));
            Assert.IsTrue(testworld.Agents.Count == 1);

            var name = "Hostile Djin female";
            var enemy = testworld.AddAgent<NPCBase>(Gender.Female, Singleton<Djin>.GetInstance(), Singleton<WarriorClass>.GetInstance(), name, 8, 25);
            enemy.AI = new HostileAI(enemy);
            enemy.IsHostile = true;
            enemy.ArmStarterGear();
            enemy.AddPartyMember(Gender.Male, Singleton<Narugan>.GetInstance(), Singleton<MageClass>.GetInstance(), "Narugan Mage");


             Assert.IsTrue(testworld.Agents.Count == 2);
             Assert.IsTrue((testworld.Agents.FindLast(n => n.GetType() == typeof(NPCBase)) as NPCBase).Name == name);

        }


        [TestMethod]
        public void InitializeBattle() {

            testWorld testworld = new testWorld();
            var player = testworld.AddAgent<Player>(Gender.Female, Singleton<Human>.GetInstance(), Singleton<MageClass>.GetInstance(), "NotInstantiated", 3, 5);
            PlayerInstanceManager.SetPlayer(player);
            Assert.IsTrue(testworld.Agents.Count == 1);

            var name = "Hostile Djin female";
            var enemy = testworld.AddAgent<NPCBase>(Gender.Female, Singleton<Djin>.GetInstance(), Singleton<WarriorClass>.GetInstance(), name, 8, 25);
            enemy.AI = new HostileAI(enemy);
            enemy.IsHostile = true;
            enemy.ArmStarterGear();
            enemy.AddPartyMember(Gender.Male, Singleton<Narugan>.GetInstance(), Singleton<MageClass>.GetInstance(), "Narugan Mage");


            BattleFaction goodGuys = new BattleFaction(player);
            BattleFaction badGuys = new BattleFaction(enemy);
            goodGuys.Enemies.Add(badGuys);
            badGuys.Enemies.Add(goodGuys);

            Battlefield field = Singleton<Grasslands>.GetInstance();
            Battle battle = Singleton<Battle>.GetInstance();
            battle.NewBattle(field, new BattleFaction[] { goodGuys, badGuys });
          


          
        }



    }
}
