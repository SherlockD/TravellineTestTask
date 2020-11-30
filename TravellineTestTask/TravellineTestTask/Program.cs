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

            _performersStorage.GetCleaningPerformer<XmlPerformer>();

            Console.ReadKey();
        }

        private static void RegisterPerformers()
        {
            _performersStorage.RegisterNewClearingPerformer(new UrlPerformer());
            _performersStorage.RegisterNewClearingPerformer(new JsonPerformer());
            _performersStorage.RegisterNewClearingPerformer(new XmlPerformer());
        }
    }
}
