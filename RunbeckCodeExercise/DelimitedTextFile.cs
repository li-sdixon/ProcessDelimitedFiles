using System;
using System.IO;

namespace ProcessDelimitedTextFile
{
    public class DelimitedTextFile : GenericFile
    {
        public DelimitedTextFile(string location, string fileFormat, int recordFieldCount) : base(location, fileFormat, recordFieldCount)
        {
        }

        public override event NewFileDelegate NewFile;

        public override Results ProcessFile()
        {
            Results result = new Results();
            ReadFile(result);
            var processingDate = GenerateResultsThatPassedBusinessRules(result);
            GenerateResultsThatFailedBusinessRules(result, processingDate);
            return result;
        }

        private void ReadFile(Results result)
        {
            char delimiter = FileFormat == "CSV" ? ',' : '\t';

            using (StreamReader reader = File.OpenText($"{Location}"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        {
                            int number = line.Split(delimiter).Length;
                            if (number == RecordFieldCount)
                                result.CorrectlyFormattedRecords.Add(line);
                            else
                                result.IncorrectlyFormattedRecords.Add(line);
                        }
                    }
                }
            }
        }

        private string GenerateResultsThatPassedBusinessRules(Results result)
        {
            string processingDate = DateTime.Now.ToString("yyyyMMdd");
            if (result.CorrectlyFormattedRecords.Count > 0)
            {
                FileInfo fInfo = new FileInfo(Location);
                if (fInfo.Directory != null)
                {
                    String dirName = fInfo.Directory.FullName;
                    string fileName = $"CorrectlyFormattedRecords_{processingDate}.txt";
                    string fullPath = Path.Combine(dirName, fileName);
                    using (StreamWriter swtr = new StreamWriter(fullPath, false))
                    {
                        foreach (string s in result.CorrectlyFormattedRecords)
                            swtr.WriteLine(s);
                    }
                }
            }

            return processingDate;
        }

        private void GenerateResultsThatFailedBusinessRules(Results result, string processingTime)
        {
            if (result.IncorrectlyFormattedRecords.Count > 0)
            {
                FileInfo fInfo = new FileInfo(Location);
                if (fInfo.Directory != null)
                {
                    String dirName = fInfo.Directory.FullName;
                    string fileName = $"IncorrectlyFormattedRecords_{processingTime}.txt";
                    string fullPath = Path.Combine(dirName, fileName);
                    using (StreamWriter swtr = new StreamWriter(fullPath, false))
                    {
                        foreach (string s in result.IncorrectlyFormattedRecords)
                            swtr.WriteLine(s);
                    }
                }
            }
        }

        protected virtual void OnNewFile()
        {
            NewFile?.Invoke(this, EventArgs.Empty);
        }
    }
}
