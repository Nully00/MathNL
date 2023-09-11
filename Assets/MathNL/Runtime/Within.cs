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


        /// <summary>
        /// 指定した範囲内に値が存在するかどうかを判定します。
        /// </summary>
        public static bool IsWithinRange(this float self, float from, float to)
        {
            var (min, max) = (from > to) ? (to, from) : (from, to);
            return min <= self && self <= max;
        }

        /// <summary>
        /// 指定した範囲内にベクトルが存在するかどうかを判定します。
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="current">現在のベクトル</param>
        /// <param name="rangeA">範囲A</param>
        /// <param name="rangeB">範囲B</param>
        public static bool IsWithinDirectionRange(Vector2 center, Vector2 current, Vector2 rangeA, Vector2 rangeB)
        {
            float rangeAAngle = GetAngle(center, rangeA);
            float rangeBAngle = GetAngle(center, rangeB);

            float currentAngle = GetAngle(center, current);
            float targetAngle = AverageAngle(rangeAAngle, rangeBAngle);
            float range = AbsoluteAngleDifference(rangeAAngle, rangeBAngle);

            return IsWithinCircularRange(currentAngle, targetAngle, range);
        }

        /// <summary>
        /// 指定した範囲および半径内にベクトルが存在するかどうかを判定します。(実験中)
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="current">現在のベクトル</param>
        /// <param name="rangeA">範囲A</param>
        /// <param name="rangeB">範囲B</param>
        /// <param name="r">半径</param>
        public static bool IsWithinSharpFunRange(Vector2 center, Vector2 current, Vector2 rangeA, Vector2 rangeB, float r)
        {
            if (!IsWithinCircleRange(center, current, r)) return false;

            return IsWithinDirectionRange(center, current, rangeA, rangeB);
        }

        /// <summary>
        /// 指定した円内にベクトルが存在するかどうかを判定します。
        /// </summary>
        public static bool IsWithinCircleRange(Vector2 center, Vector2 current, float r)
        {
            return Vector2.Distance(center, current) <= r;
        }
    }
}
