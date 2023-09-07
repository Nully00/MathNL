using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>.
        /// 角度を-180°から180°の範囲に正規化します。
        /// </summary>
        /// <param name="angle">正規化する角度。</param>
        /// <returns>正規化された角度。</returns>
        public static float NormalizeAngle(float angle)
        {
            return (angle + 180) % 360 - 180;
        }
        /// <summary>
        /// 角度を0°から360°の範囲に正規化します。
        /// </summary>
        /// <param name="angle">正規化する角度。</param>
        /// <returns>正規化された角度。</returns>
        public static float NormalizeAngle360(float angle)
        {
            return (angle % 360f + 360f) % 360f;
        }
        /// <summary>
        /// 二つの角度間の最小絶対差を計算します。
        /// </summary>
        /// <param name="angleA">最初の角度。</param>
        /// <param name="angleB">二番目の角度。</param>
        /// <returns>二つの角度間の最小絶対差。</returns>
        public static float AbsoluteAngleDifference(float angleA, float angleB)
        {
            float diff = NormalizeAngle(angleB - angleA);
            return Mathf.Abs(diff);
        }
        /// <summary>
        /// 二つの角度間の差を計算し、-180°から180°の間の値として返します。
        /// </summary>
        /// <param name="angleA">最初の角度。</param>
        /// <param name="angleB">二番目の角度。</param>
        /// <returns>angleAからangleBへの円上の方向を考慮した角度の差。</returns>
        public static float AngleDifference(float angleA, float angleB)
        {
            return NormalizeAngle(angleB - angleA);
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
            float normalizedAngle = NormalizeAngle(angle);
            return Mathf.Clamp(normalizedAngle, minAngle, maxAngle);
        }

        

        /// <summary>
        /// 一つの角度から別の角度までの時計回りの距離を計算します。
        /// </summary>
        /// <param name="fromAngle">開始角度。</param>
        /// <param name="toAngle">終了角度。</param>
        /// <returns>角度間の時計回りの距離。</returns>
        public static float ClockwiseDistance(float fromAngle, float toAngle)
        {
            float normalizedFrom = NormalizeAngle(fromAngle);
            float normalizedTo = NormalizeAngle(toAngle);
            if (normalizedTo >= normalizedFrom)
                return normalizedTo - normalizedFrom;
            return 360 + normalizedTo - normalizedFrom;
        }

        /// <summary>
        /// 一つの角度から別の角度までの反時計回りの距離を計算します。
        /// </summary>
        /// <param name="fromAngle">開始角度。</param>
        /// <param name="toAngle">終了角度。</param>
        /// <returns>角度間の反時計回りの距離。</returns>
        public static float CounterClockwiseDistance(float fromAngle, float toAngle)
        {
            return 360 - ClockwiseDistance(fromAngle, toAngle);
        }

        /// <summary>
        /// 二つの角度の間で線形補間を行います。
        /// </summary>
        /// <param name="angle1">最初の角度。</param>
        /// <param name="angle2">二番目の角度。</param>
        /// <param name="t">補間の比率。</param>
        /// <returns>補間された角度。</returns>
        public static float LerpAngle(float angle1, float angle2, float t)
        {
            float diff = NormalizeAngle(angle2 - angle1);
            if (diff > 180) diff -= 360;
            return angle1 + diff * t;
        }

        /// <summary>
        /// 一つの角度から別の角度への最短の回転方向を計算します。
        /// </summary>
        /// <param name="fromAngle">開始角度。</param>
        /// <param name="toAngle">終了角度。</param>
        /// <returns>時計回りの場合は1、反時計回りの場合は-1。</returns>
        public static int ShortestRotationDirection(float fromAngle, float toAngle)
        {
            return (NormalizeAngle(fromAngle - toAngle) > 0) ? 1 : -1;
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

        /// <summary>
        /// 角度を最も近い90度の倍数に四捨五入します。
        /// </summary>
        /// <param name="angle">四捨五入する角度。</param>
        /// <returns>四捨五入された角度。</returns>
        public static float RoundToNearestRightAngle(float angle)
        {
            return Mathf.Round(angle / 90f) * 90f;
        }

        
    }
}