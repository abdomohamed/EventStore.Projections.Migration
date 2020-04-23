using System.Collections.Generic;
using EventStore.Projections.Migration;
using NSubstitute;

namespace EventStore.Projections.Migration.Tests.Builders
{
    public class MigrationsMetadataLoaderBuilder
    {
        private List<MigrationMetadata> _returnedMetadata;

        public MigrationsMetadataLoaderBuilder()
        {
            _returnedMetadata = new List<MigrationMetadata>();
        }

        public MigrationsMetadataLoaderBuilder WithMetadata(params MigrationMetadata[] metadata)
        {
            _returnedMetadata = metadata == null || metadata.Length < 0 ? _returnedMetadata 
                               : new List<MigrationMetadata>(metadata);
            return this;
        }

        public IMigrationMetadataLoader Build()
        {
            var loader = Substitute.For<IMigrationMetadataLoader>();
            loader.Get().Returns(_returnedMetadata);
            return loader;
        }
    }
}
