namespace EventStore.Projections.Migration.Exceptions
{
    public class EmptyProjectionFileException : MigrationException
    {
        public EmptyProjectionFileException(string whatHappened) : base(whatHappened)
        {
        }
    }
}