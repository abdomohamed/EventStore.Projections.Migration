using System.Collections.Generic;

namespace EventStore.Projections.Migration.Core.Validation
{
    public interface IValidator
    {
        void Validate(IEnumerable<MigrationMetadata> metadata);
    }
}
