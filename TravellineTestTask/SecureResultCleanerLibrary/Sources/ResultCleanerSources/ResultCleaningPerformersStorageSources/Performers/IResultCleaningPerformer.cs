namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers
{
    public interface IResultCleaningPerformer
    {
        string Clear(string inputResult, string[] clearKeys);
    }
}
