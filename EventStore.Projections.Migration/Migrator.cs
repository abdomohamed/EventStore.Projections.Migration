using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStore.ClientAPI.Projections;
using EventStore.ClientAPI.SystemData;
using EventStore.Projections.Migration.Validation;

namespace EventStore.Projections.Migration
{
    /// <summary>
    /// Used to run migrations
    /// </summary>
    public class Migrator : IMigrator
    {
        private readonly ProjectionsManager _projectionsManager;
        private readonly UserCredentials _credentials;
        private readonly IMigrationMetadataLoader _loader;
        private readonly IValidator _validator;

        /// <summary>
        /// This used to run migrations 
        /// </summary>
        /// <param name="projectionsManager">EventStore ProjectionManager instance</param>
        /// <param name="credentials">EeventStore ceredentials</param>
        /// <param name="loader">Migrations loader</param>
        /// <param name="validator">Migrations Validator</param>
        public Migrator(ProjectionsManager projectionsManager, UserCredentials credentials, IMigrationMetadataLoader loader, IValidator validator)
        {
            _projectionsManager = projectionsManager;
            _credentials = credentials;
            _loader = loader;
            _validator = validator;
        }

        /// <summary>
        /// Execute migrations
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            var allMetadata = _loader.Get();
            if (!allMetadata.Any()) return;

            _validator.Validate(allMetadata);

            var projections = await _projectionsManager.ListAllAsync(_credentials);
            var newProjections = allMetadata.Where(metadata => NotIn(metadata, projections));
            await ExecuteMigrations(newProjections.ToArray());
        }

        public async Task SetupSystemProjections()
        {
            await UpdateSystemProjections();
            await EnableSystemProjections();
        }

        private async Task ExecuteMigrations(IEnumerable<MigrationMetadata> metadatas)
        {
            var orderedMetadata = metadatas.OrderBy(metadata => metadata.Order);

            foreach (var metadata in orderedMetadata)
            {
                var query = metadata.Query();
                await _projectionsManager.CreateContinuousAsync(metadata.ProjectionName, query, true, _credentials);
            }
        }

        private bool NotIn(MigrationMetadata metadata, List<ProjectionDetails> createdProjections)
        {
            if (createdProjections.All(currentProjection => currentProjection.Name != metadata.ProjectionName))
                return true;
            return false;
        }

        private async Task EnableSystemProjections()
        {
            await _projectionsManager.EnableAsync(StreamNames.Streams, _credentials);
            await _projectionsManager.EnableAsync(StreamNames.ByCategory, _credentials);
            await _projectionsManager.EnableAsync(StreamNames.StreamByCategory, _credentials);
        }

        private async Task UpdateSystemProjections()
        {
            var query = "first\r\n:";

            await _projectionsManager.UpdateQueryAsync(StreamNames.ByCategory, query, _credentials);
            await _projectionsManager.UpdateQueryAsync(StreamNames.StreamByCategory, query, _credentials);
        }
    }
}