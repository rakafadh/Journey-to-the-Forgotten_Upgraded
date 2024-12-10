public class QuestManager
{
    private List<Quest> activeQuests;

    public QuestManager()
    {
        activeQuests = new List<Quest>();
    }

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest);
        Console.WriteLine($"New Quest: {quest.Name} - {quest.Description}");
    }

    public void CheckAllQuests(Character character)
    {
        foreach (var quest in activeQuests)
        {
            quest.CheckCompletion(character);
        }
        activeQuests.RemoveAll(q => q.IsCompleted);
    }

    public void DisplayActiveQuests()
    {
        Console.WriteLine("\nActive Quests:");
        foreach (var quest in activeQuests)
        {
            Console.WriteLine($"- {quest.Name}: {quest.Description}");
        }
    }
}
