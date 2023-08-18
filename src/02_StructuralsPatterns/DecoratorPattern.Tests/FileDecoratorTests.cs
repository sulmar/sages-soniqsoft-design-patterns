using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratorPattern.UnitTests
{
    [TestClass]
    public class FileDecoratorTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            File file = new CsvFile() { Content = "Hello World!" };

            FileDecorator fileDecorator =  
                new CompressFileDecorator(
                    new EncryptFileDecorator(file));

            fileDecorator.Process();

            // Act

            // Assert
        }
    }
}
