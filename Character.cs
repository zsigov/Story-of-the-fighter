using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollPlayGame3._0
{
    public class Character
    {
        public string Name;

        public int AttackPoint;

        public int DefensePoint;

        public int MaxHealthPoint;

        public int ActualHealthPoint;

        public int Initiation;

        public Weapon MyWeapon;

        public Shield MyShield;

        public Armour MyArmour;

        public List<Equipment> MyEquipment;

        public bool Poisoned = false;

        public int PoisonDMGPerRound;

        public bool Alive
        {
            get
            {
                return ActualHealthPoint > 0;
            }
        }



        //DONE!!! Do create an other constructor with caractergeneration rules
        /// <summary>
        /// Basic constructor for character where we manually add the propertyes and it sets a basic equipment roll
        /// </summary>
        public Character
        (
            string name,
            int attackPoint,
            int defensePoint,
            int maxHealthPoint
        )
        {
            Name = name;
            AttackPoint = attackPoint;
            DefensePoint = defensePoint;
            MaxHealthPoint = maxHealthPoint;
            ActualHealthPoint = maxHealthPoint;
            MyWeapon = new Weapon();  // DONE!!! this could come from an empty construktor of a given class()
            MyShield = new Shield();
            MyArmour = new Armour();
        }

        /// <summary>
        /// Advanced constructor for PlayerCharacter where the properties are given by the rules.
        /// </summary>
        public Character
            (string name, int attackPointBase, int defensePointBase, int maxHealthPointBase, int attackPointRoll, int defensePointRoll, int maxHealthPointRoll)
        {
            Name = name;

            AttackPoint = attackPointBase + attackPointRoll;
            DefensePoint = defensePointBase + defensePointRoll;
            MaxHealthPoint = maxHealthPointBase + maxHealthPointRoll;

            ActualHealthPoint = MaxHealthPoint;

            MyWeapon = new Weapon();
            MyShield = new Shield();
            MyArmour = new Armour();
        }

        public Character()
        {
        }


        /// <summary>
        ///Increases ActualtHealthPoint
        /// </summary>
        public void Heal(int healthpoint)
        {
            if (healthpoint >= 0)
            {
                if ((ActualHealthPoint + healthpoint) <= MaxHealthPoint)
                {
                    ActualHealthPoint += healthpoint;
                }
                else
                {
                    ActualHealthPoint = MaxHealthPoint;
                }
            }
            else
            {
                throw new Exception("Can not handle negative integer");
            }
        }

        /// <summary>
        ///Decreases  ActualtHealthPoint
        /// </summary>
        public void Damage(int healthpoint)
        {
            if (healthpoint >= 0)
            {
                if ((ActualHealthPoint - healthpoint) <= 0)
                {
                    ActualHealthPoint = 0;
                }
                else
                {
                    ActualHealthPoint -= healthpoint;
                }
            }
            else
            {
                //We have nothing to do here. Armour protected the target.
            }
        }

        /// <summary>
        ///Sets the characters weapon. This method is used by Equipment class.
        /// </summary>
        private void SetWeapon(Weapon weapon)
        {
            MyWeapon = weapon;
        }

        /// <summary>
        ///Sets the characters shield. This method is used by Equipment class.
        /// </summary>
        private void SetShield(Shield shield)
        {
            MyShield = shield;
        }

        /// <summary>
        ///Sets the characters armour. This method is used by Equipment class.
        /// </summary>
        private void SetArmour(Armour armour)
        {
            MyArmour = armour;
        }

        /// <summary>
        ///Decides if an attack roll was succesfull, not successfull, or the caracter is dead.
        /// </summary>
        public bool? Attack(Character target, int attackRoll)
        {
            if (Alive && target.Alive)
            {
                var attackPower = AttackPoint + MyWeapon.AttackPoint + attackRoll;
                var targetDefensePower = target.DefensePoint + target.MyShield.DefensePoint;
                var potentialDamage = MyWeapon.WeaponDamage - target.MyArmour.DamageReduction;

                if (attackPower > targetDefensePower)
                {
                    target.Damage(potentialDamage);
                    return true;
                }

                return false;
            }

            return null;
        }

        /// <summary>
        /// Decides what type of equipment we set and set it to the character
        /// </summary>
        public void SetEquipment(Equipment equipment)
        {
            if (equipment is Weapon)
            {
                SetWeapon((Weapon)equipment);
            }
            if (equipment is Shield)
            {
                SetShield((Shield)equipment);
            }
            if (equipment is Armour)
            {
                SetArmour((Armour)equipment);
            }
        }

        public void RemoveEquipmentFromBackpack(Equipment equipment)
        {
            if (equipment.Quantity == 0)
            {
                MyEquipment.Remove(equipment);
            }
        }
    }
}