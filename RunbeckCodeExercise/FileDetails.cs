namespace ProcessDelimitedTextFile
{
    public class FileDetails
    {
        public FileDetails(string location, string fileFormat, int recordFieldCount)
        {
            Location = location;
            FileFormat = fileFormat;
            RecordFieldCount = recordFieldCount;
        }
        public string Location { get; }
        public string FileFormat { get; }
        public int RecordFieldCount { get; }
    }
}
