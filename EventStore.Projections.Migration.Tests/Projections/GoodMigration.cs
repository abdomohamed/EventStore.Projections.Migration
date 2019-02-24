using EventStore.Projections.Migration.Core;

namespace EventStore.Projections.Migration.Tests.Projections
{
    [Migrate(1, "test-proj", "good-file.json")]
    public class GoodMigration : IMigration
    {
    }
}
