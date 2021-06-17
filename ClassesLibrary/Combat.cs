using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(200);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                diceRoll = rand.Next(1, 101);
                if (diceRoll <= (attacker.HitChance / 2))
                {
                    int damageDealt = attacker.CalcCrit();
                    defender.Life -= damageDealt;

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Thread.Sleep(100);
                    Console.ResetColor();
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine("A critical shot!");
                    Console.WriteLine("{0} hit {1} for {2} damage!",
                        attacker.Name, defender.Name, damageDealt);
                    Console.ResetColor();
                }
                else
                {
                    int damageDealt = attacker.CalcDamage();
                    defender.Life -= damageDealt;

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Thread.Sleep(100);
                    Console.ResetColor();
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine("{0} hit {1} for {2} damage!",
                        attacker.Name, defender.Name, damageDealt);
                    Console.ResetColor();
                }

            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }
        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
