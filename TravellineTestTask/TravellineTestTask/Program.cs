using SecureResultCleanerLibrary.Sources.DataObjects;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;
using System;

namespace TravellineTestTask
{
    public class Program
    {
        private static IResultCleaningPerformersStorage _performersStorage;

        public static void Main(string[] args)
        {
            _performersStorage = new ResultCleaningPerformersStorage();
            string[] cleanKeys = new string[] { "users", "user", "pass" };

            RegisterPerformers();

  

            ISecureResultCleaner cleaner = new SecureResultCleaner<UrlPerformer, UrlPerformer, UrlPerformer>(_performersStorage, cleanKeys);

            IResultCleaningPerformer jsonPerformer = _performersStorage.GetCleaningPerformer<JsonPerformer>();

            Console.ReadKey();
        }

        private static void RegisterPerformers()
        {
            _performersStorage.RegisterNewClearingPerformer(new UrlPerformer());
            _performersStorage.RegisterNewClearingPerformer(new JsonPerformer());
        }
    }
}
