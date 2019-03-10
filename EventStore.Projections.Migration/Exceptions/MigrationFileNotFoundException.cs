namespace EventStore.Projections.Migration.Exceptions
{
    public class MigrationFileNotFoundException : MigrationException
    {
        public MigrationFileNotFoundException(string whatHappened) : base(whatHappened)
        {
        }
    }
}