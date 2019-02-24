namespace EventStore.Projections.Migration.Core.Validation
{
    public interface IValidMigration
    {
        bool IsValid(MigrationMetadata migration);
        void WhatShalIDo(MigrationMetadata migrationType);
        string Message { get; }
    }
}