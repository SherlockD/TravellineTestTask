using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources
{
    public interface IResultCleaningPerformersStorage
    {
        void RegisterNewClearingPerformer(IResultCleaningPerformer performer);
        IResultCleaningPerformer GetCleaningPerformer<TCleaningPerformer>() where TCleaningPerformer : IResultCleaningPerformer;
    }
}
