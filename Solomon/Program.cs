Player player = new();
Enemy enemy = new();
BattleSetup battleSetup = new(player, enemy);
BattleEngine battle = new(battleSetup);



Console.WriteLine("Welcome to Solomon v1.0");
Console.WriteLine($@"
Here are your current class stats:
{player.Name}
-----------------------------------
HP                  {player.CurrHp}
Attack              {player.Atk}
Defense             {player.Def}
Speed               {player.Spd}
-----------------------------------
");
battle.BattleLoop();
