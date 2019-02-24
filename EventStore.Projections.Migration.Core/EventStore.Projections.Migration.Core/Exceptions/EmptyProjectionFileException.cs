namespace EventStore.Projections.Migration.Core.Exceptions
{
    public class EmptyProjectionFileException : MigrationException
    {
        public EmptyProjectionFileException(string whatHappened) : base(whatHappened)
        {
        }
    }
}