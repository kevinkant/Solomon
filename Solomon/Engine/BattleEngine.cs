
class BattleEngine(BattleSetup battleSetup)
{
    //readonly behaviour to ensure enemy and player is never suddenly changed
    private readonly BattleSetup battleContext = battleSetup;

    

    

    public void StartBattle()
    {
      Console.WriteLine($"Battle start between {battleContext.Player.Name} and {battleContext.Enemy.Name}");

      var turnOrder = DetermineTurnOrder(battleContext.Combatants);

      foreach (Combatant combatant in turnOrder)
        {
            PlayerAction action = PlayerChoice();
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

    public void ContinueTurn()
    {
        throw new NotImplementedException();
    }

    public void EndTurn()
    {
        CheckDeath();
        ContinueTurn();
        EndGame();
    }

    public enum PlayerAction
    {
        Attack = 1,
        Defend = 2
    }

    public enum EnemyAction
    {
        
    }

    public PlayerAction PlayerChoice()
    {

        Console.WriteLine("Please select an action!");
        Console.WriteLine("-------------------------");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Defend");
        Console.WriteLine("-------------------------");

        int value = Convert.ToInt32(Console.ReadLine());

        if (Enum.IsDefined(typeof(PlayerAction), value))
            return (PlayerAction)value;
        
        //Purely for this version, will fix input validation in next version.
        Console.WriteLine("Invalid choice");
        return PlayerAction.Defend;
    }

    
    
    public void ExecutePlayerTurn(Combatant combatant, Combatant target, PlayerAction action)
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


    public void PlayerAttack()
    {
        int atk_value = battleContext.Player.Atk;
        battleContext.Enemy.TakeDamage(atk_value);
        Console.WriteLine($"You attacked {battleContext.Enemy.Name}");

    }

    public void EnemyAttack()
    {
        int atk_value = battleContext.Enemy.Atk;
        battleContext.Player.TakeDamage(atk_value);
        Console.WriteLine($"{battleContext.Player.Name} took {atk_value} damage. They have {battleContext.Player.CurrHp} remaining");
    }

    public void Attack(Combatant attacker, Combatant defender)
    {
        int atk_value = battleContext.Enemy.Atk;
        battleContext.Player.TakeDamage(atk_value);
        Console.WriteLine($"{battleContext.Player.Name} took {atk_value} damage. They have {battleContext.Player.CurrHp} remaining");
    }

    public void EnemyChoice()
    {
        int Hp_percentage = battleContext.Enemy.CurrHp / battleContext.Enemy.MaxHp * 100;

        if (Hp_percentage >= 70)
        {
            EnemyAttack();
        } else if (Hp_percentage >= 30)
        {
            battleContext.Player.Defend();
        }
        else
        {
            EnemyAttack();
        }
    }


    

    
    
    
    public void CheckDeath()
    {
        if (battleContext.Player.CurrHp <=0)
        {
            Console.WriteLine($"{battleContext.Player.Name} is dead! {battleContext.Enemy.Name} wins this battle!");
        }
        else if (battleContext.Enemy.CurrHp <= 0)
        {
            Console.WriteLine($"{battleContext.Enemy.Name} is dead! {battleContext.Player.Name} wins this battle!");
        }
        else
        {
            Console.WriteLine("The battle continues...");
        }
    }

    public void EndGame()
    {

    }

    public void ExecuteCombatantTurn(Combatant combatant)
    {
        if (combatant.GetType() == typeof(Player))
        {
            // Execute player turn
        }
        else
        {
            // Execute enemy attack
        }
    }
    
}
