using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollPlayGame3._0
{
    public class PlayerCharacter : Character
    {
        public int Luck;
        public int XP;
        public int Level;
        public double Gold = 0;


        public PlayerCharacter()
        {
        }

        /// <summary>
        /// Advanced constructor for PlayerCharacter where the properties are given by the rules.
        /// </summary>
        public PlayerCharacter
     (string name, int attackPointBase, int defensePointBase, int maxHealthPointBase, int luckBase, int attackPointRoll, int defensePointRoll, int maxHealthPointRoll, int luckRoll)
        : base(name, attackPointBase, defensePointBase, maxHealthPointBase, attackPointRoll, defensePointRoll, maxHealthPointRoll)
        {
            Luck = luckBase + luckRoll;
            XP = 0;
            Level = 1;
            Gold = 10;     
        }

       

        /// <summary>
        /// Restores Actual health point to maximum.
        /// </summary>
        public void Rest()
        {
            ActualHealthPoint = MaxHealthPoint;
        }

        public void AddXP(int xp)
        {
            XP += xp;
        }
    }
}