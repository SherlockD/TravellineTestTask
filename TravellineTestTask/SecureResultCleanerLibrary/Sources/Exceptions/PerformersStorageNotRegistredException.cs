using System;

namespace SecureResultCleanerLibrary.Sources.Exceptions
{
    public class PerformersStorageNotRegistredException : Exception
    {
        public PerformersStorageNotRegistredException(Type performerType) : base($"This performer is not registred in this storage, please register it to get {performerType.Name}.")
        {

        }
    }
}