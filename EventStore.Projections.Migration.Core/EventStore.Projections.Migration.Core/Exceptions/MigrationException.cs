using System;

namespace EventStore.Projections.Migration.Core.Exceptions
{
    public class MigrationException: Exception
    {
        public MigrationException(string whatHappened) : base(whatHappened)
        {   
        }
    }
}