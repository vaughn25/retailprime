using Prime.Library.Services;
using Xunit.Abstractions;

namespace Prime.Tests
{
    public class EncryptionDecryptionTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public EncryptionDecryptionTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void EncryptText_ShouldCompleteSuccessfully()
        {
            var encrypted =  PrimeSecurityService.Encrypt("HelloWorld");
            Assert.False(string.IsNullOrEmpty(encrypted));
            _testOutputHelper.WriteLine($"Encrypted text: {encrypted}");
        }

        [Fact]
        public void DecryptText_ShouldCompleteSuccessfully()
        {
            var encrypted =  PrimeSecurityService.Encrypt("HelloWorld");
            var decrypted = PrimeSecurityService.Decrypt(encrypted);
            Assert.Equal("HelloWorld", decrypted);
            _testOutputHelper.WriteLine($"Decrypted text: {decrypted}");
        }
    }
}
