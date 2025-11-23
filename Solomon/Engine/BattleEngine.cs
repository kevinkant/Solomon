
class BattleEngine(BattleSetup battleSetup)
{
    //readonly behaviour to ensure enemy and player is never suddenly changed
    private readonly BattleSetup battleContext = battleSetup;
    readonly Print print = new(battleSetup);
    
    public void TurnResolution()
    {
        var action = PlayerChoice();
        Console.WriteLine(action);


        GetPlayerAction(battleContext.Player, battleContext.Enemy, action);
        
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


    
    public void StartTurn()
    {
        // battleContext.DetermineTurnOrder();
        // Combatant combatant = battleContext.TurnOrder.Dequeue();

        // switch (combatant)
        // {
        //     case Player:
        //         PlayerAction action = PlayerTurn();
        //         ExecutePlayerTurn(action);
        //         break;
        //     case Enemy:
        //         EnemyTurn();
        //         break;
        // }
    }

    public void EndTurn()
    {
        EndGame();
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

        print.StartBattleMessage();

        int value = Convert.ToInt32(Console.ReadLine());

        if (Enum.IsDefined(typeof(PlayerAction), value))
            return (PlayerAction)value;
        
        //Purely for this version, will fix input validation in next version.
        Console.WriteLine("Invalid choice");
        return PlayerAction.Defend;
    }

    
    
    public void GetPlayerAction(Combatant combatant, Combatant target, PlayerAction action)
    {
        
        switch (action)
        {
            case PlayerAction.Attack:
                combatant.ActionQueue.Enqueue(new AttackIntent(combatant, target));
                break;
            case PlayerAction.Defend:
                combatant.ActionQueue.Enqueue(new DefendItent(combatant));
                break;
        }
    }




    
    public void EnemyChoice()
    {
        int Hp_percentage = battleContext.Enemy.CurrHp / battleContext.Enemy.MaxHp * 100;
    }


    public void EndGame()
    {

    }
    
}
