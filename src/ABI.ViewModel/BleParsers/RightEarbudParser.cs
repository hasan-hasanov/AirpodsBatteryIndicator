using ABI.Common;
using System.Globalization;

namespace ABI.ViewModel.BleParsers
{
    public class RightEarbudParser
    {
        private readonly AreEarbudsFlippedParser _areEarbudsFlippedParser;

        public RightEarbudParser(AreEarbudsFlippedParser areEarbudsFlippedParser)
        {
            _areEarbudsFlippedParser = areEarbudsFlippedParser;
        }

        public int Parse(char[] hex)
        {
            int rightEarbudPosition = _areEarbudsFlippedParser.Parse(hex) ?
                AppleConstants.RightEarbudFlippedPosition :
                AppleConstants.RightEarbudNotFlippedPosition;

            int batteryLevel = int.Parse(hex[rightEarbudPosition].ToString(), NumberStyles.HexNumber);
            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }
    }
}
