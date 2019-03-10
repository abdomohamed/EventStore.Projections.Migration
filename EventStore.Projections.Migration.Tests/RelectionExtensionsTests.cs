using System.Data.Common;
using System.Reflection;
using EventStore.Projections.Migration;
using EventStore.Projections.Migration.Extensions;
using EventStore.Projections.Migration.Tests.Projections;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace EventStore.Projections.Migration.Tests
{
    public class RelectionExtensionsTests
    {
        [Fact]
        public void GetMirgationMetadata_WhenCalledWithInvalidType_ShouldReturnNullMigrationMetadata()
        {
            var type = typeof(MigrationWithoutHasNoAttribute);
            var metadata = type.GetMirgationMetadata();
            metadata.GetType().ShouldBe(typeof(NullMigrationMetadata));
        }

        [Fact]
        public void GetMirgationMetadata_WhenCalled_ShouldReturnValidMetadata()
        {
            var type = typeof(GoodMigration);
            var metadata = type.GetMirgationMetadata();
            var expectedMetadata = new MigrationMetadata()
            {
                Order = 1,
                ProjectionName = "test-proj",
                FileName = "good-file.json",
                AssignedTo = type,
                Location = type.Assembly,
                PreRequristeFiles = new string[] { }
            };

            metadata.Should().BeEquivalentTo(expectedMetadata);
        }
    }
}
