public class SpecialAttackStrategy : IBattleStrategy
{
    public void Execute(Character character, Enemy enemy)
    {
        int specialDamage = character.Strength * 10; // Special attack does more damage
        Console.WriteLine($"{character.Name} unleashes a Special Attack on {enemy.Name}!");
        enemy.TakeDamage(specialDamage);

        if (enemy.Health > 0)
        {
            enemy.Attack(character);
        }
        else
        {
            character.GainExperience(enemy.ExperienceValue);
        }
    }
}
