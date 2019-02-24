namespace EventStore.Projections.Migration.Core.Exceptions
{
    public class MigrationFileNotFoundException : MigrationException
    {
        public MigrationFileNotFoundException(string whatHappened) : base(whatHappened)
        {
        }
    }
}