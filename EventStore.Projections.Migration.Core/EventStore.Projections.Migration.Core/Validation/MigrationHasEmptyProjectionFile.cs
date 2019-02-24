using EventStore.Projections.Migration.Core.Exceptions;

namespace EventStore.Projections.Migration.Core.Validation
{
    public class MigrationHasEmptyProjectionFile : IValidMigration
    {
        private string _message = "{0} has empty migration file ({1})";

        public bool IsValid(MigrationMetadata metadata)
        {
            var content = metadata.Query();
            return string.IsNullOrEmpty(content);
        }

        public void WhatShalIDo(MigrationMetadata metadata)
        {
            _message = string.Format(_message, metadata.AssignedTo.FullName, metadata.FileName);
            throw new EmptyProjectionFileException(_message);
        }

        public string Message => _message;
    }
}
