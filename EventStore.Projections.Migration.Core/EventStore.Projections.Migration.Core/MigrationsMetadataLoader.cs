using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EventStore.Projections.Migration.Core.Extensions;

namespace EventStore.Projections.Migration.Core
{
    public class MigrationsMetadataLoader : IMigrationMetadataLoader
    {
        private readonly Assembly _location;

        public MigrationsMetadataLoader(Assembly location = null)
        {
            _location = location?? Assembly.GetExecutingAssembly();
        }
        public IEnumerable<MigrationMetadata> Get()
        {
            var parentType = typeof(IMigration);

            var types = _location.GetTypes().Where(type => AmIAMigrationType(parentType, type)).ToList();

            return types.Select(attr => attr.GetMirgationMetadata());
        }

        public IEnumerable<MigrationMetadata> Get<T>() where T: IMigration
        {
            var parentType = typeof(IMigration);

            var types = _location.GetTypes().Where(type => AmIAMigrationType(parentType, type)).ToList().Where(type => type == typeof(T));

            return types.Select(attr => attr.GetMirgationMetadata());
        }

        private bool AmIAMigrationType(Type parentType, Type type)
        {
            return parentType.IsAssignableFrom(type) && type != parentType;
        }
        
    }
}
