using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratorPattern.UnitTests
{
    [TestClass]
    public class CloudStreamTests
    {
        [TestMethod]
        public void Write_CloudStream()
        {
            // Arrange
            Stream stream = new CloudStream();

            // Act
            stream.Write("1234-1234-1234-1234");

            // Assert

        }

        [TestMethod]
        public void Write_EncyptedCloudStream()
        {
            // Arrange
            Stream stream = new EncryptedCloudStream(new CloudStream());

            // Act
            stream.Write("1234-1234-1234-1234");

            // Assert
        }

        [TestMethod]
        public void Write_CompressCloudStream()
        {
            // Arrange
            Stream stream = new EncryptedCloudStream(new CloudStream());

            // Act
            stream.Write("1234-1234-1234-1234");

            // Assert
        }

        [TestMethod]
        public void Write_EncryptAndCompressCloudStream()
        {
            // Arrange
            Stream stream = new EncryptedCloudStream(new CompressedCloudStream( new CloudStream()));

            // Act
            stream.Write("1234-1234-1234-1234");

            // Assert
        }
    }
}
