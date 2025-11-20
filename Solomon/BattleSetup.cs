class BattleSetup(Player player, Enemy enemy)
{
    public Player Player { get; } = player;
    public Enemy Enemy { get; } = enemy;
    public Queue<Combatant> TurnOrder { get; } = new();
    public void DetermineTurnOrder()
    {
        if (Player.Spd > Enemy.Spd)
        {
            TurnOrder.Enqueue(Player);
            TurnOrder.Enqueue(Enemy);
        }
        else
        {
            TurnOrder.Enqueue(Enemy);
            TurnOrder.Enqueue(Player);
        }
    }
}
