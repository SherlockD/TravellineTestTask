using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using SecureResultCleanerLibrary.Sources.Extensions;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers
{
    public class JsonPerformer : IResultCleaningPerformer
    {
        public string Clear(string inputResult, string[] clearKeys)
        {
            JObject data = (JObject)JsonConvert.DeserializeObject(inputResult);

            foreach(var pair in data)
            {
                if (clearKeys.Contains(pair.Key))
                {
                    if (pair.Value.HasValues)
                    {
                        for(int i = 0; i < pair.Value.Children().Count(); i++)
                        {
                            pair.Value[i] = pair.Value[i].ToString().GetSecureString('X');
                        }
                    }
                    else
                    {
                        data[pair.Key] = pair.Value.ToString().GetSecureString('X');
                    }
                }
            }

            return JsonConvert.SerializeObject(data);
        }
    }
}