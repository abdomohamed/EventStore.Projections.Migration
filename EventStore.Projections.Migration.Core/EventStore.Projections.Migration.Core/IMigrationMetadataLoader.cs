using System.Collections.Generic;

namespace EventStore.Projections.Migration.Core
{
    public interface IMigrationMetadataLoader
    {
        IEnumerable<MigrationMetadata> Get();
    }
}