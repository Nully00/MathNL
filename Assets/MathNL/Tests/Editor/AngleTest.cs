using Nulock.Math;
using NUnit.Framework;

public class AngleTest
{
    [Test]
    public void NormalizeAngle()
    {
    }

    [Test]
    public void NormalizeAngle180Tests()
    {
    }

    [Test]
    public void AbsoluteAngleDifferenceTests()
    {
        Assert.AreEqual(MathNL.AbsoluteAngleDifference(0, 0), 0);
        Assert.AreEqual(MathNL.AbsoluteAngleDifference(10, -10), 20);
        Assert.AreEqual(MathNL.AbsoluteAngleDifference(350, 10), 20);
        Assert.AreEqual(MathNL.AbsoluteAngleDifference(170, -170), 20);
        Assert.AreEqual(MathNL.AbsoluteAngleDifference(170 + 360, -170), 20);
    }

    [Test]
    public void AngleDifferenceTests()
    {
        Assert.That(MathNL.AngleDifference(0, 0), Is.EqualTo(0).Within(1e-6));
        Assert.That(MathNL.AngleDifference(10, -10), Is.EqualTo(-20).Within(1e-6));
        Assert.That(MathNL.AngleDifference(-10, -30), Is.EqualTo(-20).Within(1e-6));
        Assert.That(MathNL.AngleDifference(350, 10), Is.EqualTo(20).Within(1e-6));
        Assert.That(MathNL.AngleDifference(170, -170), Is.EqualTo(20).Within(1e-6));
        Assert.That(MathNL.AngleDifference(170 + 360, -170), Is.EqualTo(20).Within(1e-6));
    }

    [Test]
    public void ClampAngleTests()
    {
        Assert.AreEqual(10f, MathNL.ClampAngle(10f, 0f, 20f));
        Assert.AreEqual(0f, MathNL.ClampAngle(-10f, 0f, 20f));
        Assert.AreEqual(20f, MathNL.ClampAngle(30f, 0f, 20f));
        Assert.AreEqual(-150f, MathNL.ClampAngle(-150f, -170f, -130f));
        Assert.AreEqual(-170f, MathNL.ClampAngle(-180f, -170f, -130f));
        Assert.AreEqual(-130f, MathNL.ClampAngle(-120f, -170f, -130f));
        Assert.AreEqual(-130f, MathNL.ClampAngle(-120f, -170f, -130f));
        Assert.AreEqual(MathNL.ClampAngle(171, -170, 170), 170);
        Assert.AreEqual(MathNL.ClampAngle(180, 170, 190), 180);
        Assert.AreEqual(MathNL.ClampAngle(195, 170, 190), 190);

    }
    [Test]
    public void ClockwiseAngleDistanceTests()
    {
        Assert.AreEqual(340f, MathNL.ClockwiseAngleDistance(10f, 30f));
        Assert.AreEqual(340f, MathNL.ClockwiseAngleDistance(350f, 10f));
        Assert.AreEqual(20f, MathNL.ClockwiseAngleDistance(-10f, -30f));
        Assert.AreEqual(40f, MathNL.ClockwiseAngleDistance(-160f, 160f));
        Assert.AreEqual(40f, MathNL.ClockwiseAngleDistance(-160f, 160f + 360f));
        Assert.AreEqual(90, MathNL.ClockwiseAngleDistance(270, 180));
    }
    [Test]
    public void CounterClockwiseAngleDistanceTests()
    {
        Assert.AreEqual(20f, MathNL.CounterClockwiseAngleDistance(10f, 30f));
        Assert.AreEqual(20f, MathNL.CounterClockwiseAngleDistance(350f, 10f));
        Assert.AreEqual(360 - 20f, MathNL.CounterClockwiseAngleDistance(-10f, -30f));
        Assert.AreEqual(360 - 40f, MathNL.CounterClockwiseAngleDistance(-160f, 160f));
        Assert.AreEqual(360 - 40f, MathNL.CounterClockwiseAngleDistance(-160f, 160f + 360f));
    }
}
