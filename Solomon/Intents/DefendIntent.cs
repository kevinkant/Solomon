/// <summary>
/// Raises defense by a certain value
/// </summary>
/// <param name="Self"></param>
record DefendItent(Combatant Self) : IActionIntent
{
    public void Execute()
    {
        Self.Def = (int)(Self.Def + (Self.Def*0.15));
        Console.WriteLine($"{Self.Name} raises its defense!");
    }
}