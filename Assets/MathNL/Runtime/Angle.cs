using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>
        /// Normalize an angle to be within the range of -180�� to 180��.
        /// �p�x��-180������180���͈̔͂ɐ��K�����܂��B
        /// </summary>
        /// <param name="angle">Angle to be normalized. ���K������p�x�B</param>
        /// <returns>Normalized angle. ���K�����ꂽ�p�x�B</returns>
        public static float NormalizeAngle(float angle)
        {
            return (angle + 180) % 360 - 180;
        }
        /// <summary>
        /// Normalize an angle to be within the range of 0�� to 360��.
        /// �p�x��0������360���͈̔͂ɐ��K�����܂��B
        /// </summary>
        /// <param name="angle">Angle to be normalized. ���K������p�x�B</param>
        /// <returns>Normalized angle. ���K�����ꂽ�p�x�B</returns>
        public static float NormalizeAngle360(float angle)
        {
            return (angle % 360f + 360f) % 360f;
        }
        /// <summary>
        /// Computes the smallest absolute difference between two angles.
        /// ��̊p�x�Ԃ̍ŏ���΍����v�Z���܂��B
        /// </summary>
        /// <param name="angleA">First angle. �ŏ��̊p�x�B</param>
        /// <param name="angleB">Second angle. ��Ԗڂ̊p�x�B</param>
        /// <returns>Smallest absolute difference between the two angles. ��̊p�x�Ԃ̍ŏ���΍��B</returns>
        public static float AbsoluteAngleDifference(float angleA, float angleB)
        {
            float diff = NormalizeAngle(angleB - angleA);
            return Mathf.Abs(diff);
        }
        /// <summary>
        /// Computes the difference between two angles, resulting in a value between -180�� and 180��.
        /// ��̊p�x�Ԃ̍����v�Z���A-180������180���̊Ԃ̒l�Ƃ��ĕԂ��܂��B
        /// </summary>
        /// <param name="angleA">First angle. �ŏ��̊p�x�B</param>
        /// <param name="angleB">Second angle. ��Ԗڂ̊p�x�B</param>
        /// <returns>Difference between the angles, considering the direction from angleA to angleB on the circle. angleA����angleB�ւ̉~��̕������l�������p�x�̍��B</returns>
        public static float AngleDifference(float angleA, float angleB)
        {
            return NormalizeAngle(angleB - angleA);
        }

        /// <summary>
        /// Clamps an angle to be within a specified range.
        /// �p�x���w�肳�ꂽ�͈͓��ɐ������܂��B
        /// </summary>
        /// <param name="angle">Angle to be clamped. ��������p�x�B</param>
        /// <param name="minAngle">Minimum angle of the range. �͈͂̍ŏ��p�x�B</param>
        /// <param name="maxAngle">Maximum angle of the range. �͈͂̍ő�p�x�B</param>
        /// <returns>Clamped angle. �������ꂽ�p�x�B</returns>
        public static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            float normalizedAngle = NormalizeAngle(angle);
            return Mathf.Clamp(normalizedAngle, minAngle, maxAngle);
        }

        

        /// <summary>
        /// Computes the clockwise distance from one angle to another.
        /// ��̊p�x����ʂ̊p�x�܂ł̎��v���̋������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">Starting angle. �J�n�p�x�B</param>
        /// <param name="toAngle">Ending angle. �I���p�x�B</param>
        /// <returns>Clockwise distance between the angles. �p�x�Ԃ̎��v���̋����B</returns>
        public static float ClockwiseDistance(float fromAngle, float toAngle)
        {
            float normalizedFrom = NormalizeAngle(fromAngle);
            float normalizedTo = NormalizeAngle(toAngle);
            if (normalizedTo >= normalizedFrom)
                return normalizedTo - normalizedFrom;
            return 360 + normalizedTo - normalizedFrom;
        }

        /// <summary>
        /// Computes the counterclockwise distance from one angle to another.
        /// ��̊p�x����ʂ̊p�x�܂ł̔����v���̋������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">Starting angle. �J�n�p�x�B</param>
        /// <param name="toAngle">Ending angle. �I���p�x�B</param>
        /// <returns>Counterclockwise distance between the angles. �p�x�Ԃ̔����v���̋����B</returns>
        public static float CounterClockwiseDistance(float fromAngle, float toAngle)
        {
            return 360 - ClockwiseDistance(fromAngle, toAngle);
        }

        /// <summary>
        /// Linearly interpolates between two angles.
        /// ��̊p�x�̊ԂŐ��`��Ԃ��s���܂��B
        /// </summary>
        /// <param name="angle1">First angle. �ŏ��̊p�x�B</param>
        /// <param name="angle2">Second angle. ��Ԗڂ̊p�x�B</param>
        /// <param name="t">The interpolation ratio. ��Ԃ̔䗦�B</param>
        /// <returns>Interpolated angle. ��Ԃ��ꂽ�p�x�B</returns>
        public static float LerpAngle(float angle1, float angle2, float t)
        {
            float diff = NormalizeAngle(angle2 - angle1);
            if (diff > 180) diff -= 360;
            return angle1 + diff * t;
        }

        /// <summary>
        /// Computes the shortest rotation direction to go from one angle to another.
        /// ��̊p�x����ʂ̊p�x�ւ̍ŒZ�̉�]�������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">Starting angle. �J�n�p�x�B</param>
        /// <param name="toAngle">Ending angle. �I���p�x�B</param>
        /// <returns>1 for clockwise, -1 for counterclockwise. ���v���̏ꍇ��1�A�����v���̏ꍇ��-1�B</returns>
        public static int ShortestRotationDirection(float fromAngle, float toAngle)
        {
            return (NormalizeAngle(fromAngle - toAngle) > 0) ? 1 : -1;
        }

        /// <summary>
        /// Calculates the average of multiple angles.
        /// �����̊p�x�̕��ς��v�Z���܂��B
        /// </summary>
        /// <param name="angles">Array of angles. �p�x�̔z��B</param>
        /// <returns>Average angle. ���ϊp�x�B</returns>
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
        /// Rounds an angle to the nearest multiple of 90 degrees.
        /// �p�x���ł��߂�90�x�̔{���Ɏl�̌ܓ����܂��B
        /// </summary>
        /// <param name="angle">Angle to round. �l�̌ܓ�����p�x�B</param>
        /// <returns>Rounded angle. �l�̌ܓ����ꂽ�p�x�B</returns>
        public static float RoundToNearestRightAngle(float angle)
        {
            return Mathf.Round(angle / 90f) * 90f;
        }

        
    }
}