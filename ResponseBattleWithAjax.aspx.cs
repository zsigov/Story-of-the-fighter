using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;



namespace RollPlayGame3._0
{
    //This page is called every time when jQuery nextRound() is requested.
    public partial class ResponseBattleWithAjax : System.Web.UI.Page
    {
        //Create object to collect fight round properties.
        FightRoundProperties roundProperties = new FightRoundProperties();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create characters.
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"]; 

            Character enemy = (Character)Session["Enemy"];

            //Set roundnumber
            roundProperties.RoundNumber = (int)Session["RoundNumber"] + 1;
            Session["RoundNumber"] = roundProperties.RoundNumber;

            //Set characters for fight.   
            roundProperties.Player = player1;
            roundProperties.Enemy = enemy;

            //Fight actions and save results.   
            SetFightersInitiation(roundProperties);
            FightThisRound(roundProperties);

            //Put characters into Session variables.
            Session["player1"] = player1;
            Session["Enemy"] = enemy;

            //Serialise the response and send it to the Response object
            JavaScriptSerializer js = new JavaScriptSerializer();
            string JsonString = js.Serialize(roundProperties);
            Response.Write(JsonString);
        }

        //Set fighters initiation.
        public void SetFightersInitiation(FightRoundProperties round)
        {
            Random initiationRoll = new Random();
            round.Player.Initiation = initiationRoll.Next(1, 10);
            Thread.Sleep(100);
            round.Enemy.Initiation = initiationRoll.Next(1, 10);
        }

        //Playes the fight round and saves the results.
        public void FightThisRound(FightRoundProperties round)
        {
            if (round.Player.Initiation >= round.Enemy.Initiation)
            {
                round.PlayerHitEnemy = FightRoundBetweenCharacters(round.Player, round.Enemy);
                round.EnemyHitPlayer = FightRoundBetweenCharacters(round.Enemy, round.Player);
            }
            else
            {
                round.EnemyHitPlayer = FightRoundBetweenCharacters(round.Enemy, round.Player);
                round.PlayerHitEnemy = FightRoundBetweenCharacters(round.Player, round.Enemy);
            }
        }

        //Playes one attack action and returns if the attacker succesfully hit the defender.
        //Old version for simple fight without equipments. -- Not in use anymore.
        public bool Attack(Character attacker, Character defender)
        {
            if (attacker.Alive)
            {
                Random attackRoll = new Random();
                attacker.AttackPoint = attacker.AttackPoint + attackRoll.Next(1, 12);
                if (attacker.AttackPoint > defender.DefensePoint)
                {
                    defender.Damage(attacker.MyWeapon.WeaponDamage);              
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { 
                return false;
            }
        }

        //Playes one attack action included shield armour and poison and returns if the attacker succesfully hit the defender.
        private bool FightRoundBetweenCharacters(Character attacker, Character defender)
        {
            Random attackRoll = new Random();
            int defenderDefensepoint;
            int AttackerAttackPoint = attacker.AttackPoint + attacker.MyWeapon.AttackPoint + attackRoll.Next(1, 7);
            if (defender.MyShield != null)
            {
                 defenderDefensepoint = defender.DefensePoint + defender.MyShield.DefensePoint;
            }
            else
            {
                 defenderDefensepoint = defender.DefensePoint;
            }

            if (attacker.Alive)
            {
                if (AttackerAttackPoint >= defenderDefensepoint)
                {
                    try
                    {
                        defender.Damage(attacker.MyWeapon.WeaponDamage - defender.MyArmour.DamageReduction);
                    }
                    catch
                    {
                        defender.Damage(attacker.MyWeapon.WeaponDamage);
                    }

                    if (attacker.MyWeapon.Poisoned == true)
                    {
                        defender.Poisoned = true;
                        defender.PoisonDMGPerRound = attacker.MyWeapon.PoisonDMG;
                        attacker.MyWeapon.Poisoned = false;
                    }
                    if (defender.Poisoned == true)
                    {
                        defender.Damage(defender.PoisonDMGPerRound);
                    }

                    return true;
                }
                else
                {
                    if (defender.Poisoned == true)
                    {
                        defender.Damage(defender.PoisonDMGPerRound);
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}