namespace ProcessDelimitedTextFile
{
    public abstract class GenericFile : FileDetails, IFile
    {
        protected GenericFile(string location, string fileFormat, int recordFieldCount) : base(location, fileFormat, recordFieldCount)
        {
        }
        public abstract event NewFileDelegate NewFile;
        public abstract Results ProcessFile();
    }
}
