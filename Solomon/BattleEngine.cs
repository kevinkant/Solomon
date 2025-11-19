using System.Collections;

class BattleEngine(Player player, Enemy enemy)
{
    //readonly behaviour to ensure enemy and player is never suddenly changed
    private readonly Player _player = player;
    private readonly Enemy _enemy = enemy;

    public void StartBattle()
    {
      Console.WriteLine($"Battle start between {_player.Name} and {_enemy.Name}");

    }

    
    public void StartTurn()
    {
        Action turnPhase = turnOrder.Dequeue();
        turnPhase.Invoke();
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

        switch (playeraction)
        {
            case PlayerAction.Attack:
                PlayerAttack();
                break; 
            case PlayerAction.Defend:
                _player.Defend();
                break;
        }
    }


    public void PlayerAttack()
    {

        int atk_value = _player.Atk;
        _enemy.TakeDamage(atk_value);
        Console.WriteLine($"{_enemy.Name} took {atk_value} damage. They have {_enemy.CurrHp} remaining");
        EndTurn();
    }

    public void EnemyTurn()
    {
        int Hp_percentage = _enemy.CurrHp / _enemy.MaxHp * 100;

        if (Hp_percentage >= 70)
        {
            EnemyAttack();
        } else if (Hp_percentage >= 30)
        {
            _player.Defend();
        }
        else
        {
            EnemyAttack();
        }
    }


    public void EnemyAttack()
    {
        int atk_value = _enemy.Atk;
        _player.TakeDamage(atk_value);
        Console.WriteLine($"{_player.Name} took {atk_value} damage. They have {_player.CurrHp} remaining");
    }

    public void EndTurn()
    {
        CheckDeath();
        //turnOrder.Dequeue();
        EndGame();

    }
    
    
    public void CheckDeath()
    {
        if (_player.CurrHp <=0)
        {
            Console.WriteLine($"{_player.Name} is dead! {_enemy.Name} wins this battle!");
        }
        else if (_enemy.CurrHp <= 0)
        {
            Console.WriteLine($"{_player.Name} is dead! {_enemy.Name} wins this battle!");
        }
    }

    public void EndGame()
    {

    }
    
}
