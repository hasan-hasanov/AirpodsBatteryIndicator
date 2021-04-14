using ABI.Common.Constants;
using System;
using System.Globalization;

namespace AirpodsBatteryIndicator
{
    public class AirpodBleParser
    {
        private readonly bool _isFlipped;

        private readonly int _leftEarbudBatteryLevel;
        private readonly int _rightEarbudBatteryLevel;
        private readonly int _caseBatteryLevel;

        public AirpodBleParser()
        {
            _leftEarbudBatteryLevel = -1;
            _rightEarbudBatteryLevel = -1;
            _caseBatteryLevel = -1;
        }

        public AirpodBleParser(char[] hex)
        {
            _isFlipped = IsFlipped(hex);

            _leftEarbudBatteryLevel = ParseLeftEarbudBatteryLevel(hex);
            _rightEarbudBatteryLevel = ParseRightEarbudBatteryLevel(hex);
            _caseBatteryLevel = ParseCaseBatteryLevel(hex);
        }

        public int LeftEarbudBatteryLevel => _leftEarbudBatteryLevel;

        public int RightEarbudBatteryLevel => _rightEarbudBatteryLevel;

        public int CaseBatteryLevel => _caseBatteryLevel;

        public bool IsConnected => _leftEarbudBatteryLevel > 0 || _rightEarbudBatteryLevel > 0 || _caseBatteryLevel > 0;


        private bool IsFlipped(char[] hex)
        {
            string isFlippedInfoBinary = Convert.ToString(short.Parse(hex[10].ToString()) + 0x10, 2);
            return isFlippedInfoBinary[3] == '0';
        }

        private int ParseLeftEarbudBatteryLevel(char[] hex)
        {
            int leftEarbudPosition = _isFlipped ? AppleConstants.LeftEarbudFlippedPosition : AppleConstants.LeftEarbudNotFlippedPosition;
            int batteryLevel = int.Parse(hex[leftEarbudPosition].ToString(), NumberStyles.HexNumber);

            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }

        private int ParseRightEarbudBatteryLevel(char[] hex)
        {
            int rightEarbudPosition = _isFlipped ? AppleConstants.RightEarbudFlippedPosition : AppleConstants.RightEarbudNotFlippedPosition;
            int batteryLevel = int.Parse(hex[rightEarbudPosition].ToString(), NumberStyles.HexNumber);

            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }

        private int ParseCaseBatteryLevel(char[] hex)
        {
            int batteryLevel = int.Parse(hex[AppleConstants.CasePosition].ToString(), NumberStyles.HexNumber);

            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }
    }
}
