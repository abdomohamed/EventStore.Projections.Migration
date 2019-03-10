using System;
using System.Reflection;
using EventStore.Projections.Migration;

namespace EventStore.Projections.Migration.Tests.Builders
{
    public class NullMigrationMetadataBuilder
    {
        private Type _assginedTo;
        private string _fileName;
        private Assembly _location;
        private int _order;
        private string _projectionName;

        public NullMigrationMetadataBuilder WithAssignedTo(Type assignedTo)
        {
            _assginedTo = assignedTo;
            return this;
        }

        public NullMigrationMetadataBuilder WithFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }
        public NullMigrationMetadataBuilder WithLocation(Assembly location)
        {
            _location = location;
            return this;
        }
        public NullMigrationMetadataBuilder WithOrder(int order)
        {
            _order = order;
            return this;
        }
        public NullMigrationMetadataBuilder WithProjectionName(string projectionName)
        {
            _projectionName = projectionName;
            return this;
        }

        public NullMigrationMetadata Build()
        {
            return new NullMigrationMetadata
            {
                AssignedTo = _assginedTo,
                FileName = _fileName,
                Location = _location,
                Order = _order,
                ProjectionName = _projectionName
            };
        }
    }
}
