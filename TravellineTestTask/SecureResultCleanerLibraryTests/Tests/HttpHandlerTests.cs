using Moq;
using SecureResultCleanerLibrary.Sources;
using SecureResultCleanerLibrary.Sources.DataObjects;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests.Tests
{
    public class HttpHandlerTests
    {
        [Fact]
        public void HttpLogHandler_Process_BookingcomHttpResult_ClearSecureData()
        {
            //Arrange
            Mock<IResultCleaningPerformersStorage> performerStorageMock = new Mock<IResultCleaningPerformersStorage>();
            performerStorageMock.Setup(a => a.GetCleaningPerformer<UrlPerformer>()).Returns(new UrlPerformer());

            string[] keys = new string[] { "user", "users", "pass" };

            ISecureResultCleaner cleaner = new SecureResultCleaner<UrlPerformer, UrlPerformer, UrlPerformer>(performerStorageMock.Object, keys);

            var bookingcomHttpResult = new HttpResult
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

            var httpLogHandler = new HttpHandler();

            //Act
            httpLogHandler.Process(bookingcomHttpResult.Url, bookingcomHttpResult.RequestBody, bookingcomHttpResult.ResponseBody, cleaner);

            //Assert
            Assert.Equal(secureResult.ToString(), httpLogHandler.CurrentLog.ToString());
        }
    }
}
