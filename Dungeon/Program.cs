using ClassesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Destiny: Lost Sector";

            Console.WriteLine(@"                                                  
        #@/                             /@#       
    @@@@@@@@@@@@                   @@@@@@@@@@@@   
  @@@@@@@@@@@@@@@@    @@@@@@@    @@@@@@@@@@@@@@@@ 
  @@@@@@@@@@@@@@@@   @@@@@@@@@   @@@@@@@@@@@@@@@@ 
  @@@@@@@@@@@@@@@@  #@@@@@@@@@(  @@@@@@@@@@@@@@@@ 
   (@@@@@@@@@@@@@@  #@@@@@@@@@(  @@@@@@@@@@@@@@%  
       @@@@@@@@@@@  #@@@@@@@@@(  @@@@@@@@@@@      
          @@@@@@@@  (@@@@@@@@@(  @@@@@@@@         
            @@@@@@(  @@@@@@@@@  /@@@@@@           
              @@@@@@           @@@@@@             
               @@@@@@@@@@@@@@@@@@@@@              
                @@@@@@@@@@@@@@@@@@@               
                 @@@@@@@@@@@@@@@@@                
                  @@@@@@@@@@@@@@@                 
                  @@@@@@@@@@@@@@@                 
                  @@@@@@@@@@@@@@@                 
                   @@@@@@@@@@@@@                  
                     @@@@@@@@@                    
                Destiny: Lost Sector
               Created by Ryan Palmer            ");
            Console.ReadKey(true);
            //score running total variable
            int score = 0;
            //Added intro
            //TODO - Fix Accuracy Issue
            //TODO - Add Inventories
            //TODO - Multi Enemy Battles?

            //Creating a weapon & creating the player with the weapon
            Weapon starterPistol = new Weapon(25, 45, "City Issued Handgun", 30, false, true, 
                "A simple but reliable piece, requisitioned by Commander Zavala to aid you in your mission. " +
                "Not much, but it'll get the job done");

            //This is where you could give the player some interaction to choose race/weapon
            Player player = new Player("Guardian", 40, 10, 300, 300, Race.Human, starterPistol);
            //TODO - Add character customization
            //Create the outer loop - for the room and monster
            Console.Clear();
            Console.WriteLine("It's another early morning in the the Last City. You navigate the busy" +
                " streets, making your way to the looming Tower in the distance. There's work to do.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to continue to the Tower.");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("You ascend the elevator to the top, nervous in anticipation of the day. " +
                "You've finally been cleared for active duty, and today is your first mission. Commander " +
                "Zavala, director of Vanguard Operations, has requested your audience.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to enter Zavala's office");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            //Zavala's Office
            Console.WriteLine("\"Hello Guardian\" Zavala greets.\n" +
                "\"Ready to get to work? Good. We've recieved intel from our Hunters that a " +
                "significant enemy presence has been spotted building in the EDZ. Scouts report " +
                "they've been using an old Exodus Colony ship to assemble their forces.\"\n\n" +
                "He pauses, looking out across the wilds beyond the Wall surrounding the City.\n\n" +
                "\"A little too close to home for my liking. We need you to find out what they're " +
                "planning, and clear them out.\"\n\n" +
                "A sudden rememberence crosses his face, and he hesitates a moment before continuing.\n\n" +
                "\"I understand this is your first operation in the field. So long as you remember your " +
                "training and trust in the Light, I have confidence you'll succeed. I await " +
                "your return, Guardian.\"\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to exit Zavala's office");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            //First Weapon (may replace with a visit to the Gunsmith to choose your own starting weapon)
            Console.WriteLine("Zavala calls to you as you leave to prep your ship.\n\n" +
                "\"Guardian, I almost forgot\"\n\n" +
                "He plants a firearm in your palm. A simple yet elegant sidearm used by those who defend " +
                "the Walls\n\n" +
                "\"Good luck\" He offers\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("City Issued Handgun Acquired");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to roll out");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();

            bool exit = false;

            do
            {
                //Create a monster array
                Monster fallenScavenger = new Monster("Fallen Scavenger", 100, 100, 10, 40, 5, 20,
                    "An Eliksni Vandal, searching a pile of wreckage for parts.");
                Monster fallenCaptain = new Monster("Fallen Captain", 200, 200, 50, 20, 5, 20,
                    "A high ranking Eliksni, larger than the other ether-deprieved Dregs you've seen.");
                Monster fallenServitor = new Monster("Fallen Servitor", 200, 200, 50, 20, 5, 20,
                    "A high ranking Eliksni, larger than the other ether-deprieved Dregs you've seen.");
                Monster[] monsters = { fallenScavenger, fallenCaptain, fallenScavenger };
                bool entry = true;
                Monster monster = monsters[0];
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                if (entry == true)
                {
                    Console.WriteLine("After a short flight you pull over the EDZ. On the horizon you" +
                        " spot the derelict Colony Ship. You land a ways out and move in on foot. \nThere's " +
                        "a single Fallen Vandal out front.\n\n");
                    monster = monsters[0];
                    entry = false;
                }
                else
                {
                    //Load a room
                    Console.WriteLine(GetRoom());
                    //TODO - Add movement animation
                    
                    monster = monsters[randomNbr];
                }
                //Load a room

                //Show the monster in the room
                Console.WriteLine("\nIn this room: " + monster.Name);

                //Inner loop for menu
                bool reload = false;
                
                do
                {
                    //Create a menu
                    #region Menu
                    Console.Write("\nPlease Choose an Action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //Catch the user choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    //Build our menu functionality
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //Monster is dead, could add loot, or something
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                //Reload new room and monster
                                Console.ResetColor();
                                reload = true;
                                //Add to score
                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Run Away");
                            //Handle Run Away Functionality
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;//load
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //Handle Player Info Functionality
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine("Enemy Info");
                            //Handle Monster Info Functionality
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("No one likes a quitter");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Incorrect option.");
                            break;
                    }
                    #endregion
                    //Check player life
                    if (player.Life <= 0)
                    {
                        //TODO - Add resurrection event
                        Console.WriteLine("Dude, you died!");
                        Console.WriteLine($"You defeated {score} enemies during your game!");
                        exit = true;
                    }
                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("You defeated " + score +
                " enem" + (score == 1 ? "y" : "ies")+ " of the city");

        }
        //Create a GetRoom() & plug this in the appropriate ToDo above
        private static string GetRoom()
        {
            //Create a collection of different rooms.
            string[] rooms =
            {
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                "."
            };

            //Generate a random object
            Random rand = new Random();
            //Generate a random index number using Next()
            int indexNbr = rand.Next(rooms.Length);
            //create a string for the single room that will be returned
            string room = rooms[indexNbr];
            //return the room
            return room;
        }
    }
}
