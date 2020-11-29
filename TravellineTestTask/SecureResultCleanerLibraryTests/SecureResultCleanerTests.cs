using Moq;
using SecureResultCleanerLibrary.Sources.DataObjects;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests
{
    public class SecureResultCleanerTests
    {
        [Fact]
        public void SecureResultCleaner_GetSecureResult_NonSecureHttpInput_SecureHttpInput()
        {
            // Arrange
            Mock<IResultCleaningPerformersStorage> performerStorageMock = new Mock<IResultCleaningPerformersStorage>();
            performerStorageMock.Setup(a => a.GetCleaningPerformer<UrlPerformer>()).Returns(new UrlPerformer());

            string[] keys = new string[] { "user", "users", "pass" };

            ISecureResultCleaner cleaner = new SecureResultCleaner<UrlPerformer, UrlPerformer, UrlPerformer>(performerStorageMock.Object, keys);

            HttpResult inputResult = new HttpResult()
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            HttpResult secureResult = new HttpResult()
            {
                Url = "http://test.com/users/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };
            // Act

            HttpResult resultAfterCleaning = cleaner.GetSecureResult(inputResult);

            // Assert
            Assert.Equal(secureResult.ToString(), resultAfterCleaning.ToString());
        }
    }
}