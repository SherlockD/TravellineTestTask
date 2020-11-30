using System;
using System.Collections.Generic;
using SecureResultCleanerLibrary.Sources.Exceptions;
using SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources
{
    public class ResultCleaningPerformersStorage : IResultCleaningPerformersStorage
    {
        private Dictionary<Type, IResultCleaningPerformer> _storage = new Dictionary<Type, IResultCleaningPerformer>();

        public IResultCleaningPerformer GetCleaningPerformer<TCleaningPerformer>() where TCleaningPerformer : IResultCleaningPerformer
        {
            if (_storage.ContainsKey(typeof(TCleaningPerformer)))
            {
                return _storage[typeof(TCleaningPerformer)];
            }
            else
            {
                throw new PerformersStorageNotRegistredException(typeof(TCleaningPerformer));
            }
        }

        public void RegisterNewClearingPerformer(IResultCleaningPerformer performer)
        {
            if (!_storage.ContainsKey(performer.GetType()))
            {
                _storage.Add(performer.GetType(), performer);
            }
        }
    }
}
