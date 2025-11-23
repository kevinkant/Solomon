class Print(BattleSetup battleSetup)
{

    private readonly BattleSetup battleContext = battleSetup;
    // public static void TurnChoice()
    // {
    //     Console.WriteLine("Please select an action!");
    //     Console.WriteLine("-------------------------");
    //     Console.WriteLine("1. Attack");
    //     Console.WriteLine("2. Defend");
    //     Console.WriteLine("-------------------------");
    // }

    public void StartBattleMessage()
    {
        
        Console.WriteLine($"Battle start between {battleContext.Player.Name} and {battleContext.Enemy.Name}");
    }

    public void EndOfBattleMessage()
    {
        
    }
}