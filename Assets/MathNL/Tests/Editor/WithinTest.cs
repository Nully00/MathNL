using Nulock.Math;
using NUnit.Framework;
using UnityEngine;

public class WithinTest
{
    [Test]
    public void IsWithinCircularRangeTests()
    {
        // 現在の角度が目標の角度の範囲内にある場合のテスト
        Assert.That(MathNL.IsWithinCircularRange(10, 0, 20), Is.True);

        // 現在の角度が目標の角度の範囲外にある場合のテスト
        Assert.That(MathNL.IsWithinCircularRange(15, 0, 10), Is.False);

        // 現在の角度が境界上にある場合のテスト
        Assert.That(MathNL.IsWithinCircularRange(10, 0, 20), Is.True);
        Assert.That(MathNL.IsWithinCircularRange(-10, 0, 20), Is.True);

        // 360度を越える角度でのテスト
        Assert.That(MathNL.IsWithinCircularRange(350, 10, 40), Is.True);
        Assert.That(MathNL.IsWithinCircularRange(350, 10, 20), Is.False);

        // 負の角度でのテスト
        Assert.That(MathNL.IsWithinCircularRange(-10, 350, 40), Is.True);

        // rangeAngleが0の場合のテスト
        Assert.That(MathNL.IsWithinCircularRange(10, 10, 0), Is.True);
        Assert.That(MathNL.IsWithinCircularRange(11, 10, 0), Is.False);
    }

    [Test]
    public void IsWithinRangeTests()
    {
        // 範囲内のテスト
        Assert.That(5f.IsWithinRange(1f, 10f), Is.True);
        Assert.That(5f.IsWithinRange(10f, 1f), Is.True); // fromとtoの順序を入れ替えたケース

        // 境界のテスト
        Assert.That(1f.IsWithinRange(1f, 10f), Is.True);
        Assert.That(10f.IsWithinRange(1f, 10f), Is.True);

        // 範囲外のテスト
        Assert.That(11f.IsWithinRange(1f, 10f), Is.False);
        Assert.That(0f.IsWithinRange(1f, 10f), Is.False);
    }
    [Test]
    public void IsWithinDirectionRangeTests()
    {
        var center = Vector2.zero;
        var rangeA = new Vector2(1, 1);
        var rangeB = new Vector2(-1, 1);

        // 範囲内のベクトルのテスト
        Assert.That(MathNL.IsWithinDirectionRange(center, new Vector2(0, 1), rangeA, rangeB), Is.True);

        // 範囲の境界上のベクトルのテスト
        Assert.That(MathNL.IsWithinDirectionRange(center, new Vector2(1, 1), rangeA, rangeB), Is.True);
        Assert.That(MathNL.IsWithinDirectionRange(center, new Vector2(-1, 1), rangeA, rangeB), Is.True);

        // 範囲外のベクトルのテスト
        Assert.That(MathNL.IsWithinDirectionRange(center, new Vector2(-1, -1), rangeA, rangeB), Is.False);
    }
    [Test]
    public void IsWithinCircleRangeTests()
    {
        var center = Vector2.zero;

        // 円の内部にあるベクトル
        Assert.That(MathNL.IsWithinCircleRange(center, new Vector2(0.5f, 0.5f), 1f), Is.True);

        // 円の境界上のベクトル
        Assert.That(MathNL.IsWithinCircleRange(center, new Vector2(1f, 0f), 1f), Is.True);

        // 円の外部のベクトル
        Assert.That(MathNL.IsWithinCircleRange(center, new Vector2(1.5f, 1.5f), 1f), Is.False);
    }

    [Test]
    public void IsWithinSharpFunRangeTests()
    {
        var center = Vector2.zero;
        var rangeA = new Vector2(1, 1);
        var rangeB = new Vector2(-1, 1);

        // 範囲および半径内のベクトル
        Assert.That(MathNL.IsWithinSharpFunRange(center, new Vector2(0.5f, 0.5f), rangeA, rangeB, 1f), Is.True);

        // 範囲内だが半径外のベクトル
        Assert.That(MathNL.IsWithinSharpFunRange(center, new Vector2(2f, 2f), rangeA, rangeB, 1f), Is.False);

        // 半径内だが範囲外のベクトル
        Assert.That(MathNL.IsWithinSharpFunRange(center, new Vector2(-1f, -1f), rangeA, rangeB, 1f), Is.False);
    }
}
