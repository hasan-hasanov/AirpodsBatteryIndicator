using ABI.Common.Constants;
using System.Globalization;

namespace ABI.ViewModel.AirpodsBle
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
