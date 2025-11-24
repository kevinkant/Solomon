

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

/// <summary>
/// Buff attacker's next attack
/// </summary>
/// <param name="Attacker"></param>
record BuffIntent(Combatant Attacker) : IActionIntent
{
    public void Execute()
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// 2 Turn attack where attacker charges their attack in the first turn and releases that attack in the second turn
/// </summary>
/// <param name="Attacker"></param>
record ChargeItnent(Combatant Attacker) : IActionIntent
{
    public void Execute()
    {
        throw new NotImplementedException();
    }
}
