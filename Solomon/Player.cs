class Player : Combatant
{

    public override string Name {get;set;}
    

    public override void TakeDamage(int value)
    {
        Hp -= value;
        Hp = Math.Clamp(Hp, 0, 200);
    }

    public override void Defend()
    {
        Def = (int)(Def + (Def*0.15));
    }

    public Player()
    {
        Name = "Kevin";
        Hp = 200;
        Atk = 10;
        Def = 60;
        Spd = 50;
    }

    
}