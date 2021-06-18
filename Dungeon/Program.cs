using ClassesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
              @@@@@@   ALPHA   @@@@@@             
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
            //Fixed Accuracy Issue
            //TODO - Add Inventories
            //TODO - Multi Enemy Battles?

            //Creating a weapon & creating the player with the weapon
            Weapon starterPistol = new Weapon(25, 45, "City Issued Handgun", 30, false, true,
                "A simple but reliable piece, requisitioned by Commander Zavala to aid you in your mission. " +
                "Not much, but it'll get the job done");

            Player player = new Player("Guardian", 40, 10, 300, 300, Race.Human, TClass.Titan, starterPistol, 0, 40, 20);
            //TODO - Add character customization
            //Create the outer loop - for the room and monster
            Console.Clear();
            Console.WriteLine("You awaken. Today's a big day. Very big. So big you seem to have forgotten" +
                " your own name.\n");
            Console.WriteLine("What was it again?\n");
            player.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Well " + player.Name + ", today is certainly a big day. Grab your things" +
                " and splash some water in your face. What do you see in the mirror?\n");
            //Add race selection
            bool rSelected = true;
            do
            {
                //Create a menu

                Console.Write("\nSelect a Race:\n" +
                    "H)uman: Natives to Earth, the last remnants stand in the Last City.\n\n" +
                    "E)xo: Machines derived from human minds, built for a war long forgotten.\n\n" +
                    "A)woken: Humans who fell into a singularity, forever changing their being.\n\n" +
                    "F)allen: An Eliksni, once Traveler's Chosen. Now aids the City and Humanity.\n\n");

                //Catch the user choice
                ConsoleKey userCChoice = Console.ReadKey(true).Key;
                Console.Clear();

                //Build our menu functionality
                switch (userCChoice)
                {
                    case ConsoleKey.H:
                        player.CharacterRace = Race.Human;
                        rSelected = false;
                        break;

                    case ConsoleKey.E:
                        player.CharacterRace = Race.Exo;
                        rSelected = false;
                        break;

                    case ConsoleKey.A:
                        player.CharacterRace = Race.Awoken;
                        rSelected = false;
                        break;

                    case ConsoleKey.F:
                        player.CharacterRace = Race.Fallen;
                        rSelected = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect option.");
                        break;
                }
            } while (rSelected);
            Console.WriteLine("It's another early morning in the the Last City, " + player.CharacterRace + ". You navigate the busy" +
        " streets, making your way to the looming Tower in the distance. There's work to do.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to continue to the Tower.");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("As you enter the Tower, there's some Requisitions here already prepared for you.\n" +
                "Zavala must have called them for you ahead of time. Which kit do you grab?");
            bool cSelected = true;

            do
            {
                //Create a menu

                Console.Write("\nSelect a Class:\n" +
                    "T)itan: A steadfast class of warriors who form the frontline. Solid, large, unbroken.\n\n" +
                    "W)arlock: An elegant class of scholars who bend the reality around them. Intelligent, thoughtful, forward-thinking.\n\n" +
                    "H)unter: An agile class of scouts who strike from the shadows. Fast, adaptable, lethal.\n\n");

                //Catch the user choice
                ConsoleKey userRChoice = Console.ReadKey(true).Key;
                Console.Clear();

                //Build our menu functionality
                switch (userRChoice)
                {
                    case ConsoleKey.T:
                        player.PClass = TClass.Titan;
                        player.MaxLife = 400;
                        player.Life = 400;
                        cSelected = false;
                        break;

                    case ConsoleKey.W:
                        player.PClass = TClass.Warlock;
                        player.Recovery = 30;
                        cSelected = false;
                        break;

                    case ConsoleKey.H:
                        player.PClass = TClass.Hunter;
                        player.HitChance = 45;
                        player.Block = 15;
                        cSelected = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect option.");
                        break;
                }
                //Added class selection
            } while (cSelected);

            Console.WriteLine("You ascend the elevator to the top, nervous in anticipation of the day. " +
            "You've finally been cleared for active duty, and today is your first mission. Commander " +
            "Zavala, director of Vanguard Operations, has requested your audience.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to enter Zavala's office");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            //Zavala's Office
            Console.WriteLine("\"" + player.PClass + ".\" Zavala greets.\n" +
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
            bool finalBoss = false;
            bool win = false;
            bool exit = false;
            bool entry1 = true;
            bool talk = true;
            do
            {
                //Create a monster array
                Monster fallenScavenger = new Monster("Fallen Scavenger", 100, 100, 50, 10, 5, 20,
                    "An Eliksni Vandal, searching a pile of wreckage for parts.");
                Monster fallenCaptain = new Monster("Fallen Captain", 200, 200, 50, 5, 5, 30,
                    "A high ranking Eliksni, larger than the other ether-deprieved Dregs you've seen.");
                Monster fallenServitor = new Monster("Fallen Servitor", 1000, 1000, 60, 5, 5, 50,
                    "An Eliksni Servitor, one of their machine gods that gives them strength.");
                Monster[] monsters = { fallenScavenger, fallenCaptain, fallenServitor };

                Monster monster = monsters[0];
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length - 1);

                if (entry1 == true)
                {
                    Console.WriteLine("After a short flight you pull over the EDZ. On the horizon you" +
                        " spot the derelict Colony Ship. You land a ways out and move in on foot. \nThere's " +
                        "a single Fallen Vandal out front.\n\n");
                    monster = monsters[0];

                }
                if (finalBoss)
                {
                    Console.WriteLine("You've arrived at the helm of the ship. Before you lies the source" +
                        " of this corruption. Time to put an end to this.");
                    monster = monsters[2];
                }
                if (!finalBoss && !entry1)
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
                        "T) Talk with Ghost\n" +
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
                                Console.WriteLine("\nYou killed the {0}!\n", monster.Name);
                                //Reload new room and monster
                                Console.ResetColor();
                                reload = true;
                                //Add to score
                                if (entry1)
                                {
                                    entry1 = false;
                                }

                                if (finalBoss)
                                {
                                    win = true;
                                }
                                score++;
                                player.Life += player.Recovery;
                                talk = true;
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

                        case ConsoleKey.T:
                            if (talk)
                            {
                                Console.WriteLine("You check in on Ghost\n\n");
                                //Handle Monster Info Functionality
                                Console.WriteLine("How are you hanging in there? Don't lose hope yet!");
                                player.GhostConfidence += 30;
                                talk = false;
                            }
                            else
                            {
                                Console.WriteLine("You just spoke to Ghost, you have to deal with this" +
                                    " threat in front of you first!");
                            }
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("Retreat to the ship! You get out while you still can.");
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
                        //TODO - Add Ghost relationship stats, talking with your ghost will
                        //increase it's confidence to more reliably resurrect you.
                        Console.WriteLine("You've fallen in battle. It's up to your Ghost to save you now");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Call to them.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        Random believe = new Random();
                        int ressurection = believe.Next(0, 75);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Thread.Sleep(100);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Thread.Sleep(100);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Thread.Sleep(100);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Thread.Sleep(2000);
                        if (ressurection < player.GhostConfidence)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Yellow; //TODO - What.
                            Console.Beep(600, 700);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Your Ghost rushes to your side, reviving you!\n" +
                                "Eyes up, Guardian!");
                            player.Life = player.MaxLife;
                        }
                        else
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Beep(200, 600);
                            Thread.Sleep(500);
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Your Ghost was unable to make it to you. You are lost" +
                            " to darkness.");

                            exit = true;
                        }


                    }
                    if (score == 5)
                    {
                        finalBoss = true;
                    }
                    if (win)
                    {
                        Console.WriteLine("The machine whirs and stutters, before dramatically spinning" +
                            " and exploding in an astounding fashion. \n\nMission complete. The City is safe..." +
                            " for now.\n\n\n");
                        Console.WriteLine("Thanks for playing the Alpha of my game! This is just" +
                            " a taste of things to come. Upcoming features include:\n" +
                            "-A Narrative-driven adventure to find out what's going on within the ship\n" +
                            "-Tons of new weapons for you to find and equip\n" +
                            "-An XP system for advancing your skills\n" +
                            "-More unique enemies\n" +
                            "-Mechanic-Based battles that add a layer of strategy\n" +
                            "-A puzzle-like final boss\n" +
                            "-Battles involving multiple enemies at once\n");
                        exit = true;
                    }
                } while (!exit && !reload);
            } while (!exit);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You defeated " + score +
                " enem" + (score == 1 ? "y" : "ies") + " of the city");

        }
        //Create a GetRoom() & plug this in the appropriate ToDo above
        private static string GetRoom()
        {
            //Create a collection of different rooms.
            string[] rooms =
            {
                "A group of Fallen crowd in the corner. One of them singles you out.",
                "You push forward into a strangly familiar room. Unfortunately no time for reminiscing, a Fallen attacks!.",
                "It's truly disheartening to see what's become of the ship. Luckily an oncoming Fallen moves in to provide some therapy.",
                "The data room. Could be useful information to grab after dealing with the guards.",
                "A Fallen seems to have found a new toy. Might as well give them a target to test it on.",
                "More Fallen, what a surprise.",
                "These rooms are kinda repetitive, maybe the developer should add some new mechanics."
            };

            //Generate a random object
            Random rand = new Random();
            //Generate a random index number using Next()
            string room = "You shouldn't be reading this.";
            int secret = rand.Next(1, 50);
            if (secret == 42)
            {
                room = rooms[rooms.Length - 1];
            }
            else
            {
                room = rooms[rand.Next(rooms.Length - 1)];
            }

            //create a string for the single room that will be returned
            //return the room
            return room;
        }
    }
}
//TODO - Add class selection T/health W/Regen H/Evasion
//do
//            {
//                //Create a menu
//                #region Menu
//                Console.Write("\nSelect a Race:\n" +
//                    "T)itan: A steadfast class of warriors who form the frontline. Solid, large, unbroken.\n\n" +
//                    "W)arlock: An elegant class of scholars who bend the reality around them. Intelligent, thoughtful, forward-thinking.\n\n" +
//                    "H)unter: An agile class of scouts who strike from the shadows. Fast, adaptable, lethal.\n\n");

//                //Catch the user choice
//                ConsoleKey userChoice = Console.ReadKey(true).Key;
//Console.Clear();

//                //Build our menu functionality
//                switch (userChoice)
//                {
//                    case ConsoleKey.T:
//                        player.MClass = "Titan"
//                        break;

//                    case ConsoleKey.W:
//                        player.MClass = "Warlock"
//                        break;

//                    case ConsoleKey.H:
//                        player.MClass = "Hunter"
//                        break;

//                    default:
//                        Console.WriteLine("Incorrect option.");
//                        break;
//                }
