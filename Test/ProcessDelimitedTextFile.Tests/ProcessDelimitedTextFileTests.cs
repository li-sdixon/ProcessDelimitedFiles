using System;
using Xunit;

namespace ProcessDelimitedTextFile.Tests
{
    public class ProcessDelimitedTextFileTests
    {
        [Fact]
        public void ControlTest()
        {
            // Arrange
            int x = 5;
            int y = 2;
            int expected = 7;

            // Act
            int actual = x + y;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDelimitedTextFileObjectCreation()
        {
            // Arrange
            DelimitedTextFile file;

            // Act
            file = new DelimitedTextFile(@"TestLocation\TestFile.txt", "CSV", 3);

            // Assert
            Assert.Equal(3, file.RecordFieldCount);
            Assert.Equal(@"TestLocation\TestFile.txt", file.Location);
            Assert.Equal("CSV", file.FileFormat);
        }
    }
}
