
namespace MiniGame
{
    internal class GameManager
    {
        Player player;

        private Random random = new Random();

        // Start the game
        internal void StartGame()
        {
            Console.Clear();
            Console.WriteLine("#### Welcome to this Amazing game! ####\n");
            Console.WriteLine("In this game, you will create a character and fight enemies to earn gold.");
            Console.WriteLine("You can choose from three classes: Warrior, Mage, and Rogue. Each class has its own strengths and weaknesses.\n");
            Console.WriteLine("Now, let's create your character!\n");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            CreateHero();
            ShowMenu();
        }

        // Create a hero
        internal void CreateHero()
        {
            Console.Clear();
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nChoose your class:");
            Console.WriteLine("1. Warrior (High HP, Medium Damage)");
            Console.WriteLine("2. Mage (Low HP, High Damage)");
            Console.WriteLine("3. Rogue (Low HP, Medium Damage, Bonus gold loot)");
            Console.Write("Enter the number of your choice: ");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    player = new Player
                    {
                        Name = name,
                        PlayerClass = "Warrior",
                        currentHP = 150,
                        MaxHP = 150,
                        Damage = 20,
                        Gold = 0
                    };
                    break;
                case "2":
                    player = new Player
                    {
                        Name = name,
                        PlayerClass = "Mage",
                        currentHP = 100,
                        MaxHP = 100,
                        Damage = 30,
                        Gold = 0
                    };
                    break;
                case "3":
                    player = new Player
                    {
                        Name = name,
                        PlayerClass = "Rogue",
                        currentHP = 110,
                        MaxHP = 110,
                        Damage = 25,
                        Gold = 0
                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    CreateHero();
                    return;
            }
            Console.WriteLine($"\nHero Created! Welcome, {player.Name} the {player.PlayerClass}!");
            Console.WriteLine($"Max HP: {player.MaxHP}, Damage: {player.Damage}, Gold: {player.Gold}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Show the main menu
        private void ShowMenu()
        {
            bool endGame = false;

            while (!endGame)
            {
                DisplayMenuOptions();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartAdventure();
                        break;
                    case "2":
                        Console.WriteLine("Your hero is resting and recovering health. Press any key to continue.");
                        player.currentHP = player.MaxHP;
                        Console.ReadKey();
                        break;
                    case "3":
                        ShowHeroStatus();
                        break;
                    case "4":
                        CreateHero();
                        break;
                    case "5":
                        endGame = true;
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Show hero status
        private void ShowHeroStatus()
        {
            Console.Clear();
            Console.WriteLine("##### Hero Status #####");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Class: {player.PlayerClass}");
            Console.WriteLine($"Current HP: {player.currentHP}/{player.MaxHP}");
            Console.WriteLine($"Damage: {player.Damage}");
            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }

        // Start an adventure
        private void StartAdventure()
        {
            Enemy[] enemies = new Enemy[]
            {
            new Enemy { EnemyClass = "Goblin", Damage = 10, HP = 45, Gold = 20 },
            new Enemy { EnemyClass = "Rat", Damage = 5, HP = 15, Gold = 5 },
            new Enemy { EnemyClass = "Troll", Damage = 20, HP = 55, Gold = 30 },
            new Enemy { EnemyClass = "Orc", Damage = 25, HP = 75, Gold = 15 },
            new Enemy { EnemyClass = "Bandit", Damage = 15, HP = 35, Gold = 40 }
            };

            int randomEnemy = random.Next(enemies.Length);
            Enemy enemy = enemies[randomEnemy];
            bool inAdventure = true;

            while (inAdventure && player.currentHP > 0)
            {
                Console.Clear();

                if (player.currentHP <= 0)
                {
                    Console.WriteLine("You have been defeated! Game Over.");
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                    inAdventure = false;
                }

                Console.WriteLine($"You encounter a {enemy.EnemyClass}!");
                Console.WriteLine($"Enemy Damage: {enemy.Damage}, Gold Reward: {enemy.Gold}\n");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Run away\n");
                Console.Write("Choose your action:\n");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        // Fight logic
                        enemy.HP -= player.Damage;
                        Console.WriteLine($"You dealt {player.Damage} damage to the {enemy.EnemyClass}. Leaving the {enemy.EnemyClass} at {enemy.HP} HP.");
                        if (enemy.HP <= 0)
                        {
                            Console.WriteLine($"You defeated the {enemy.EnemyClass} and earned {enemy.Gold} gold!");
                            player.Gold += enemy.Gold;
                            if (player.PlayerClass == "Rogue")
                            {
                                int bonusGold = (int)(enemy.Gold * 0.1);
                                player.Gold += bonusGold;
                                Console.WriteLine($"As a Rogue, you found a hidden stash and earned an additional {bonusGold} gold!");
                            }
                            Console.WriteLine("Press any key to continue your adventure.");
                            Console.ReadKey();
                            inAdventure = false;
                        }
                        else
                        {
                            player.currentHP -= enemy.Damage;
                            Console.WriteLine($"The {enemy.EnemyClass} attacks you back for {enemy.Damage} damage. You have {player.currentHP} HP left.");
                            if (player.currentHP <= 0)
                            {
                                Console.WriteLine("You have been defeated! Game Over.");
                                Console.WriteLine("Press any key to return to the main menu.");
                                Console.ReadKey();
                                inAdventure = false;
                                CreateHero();
                                break;
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                            break;
                    case "2":
                        // Heal logic
                        Console.WriteLine("You healed yourself.");
                        player.currentHP = player.MaxHP;
                        break;
                    case "3":
                        // Run away logic
                        Console.WriteLine("You ran away safely. Press any key to continue.");
                        Console.ReadKey();
                        ShowMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid action, try again!");
                        break;
                }
            }

        }

        // Display menu options
        private void DisplayMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("##### Main Menu #####");
            Console.WriteLine("1. Go on an adventure");
            Console.WriteLine("2. Give your hero some rest");
            Console.WriteLine("3. Hero status");
            Console.WriteLine("4. Restart game");
            Console.WriteLine("5. Exit game");
            Console.Write("\nEnter your choice: ");
        }
    }
}
