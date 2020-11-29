using SecureResultCleanerLibrary.Sources.DataObjects;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources
{
    public class SecureResultCleaner<TUrlPerformer, TRequestPerformer, TResponcePerformer> : ISecureResultCleaner
        where TUrlPerformer : IResultCleaningPerformer
        where TRequestPerformer : IResultCleaningPerformer
        where TResponcePerformer : IResultCleaningPerformer
    {
        private IResultCleaningPerformer _urlPerformer;
        private IResultCleaningPerformer _requestPerformer;
        private IResultCleaningPerformer _responsePerformer;

        private string[] _keys;

        public SecureResultCleaner(IResultCleaningPerformersStorage storage , string[] keys)
        {
            _urlPerformer = storage.GetCleaningPerformer<TUrlPerformer>();
            _requestPerformer = storage.GetCleaningPerformer<TRequestPerformer>();
            _responsePerformer = storage.GetCleaningPerformer<TResponcePerformer>();

            _keys = keys;
        }

        public HttpResult GetSecureResult(HttpResult inputResult)
        {
            return new HttpResult()
            {
                Url = _urlPerformer.Clear(inputResult.Url, _keys),
                RequestBody = _requestPerformer.Clear(inputResult.RequestBody, _keys),
                ResponseBody = _responsePerformer.Clear(inputResult.ResponseBody, _keys)
            };
        }
    }
}
