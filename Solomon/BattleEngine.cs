

class BattleEngine(BattleSetup battleSetup)
{
    //readonly behaviour to ensure enemy and player is never suddenly changed
    private readonly BattleSetup battleContext = battleSetup;
    public void StartBattle()
    {
      Console.WriteLine($"Battle start between {battleContext.Player.Name} and {battleContext.Enemy.Name}");

    }

    
    public void StartTurn()
    {

        battleContext.DetermineTurnOrder();

        Combatant combatant = battleContext.TurnOrder.Dequeue();

        switch (combatant)
        {
            case Player:
                PlayerTurn();
                break;
            case Enemy:
                EnemyTurn();
                break;

        }
    }

    private enum PlayerAction
    {
        Attack = 1,
        Defend
    }

    private PlayerAction playeraction;

    public void PlayerTurn()
    {
        Console.WriteLine("Please select an action!");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Defend");

        int value = Convert.ToInt32(Console.ReadLine());

        switch (value)
        {
            case (int)PlayerAction.Attack:
                PlayerAttack();
                break; 
            case (int)PlayerAction.Defend:
                battleContext.Player.Defend();
                battleContext.TurnOrder.Enqueue(battleContext.Player);
                break;
        }
    }


    public void PlayerAttack()
    {
        int atk_value = battleContext.Player.Atk;
        battleContext.Enemy.TakeDamage(atk_value);
        Console.WriteLine($"{battleContext.Enemy.Name} took {atk_value} damage. They have {battleContext.Enemy.CurrHp} remaining");
        battleContext.TurnOrder.Enqueue(battleContext.Player);
        EndTurn();
    }

    public void EnemyTurn()
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


    public void EnemyAttack()
    {
        int atk_value = battleContext.Enemy.Atk;
        battleContext.Player.TakeDamage(atk_value);
        Console.WriteLine($"{battleContext.Player.Name} took {atk_value} damage. They have {battleContext.Player.CurrHp} remaining");
        battleContext.TurnOrder.Enqueue(battleContext.Enemy);
        EndTurn();
    }

    public void EndTurn()
    {
        CheckDeath();
        StartTurn();
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
    
}
