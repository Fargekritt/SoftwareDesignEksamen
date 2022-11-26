using SoftwareDesignEksamen.unit;
using SoftwareDesignEksamen.unit.unitDecorator;
using SoftwareDesignEksamen.unit.unitFactory;

namespace NunitTests;

public class UnitTests
{
    
    [TestCase("elf", 10, 10, 1, 0, 50, 0, 10)]
    [TestCase("human", 10, 50, 1, 0, 100, 0, 0)]
    [TestCase("orc", 10, 20, 1, 0, 150, 30, 0)]
    public void TestUnits(string unit, int expectedCost, int expectedDmg, int expectedReach, int expectedLifeSteal,
        int expectedHp, int expectedArmor, int expectedHealing)
    {
        Unit? abstractUnit = unit switch
        {
            "elf" => new ElfUnit(),
            "human" => new HumanUnit(),
            "orc" => new OrcUnit(),
            _ => null
        };

        Assert.Multiple(() =>
        {
            if (abstractUnit == null) return;
            Assert.That(abstractUnit.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractUnit.Damage, Is.EqualTo(expectedDmg));
            Assert.That(abstractUnit.Reach, Is.EqualTo(expectedReach));
            Assert.That(abstractUnit.LifeSteal, Is.EqualTo(expectedLifeSteal));
            Assert.That(abstractUnit.Health, Is.EqualTo(expectedHp));
            Assert.That(abstractUnit.Armor, Is.EqualTo(expectedArmor));
            Assert.That(abstractUnit.Healing, Is.EqualTo(expectedHealing));
        });
    }

    [TestCase("dps", 10, 75, 1, 0, 100, 0, 0)]
    [TestCase("healer", 10, 7, 1, 0, 50, 0, 15)]
    [TestCase("tank", 10, 16, 1, 0, 150, 42, 0)]
    public void TestUnitDecorators(string decorator, int expectedCost, int expectedDmg, int expectedReach,
        int expectedLifeSteal,
        int expectedHp, int expectedArmor, int expectedHealing)
    {
        Unit? abstractUnit = decorator switch
        {
            "dps" => new DpsDecorator(new HumanUnit()),
            "healer" => new HealerDecorator(new ElfUnit()),
            "tank" => new TankDecorator(new OrcUnit()),
            _ => null
        };

        Assert.Multiple(() =>
        {
            if (abstractUnit == null) return;
            Assert.That(abstractUnit.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractUnit.Damage, Is.EqualTo(expectedDmg));
            Assert.That(abstractUnit.Reach, Is.EqualTo(expectedReach));
            Assert.That(abstractUnit.LifeSteal, Is.EqualTo(expectedLifeSteal));
            Assert.That(abstractUnit.Health, Is.EqualTo(expectedHp));
            Assert.That(abstractUnit.Armor, Is.EqualTo(expectedArmor));
            Assert.That(abstractUnit.Healing, Is.EqualTo(expectedHealing));
        });
    }

    [TestCase("dps", 14, 127, 1, 0, 100, 0, 0)]
    [TestCase("healer", 10, 7, 1, 0, 50, 0, 15)]
    [TestCase("tank", 22, 66, 1, 0, 150, 57, 0)]
    [TestCase("raidBoss", 37, 80, 2, 30, 150, 30, 0)]
    public void TestUnitFactory(string unit, int expectedCost, int expectedDmg, int expectedReach,
        int expectedLifeSteal,
        int expectedHp, int expectedArmor, int expectedHealing)
    {
        var factory = new UnitFactory();

        var abstractUnit = unit switch
        {
            "dps" => factory.CreateUnit(UnitEnum.Dps),
            "healer" => factory.CreateUnit(UnitEnum.Healer),
            "tank" => factory.CreateUnit(UnitEnum.Tank),
            "raidBoss" => factory.CreateUnit(UnitEnum.RaidBoss),
            _ => null
        };
        Assert.Multiple(() =>
        {
            if (abstractUnit == null) return;
            Assert.That(abstractUnit.Cost, Is.EqualTo(expectedCost));
            Assert.That(abstractUnit.Damage, Is.EqualTo(expectedDmg));
            Assert.That(abstractUnit.Reach, Is.EqualTo(expectedReach));
            Assert.That(abstractUnit.LifeSteal, Is.EqualTo(expectedLifeSteal));
            Assert.That(abstractUnit.Health, Is.EqualTo(expectedHp));
            Assert.That(abstractUnit.Armor, Is.EqualTo(expectedArmor));
            Assert.That(abstractUnit.Healing, Is.EqualTo(expectedHealing));
        });
    }
}