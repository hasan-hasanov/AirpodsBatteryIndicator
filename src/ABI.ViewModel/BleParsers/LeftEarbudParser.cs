using ABI.Common;
using System.Globalization;

namespace ABI.ViewModel.BleParsers
{
    public class LeftEarbudParser
    {
        private readonly AreEarbudsFlippedParser _areEarbudsFlippedParser;

        public LeftEarbudParser(AreEarbudsFlippedParser areEarbudsFlippedParser)
        {
            _areEarbudsFlippedParser = areEarbudsFlippedParser;
        }

        public int Parse(char[] hex)
        {
            int leftEarbudPosition = _areEarbudsFlippedParser.Parse(hex) ?
                AppleConstants.LeftEarbudFlippedPosition :
                AppleConstants.LeftEarbudNotFlippedPosition;

            int batteryLevel = int.Parse(hex[leftEarbudPosition].ToString(), NumberStyles.HexNumber);
            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }
    }
}
