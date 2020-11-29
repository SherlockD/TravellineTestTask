using SecureResultCleanerLibrary.Sources.DataObjects;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources
{
    public interface ISecureResultCleaner
    {
        HttpResult GetSecureResult(HttpResult inputResult);
    }
}
