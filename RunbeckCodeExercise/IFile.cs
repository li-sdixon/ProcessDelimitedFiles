namespace ProcessDelimitedTextFile
{
    public interface IFile
    {
        Results ProcessFile();
        string Location { get; }
        string FileFormat { get; }
        int RecordFieldCount { get; }
        event NewFileDelegate NewFile;
    }
}
