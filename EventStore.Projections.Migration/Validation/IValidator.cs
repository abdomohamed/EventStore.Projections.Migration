using System.Collections.Generic;

namespace EventStore.Projections.Migration.Validation
{
    public interface IValidator
    {
        void Validate(IEnumerable<MigrationMetadata> metadata);
    }
}
