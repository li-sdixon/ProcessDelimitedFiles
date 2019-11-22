using System.Collections.Generic;

namespace ProcessDelimitedTextFile
{
    public class Results
    {
        public List<string> CorrectlyFormattedRecords { get; private set; }
        public List<string> IncorrectlyFormattedRecords { get; private set; }

        public Results()
        {
            CorrectlyFormattedRecords = new List<string>();
            IncorrectlyFormattedRecords = new List<string>();
        }
    }
}
