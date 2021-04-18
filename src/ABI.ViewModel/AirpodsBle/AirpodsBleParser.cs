using ABI.Model.Entities;

namespace ABI.ViewModel.AirpodsBle
{
    public class AirpodsBleParser
    {
        private readonly CaseParser _caseParser;
        private readonly LeftEarbudParser _leftEarbudParser;
        private readonly RightEarbudParser _rightEarbudParser;

        public AirpodsBleParser(
            CaseParser caseParser,
            LeftEarbudParser leftEarbudParser,
            RightEarbudParser rightEarbudParser)
        {
            _caseParser = caseParser;
            _leftEarbudParser = leftEarbudParser;
            _rightEarbudParser = rightEarbudParser;
        }

        public AirpodsInfo Parse(char[] hex)
        {
            AirpodsInfo airpodsInfo = new AirpodsInfo
            {
                CaseStatus = _caseParser.Parse(hex),
                LeftEarbudStatus = _leftEarbudParser.Parse(hex),
                RightEarbudStatus = _rightEarbudParser.Parse(hex),
            };

            return airpodsInfo;
        }
    }
}
