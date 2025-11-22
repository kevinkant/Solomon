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
        Console.WriteLine($"You attacked {Target.Name}");
    }
}
