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
        Hp -= value;
        Hp = Math.Clamp(Hp, 0, 200);
    }

    public override void Defend()
    {
        Def = (int)(Def + (Def*0.15));
    }

     public Enemy()
    {
        Name = ChooseName();
        Hp = 100;
        Atk = 10;
        Def = 50;
        Spd = 30;
    }
}