using ABI.Common;
using System.Globalization;

namespace ABI.ViewModel.BleParsers
{
    public class CaseParser
    {
        public int Parse(char[] hex)
        {
            int batteryLevel = int.Parse(hex[AppleConstants.CasePosition].ToString(), NumberStyles.HexNumber);
            return batteryLevel == 15 ? -1 : batteryLevel * 10;
        }
    }
}
