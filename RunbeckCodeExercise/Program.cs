using System;

namespace ProcessDelimitedTextFile
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool success = AcceptFileDetailsFromUser(out string fileLocation, out string fileFormat, out int recordFieldCount);

                if (success)
                {
                    DelimitedTextFile file = new DelimitedTextFile(fileLocation, fileFormat, recordFieldCount);
                    file.NewFile += OnNewFileToProcess;
                    Results results = file.ProcessFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error was encountered during the processing of the file, The error is as follows - '{ex.Message}'");
            }
            finally
            {
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }
        }

        private static bool AcceptFileDetailsFromUser(out string fileLocation, out string fileFormat, out int recordFieldCount)
        {
            fileFormat = string.Empty;
            recordFieldCount = 0;

            while (true)
            {
                Console.WriteLine("Please enter the file location or 'q' to quit");
                fileLocation = Console.ReadLine();

                if (fileLocation == "q") return false;
                do
                {
                    Console.WriteLine("Please enter CSV for comma-separated values or TSV for tab-separated values or 'q' to quit");
                    fileFormat = Console.ReadLine()?.ToUpper().Trim();
                    if (fileFormat == "Q" || fileFormat == "CSV" || fileFormat == "TSV")
                        break;
                } while (true);

                if (fileFormat == "Q") return false;

                int count = 0;
                string input;
                do
                {
                    Console.WriteLine("Please enter the number of fields each record should contain or 'q' to quit");
                    input = Console.ReadLine()?.ToUpper().Trim();
                    bool isNumber = input != null && int.TryParse(input.Trim(), out count);
                    recordFieldCount = count;
                    if (input == "Q" || isNumber)
                        break;
                } while (true);

                if (input == "Q") return false;
                break;
            }

            return true;
        }

        private static void OnNewFileToProcess(object sender, EventArgs e)
        {
            // ...
        }
    }
}
