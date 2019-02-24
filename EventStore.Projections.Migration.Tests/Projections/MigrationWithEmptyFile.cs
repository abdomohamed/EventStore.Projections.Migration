using EventStore.Projections.Migration.Core;

namespace EventStore.Projections.Migration.Tests.Projections
{
    [Migrate(1, "test-proj", "empty.json")]
    public class MigrationWithEmptyFile : IMigration
    {
    }
}
