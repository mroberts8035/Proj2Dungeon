using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterMash
{
    public class Apprentice : Opponent
    {
        public Weapon EquippedWeapon { get; set; }

        public Apprentice(string name, int life, int maxLife, int hitChance, int block, string description, Weapon equippedWeapon)
        {
            EquippedWeapon = equippedWeapon;
            MaxLife = maxLife;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Description = description;
        }

        public override string ToString()
        {
            //return base.ToString(); 

            return string.Format("*** {0} ***\n" +
                "Life:  {1} of {2}\n" +
                "HitChance: {3}%\n" +
                "Weapon:\n{4}\n" +
                "Block: {5}\n" +
                "Description: {6}\n",

                Name, Life, MaxLife, CalcHitChance(), EquippedWeapon, Block, Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

    }
}
