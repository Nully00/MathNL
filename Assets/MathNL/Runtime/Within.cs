using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// 指定された現在の角度が、目標の角度に対する指定範囲内にあるかどうかを判断します。
        /// </summary>
        /// <param name="currentAngle">調査する角度。</param>
        /// <param name="targetAngle">希望の範囲の中心角度。</param>
        /// <param name="rangeAngle">目標角度の周りの希望の範囲の幅。</param>
        /// <returns>現在の角度が目標角度の指定範囲内にある場合はtrueを返し、それ以外の場合はfalseを返します。</returns>
        public static bool IsWithinCircularRange(float currentAngle, float targetAngle, float rangeAngle)
        {
            float diff = AbsoluteAngleDifference(currentAngle, targetAngle);
            return diff <= rangeAngle / 2;
        }
    }
}
