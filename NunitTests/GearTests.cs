using SoftwareDesignEksamen.gear.chestPlate;
using SoftwareDesignEksamen.gear.shield;
using SoftwareDesignEksamen.gear.weapon.decorator;
using SoftwareDesignEksamen.unit.unitFactory;
using SoftwareDesignEksamen.weapon;

namespace NunitTests;

public class GearTests
{
    [TestCase("noSword", 0, 0, 0, 0)]
    [TestCase("sword", 2, 50, 0, 0)]
    [TestCase("spear", 2, 30, 1, 0)]
    public void TestWeapons(string weapon, int expectedCost, int expectedDmg, int expectedReach, int expectedLifeSteal)
    {
        AbstractWeapon abstractWeapon = weapon switch
        {
            "sword" => new Sword(),
            "spear" => new Spear(),
            _ => new NoSword()
        };

        Assert.Multiple(() =>
        {
            Assert.That(abstractWeapon.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractWeapon.Damage, Is.EqualTo(expectedDmg));
            Assert.That(abstractWeapon.Reach, Is.EqualTo(expectedReach));
            Assert.That(abstractWeapon.LifeSteal, Is.EqualTo(expectedLifeSteal));
        });
    }

    [TestCase("reach", 7, 50, 1, 0)]
    [TestCase("lifeSteal", 12, 50, 0, 30)]
    [TestCase("sharp", 4, 52, 0, 0)]
    public void TestWeaponDecorators(string decorator, int expectedCost, int expectedDmg, int expectedReach,
        int expectedLifeSteal)
    {
        AbstractWeapon abstractWeapon = new Sword();
        switch (decorator)
        {
            case "reach":
                abstractWeapon = new ReachDecorator(abstractWeapon);
                break;
            case "lifeSteal":
                abstractWeapon = new LifeStealDecorator(abstractWeapon);
                break;
            case "sharp":
                abstractWeapon = new SharpDecorator(abstractWeapon);
                break;
        }

        Assert.Multiple(() =>
        {
            Assert.That(abstractWeapon.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractWeapon.Damage, Is.EqualTo(expectedDmg));
            Assert.That(abstractWeapon.Reach, Is.EqualTo(expectedReach));
            Assert.That(abstractWeapon.LifeSteal, Is.EqualTo(expectedLifeSteal));
        });
    }

    [TestCase("noShield", 0, 0)]
    [TestCase("kiteShield", 10, 15)]
    public void TestShields(string shield, int expectedCost, int expectedArmor)
    {
        AbstractShield abstractShield = shield switch
        {
            "kiteShield" => new KiteShield(),
            _ => new NoShield()
        };

        Assert.Multiple(() =>
        {
            Assert.That(abstractShield.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractShield.Armor, Is.EqualTo(expectedArmor));
        });
    }

    [TestCase("noChestPlate", 0, 0)]
    public void TestChestPlate(string chestPlate, int expectedCost, int expectedArmor)
    {
        AbstractChestPlate abstractChestPlate = new NoChestPlate();

        /*switch (chestPlate)
        {
            case "":
                abstractChestPlate 
                break;
        }*/

        Assert.Multiple(() =>
        {
            Assert.That(abstractChestPlate.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractChestPlate.Armor, Is.EqualTo(expectedArmor));
        });
    }
}