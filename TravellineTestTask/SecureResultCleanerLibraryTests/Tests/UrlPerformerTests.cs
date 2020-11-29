using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests
{
    public class UrlPerformerTests
    {
        [Fact]
        public void UrlPerformerTest_Clear_ClearOneFieldInUrl_FieldShouldClear()
        {
            // Arrange
            IResultCleaningPerformer urlPerformer = new UrlPerformer();
            string[] keys = new string[] { "users", "user", "pass" };

            string[] urls = new string[]
            {
                "http://test.com?user=max&pass=123456",
                "http://test.com/users/max/info",
                "http://test.com/users/max/info?pass=123456",
                "http://test.com?user=max&pass=123456"
            };

            string[] secureUrls = new string[]
            {
                "http://test.com?user=XXX&pass=XXXXXX",
                "http://test.com/users/XXX/info",
                "http://test.com/users/XXX/info?pass=XXXXXX",
                "http://test.com?user=XXX&pass=XXXXXX"
            };

            // Act
            for(int i = 0; i < urls.Length; i++)
            {
                urls[i] = urlPerformer.Clear(urls[i], keys);
            }

            // Assert
            Assert.Equal(urls, secureUrls);
        }
    }
}