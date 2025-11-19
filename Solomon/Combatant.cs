abstract class Combatant
{
    public abstract string Name {get; set;}
    public int Hp {get; set;}
    public int Atk {get; set;}
    public int Def {get; set;}
    public int Spd {get; set;}

    //TODO
    //Differentiate between baseAtk and Atk


    public abstract void TakeDamage(int value);
    public abstract void Defend();

    
}