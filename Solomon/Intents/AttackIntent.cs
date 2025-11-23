

/// <summary>
/// Attacks a Target
/// </summary>
/// <param name="Attacker"></param>
/// <param name="Target"></param>
record AttackIntent(Combatant Attacker, Combatant Target) : IActionIntent
{
    public void Execute()
    {
        int dmg = Attacker.Atk;
        Target.TakeDamage(dmg);

        if (Attacker.GetType() == typeof(Player))
        {
            Console.WriteLine($"You attacked {Target.Name}");
        }
        else
        {
            Console.WriteLine($"You got attacked by {Attacker.Name}");
        }
    }
}

record BuffIntent(Combatant Attacker) : IActionIntent
{
    public void Execute()
    {
        throw new NotImplementedException();
    }
}
