using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollPlayGame3._0
{
    public class FightRoundProperties
    { 
        public int RoundNumber;

        public PlayerCharacter Player;

        public Character Enemy;

        //True if Player could hit the Enemy.
        public bool PlayerHitEnemy;

        //True if Enemy could hit the Player.
        public bool EnemyHitPlayer;
    }
}