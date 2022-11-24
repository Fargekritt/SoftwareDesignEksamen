using SoftwareDesignEksamen.army;
using SoftwareDesignEksamen.unit;
using SoftwareDesignEksamen.unit.unitFactory;

namespace NunitTests;

public class ArmyTests
{
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

    [Test]
    public void TestHealingTurn()
    {
        var factory = new UnitFactory();
        var dps = factory.CreateUnit(UnitEnum.Dps);
        var healer = factory.CreateUnit(UnitEnum.Healer);

        var army = new Army();
        army.AddUnit(dps);
        army.AddUnit(healer);

        army.Units[0].TakeDamage(50);
        army.HealingTurn();

        Assert.That(army.Units[0].Health, Is.EqualTo(65));
    }
}