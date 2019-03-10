using System.Collections.Generic;
using System.Linq;

namespace EventStore.Projections.Migration.Validation
{
    public class Validator : IValidator
    {
        public void Validate(IEnumerable<MigrationMetadata> migrationsMeta)
        {
            foreach (var meta in migrationsMeta)
            {
                Validate(meta);
            }
        }

        private void Validate(MigrationMetadata metadata)
        {
            var rules = GetValidationRules();
            var firstNotValidRule = rules.FirstOrDefault(rule => rule.IsValid(metadata));
            firstNotValidRule?.WhatShalIDo(metadata);
        }

        private List<IValidMigration> GetValidationRules()
        {
            return new List<IValidMigration>
            {
                new MigrationHasAttributeAssigned(),
                new MigrationHasNoProjectionFile(),
                new MigrationHasEmptyProjectionFile(),
                new MigrationHasNegativeOrderNumber()
            };
        }
    }
}
