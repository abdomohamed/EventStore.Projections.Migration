using EventStore.Projections.Migration.Core.Exceptions;

namespace EventStore.Projections.Migration.Core.Validation
{
    public class MigrationHasNegativeOrderNumber : IValidMigration
    {
        private string _message = "{0} has migration number is negative or zero";

        public bool IsValid(MigrationMetadata metadata)
        {
            return metadata.Order <= 0;
        }

        public void WhatShalIDo(MigrationMetadata metadadata)
        {
            var migrationClassName = metadadata.AssignedTo.FullName;
            _message = string.Format(_message, migrationClassName);

            throw new NegativeOrderNumerException(_message);
        }

        public string Message => _message;
    }
}
