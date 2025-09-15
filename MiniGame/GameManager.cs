
namespace MiniGame
{
    internal class GameManager
    {
        Player player;
        Enemy[] enemies = new Enemy[]
        {
            new Enemy { EnemyClass = "Goblin", Damage = 10, Gold = 20 },
            new Enemy { EnemyClass = "Rat", Damage = 5, Gold = 5 },
            new Enemy { EnemyClass = "Troll", Damage = 20, Gold = 30 },
            new Enemy { EnemyClass = "Orc", Damage = 25, Gold = 15 },
            new Enemy { EnemyClass = "Bandit", Damage = 15, Gold = 40 }
        };

        private Random random = new Random();

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
                        HeroRest();
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

        private void ShowHeroStatus()
        {
            throw new NotImplementedException();
        }

        private void HeroRest()
        {
            throw new NotImplementedException();
        }

        private void StartAdventure()
        {
            int randomEnemy = random.Next(enemies.Length);
            
            Console.Clear();
            Console.WriteLine($"You encounter a {enemies[randomEnemy].EnemyClass}!");
            Console.WriteLine($"Enemy Damage: {enemies[randomEnemy].Damage}, Gold Reward: {enemies[randomEnemy].Gold}\n");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Run away\n");
            Console.Write("Choose your action:\n");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    // Fight logic
                    Console.WriteLine($"You fought the {enemies[randomEnemy].EnemyClass} and won!");
                    player.Gold += enemies[randomEnemy].Gold;
                    Console.WriteLine($"You earned {enemies[randomEnemy].Gold} gold. Total Gold: {player.Gold}");
                    break;
                case "2":
                    // Heal logic
                    Console.WriteLine("You healed yourself.");
                    break;
                case "3":
                    // Run away logic
                    Console.WriteLine("You ran away safely.");
                    break;
                default:
                    Console.WriteLine("Invalid action. The enemy attacks you while you hesitate!");
                    break;
            }
        }

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
