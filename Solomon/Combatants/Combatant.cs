abstract class Combatant
{
    public abstract string Name {get; set;}
    public int MaxHp {get;set;}
    public int CurrHp {get; set;}
    public int Atk {get; set;}
    public int Def {get; set;}
    public int Spd {get; set;}
    public Queue<IActionIntent> ActionQueue {get; set;} = [];

    //TODO
    //Differentiate between baseAtk and Atk


    public abstract void TakeDamage(int value);

    public bool IsDead()
    {
        if (CurrHp <= 0)
        {
            return true;
        }
        else
        { 
            return false;
        }
    }


    
}