using EventStore.Projections.Migration;

namespace EventStore.Projections.Migration.Tests.Projections
{
    [Migrate(1, "test-proj", "good-file.json")]
    public class GoodMigration : IMigration
    {
    }
}
