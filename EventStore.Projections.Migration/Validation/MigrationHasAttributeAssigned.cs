using EventStore.Projections.Migration.Exceptions;

namespace EventStore.Projections.Migration.Validation
{
    public class MigrationHasAttributeAssigned : IValidMigration
    {
        private string _message = $"{0} haven't got {1} assigned";

        public bool IsValid(MigrationMetadata migrationType)
        {
            return migrationType is NullMigrationMetadata;
        }

        public void WhatShalIDo(MigrationMetadata migrationType)
        {
            _message = $"{migrationType.AssignedTo.FullName} haven't got {nameof(MigrateAttribute)} assigned";

            throw new AttributeNotAssignedException(_message);
        }

        public string Message => _message;
    }
}
