using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests.Tests
{
    public class XmlPerformerTests
    {
        [Fact]
        public void UrlPerformerTest_Clear_ClearOneFieldInXml_FieldShouldClear()
        {
            // Arrange
            IResultCleaningPerformer xmlPerformer = new XmlPerformer();
            string[] keys = new string[] { "users", "user", "pass" };

            string xml = "<note><to>Vaaya</to><users><user1>max</user1><user>bob</user></users><pass>123456</pass><body>Call</body></note>";
            string secureXml = "<note><to>Vaaya</to><users><user1>max</user1><user>XXX</user></users><pass>XXXXXX</pass><body>Call</body></note>";

            // Act
            string result = xmlPerformer.Clear(xml, keys);

            // Assert
            Assert.Equal(secureXml, result);
        }
    }
}
