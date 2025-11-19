class BattleSetup(Player player, Enemy enemy)
{

    private readonly Player _player = player;
    private readonly Enemy _enemy = enemy;

    readonly Queue<Action> turnOrder = [];   

    enum Turn
    {
        Player,
        Enemy
    }
    public void DetermineTurnOrder()
    {
        if (_player.Spd > _enemy.Spd)
        {
            turnOrder.Enqueue( () => PlayerTurn());
            turnOrder.Enqueue( () => EnemyTurn());
        }
        else
        {
            turnOrder.Enqueue( () => EnemyTurn());
            turnOrder.Enqueue( () => PlayerTurn());
        }
    }

}
