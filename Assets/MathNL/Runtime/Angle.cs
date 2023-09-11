using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// 角度を0°から360°の範囲に正規化します。
        /// </summary>
        /// <param name="angle">正規化する角度。</param>
        /// <returns>正規化された角度。</returns>
        public static float NormalizeAngle(float angle)
        {
            return (angle % 360f + 360f) % 360f;
        }
        /// <summary>.
        /// 角度を-180°から180°の範囲に正規化します。
        /// </summary>
        /// <param name="angle">正規化する角度。</param>
        /// <returns>正規化された角度。</returns>
        public static float NormalizeAngle180(float angle)
        {
            return (360f + (angle + 180f) % 360f) % 360f - 180f;
        }
        /// <summary>
        /// 二つの角度間の最小絶対差を計算します。
        /// </summary>
        /// <param name="angleA">最初の角度。</param>
        /// <param name="angleB">二番目の角度。</param>
        /// <returns>二つの角度間の最小絶対差。</returns>
        public static float AbsoluteAngleDifference(float angleA, float angleB)
        {
            return Mathf.Abs(AngleDifference(angleA, angleB));
        }
        /// <summary>
        /// 二つの角度間の最小差を計算します。
        /// </summary>
        /// <param name="angleA">最初の角度。</param>
        /// <param name="angleB">二番目の角度。</param>
        /// <returns>angleAからangleBへの円上の方向を考慮した角度の差。</returns>
        public static float AngleDifference(float angleA, float angleB)
        {
            return NormalizeAngle180(angleB - angleA);
        }

        /// <summary>
        /// 角度を指定された範囲内に制限します。
        /// </summary>
        /// <param name="angle">制限する角度。</param>
        /// <param name="minAngle">範囲の最小角度。</param>
        /// <param name="maxAngle">範囲の最大角度。</param>
        /// <returns>制限された角度。</returns>

        public static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            float distanceToMin = AngleDifference(angle, minAngle);
            float distanceToMax = AngleDifference(angle, maxAngle);

            if (distanceToMin <= 0 && distanceToMax >= 0)
            {
                return angle;
            }

            return Mathf.Abs(distanceToMin) < Mathf.Abs(distanceToMax) ? minAngle : maxAngle;
        }


        /// <summary>
        /// 一つの角度から別の角度までの時計回りの距離を計算します。
        /// </summary>
        /// <returns>角度間の時計回りの距離。</returns>
        public static float ClockwiseAngleDistance(float angleA, float angleB)
        {
            return 360f - NormalizeAngle(angleB - angleA);
        }

        /// <summary>
        /// 一つの角度から別の角度までの反時計回りの距離を計算します。
        /// </summary>
        /// <returns>角度間の反時計回りの距離。</returns>
        public static float CounterClockwiseAngleDistance(float angleA, float angleB)
        {
            return 360f - NormalizeAngle(angleA - angleB);
        }


        /// <summary>
        /// 角度を最も近い90度の倍数に四捨五入します。
        /// </summary>
        /// <param name="angle">四捨五入する角度。</param>
        /// <returns>四捨五入された角度。</returns>
        public static float RoundToNearestRightAngle(float angle)
        {
            float a = Mathf.Round(NormalizeAngle(angle) / 90f) * 90f;
            return (a == 360) ? 0 : a;
        }

        /// <summary>
        /// 複数の角度の平均を計算します。
        /// </summary>
        /// <param name="angles">角度の配列。</param>
        /// <returns>平均角度。</returns>
        public static float AverageAngle(params float[] angles)
        {
            float sinSum = 0;
            float cosSum = 0;

            foreach (float angle in angles)
            {
                sinSum += Mathf.Sin(angle * Mathf.Deg2Rad);
                cosSum += Mathf.Cos(angle * Mathf.Deg2Rad);
            }

            return Mathf.Atan2(sinSum, cosSum) * Mathf.Rad2Deg;
        }
    }
}