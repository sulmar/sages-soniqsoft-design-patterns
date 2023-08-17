namespace SingletonPattern.XUnitTests
{
    public class ConfigManagerTests
    {
        [Fact]
        public void SetGet_WhenCalled_ShouldReturnsValue()
        {
            // Arrange
            ConfigManager manager = ConfigManager.Instance;
            manager.Set("name", "Marcin");

            ConfigManager other = ConfigManager.Instance;

            // Act
            object result = other.Get("name");

            // Assert
            Assert.Equal("Marcin", result);
            Assert.True(ReferenceEquals(manager, other));
            Assert.Same(manager, other);

        }
    }
}