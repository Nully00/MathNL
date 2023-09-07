using UnityEngine;

namespace Nulock.Math
{
    public static partial class MathNL
    {
        /// <summary>.
        /// �p�x��-180������180���͈̔͂ɐ��K�����܂��B
        /// </summary>
        /// <param name="angle">���K������p�x�B</param>
        /// <returns>���K�����ꂽ�p�x�B</returns>
        public static float NormalizeAngle(float angle)
        {
            return (angle + 180) % 360 - 180;
        }
        /// <summary>
        /// �p�x��0������360���͈̔͂ɐ��K�����܂��B
        /// </summary>
        /// <param name="angle">���K������p�x�B</param>
        /// <returns>���K�����ꂽ�p�x�B</returns>
        public static float NormalizeAngle360(float angle)
        {
            return (angle % 360f + 360f) % 360f;
        }
        /// <summary>
        /// ��̊p�x�Ԃ̍ŏ���΍����v�Z���܂��B
        /// </summary>
        /// <param name="angleA">�ŏ��̊p�x�B</param>
        /// <param name="angleB">��Ԗڂ̊p�x�B</param>
        /// <returns>��̊p�x�Ԃ̍ŏ���΍��B</returns>
        public static float AbsoluteAngleDifference(float angleA, float angleB)
        {
            float diff = NormalizeAngle(angleB - angleA);
            return Mathf.Abs(diff);
        }
        /// <summary>
        /// ��̊p�x�Ԃ̍����v�Z���A-180������180���̊Ԃ̒l�Ƃ��ĕԂ��܂��B
        /// </summary>
        /// <param name="angleA">�ŏ��̊p�x�B</param>
        /// <param name="angleB">��Ԗڂ̊p�x�B</param>
        /// <returns>angleA����angleB�ւ̉~��̕������l�������p�x�̍��B</returns>
        public static float AngleDifference(float angleA, float angleB)
        {
            return NormalizeAngle(angleB - angleA);
        }

        /// <summary>
        /// �p�x���w�肳�ꂽ�͈͓��ɐ������܂��B
        /// </summary>
        /// <param name="angle">��������p�x�B</param>
        /// <param name="minAngle">�͈͂̍ŏ��p�x�B</param>
        /// <param name="maxAngle">�͈͂̍ő�p�x�B</param>
        /// <returns>�������ꂽ�p�x�B</returns>
        public static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            float normalizedAngle = NormalizeAngle(angle);
            return Mathf.Clamp(normalizedAngle, minAngle, maxAngle);
        }

        

        /// <summary>
        /// ��̊p�x����ʂ̊p�x�܂ł̎��v���̋������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">�J�n�p�x�B</param>
        /// <param name="toAngle">�I���p�x�B</param>
        /// <returns>�p�x�Ԃ̎��v���̋����B</returns>
        public static float ClockwiseDistance(float fromAngle, float toAngle)
        {
            float normalizedFrom = NormalizeAngle(fromAngle);
            float normalizedTo = NormalizeAngle(toAngle);
            if (normalizedTo >= normalizedFrom)
                return normalizedTo - normalizedFrom;
            return 360 + normalizedTo - normalizedFrom;
        }

        /// <summary>
        /// ��̊p�x����ʂ̊p�x�܂ł̔����v���̋������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">�J�n�p�x�B</param>
        /// <param name="toAngle">�I���p�x�B</param>
        /// <returns>�p�x�Ԃ̔����v���̋����B</returns>
        public static float CounterClockwiseDistance(float fromAngle, float toAngle)
        {
            return 360 - ClockwiseDistance(fromAngle, toAngle);
        }

        /// <summary>
        /// ��̊p�x�̊ԂŐ��`��Ԃ��s���܂��B
        /// </summary>
        /// <param name="angle1">�ŏ��̊p�x�B</param>
        /// <param name="angle2">��Ԗڂ̊p�x�B</param>
        /// <param name="t">��Ԃ̔䗦�B</param>
        /// <returns>��Ԃ��ꂽ�p�x�B</returns>
        public static float LerpAngle(float angle1, float angle2, float t)
        {
            float diff = NormalizeAngle(angle2 - angle1);
            if (diff > 180) diff -= 360;
            return angle1 + diff * t;
        }

        /// <summary>
        /// ��̊p�x����ʂ̊p�x�ւ̍ŒZ�̉�]�������v�Z���܂��B
        /// </summary>
        /// <param name="fromAngle">�J�n�p�x�B</param>
        /// <param name="toAngle">�I���p�x�B</param>
        /// <returns>���v���̏ꍇ��1�A�����v���̏ꍇ��-1�B</returns>
        public static int ShortestRotationDirection(float fromAngle, float toAngle)
        {
            return (NormalizeAngle(fromAngle - toAngle) > 0) ? 1 : -1;
        }

        /// <summary>
        /// �����̊p�x�̕��ς��v�Z���܂��B
        /// </summary>
        /// <param name="angles">�p�x�̔z��B</param>
        /// <returns>���ϊp�x�B</returns>
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
        /// �p�x���ł��߂�90�x�̔{���Ɏl�̌ܓ����܂��B
        /// </summary>
        /// <param name="angle">�l�̌ܓ�����p�x�B</param>
        /// <returns>�l�̌ܓ����ꂽ�p�x�B</returns>
        public static float RoundToNearestRightAngle(float angle)
        {
            return Mathf.Round(angle / 90f) * 90f;
        }

        
    }
}