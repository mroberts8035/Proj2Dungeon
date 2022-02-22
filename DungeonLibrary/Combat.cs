using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DungeonLibrary
{
    public class Combat
    {

        //This class will not have fields, properties, or custom constructors. As it is just a container for different methods. We are not constructing a Combat object

        public static void DoAttack(Character attacker, Character defender) //One way attack, attack of opportunity
        {
            //Get a random number from 1 - 100
            Random rand = new Random();
            int diceRool = rand.Next(1, 101);
            Thread.Sleep(30);

            if (diceRool <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //If the attacker hit, calculate the damage
                int damageDealt = attacker.CalcDamage();

                //Assign the damage
                defender.Life -= damageDealt;

                //Write result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }//end if
            else
            {
                //The attacker missed
                Console.WriteLine("{0} missed!", attacker.Name);
            }//end else
        }//end DoAttack

        public static void DoBattle(Player player, Opponent monster) //Combat in both directions
        {
            //Player has high initiative (benefit of attacking first) (if initiative is a stat then compare it here first)
            DoAttack(player, monster);

            //Combat happens turn based, Monster attacks second -- if they are still alive (We are doing this by performing a check of the monsters life

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if

        }//end DoBattle

    }//end class
}
