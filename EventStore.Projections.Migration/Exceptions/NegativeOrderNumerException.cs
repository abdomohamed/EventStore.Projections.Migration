namespace EventStore.Projections.Migration.Exceptions
{
    public class NegativeOrderNumerException : MigrationException
    {
        public NegativeOrderNumerException(string whatHappened) : base(whatHappened)
        {
        }
    }
}