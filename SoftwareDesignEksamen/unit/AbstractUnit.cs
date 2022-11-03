namespace SoftwareDesignEksamen.unit;

public abstract class AbstractUnit
{
    private int _maxHealth;
    public int Health { get; set; }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            Health = value;
            _maxHealth = value;
        }
    }

    public int Damage { get; set; }
    public int Healing { get; set; }
    public int Armor { get; set; }
    public int Reach { get; set; }

    // LifeSteal Defined in percentage.
    public int LifeSteal { get; set; }
    public int Cost { get; set; }


    // Returns true if health is not 0.
    public bool IsAlive()
    {
        return Health > 0;
    }

    // Reduces health in unit and returns the damage dealt
    public int TakeDamage(int damage)
    {
        damage -= Armor;
        Health -= damage;

        return damage;
    }

    // todo:
    //  damage === damage - armor FOR NOW!!!

    public void DamageDealt(int damageDealt)
    {
        Health += (damageDealt / 100) * LifeSteal;
    }

    public void Heal(int heal)
    {
        Health += heal;
    }
}