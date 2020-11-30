using SecureResultCleanerLibrary.Sources.DataObjects;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources;

namespace SecureResultCleanerLibrary.Sources
{
    public class HttpHandler
    {
        public HttpResult CurrentLog { get; private set; }

        public string Process(string url, string body, string response, ISecureResultCleaner cleaner)
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = body,
                ResponseBody = response
            };

            httpResult = cleaner.GetSecureResult(httpResult);

            Log(httpResult);

            return response;
        }

        /// <summary>
        /// Логирует данные запроса, они должны быть уже без данных которые нужно защищать
        /// </summary>
        /// <param name="result"></param>
        protected void Log(HttpResult result)
        {
            CurrentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}