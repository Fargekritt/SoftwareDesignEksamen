using System.ComponentModel;
using SoftwareDesignEksamen.army;
using SoftwareDesignEksamen.gear.chestPlate;
using SoftwareDesignEksamen.gear.shield;
using SoftwareDesignEksamen.gear.weapon.decorator;
using SoftwareDesignEksamen.player;
using SoftwareDesignEksamen.unit;
using SoftwareDesignEksamen.unit.unitDecorator;
using SoftwareDesignEksamen.unit.unitFactory;
using SoftwareDesignEksamen.weapon;

namespace NunitTests;

public class Tests
{
    // ARMY

    // TEST methodes attackedBy, healingTurn .....


    [SetUp]
    public void Setup()
    {
    }

    #region Gear

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


    // ADD CHESTPLATE !?
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

    #endregion

    #region Unit

    [TestCase("elf", 10, 10, 1, 0, 50, 0, 10)]
    [TestCase("human", 10, 50, 1, 0, 100, 0, 0)]
    [TestCase("orc", 10, 20, 1, 0, 150, 30, 0)]
    public void TestUnits(string unit, int expectedCost, int expectedDmg, int expectedReach, int expectedLifeSteal,
        int expectedHp, int expectedArmor, int expectedHealing)
    {
        AbstractUnit? abstractUnit = unit switch
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
        AbstractUnit? abstractUnit = decorator switch
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

    #endregion

    #region Army

    [Test]
    public void TestAttackedBy()
    {
        UnitFactory factory = new UnitFactory();
        var defenderDps1 = factory.CreateUnit(UnitEnum.Dps);
        var defenderDps2 = factory.CreateUnit(UnitEnum.Dps);
        Army defenderArmy = new Army();
        defenderArmy.AddUnit(defenderDps1);
        defenderArmy.AddUnit(defenderDps2);


        var attackerDps1 = factory.CreateUnit(UnitEnum.Dps);
        var attackerDps2 = factory.CreateUnit(UnitEnum.Dps);
        Army attackerArmy = new Army();
        attackerArmy.AddUnit(attackerDps1);
        attackerArmy.AddUnit(attackerDps2);

        Assert.That(defenderArmy.Units, Has.Count.EqualTo(2));

        defenderArmy.AttackedBy(attackerArmy);
        Assert.That(defenderArmy.Units[0].Health, Is.EqualTo(0));

        defenderArmy.Update();
        Assert.That(defenderArmy.Units, Has.Count.EqualTo(1));
        
        defenderArmy.AttackedBy(attackerArmy);
        Assert.That(defenderArmy.Units[0].Health, Is.EqualTo(0));
    }

     
    #endregion
}