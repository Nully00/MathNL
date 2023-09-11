using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// ２つのベクトル間の角度を取得します。(0から360)
        /// </summary>
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            return NormalizeAngle(GetAngle180(from, to));
        }
        /// <summary>
        /// ２つのベクトル間の角度を取得します。(-180から180)
        /// </summary>
        public static float GetAngle180(Vector2 from, Vector2 to)
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
        /// 原点から指定したベクトルへの角度を取得します。
        /// </summary>
        public static float GetAngle180(Vector2 to)
        {
            return GetAngle180(Vector2.zero, to);
        }
        /// <summary>
        /// 指定した角度の方向ベクトルを取得します。
        /// </summary>
        public static Vector2 GetDirection(float angle)
        {
            return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
        /// <summary>
        /// 指定した角度の方向ベクトルを取得します。
        /// </summary>
        public static Vector2 GetDirection(Vector2 to)
        {
            return GetDirection(GetAngle(to));
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

            float angle = Vector2.Angle(dir, diff);

            float cross = dir.x * diff.y - dir.y * diff.x;

            return angle * ((cross > 0) ? 1 : -1);
        }
    }
}
