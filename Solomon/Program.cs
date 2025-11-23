Player player = new();
Enemy enemy = new();
BattleSetup battleSetup = new(player, enemy);
BattleEngine battle = new(battleSetup);





battle.TurnResolution();
