class Print(BattleSetup battleSetup)
{

    private readonly BattleSetup battleContext = battleSetup;
    public void TurnChoice()
    {
        Console.WriteLine("Please select an action!");
        Console.WriteLine("-------------------------");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Defend");
        Console.WriteLine("-------------------------");
    }

    public void StartBattleMessage()
    {
        
        Console.WriteLine($"Battle start between {battleContext.Player.Name} and {battleContext.Enemy.Name}");
    }

    public void EndOfTurn()
    {
        Console.WriteLine($"You have {battleContext.Player.CurrHp} remaining. Enemy has {battleContext.Enemy.CurrHp}");
    }

    public void EndOfBattleMessage()
    {
        if (battleContext.Enemy.IsDead())
        {
            Console.WriteLine($"You have won the game!");
        }else
        {
            Console.WriteLine($"You have lost the game :( )");
        }
    }
}