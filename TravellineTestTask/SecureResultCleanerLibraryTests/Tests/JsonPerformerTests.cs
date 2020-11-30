using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests
{
    public class JsonPerformerTests
    {
        [Fact]
        public void UrlPerformerTest_Clear_ClearOneFieldInJson_FieldShouldClear()
        {
            // Arrange
            IResultCleaningPerformer jsonPerformer = new JsonPerformer();
            string[] keys = new string[] { "users", "user", "pass" };

            string json = @"{""user"":""max"",""pass"":""123456"",""users"":[""max"", ""dan"", ""mark""],""another"":""empty""}";

            string resultSecureJson = JsonConvert.SerializeObject(
                    (JObject)JsonConvert.DeserializeObject(@"{""user"":""XXX"",""pass"":""XXXXXX"",""users"":[""XXX"", ""XXX"", ""XXXX""],""another"":""empty""}")
                ); //Эта конструкция выглядит странно, но нужна для того что бы руками не форматировать строку, которая в итоге должна получится в формате, в который десереализует Newtonsoft.Json
                   //иначе не будет нормально работать сравнение

            // Act
            string result = jsonPerformer.Clear(json, keys);

            // Assert
            Assert.Equal(resultSecureJson, result);
        }
    }
}
