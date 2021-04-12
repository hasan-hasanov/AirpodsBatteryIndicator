using ABI.Common.Constants;
using System;

namespace AirpodsBatteryIndicator
{
    public class AirpodBleParser
    {
        private readonly bool _isFlipped;

        private readonly int _leftEarbudBatteryLevel;
        private readonly int _rightEarbudBatteryLevel;
        private readonly int _caseBatteryLevel;

        public AirpodBleParser(char[] hex)
        {
            _isFlipped = IsFlipped(hex);

            _leftEarbudBatteryLevel = ParseLeftEarbudBatteryLevel(hex);
            _rightEarbudBatteryLevel = ParseRightEarbudBatteryLevel(hex);
            _caseBatteryLevel = ParseCaseBatteryLevel(hex);
        }

        public int LeftEarbudBatteryLevel => _leftEarbudBatteryLevel;

        public int RightEarbudBatteryLevel => _rightEarbudBatteryLevel;

        public int CaseEarbudBatteryLevel => _caseBatteryLevel;


        private bool IsFlipped(char[] hex)
        {
            string isFlippedInfoBinary = Convert.ToString(short.Parse(hex[10].ToString()) + 0x10, 2);
            return isFlippedInfoBinary[3] == '0';
        }

        private int ParseLeftEarbudBatteryLevel(char[] hex)
        {
            int leftEarbudPosition = _isFlipped ? AppleConstants.LeftEarbudFlippedPosition : AppleConstants.LeftEarbudNotFlippedPosition;
            return int.Parse(hex[leftEarbudPosition].ToString());
        }

        private int ParseRightEarbudBatteryLevel(char[] hex)
        {
            int rightEarbudPosition = _isFlipped ? AppleConstants.RightEarbudFlippedPosition : AppleConstants.RightEarbudNotFlippedPosition;
            return int.Parse(hex[rightEarbudPosition].ToString());
        }

        private int ParseCaseBatteryLevel(char[] hex)
        {
            return int.Parse(hex[AppleConstants.CasePosition].ToString());
        }
    }
}
