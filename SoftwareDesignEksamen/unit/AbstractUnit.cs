using SoftwareDesignEksamen.battleLog;
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
    private BattleLogger _logger = BattleLogger.CreateInstance();

    public string Description { get; set; } = "";
    public int Health { get; set; }

    public int MaxHealth
    {
        get => _maxHealth;
        protected init
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


    public string Name { get; set; } = "";
    public int LifeSteal
    {
        get => Weapon.LifeSteal + _lifeSteal;
        protected init => _lifeSteal = value;
    }

    public int Cost
    {
        get => _cost + Weapon.Cost + Shield.Cost + ChestPlate.Cost;
        protected init => _cost = value;
    }


    // Returns true if health is not 0.
    public bool IsAlive()
    {
        return Health > 0;
    }

    // Reduces health in unit and returns the damage dealt
    /// <summary>
    /// Reduces the units health based on the damage taken and armor
    /// </summary>
    /// <param name="damage">how much damage the attacker has</param>
    /// <returns>how much damage was dealt after armor reductions</returns>
    public int TakeDamage(int damage)
    {
        damage -= Armor;
        if (damage < 1)
        {
            damage = 1;
        }
        _logger.Info($"{Name} has {Armor} armor and is taking {damage} Damage.");
        if (Health - damage < 1)
        {
            int damageTaken = Health;
            Health = 0;
            _logger.Info($"<!!!! {Name} Has now died </3 !!!!>", ConsoleColor.Magenta);
            return damageTaken;
        }
        Health -= damage;
        _logger.Info($"{Name}s current Health is {Health}");

        return damage;
    }

    // todo:
    //  damage === damage - armor FOR NOW!!!

    // What will happen when damage is dealt.
    
    /// <summary>
    /// How much damage the unit has dealt on enemy units. Lifesteals based on the damagedealt
    /// </summary>
    /// <param name="damageDealt">DamageDealt</param>
    public void DamageDealt(int damageDealt)
    {
        _logger.Info($"{Name} dealt {damageDealt} amount of damage");
        var lifeStolen = (damageDealt * LifeSteal) / 100;
        _logger.Info($"{Name} has {LifeSteal}% Lifesteal and is healing for {lifeStolen}");
        if (lifeStolen > 0)
        {
            Heal(lifeStolen);
        }
        
    }

    /// <summary>
    /// Heals the unit. caps at the units max health
    /// </summary>
    /// <param name="heal">how much to heal the unit for</param>
    public void Heal(int heal)
    {
        _logger.Info($"{Name} is healing for {heal}");
        if (Health + heal < MaxHealth)
        {
            Health += heal;
        }
        else
        {
            Health = MaxHealth;
        }
        _logger.Info($"{Name}s current health after healing {Health}");
    }

    public override string ToString()
    {
        return $"Name: {Name} \nDescription: {Description} \nHealth: {Health}";

    }
}