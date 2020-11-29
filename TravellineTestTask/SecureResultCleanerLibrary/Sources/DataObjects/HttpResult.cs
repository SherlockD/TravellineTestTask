namespace SecureResultCleanerLibrary.Sources.DataObjects
{
    public class HttpResult
    {
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

        public HttpResult()
        {

        }

        public HttpResult(string url, string requestBody, string responceBody)
        {
            Url = url;
            RequestBody = requestBody;
            ResponseBody = responceBody;
        }

        public override string ToString()
        {
            return $"URL: {Url}\nRequest body: {RequestBody}\nResponce body: {ResponseBody}";
        }
    }
}
