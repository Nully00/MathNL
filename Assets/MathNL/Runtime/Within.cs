using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// Determines if the given current angle is within a specified range relative to a target angle.
        /// The function handles the circular nature of angles, wrapping between -180° and 180°.
        /// 指定された現在の角度が、目標の角度に対する指定範囲内にあるかどうかを判断します。
        /// </summary>
        /// <param name="currentAngle">The angle to check. 調査する角度。</param>
        /// <param name="targetAngle">The center angle of the desired range. 希望の範囲の中心角度。</param>
        /// <param name="rangeAngle">The width of the desired range around the target angle. 目標角度の周りの希望の範囲の幅。</param>
        /// <returns>Returns true if the current angle is within the specified range of the target angle; otherwise, false. 現在の角度が目標角度の指定範囲内にある場合はtrueを返し、それ以外の場合はfalseを返します。</returns>
        public static bool WithinCircularRange(float currentAngle, float targetAngle, float rangeAngle)
        {
            float diff = AbsoluteAngleDifference(currentAngle, targetAngle);
            return diff <= rangeAngle / 2;
        }
    }
}
