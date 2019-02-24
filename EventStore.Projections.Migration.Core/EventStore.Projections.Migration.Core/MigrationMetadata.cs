using System;
using System.Linq;
using System.Reflection;
using System.Text;
using EventStore.Projections.Migration.Core.Extensions;

namespace EventStore.Projections.Migration.Core
{
    public class MigrationMetadata
    {
        public int Order { get; set; }
        public string FileName { get; set; }
        public string ProjectionName { get; set; }
        public Assembly Location { get; set; }
        public Type AssignedTo { get; set; }
        public string[] PreRequristeFiles { get; set; }

        public string Query()
        {
            var queryFile = Location.ReadResource(FileName);
            var preRequsiteContent = ReadRequsiteFilesContent();

            if (string.IsNullOrEmpty(preRequsiteContent)) return queryFile;

            return preRequsiteContent + Environment.NewLine + queryFile;
        }

        private string ReadRequsiteFilesContent()
        {
            if (PreRequristeFiles == null || !PreRequristeFiles.Any()) return string.Empty;

            StringBuilder preRequsiteFilesContent = new StringBuilder();

            foreach (var preRequristeFile in PreRequristeFiles)
            {
                preRequsiteFilesContent.AppendLine(Location.ReadResource(preRequristeFile));
            }

            return preRequsiteFilesContent.ToString();
        }
    }
}