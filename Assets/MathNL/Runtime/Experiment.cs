using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            var dx = to.x - from.x;
            var dy = to.y - from.y;
            var rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }
        public static float GetAngle(Vector2 to)
        {
            return GetAngle(Vector2.zero, to);
        }

        public static Vector2 GetDirection(float angle)
        {
            return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
        public static Vector2 GetDirection(Vector2 from, Vector2 to)
        {
            return GetDirection(GetAngle(from, to));
        }
        public static float GetSide(Vector2 self, Vector2 target, Vector2 dir)
        {
            Vector2 diff = target - self;
            float cross = Cross(dir, diff);
            return Vector2.Angle(dir, diff) * ((cross > 0) ? 1 : -1);

            float Cross(Vector2 a, Vector2 b) => a.x * b.y - a.y * b.x;
        }

        public static int ApproxUp(this IEnumerable<int> list, int target)
        {
            int num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target + num) ? target + num : target - num;
        }
        public static float ApproxUp(this IEnumerable<float> list, float target)
        {
            float num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target + num) ? target + num : target - num;
        }
        public static int ApproxDown(this IEnumerable<int> list, int target)
        {
            int num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target - num) ? target - num : target + num;
        }
        public static float ApproxDown(this IEnumerable<float> list, float target)
        {
            float num = list.Select(x => Mathf.Abs(x - target)).Min();
            return list.Contains(target - num) ? target - num : target + num;
        }

        public static float Var(this IEnumerable<float> list)
        {
            return (float)list.Select(x => Mathf.Pow(x - list.Average(), 2)).Average();
        }
        public static float Stdev(this IEnumerable<float> list)
        {
            return (float)Mathf.Sqrt(list.Var());
        }
        public static float Range(this IEnumerable<float> list)
        {
            return list.Max() - list.Min();
        }
        public static bool WithinRange(this float self, float from, float to)
        {
            var (min, max) = (from > to) ? (to, from) : (from, to);
            return min <= self && self <= max;
        }

        //未検証
        public static bool WithinDirectionRange(Vector2 center,Vector2 current, Vector2 rangeA, Vector2 rangeB)
        {
            float rangeAAngle = GetAngle(center,rangeA);
            float rangeBAngle = GetAngle(center, rangeB);

            float currentAngle = GetAngle(center, current);
            float targetAngle = AverageAngle(rangeAAngle, rangeBAngle);
            float range = AbsoluteAngleDifference(rangeAAngle, rangeBAngle);

            return WithinCircularRange(currentAngle, targetAngle, range);
        }

        //未検証
        public static bool WithinSharpFunRange(Vector2 center, Vector2 current, Vector2 rangeA, Vector2 rangeB,float r)
        {
            if(Vector2.Distance(center, current) > r) return false;

            return WithinDirectionRange(center, current, rangeA, rangeB);
        }
        public static bool WithinCircleRange(this Vector2 self, Vector2 target, float r)
        {
            return Vector2.Distance(self, target) <= r;
        }
    }
}
