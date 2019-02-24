using System;
using System.Reflection;
using EventStore.Projections.Migration.Core;
using EventStore.Projections.Migration.Core.Exceptions;
using EventStore.Projections.Migration.Core.Validation;
using EventStore.Projections.Migration.Tests.Builders;
using EventStore.Projections.Migration.Tests.Projections;
using Xunit;

namespace EventStore.Projections.Migration.Tests
{
    public class RunProjectionTest
    {
        private readonly IValidator _validator;

        public RunProjectionTest()
        {
            _validator = new Validator();
        }

        [Fact]
        public void MigratorShouldNotThrowExceptionIfWhaveValidMigrations()
        {
            var databuilder = new MigrationMetadataBuilder();
            var migrationMetadata = databuilder.WithAssignedTo(typeof(GoodMigration))
                                               .WithLocation(Assembly.GetExecutingAssembly())
                                               .WithFileName("good-file.json")
                                               .WithProjectionName("test-proj")
                                               .WithOrder(1)
                                               .Build();

            var metadataLoader = new MigrationsMetadataLoaderBuilder().WithMetadata(migrationMetadata).Build();

            _validator.Validate(metadataLoader.Get());
        }

        [Fact]
        public void MigratorDidnotThrowExceptionIfThereIsNoMigrations()
        {
            var locationWhereNoData = Assembly.GetAssembly(typeof(Activator));
            var metadataLoader = new MigrationsMetadataLoader(locationWhereNoData);
            _validator.Validate(metadataLoader.Get());
        }

        [Fact]
        public void MigratorShouldThrowExceptionAsMigrationDidnotAddMetadata()
        {
            var databuilder = new NullMigrationMetadataBuilder();

            var location = Assembly.GetExecutingAssembly();

            var migrationMetadata = databuilder
                                    .WithAssignedTo(typeof(MigrationWithoutHasNoAttribute))
                                    .WithLocation(location).Build();

            var metadataLoader = new MigrationsMetadataLoaderBuilder().WithMetadata(migrationMetadata).Build();
            Assert.Throws<AttributeNotAssignedException>(() => _validator.Validate(metadataLoader.Get()));
        }   

        [Fact]
        public void MigratorShouldThrowExceptionIfMetadataHasWrongFileName()
        {
            var databuilder = new MigrationMetadataBuilder();
            var location = Assembly.GetExecutingAssembly();

            var migrationMetadata = databuilder.WithAssignedTo(typeof(MigrationWithEmptyFile))
                                    .WithLocation(location).Build();

            var metadataLoader = new MigrationsMetadataLoaderBuilder().WithMetadata(migrationMetadata).Build();
            Assert.Throws<MigrationFileNotFoundException>(() => _validator.Validate(metadataLoader.Get()));
        }

        [Fact]
        public void MigratorShouldThrowExceptionIfMetadataHasEmptyProjectionFile()
        {
            var databuilder = new MigrationMetadataBuilder();
            var location = Assembly.GetExecutingAssembly();

            var migrationMetadata = databuilder
                .WithAssignedTo(typeof(MigrationWithEmptyFile))
                .WithFileName("empty.json")
                .WithOrder(1)
                .WithLocation(location).Build();

            var metadataLoader = new MigrationsMetadataLoaderBuilder().WithMetadata(migrationMetadata).Build();
            Assert.Throws<EmptyProjectionFileException>(() => _validator.Validate(metadataLoader.Get()));
        }
    }
}
