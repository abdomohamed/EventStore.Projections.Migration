using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EventStore.Projections.Migration.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static MigrationMetadata GetMirgationMetadata(this Type type)
        {
            var attribute = Attribute.GetCustomAttribute(type, typeof(MigrateAttribute)) as MigrateAttribute;

            if (attribute == null)
                return new NullMigrationMetadata {
                    Location = type.Assembly
                };

            return new MigrationMetadata
            {
                Order = attribute.Order,
                ProjectionName = attribute.ProjectionName,
                FileName = attribute.FileName,
                Location = type.Assembly,
                AssignedTo = type,
                PreRequristeFiles = attribute.PreRequsiteFiles
            };
        }

        public static string ReadResource(this Assembly assembly, string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName)) return null;

            var resourcesName = assembly.GetManifestResourceNames();

            var fullResourceName = resourcesName.FirstOrDefault(name => name.ToLower().Contains(resourceName.ToLower()));

            var resourceStream = assembly.GetManifestResourceStream(fullResourceName);

            if (resourceStream == null) return null;

            using (var reader = new StreamReader(resourceStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
