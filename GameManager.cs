public class GameManager
{
    private Character player;
    private BattleSystem battleSystem;
    private QuestManager questManager;

    public GameManager()
    {
        player = Character.GetInstance();
        battleSystem = new BattleSystem();
        questManager = new QuestManager();
    }

    public void StartNewGame(string playerName)
    {
        player.Initialize(playerName);
        Console.WriteLine($"Welcome, {playerName}! Your adventure begins.");

        // Tambahkan quest awal
        questManager.AddQuest(new Quest(
            "Defeat the Dragon",
            "Defeat the Dragon to prove your strength.",
            character => character.Level >= 2 && character.Inventory.GetItems().Count > 1,
            character => character.GainExperience(300)
        ));
    }

    public void StartAdventure()
    {
        Random rand = new Random();
        while (player.Health > 0)
        {
            // Random enemy encounter
            Enemy enemy = rand.Next(3) switch
            {
                0 => new Goblin(),
                1 => new Skeleton(),
                _ => new Dragon()
            };

            Console.WriteLine($"\nA wild {enemy.Name} appears!");

            battleSystem.ExecuteBattle(player, enemy);

            if (player.Health <= 0)
            {
                Console.WriteLine("Game Over!");
                break;
            }

            // Check quests after each battle
            questManager.CheckAllQuests(player);

            // Ask player to view quests
            Console.WriteLine("Do you want to view your active quests? (y/n)");
            string viewQuests = Console.ReadLine();
            if (viewQuests.ToLower() == "y")
            {
                questManager.DisplayActiveQuests();
            }

            // Ask player to continue
            Console.WriteLine("\nDo you want to continue your adventure? (y/n)");
            string continueAdventure = Console.ReadLine();
            if (continueAdventure.ToLower() != "y")
            {
                break;
            }
        }
    }
}
