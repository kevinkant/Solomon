class BattleSetup(Player player, Enemy enemy)
{
    public Player Player { get; } = player;
    public Enemy Enemy { get; } = enemy;
    public List<Combatant> Combatants { get; } = [player, enemy];
    
}
