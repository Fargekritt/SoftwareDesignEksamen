using SoftwareDesignEksamen.gear.shield;
using SoftwareDesignEksamen.gear.weapon.decorator;
using SoftwareDesignEksamen.unit.unitDecorator;
using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.unit.unitFactory;

public class UnitFactory
{
    public AbstractUnit CreateUnit(UnitEnum unit)
    {
        switch (unit)
        {
            case UnitEnum.Dps:
            {
                var dps = new DpsDecorator(new HumanUnit())
                {
                    Weapon = CreateWeapon(WeaponEnum.SharpSword)
                };
                dps.Description = "Basic DPS unit, Simple cheap";
                return dps;
            }
            case UnitEnum.Tank:
            {
                var tank = new TankDecorator(new OrcUnit())
                {
                    Weapon = CreateWeapon(WeaponEnum.ShortSword),
                    Shield = CreateShield(ShieldEnum.Kite)
                };
                tank.Description = "Basic Tank unit, Simple cheap";
                return tank;
            }
            case UnitEnum.Healer:
            {
                var healer = new HealerDecorator(new ElfUnit());
                healer.Description = "Basic Healer unit, Simple cheap";
                return healer;
                
            }
            case UnitEnum.RaidBoss:
            {
                var raidBoss = new DpsDecorator(new OrcUnit())
                {
                    Weapon = CreateWeapon(WeaponEnum.VampircSword),
                    Shield = CreateShield(ShieldEnum.Kite)
                };
                raidBoss.Description = "High heavy hitting tank, with Lifestealing sword. Can hold the frontline on its own";
                return raidBoss;
            }
            default: return new HumanUnit();
        }
    }


    public AbstractWeapon CreateWeapon(WeaponEnum weapon)
    {
        switch (weapon)
        {
            case WeaponEnum.LongSword : return new ReachDecorator(new Sword());
            case WeaponEnum.ShortSword : return new Sword();
            case WeaponEnum.SharpSword : return new SharpDecorator(new Sword());
            case WeaponEnum.Spear : return new Spear();
            case WeaponEnum.Pike : return new ReachDecorator(new Spear());
            case WeaponEnum.VampircSword : return new LifeStealDecorator(new ReachDecorator(new Sword()));
        }

        return new NoSword();
    }

    public AbstractShield CreateShield(ShieldEnum shield)
    {
        switch (shield)
        {
            case ShieldEnum.Kite: return new KiteShield();
        }

        return new NoShield();
    }
}

public enum ShieldEnum
{
    Kite = 1,
}

public enum WeaponEnum
{
    LongSword = 1,
    ShortSword = 2,
    Spear = 3,
    Pike = 4,
    SharpSword = 5,
    VampircSword = 6
}