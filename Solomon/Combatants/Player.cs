class Player : Combatant
{

    public override string Name {get;set;}
    

    public override void TakeDamage(int value)
    {
        CurrHp -= value;
        CurrHp = Math.Clamp(CurrHp, 0, 200);
    }



    public Player()
    {
        Name = "Player1";
        MaxHp = 200;
        CurrHp = MaxHp;
        Atk = 10;
        Def = 60;
        Spd = 50;
    }

    
}