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
        OfferQuestSelection();
    }

    private void OfferQuestSelection()
    {
        Console.WriteLine("\nChoose your starting quest:");
        var quests = new List<Quest>
        {
            new Quest(
                "Defeat the Dragon",
                "Defeat the Dragon to prove your strength.",
                character => character.Level >= 2 && character.Inventory.GetItems().Count > 1,
                character => character.GainExperience(300)
            ),
            new Quest(
                "Gather Herbs",
                "Collect 5 healing herbs for the village healer.",
                character => character.Inventory.GetItems().Count(item => item.Name.Contains("Herb")) >= 5,
                character => character.GainExperience(150)
            ),
            new Quest(
                "Protect the Village",
                "Defend the village from a goblin attack.",
                character => character.Level >= 1,
                character => character.GainExperience(200)
            )
        };

        for (int i = 0; i < quests.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quests[i].Name} - {quests[i].Description}");
        }

        Console.Write("Enter the number of your chosen quest: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= quests.Count)
        {
            var chosenQuest = quests[choice - 1];
            questManager.AddQuest(chosenQuest);
            Console.WriteLine($"You have chosen the quest: {chosenQuest.Name} - {chosenQuest.Description}");
        }
        else
        {
            Console.WriteLine("Invalid choice. No quest selected.");
        }
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
                Console.WriteLine("\nGame Over!");
                break;
            }

            // Check quests after each battle
            questManager.CheckAllQuests(player);

            // Ask player to view quests
            Console.WriteLine("\nDo you want to view your active quests? (y/n)");
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
