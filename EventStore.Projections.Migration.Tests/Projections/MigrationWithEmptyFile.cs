using EventStore.Projections.Migration;

namespace EventStore.Projections.Migration.Tests.Projections
{
    [Migrate(1, "test-proj", "empty.json")]
    public class MigrationWithEmptyFile : IMigration
    {
    }
}
