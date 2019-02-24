using System;
using System.Reflection;
using EventStore.Projections.Migration.Core;

namespace EventStore.Projections.Migration.Tests.Builders
{
    public class MigrationMetadataBuilder
    {
        private Type _assginedTo;
        private string _fileName;
        private Assembly _location;
        private int _order;
        private string _projectionName;
        private string[] _preRequsiteFiles = {};

        public MigrationMetadataBuilder WithAssignedTo(Type assignedTo)
        {
            _assginedTo = assignedTo;
            return this;
        }

        public MigrationMetadataBuilder WithFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }
        public MigrationMetadataBuilder WithLocation(Assembly location)
        {
            _location = location;
            return this;
        }
        public MigrationMetadataBuilder WithOrder(int order)
        {
            _order = order;
            return this;
        }
        public MigrationMetadataBuilder WithProjectionName(string projectionName)
        {
            _projectionName = projectionName;
            return this;
        }

        public MigrationMetadataBuilder WithPreqRequisteFiles(params string[] preRequsiteFiles)
        {
            _preRequsiteFiles = preRequsiteFiles;
            return this;
        }

        public MigrationMetadata Build()
        {
            return new MigrationMetadata
            {
                AssignedTo = _assginedTo,
                FileName = _fileName,
                Location = _location,
                Order = _order,
                ProjectionName = _projectionName,
                PreRequristeFiles = _preRequsiteFiles
            };
        }
    }
}
