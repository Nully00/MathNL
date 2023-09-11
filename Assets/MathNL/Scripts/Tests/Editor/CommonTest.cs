using Nulock.Math;
using NUnit.Framework;
using UnityEngine;

public class CommonTest
{
    [Test]
    public void GetAngleTests()
    {
        Assert.That(MathNL.GetAngle(Vector2.zero, Vector2.right), Is.EqualTo(0).Within(1e-6));

        Assert.That(MathNL.GetAngle(Vector2.zero, Vector2.up), Is.EqualTo(90).Within(1e-6));

        Assert.That(MathNL.GetAngle(new Vector2(1, 1), new Vector2(1, 2)), Is.EqualTo(90).Within(1e-6));
    }


    [Test]
    public void GetDirectionTests()
    {
        var dir = MathNL.GetDirection(0);
        Assert.That(dir.x, Is.EqualTo(1).Within(1e-6));
        Assert.That(dir.y, Is.EqualTo(0).Within(1e-6));

        dir = MathNL.GetDirection(90);
        Assert.That(dir.x, Is.EqualTo(0).Within(1e-6));
        Assert.That(dir.y, Is.EqualTo(1).Within(1e-6));
    }

    [Test]
    public void GetDirectionFromToTests()
    {
        var dir = MathNL.GetDirection(Vector2.zero, new Vector2(1, 1));
        Assert.That(dir.x, Is.EqualTo(0.7071).Within(1e-4));
        Assert.That(dir.y, Is.EqualTo(0.7071).Within(1e-4));
    }

    [Test]
    public void GetSideTests()
    {
        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.right, Vector2.up), Is.EqualTo(-90).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.left, Vector2.up), Is.EqualTo(90).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.up, Vector2.up), Is.EqualTo(0).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.down, Vector2.up), Is.EqualTo(-180).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.up, Vector2.right), Is.EqualTo(90).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, Vector2.down, Vector2.right), Is.EqualTo(-90).Within(1e-6));

        Assert.That(MathNL.GetSide(Vector2.zero, new Vector2(1, 1), Vector2.up), Is.EqualTo(-45).Within(1e-6));
    }
}
