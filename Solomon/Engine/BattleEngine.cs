
class BattleEngine(BattleSetup battleSetup)
{
    //readonly behaviour to ensure enemy and player is never suddenly changed
    private readonly BattleSetup battleContext = battleSetup;
    readonly Print print = new(battleSetup);

    public void BattleLoop()
    {
        print.StartBattleMessage();

        while(!battleContext.Player.IsDead() && !battleContext.Enemy.IsDead())
        {
            TurnResolution();
            print.EndOfTurn();
        }

        print.EndOfBattleMessage();
        EndGame();
    }
    
    
    public void TurnResolution()
    {
        var action = PlayerChoice();
        var eAction = EnemyChoice();
        
        GetPlayerAction(battleContext.Player, battleContext.Enemy, action);
        GetEnemyAction(battleContext.Enemy, battleContext.Player, eAction);
        
        var turnOrder = DetermineTurnOrder(battleContext.Combatants);

        foreach (Combatant combatant in turnOrder)
        {
            var intent = combatant.ActionQueue.Dequeue();
            intent.Execute();
        }

    }

    public static List<Combatant> DetermineTurnOrder(List<Combatant> combatants)
    {
       return combatants
       .OrderByDescending(c => c.Spd)
       .ToList();
    }


    public enum PlayerAction
    {
        Attack = 1,
        Defend = 2
    }

    public enum EnemyAction
    {
        Attack = 1,
        Defend = 2
    }

    public PlayerAction PlayerChoice()
    {

        print.TurnChoice();

        int value = Convert.ToInt32(Console.ReadLine());

        if (Enum.IsDefined(typeof(PlayerAction), value))
            return (PlayerAction)value;
        
        //Purely for this version, will fix input validation in next version.
        Console.WriteLine("Invalid choice");
        return PlayerAction.Defend;
    }

    
    
    public void GetPlayerAction(Combatant player, Combatant target, PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.Attack:
                player.ActionQueue.Enqueue(new AttackIntent(player, target));
                break;
            case PlayerAction.Defend:
                player.ActionQueue.Enqueue(new DefendItent(player));
                break;
        }
    }




    
    public EnemyAction EnemyChoice()
    {
        int Hp_percentage = battleContext.Enemy.CurrHp / battleContext.Enemy.MaxHp * 100;

        if (Hp_percentage >= 70)
        {
            return EnemyAction.Attack;
        }

        if (Hp_percentage < 30)
        {
            return EnemyAction.Defend;
        }

        Random rng = new();

        return rng.NextDouble() < 0.5
            ? EnemyAction.Attack
            : EnemyAction.Defend;
    }

    public void GetEnemyAction(Combatant enemy, Combatant target, EnemyAction action)
    {
        switch (action)
        {
            case EnemyAction.Attack:
                enemy.ActionQueue.Enqueue(new AttackIntent(enemy, target));
                break;
            case EnemyAction.Defend:
                enemy.ActionQueue.Enqueue(new DefendItent(enemy));
                break;
        }
    }


    public static void EndGame()
    {
        Console.WriteLine("Thank you for playing! Exiting...");
        Environment.Exit(0);
    }
    
}
