using SoftwareDesignEksamen.gear.chestPlate;
using SoftwareDesignEksamen.gear.shield;
using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.unit;

public abstract class AbstractUnit
{
    public AbstractWeapon Weapon { get; set; } = new NoSword();
    public AbstractShield Shield { get; set; } = new NoShield();

    public AbstractChestPlate ChestPlate { get; set; } = new NoChestPlate();
    

    private readonly int _maxHealth;
    private readonly int _cost;
    private readonly int _lifeSteal;
    private readonly int _damage;
    private readonly int _reach;
    private readonly int _armor;
    private int _maxHealth;

    public string Description { get; set; } = "";
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

    public int Damage
    {
        get => Weapon.Damage + _damage;
        protected init => _damage = value;
    }

    public int Healing { get; protected init; }
    public int Armor
    {
        get => _armor + Shield.Armor + ChestPlate.Armor;
        protected init => _armor = value;
    }

    public int Reach
    {
        get => _reach + Weapon.Reach;
        protected init => _reach = value;
    }

    // LifeSteal Defined in percentage.
    public int LifeSteal { get; set; }
    public int Cost { get; set; }
    public string Name { get; set; }
    public int LifeSteal
    {
        get => Weapon.LifeSteal + _lifeSteal;
        protected init => _lifeSteal = value;
    }

    public int Cost
    {
        get => _cost + Weapon.Cost + Shield.Cost + ChestPlate.Cost;
        init => _cost = value;
    }


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

    // What will happen when damage is dealt.
    public void DamageDealt(int damageDealt)
    {
        Heal(damageDealt * (LifeSteal / 100));
    }

    public void Heal(int heal)
    {
        if (Health + heal < MaxHealth)
        {
            Health += heal;
        }
        else
        {
            Health = MaxHealth;
        }
    }
}