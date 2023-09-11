using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        
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
    }
}
