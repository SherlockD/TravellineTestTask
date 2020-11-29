using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using Xunit;

namespace SecureResultCleanerLibraryTests
{
    public class ResultCleaningPerformersStorageTests
    {
        [Fact]
        public void ResultCleaningPerformersStorage_RegisterNewClearingPerformer_EmptyStorage_StorageWithAddedPerformer()
        {
            // Arrange
            IResultCleaningPerformersStorage storage = new ResultCleaningPerformersStorage();

            UrlPerformer urlPerformer = new UrlPerformer();

            storage.RegisterNewClearingPerformer(urlPerformer);

            // Act

            IResultCleaningPerformer resultPerformer = storage.GetCleaningPerformer<UrlPerformer>();

            // Assert
            Assert.Equal(urlPerformer, resultPerformer);
        }
    }
}