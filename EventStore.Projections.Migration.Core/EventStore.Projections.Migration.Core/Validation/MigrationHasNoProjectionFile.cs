using System.Linq;
using EventStore.Projections.Migration.Core.Exceptions;

namespace EventStore.Projections.Migration.Core.Validation
{
    public class MigrationHasNoProjectionFile : IValidMigration
    {
        private string _message = "{0} is pointing to invalid migration file ({1})";

        public bool IsValid(MigrationMetadata metadata)
        {
            var assembly = metadata.Location;
            var resourcesName = assembly.GetManifestResourceNames();

            if (string.IsNullOrEmpty(metadata.FileName)) return true;

            var resourceName = resourcesName.FirstOrDefault(name => IsMatching(name, metadata.FileName));

            return string.IsNullOrEmpty(resourceName);
        }

        private  bool IsMatching(string resourceFullName, string fileName)
        {
            return resourceFullName.ToLower().Contains(fileName.ToLower());
        }

        public void WhatShalIDo(MigrationMetadata metadata)
        {
            _message = string.Format(_message, metadata.AssignedTo.FullName, metadata.FileName);
            throw new MigrationFileNotFoundException(_message);
        }

        public string Message => _message;
    }
}
