namespace EventStore.Projections.Migration.Core.Exceptions
{
    public class AttributeNotAssignedException : MigrationException
    {
        public AttributeNotAssignedException(string whatHappened) : base(whatHappened)
        {
        }
    }
}