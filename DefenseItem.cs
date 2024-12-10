public class DefenseItem : BaseItem
{
    public int DefenseBonus { get; private set; }

    public DefenseItem(string name, string description, int defenseBonus)
    {
        Name = name;
        Description = description;
        DefenseBonus = defenseBonus;
    }

    public override void Use(Character character)
    {
        base.Use(character);
        character.Defense += DefenseBonus;
        Console.WriteLine($"{Name} increases {character.Name}'s defense by {DefenseBonus}!");
    }
}