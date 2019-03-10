using System.Collections.Generic;

namespace EventStore.Projections.Migration
{
    public interface IMigrationMetadataLoader
    {
        IEnumerable<MigrationMetadata> Get();
    }
}