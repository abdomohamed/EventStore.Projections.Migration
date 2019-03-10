using System;

namespace EventStore.Projections.Migration.Exceptions
{
    public class MigrationException: Exception
    {
        public MigrationException(string whatHappened) : base(whatHappened)
        {   
        }
    }
}