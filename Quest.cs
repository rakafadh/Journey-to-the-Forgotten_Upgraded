public class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public Action<Character> Reward { get; private set; }
    private Func<Character, bool> completionCriteria;

    public Quest(string name, string description, Func<Character, bool> criteria, Action<Character> reward)
    {
        Name = name;
        Description = description;
        completionCriteria = criteria;
        Reward = reward;
        IsCompleted = false;
    }

    public void CheckCompletion(Character character)
    {
        if (!IsCompleted && completionCriteria(character))
        {
            IsCompleted = true;
            Console.WriteLine($"Quest Completed: {Name}!");
            Reward(character);
        }
    }
}
