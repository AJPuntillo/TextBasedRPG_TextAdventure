using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameLoop = 1;

            while(gameLoop != 0)
            {
                Console.WriteLine("Enter 1 to run or 0 to exit");
                string toStringValue = Console.ReadLine();

                if (toStringValue == "1")
                {
                    gameMenu();
                }
                else if (toStringValue == "0")
                {
                    int.TryParse(toStringValue, out gameLoop);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
        }

        public static void gameMenu()
        {
            Console.Clear();
            Console.WriteLine("Game Menu");
            Console.WriteLine("---------");
            Console.WriteLine("Would you like to start a new game?");
            Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
            //Display instructions about the game

            int menuLoop = 1;

            while(menuLoop != 0)
            {
                string newGame = Console.ReadLine();
                newGame = newGame.ToUpper();

                if (newGame == "PLAY")
                {
                    gameMain();
                    //Send to main game function
                    //Main game function contains every if statement
                }
                else if (newGame == "QUIT")
                {
                    Console.Clear();
                    int.TryParse(newGame, out menuLoop);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                    Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                }
            }
            
        }

        //Main game function > contains all if statements/choices the player must make
        public static void gameMain()
        {
            Console.Clear();
            player newPlayer = new player();

            string userName = "";
            string playerChoice = "";

            //Welcome screen
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to Text Adventure!");
            Console.WriteLine("==========================\n");
            Console.WriteLine("Text Adventure is a text-based RPG that allows you to make decisions when presented with various encounters.");
            Console.WriteLine("Your adventurer gains levels for beating enemies in combat. You can only defeat enemies who have a lower attack than yours.");
            Console.WriteLine("Karma is given and taken away based on your choices.");
            Console.WriteLine("You can view your adventurer's stats at all times by inputting \"C\".");
            Console.WriteLine("By inputting \"Menu\" you can quit the game or start over.");

            Console.WriteLine("\nNow let's begin!");
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter your adventurer's name: ");
            userName = Console.ReadLine();
            newPlayer.playerName = userName; //Calling the playerName variable from the player class << must go after the user inputs their name so it can properly set the desired name to the player class
            Console.WriteLine("\nWelcome {0}.", userName);
            Console.WriteLine("\nIn ancient times...");
            Console.WriteLine("There were mighty artifacts that contained destructive powers. Many wars were fought over these artifacts, many of them won by wielding their power. The artifacts lead to the destrution of many lands and eventually thought to have all disappeared from the world.");
            Console.WriteLine("Many centuries later a perculiar sword was discovered in a mining expedition near the village of Aaethea. Unaware of what the sword could possibly be, a young adventurer named {0} was tasked with the quest to deliver the sword to an artifact researcher in the grand cathedral in the town of Hildt.", newPlayer.playerName);

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();

            int storyProgress = 0;

            while (storyProgress != 100) // Keeps you in the gameMain function until that game is beaten or user quits
            {

                // >>> Scenes <<<

                //Scene1

                if (storyProgress == 0) //Tracks your story progress and allows you continue when you make the right choice
                {
                    Console.Clear();
                    Console.WriteLine("{0} begins their journey to deliver the artifact. Peacefully walking through the forest path, {0} notices a merchant struggling with his carriage full of trade goods. The merchant shouts out, asking if {0} can lend a hand.", newPlayer.playerName);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Help the merchant.");
                    Console.WriteLine("(2) Ignore him.");
                    Console.WriteLine("(3) Steal some of his goods and run.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        Console.WriteLine("You decide to help the merchant. [+25 Karma]");
                       // newPlayer.playerScore = newPlayer.playerScore + 10;
                        newPlayer.playerScore += 25; //Short version of line above
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 1;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You leave the defenseless merchant to pick up all of his goods. [-10 Karma]");
                        newPlayer.playerScore -= 10;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 3;
                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("You steal from the merchant and takes off in the blink of an eye. [-25 Karma]");
                        newPlayer.playerScore -= 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 3;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer); //passing newplayer to the playerstatsmenu function to read all the changes made to the player class
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene2 - Encounter 1

                if (storyProgress == 1)
                {
                    enemy orc1 = new enemy();

                    Console.Clear();
                    Console.WriteLine("While helping the merchant an Orc Bandit [HP: {0}] [ATK: {1}] appears from the tall bushes. He readies his weapon and prepares to strike.", orc1.enemyHealth, orc1.enemyAttack);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Attack.");
                    Console.WriteLine("(2) Run away.");
                    Console.WriteLine("(3) Protect the merchant's goods.");
                    Console.WriteLine("\n");
                    playerChoice = Console.ReadLine();
                    playerChoice = playerChoice.ToUpper();
                    
                    if (playerChoice == "1")
                    {
                        if(newPlayer.playerAttack >= orc1.enemyAttack && newPlayer.playerHealth > orc1.enemyAttack)
                        {
                            Console.WriteLine("You chose to attack. You have defeated the bandit! [-{0} Health] [Level Up]", orc1.enemyAttack);
                            newPlayer.playerHealth -= orc1.enemyAttack;
                            playerLevelUp(newPlayer);
                            storyProgress = 2;
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You flee! Leaving the merchant to die. [-25 Karma]");
                        newPlayer.playerScore -= 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 3;

                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("Attempting to protect the merchant's goods has left you defenseless. The bandit strikes you in the back. {0} is dead.", newPlayer.playerName);
                        gameOver();
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene3

                if (storyProgress == 2)
                {
                    Console.Clear();
                    Console.WriteLine("The bandit falls to the ground and the erchant turns to {0} thanking him graciously. The merchant offers up some of his bread as a reward for the great help.");
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Humbly refuse the bread. You were just doing what was right.");
                    Console.WriteLine("(2) Accept the loaf of bread.");
                    Console.WriteLine("(3) Refuse. Who knows where that bread has been.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        Console.WriteLine("Humbly refuse the bread. [+25 Karma]");
                        newPlayer.playerScore += 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 3;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("Accepted the bread. [Health Restored]");
                        newPlayer.playerHealth = 150;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 4;
                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("Refuse.");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 3;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene4 - Branch1 - Encounter 2

                if (storyProgress == 3)
                {
                    enemy orc2 = new enemy(100, "Orc Thief", 15, "Dagger");

                    Console.Clear();
                    Console.WriteLine("Continuing the journey, {0} starts to get very hungry. {0} creates a makeshift spear from the fallen branches and goes fishing. Managing to skewer a few fish, {0} then decides to create a campfire to cook the fish on. The smell of cooked fish attracts the attention of a wandering Orc Thief [HP: {1}] [ATK: {2}]. The orc approaches slowly, ready to strike.", newPlayer.playerName, orc2.enemyHealth, orc2.enemyAttack);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Attack.");
                    Console.WriteLine("(2) Run away.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        if (newPlayer.playerAttack >= orc2.enemyAttack && newPlayer.playerHealth > orc2.enemyAttack)
                        {
                            Console.WriteLine("You chose to attack. You have defeated the bandit and sated your hunger! [-{0} Health] [Level Up] [Health Restored]", orc2.enemyAttack);
                            newPlayer.playerHealth -= orc2.enemyAttack;
                            playerLevelUp(newPlayer);
                            if (newPlayer.playerLevel == 3)
                            {
                                newPlayer.playerHealth = 200;
                                storyProgress = 5;
                            }
                            else if (newPlayer.playerLevel == 2)
                            {
                                newPlayer.playerHealth = 150;
                                storyProgress = 5;
                            }
                            else
                            {
                                newPlayer.playerHealth = 100;
                                storyProgress = 5;
                            }
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You flee!");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 5;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene4 - Branch2

                if (storyProgress == 4)
                {
                    Console.Clear();
                    //int bunnyCompanion = 0;
                    Console.WriteLine("While approching the end of the forest path, {0} notices an injured rabbit laying on the side of the dirt road.", newPlayer.playerName);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Help the injured rabbit.");
                    Console.WriteLine("(2) Leave the bunny.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        //bunnyCompanion = 1;
                        Console.WriteLine("You helped the bunny. Bandaging it's injured leg and putting it somewhere safe from predators. [+10 Karma]");
                        Console.WriteLine("/) /)");
                        Console.WriteLine("('u')");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 5;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You leave the bunny. It can be someone's meal.");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 5;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene5

                if (storyProgress == 5)
                {
                    Console.Clear();
                    Console.WriteLine("It begins to rain. Searching for shelter, {0} comes across an abandoned hut and decides to stay there for the night. Once inside {0} notices a faint glow coming from under the floor boards. Under the floor boards, a glowing chest is discovered.", newPlayer.playerName);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Open the chest. Curious to see what is inside.");
                    Console.WriteLine("(2) Leave it shut. It's not polite to dig through someone's belongings.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        if (newPlayer.playerScore >= 25)
                        {
                            Console.WriteLine("You found a shining sword! [Equipped a new weapon: Blessed Sword] [+10 Attack]");
                            newPlayer.playerWeapon = "Blessed Longsword";
                            newPlayer.playerAttack += 10;
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 6;
                        }
                        else
                        {
                            if (newPlayer.playerHealth <= 10)
                            {
                                Console.WriteLine("The chest sends a bolt of lightning through your hands to you body. [-10 Health]");
                                Console.WriteLine("{0} is dead", newPlayer.playerName); ;
                                gameOver();
                            }
                            else
                            {
                                Console.WriteLine("The chest sends a bolt of lightning through your hands to you body. [-10 Health]");
                                newPlayer.playerHealth -= 10;
                                Console.WriteLine("\nPress ENTER to continue...");
                                Console.ReadLine();
                                storyProgress = 6;
                            }
                        }
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You ignored the chest");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 6;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene6 - Encounter 3

                if (storyProgress == 6)
                {
                    Console.Clear();

                    enemy orcSoldier1 = new enemy(150, "Orc Soldier", 25, "Soldier's Axe");
                    enemy orcSoldier2 = new enemy(150, "Orc Soldier", 25, "Soldier's Axe");

                    Console.WriteLine("The rain has finally lifted and {0} is ready to continue the journey. Leaving the hut, two Orc Soldier's [HP: {1}] [ATK: {2}] ambush the adventurer on the road out.", newPlayer.playerName, orcSoldier1.enemyHealth, orcSoldier2.enemyAttack);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Attack the first soldier.");
                    Console.WriteLine("(2) Attack the second soldier.");
                    Console.WriteLine("(3) Run away.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        if (newPlayer.playerAttack > orcSoldier1.enemyAttack)
                        {
                            Console.WriteLine("You chose to attack the first soldier. You have defeated him but have suffered damage from the other soldier! [-{0} Health] [Level Up]", orcSoldier2.enemyAttack);
                            newPlayer.playerHealth -= orcSoldier2.enemyAttack;
                            playerLevelUp(newPlayer);
                            storyProgress = 7;
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    }
                    else if (playerChoice == "2")
                    {
                        if (newPlayer.playerAttack > orcSoldier2.enemyAttack)
                        {
                            Console.WriteLine("You chose to attack the second soldier. You have defeated him but have suffered damage from the other soldier! [-{0} Health] [Level Up]", orcSoldier1.enemyAttack);
                            newPlayer.playerHealth -= orcSoldier1.enemyAttack;
                            playerLevelUp(newPlayer);
                            storyProgress = 7;
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("You flee! But you suffer damage while escaping! [-{0} Health]", orcSoldier1.enemyAttack + orcSoldier2.enemyAttack);
                        if (newPlayer.playerHealth > 50)
                        {
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 9;
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene7 - Branch1

                if (storyProgress == 7)
                {
                    Console.Clear();
                    Console.WriteLine("The remaining soldier surrenders himself after seeing his partner struck down");
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Spare the soldier.");
                    Console.WriteLine("(2) Kill the soldier.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        Console.WriteLine("You spare the soldier. [+25 Karma]");
                        newPlayer.playerScore += 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 8;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You kill the soldier. [-25 Karma]");
                        newPlayer.playerScore -= 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 9;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene 7 - Branch2

                if (storyProgress == 8)
                {
                    Console.Clear();
                    Console.WriteLine("As {0} walks away, the orc attempts to strike you with your back turned. {0} manages to parry the attack, crippling the soldier.", newPlayer.playerName);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Spare him again. Your power to forgive is strong.");
                    Console.WriteLine("(2) Kill the soldier. He had his chance.");
                    Console.WriteLine("(3) Disarm him and take his weapon. No more risks.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        Console.WriteLine("You spare him a second time. [+50 Karma]");
                        newPlayer.playerScore += 50;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 9;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You kill the soldier.");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 9;
                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("Take his weapon [Equipped a new weapon: Soldier's Axe][+15 Attack]");
                        newPlayer.playerWeapon = "Soldier's Axe";
                        newPlayer.playerAttack += 15;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 9;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        storyProgress = 100;
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene8

                if (storyProgress == 9)
                {
                    Console.Clear();
                    Console.WriteLine("{0} arrives at the village only to find that it has been raided. The village seems to be completely looted with many buildings laying in ruin. Carefully, {0} heds towards the cathedral in hopes that there are some sign of people. Before entering, {0} notices the fountain outside glowing faintly.", newPlayer.playerName);
                    Console.WriteLine("What will {0} do?", newPlayer.playerName);
                    Console.WriteLine("\nEnter your choice:");
                    Console.WriteLine("(1) Say a prayer.");
                    Console.WriteLine("(2) Drink from the fountain.");
                    Console.WriteLine("(3) Ignore it.");
                    playerChoice = Console.ReadLine();
                    Console.WriteLine("\n");
                    playerChoice = playerChoice.ToUpper();

                    if (playerChoice == "1")
                    {
                        Console.WriteLine("You feel blessed. [+25 Karma]");
                        newPlayer.playerScore += 25;
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 10;
                    }
                    else if (playerChoice == "2")
                    {
                        Console.WriteLine("You feel renewed. [Health Restored]");
                        if (newPlayer.playerLevel == 4)
                        {
                            newPlayer.playerHealth = 250;
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 10;
                        }
                        else if (newPlayer.playerLevel == 3)
                        {
                            newPlayer.playerHealth = 200;
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 10;
                        }
                        else if (newPlayer.playerLevel == 2)
                        {
                            newPlayer.playerHealth = 150;
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 10;
                        }
                        else
                        {
                            newPlayer.playerHealth = 100;
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            storyProgress = 10;
                        }
                    }
                    else if (playerChoice == "3")
                    {
                        Console.WriteLine("You ignore it.");
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        storyProgress = 10;
                    }
                    else if (playerChoice == "C")
                    {
                        playerStatsMenu(newPlayer);
                    }
                    else if (playerChoice == "MENU")
                    {
                        Console.WriteLine("Exiting the game...");
                        Console.Clear();
                        Console.WriteLine("Game Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("Would you like to start a new game?");
                        Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }

                //Scene 9 - Boss Encounter

                if (storyProgress == 10)
                {
                    Console.Clear();

                    enemy orcBoss = new enemy(500, "Orc Commander", 35, "Commander's Greatsword");
                    bool bossFight = true;
                    
                    while (bossFight == true)
                    {
                        Console.Clear();
                        Console.WriteLine("{0} enters the catheral only to find a hulking figure standing over the altar. The figure steps out of the shadows and reveals himself to be the Orc Commander [HP: 500] [ATK: {1}]. He readies his weapon and demands {0} to give up the artifact weapon.", newPlayer.playerName, orcBoss.enemyAttack);
                        Console.WriteLine("What will {0} do?", newPlayer.playerName);
                        Console.WriteLine("\nEnter your choice:");
                        Console.WriteLine("(1) Attack the chest.");
                        Console.WriteLine("(2) Attack the back.");
                        Console.WriteLine("(3) Attack the legs.");
                        playerChoice = Console.ReadLine();
                        Console.WriteLine("\n");
                        playerChoice = playerChoice.ToUpper();

                        if (newPlayer.playerHealth > 0 && orcBoss.enemyHealth > 0)
                        {
                            if (newPlayer.playerHealth <= 50 && newPlayer.playerScore >= 100)
                            {
                                Console.WriteLine("You start to feel weaker. The power of the commander is too much for you to handle. Just as your confidence starts to fade, you feel power building from your bag. [Karma over 100] The articfact sword has started to shine and you decide to wield it. You charge forward and lunge at the commander, piercing through him with the overwhelming power of the artifact.");
                                Console.WriteLine("The commander falls to the ground, defeated.");
                                Console.WriteLine("You've defeated the commander!");
                                Console.WriteLine("\nPress ENTER to continue...");
                                Console.ReadLine();
                                orcBoss.enemyHealth = 0;
                            }
                            else
                            {
                                if (playerChoice == "1")
                                {
                                    Console.WriteLine("Attack Chest.");
                                    orcBoss.enemyHealth -= newPlayer.playerAttack + 10;
                                    newPlayer.playerHealth -= orcBoss.enemyAttack;
                                    Console.WriteLine("[{0}'s remaining Health: {1}]", newPlayer.playerName, newPlayer.playerHealth);
                                    Console.WriteLine("[Commander's remaining Health: {0}]", orcBoss.enemyHealth);
                                    Console.WriteLine("\nPress ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else if (playerChoice == "2")
                                {
                                    Console.WriteLine("Attack Back");
                                    orcBoss.enemyHealth -= newPlayer.playerAttack + 15;
                                    newPlayer.playerHealth -= orcBoss.enemyAttack;
                                    Console.WriteLine("[{0}'s remaining Health: {1}]", newPlayer.playerName, newPlayer.playerHealth);
                                    Console.WriteLine("[Commander's remaining Health: {0}]", orcBoss.enemyHealth);
                                    Console.WriteLine("\nPress ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else if (playerChoice == "3")
                                {
                                    Console.WriteLine("Attack Legs");
                                    orcBoss.enemyHealth -= newPlayer.playerAttack + 5;
                                    newPlayer.playerHealth -= orcBoss.enemyAttack;
                                    Console.WriteLine("[{0}'s remaining Health: {1}]", newPlayer.playerName, newPlayer.playerHealth);
                                    Console.WriteLine("[Commander's remaining Health: {0}]", orcBoss.enemyHealth);
                                    Console.WriteLine("\nPress ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else if (playerChoice == "C")
                                {
                                    playerStatsMenu(newPlayer);
                                }
                                else if (playerChoice == "MENU")
                                {
                                    Console.WriteLine("Exiting the game...");
                                    storyProgress = 100;
                                    Console.Clear();
                                    Console.WriteLine("Game Menu");
                                    Console.WriteLine("---------");
                                    Console.WriteLine("Would you like to start a new game?");
                                    Console.WriteLine("Type \"Play\" to start a new game or \"Quit\" to exit");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry");
                                }
                            }
                        }
                        else if (newPlayer.playerHealth > 0 && orcBoss.enemyHealth <= 0)
                        {
                            Console.WriteLine("The commander falls to the ground, defeated.");
                            Console.WriteLine("You've defeated the commander!");
                            Console.WriteLine("\nPress ENTER to  continue...");
                            Console.ReadLine();
                            bossFight = false;
                            storyProgress = 11;
                        }
                        else
                        {
                            Console.WriteLine("{0} is dead", newPlayer.playerName);
                            gameOver();
                        }
                    }
                }

                //Winning Scene
                if (storyProgress == 11)
                {
                    Console.Clear();
                    Console.WriteLine("With the Commander dead, you search for any survivors from the raid. You hear noise coming from below you and go to inspect it. Luckily many of the villagers are safe and amongst them is artifact researcher.");
                    Console.WriteLine("Congratulations! You completed Text Adventure!");
                    storyProgress = 100;
                    Console.WriteLine("\nPress ENTER to continue...");
                    Console.ReadLine();
                    gameMenu();
                }
            } 
        }

        public static void playerStatsMenu(player p) //Passing the player object to this function and naming it 'p'
        {
            Console.Clear();
            //Player Stats Menu Function
            Console.WriteLine("Character Stats");
            Console.WriteLine("---------------\n");
            Console.WriteLine("Name: " + p.playerName);
            Console.WriteLine("Level: " + p.playerLevel);
            Console.WriteLine("Health: " + p.playerHealth);
            Console.WriteLine("Weapon: " + p.playerWeapon);
            Console.WriteLine("Attack: " + p.playerAttack);
            Console.WriteLine("Karma: " + p.playerScore);
            Console.WriteLine("\n");

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();

            //Possibly add Clear and ENTER to continue functionality...
        }

        public static void gameOver()
        {
            Console.WriteLine("\n---------");
            Console.WriteLine("GAME OVER");
            Console.WriteLine("---------");
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
            gameMenu();
        }

        public static void playerLevelUp(player p)
        {
            p.playerLevel = p.playerLevel + 1;
            p.playerHealth = p.playerHealth + 50;
            p.playerAttack = p.playerAttack + 5;
            Console.WriteLine("You are now level {0}!", p.playerLevel);
            Console.WriteLine("Your strength grows and you have gained 50 Health and 5 Attack!");
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}
