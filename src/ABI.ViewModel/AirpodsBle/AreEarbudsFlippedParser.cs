using System;

namespace ABI.ViewModel.AirpodsBle
{
    public class AreEarbudsFlippedParser
    {
        public bool Parse(char[] hex)
        {
            string isFlippedInfoBinary = Convert.ToString(short.Parse(hex[10].ToString()) + 0x10, 2);
            return isFlippedInfoBinary[3] == '0';
        }
    }
}
