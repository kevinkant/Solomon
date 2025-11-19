Player player = new();
Enemy enemy = new();
BattleEngine battle = new(player, enemy);



while (player.CurrHp != 0)
{
    battle.StartBattle();
    
    
}