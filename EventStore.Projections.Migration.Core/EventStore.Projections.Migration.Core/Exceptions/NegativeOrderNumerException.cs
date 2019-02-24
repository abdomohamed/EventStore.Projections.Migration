namespace EventStore.Projections.Migration.Core.Exceptions
{
    public class NegativeOrderNumerException : MigrationException
    {
        public NegativeOrderNumerException(string whatHappened) : base(whatHappened)
        {
        }
    }
}