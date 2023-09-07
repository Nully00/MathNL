using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// ２つのベクトル間の角度を取得します。
        /// </summary>
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            var dx = to.x - from.x;
            var dy = to.y - from.y;
            var rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }
        /// <summary>
        /// 原点から指定したベクトルへの角度を取得します。
        /// </summary>
        public static float GetAngle(Vector2 to)
        {
            return GetAngle(Vector2.zero, to);
        }
        /// <summary>
        /// 指定した角度の方向ベクトルを取得します。
        /// </summary>
        public static Vector2 GetDirection(float angle)
        {
            return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
        /// <summary>
        /// ２つのベクトル間の方向ベクトルを取得します。
        /// </summary>
        public static Vector2 GetDirection(Vector2 from, Vector2 to)
        {
            return GetDirection(GetAngle(from, to));
        }
        /// <summary>
        /// どちら側にいるかどうかを取得します。
        /// </summary>
        public static float GetSide(Vector2 self, Vector2 target, Vector2 dir)
        {
            Vector2 diff = target - self;
            float cross = Cross(dir, diff);
            return Vector2.Angle(dir, diff) * ((cross > 0) ? 1 : -1);

            float Cross(Vector2 a, Vector2 b) => a.x * b.y - a.y * b.x;
        }
        /// <summary>
        /// 与えられたリスト内で、指定した目標値に最も近い上の値を取得します。
        /// </summary>
        public static int ApproxUp(this IEnumerable<int> list, int target)
        {
            int num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target + num) ? target + num : target - num;
        }
        /// <summary>
        /// 与えられたリスト内で、指定した目標値に最も近い上の値を取得します。
        /// </summary>
        public static float ApproxUp(this IEnumerable<float> list, float target)
        {
            float num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target + num) ? target + num : target - num;
        }
        /// <summary>
        /// 与えられたリスト内で、指定した目標値に最も近い下の値を取得します。
        /// </summary>
        public static int ApproxDown(this IEnumerable<int> list, int target)
        {
            int num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target - num) ? target - num : target + num;
        }
        /// <summary>
        /// 与えられたリスト内で、指定した目標値に最も近い下の値を取得します。
        /// </summary>
        public static float ApproxDown(this IEnumerable<float> list, float target)
        {
            float num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target - num) ? target - num : target + num;
        }
        /// <summary>
        /// 与えられたリストの分散を計算します。
        /// </summary>
        public static float Var(this IEnumerable<float> list)
        {
            return (float)list.Select(x => Mathf.Pow(x - list.Average(), 2)).Average();
        }
        /// <summary>
        /// 与えられたリストの標準偏差を計算します。
        /// </summary>
        public static float Stdev(this IEnumerable<float> list)
        {
            return (float)Mathf.Sqrt(list.Var());
        }
        /// <summary>
        /// 与えられたリストの範囲（最大値 - 最小値）を計算します。
        /// </summary>
        public static float Range(this IEnumerable<float> list)
        {
            return list.Max() - list.Min();
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
        /// 指定した範囲内にベクトルが存在するかどうかを判定します。(実験中)
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="current">現在のベクトル</param>
        /// <param name="rangeA">範囲A</param>
        /// <param name="rangeB">範囲B</param>
        public static bool IsWithinDirectionRange(Vector2 center,Vector2 current, Vector2 rangeA, Vector2 rangeB)
        {
            float rangeAAngle = GetAngle(center,rangeA);
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
        public static bool IsWithinSharpFunRange(Vector2 center, Vector2 current, Vector2 rangeA, Vector2 rangeB,float r)
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
