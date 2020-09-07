using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollPlayGame3._0
{
    public class Equipment
    {
        public string Name;

        public double GoldValue;

        public double Weight;

        public int Quantity;


        /// <summary>
        /// Empty constructor for Equipment
        /// </summary>
        public Equipment()
        {

        }

        /// <summary>
        /// Give a name to an equipment
        /// </summary>
        public Equipment(string name)
        {
            Name = name;
        }

        public Equipment(string name, double gold, double weight)
        {
            Name = name;
            GoldValue = gold;
            Weight = weight;
            Quantity = 1;
        }


    }

    public class Weapon : Equipment
    {
        public int WeaponDamage;

        public int AttackPoint;

        public bool Poisoned = false;

        public int PoisonDMG;
        /// <summary>
        /// Set the basic weapon equipment
        /// </summary>
        public Weapon()
        {
            Name = "Unarmed";
            AttackPoint = 0;
            WeaponDamage = 0;
        }

        /// <summary>
        /// Set the advanced weapon equipment given by the programmer
        /// </summary>
        public Weapon(string name, int damage, int attackPoint) : base(name)
        {
            Name = name;
            WeaponDamage = damage;
            AttackPoint = attackPoint;
        }
    }

    public class Shield : Equipment
    {
        public int DefensePoint;

        /// <summary>
        /// Set the basic Shield equipment
        /// </summary>
        public Shield()
        {
            Name = "Unshielded";
            DefensePoint = 0;
        }

        /// <summary>
        /// Set the advanced Shield equipment given by the programmer
        /// </summary>
        public Shield(string name, int defense) : base(name)
        {
            Name = name;
            DefensePoint = defense;
        }
    }

    public class Armour : Equipment
    {
        public int DamageReduction;

        /// <summary>
        /// Set the basic Armour equipment
        /// </summary>
        public Armour()
        {
            Name = "Clothes";
            DamageReduction = 0;
        }

        /// <summary>
        /// Set the advanced Armour equipment given by the programmer
        /// </summary>
        public Armour(string name, int damagereduction) : base(name)
        {
            Name = name;
            DamageReduction = damagereduction;
        }
    }

    public class Potion : Equipment
    {
        public Potion() { }

        public Potion(string name, double gold, double weight) : base(name, gold, weight)
        {

        }
    }

    public class HealingPotion : Potion
    {
        public int HealAmount;

        public HealingPotion(int plusHP)
        {
            HealAmount = plusHP;
        }

        public HealingPotion(int plusHP, string name, double gold, double weight) : base(name, gold, weight)
        {
            HealAmount = plusHP;
            Name = name;
            GoldValue = gold;
            Weight = weight;
        }

        public static void UseHealingPotion(Character player, HealingPotion healingPotion)
        {
            player.Heal(healingPotion.HealAmount);
        }

    }

    public class Poison : Potion
    {
        public int PoisonDamage;


        public Poison(int poisonDamage, string name, double gold, double weight) : base(name, gold, weight)
        {
            PoisonDamage = poisonDamage;
            Name = name;
            GoldValue = gold;
            Weight = weight;
        }

        public static void PoisonWeapon(Character player, Poison poison)
        {
            player.MyWeapon.Poisoned = true;
            player.MyWeapon.PoisonDMG = poison.PoisonDamage;
        }
    }
}