class Enemy : Combatant
{
    
    readonly string[] names = ["Sephiroth", "Gwynn", "The Knight", "Soul King", "Abyss"];

    public override string Name { get;set;}

    public string ChooseName()
    {
        Random random = new();
        return names[random.Next(names.Length)];
    }

    

    public override void TakeDamage(int value)
    {
        CurrHp -= value;
        CurrHp = Math.Clamp(CurrHp, 0, 200);
    }


     public Enemy()
    {
        Name = ChooseName();
        MaxHp = 150;
        CurrHp = MaxHp;
        Atk = 10;
        Def = 50;
        Spd = 30;
    }
}