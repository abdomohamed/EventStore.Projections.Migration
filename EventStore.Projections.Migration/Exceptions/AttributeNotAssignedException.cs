namespace EventStore.Projections.Migration.Exceptions
{
    public class AttributeNotAssignedException : MigrationException
    {
        public AttributeNotAssignedException(string whatHappened) : base(whatHappened)
        {
        }
    }
}