using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        [Fact]
        public void SecureResultCleaner_GetSecureResult_NonSecureMultypyTypeInput_SecureMultypyTypeInput()
        {
            // Arrange
            Mock<IResultCleaningPerformersStorage> performerStorageMock = new Mock<IResultCleaningPerformersStorage>();

            performerStorageMock.Setup(a => a.GetCleaningPerformer<UrlPerformer>()).Returns(new UrlPerformer());
            performerStorageMock.Setup(a => a.GetCleaningPerformer<JsonPerformer>()).Returns(new JsonPerformer());
            performerStorageMock.Setup(a => a.GetCleaningPerformer<XmlPerformer>()).Returns(new XmlPerformer());

            string[] keys = new string[] { "user", "users", "pass" };

            ISecureResultCleaner cleaner = new SecureResultCleaner<UrlPerformer, JsonPerformer, XmlPerformer>(performerStorageMock.Object, keys);

            HttpResult inputResult = new HttpResult()
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = @"{""user"":""max"",""pass"":""123456"",""users"":[""max"", ""dan"", ""mark""],""another"":""empty""}",
                ResponseBody = "<note><to>Vaaya</to><users><user1>max</user1><user>bob</user></users><pass>123456</pass><body>Call</body></note>"
        };

            HttpResult secureResult = new HttpResult()
            {
                Url = "http://test.com/users/XXX/info?pass=XXXXXX",
                RequestBody = JsonConvert.SerializeObject(
                    (JObject)JsonConvert.DeserializeObject(@"{""user"":""XXX"",""pass"":""XXXXXX"",""users"":[""XXX"", ""XXX"", ""XXXX""],""another"":""empty""}")),
                ResponseBody = "<note><to>Vaaya</to><users><user1>max</user1><user>XXX</user></users><pass>XXXXXX</pass><body>Call</body></note>"
        };
            // Act

            HttpResult resultAfterCleaning = cleaner.GetSecureResult(inputResult);

            // Assert
            Assert.Equal(secureResult.ToString(), resultAfterCleaning.ToString());
        }
    }
}