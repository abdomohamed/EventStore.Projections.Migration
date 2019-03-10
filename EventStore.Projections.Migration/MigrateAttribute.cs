using System;

namespace EventStore.Projections.Migration
{
    public class MigrateAttribute : Attribute
    {
        public int Order { get; }
        public string ProjectionName { get; }
        public string FileName { get; }
        public string[] PreRequsiteFiles { get; }
        public MigrateAttribute(int order, string projectionName, string fileName, params string[] preRequsiteFiles)
        {
            Order = order;
            ProjectionName = projectionName;
            FileName = fileName;
            PreRequsiteFiles = preRequsiteFiles;
        }

        public MigrateAttribute(int order, string projectionName) : this(order, projectionName, projectionName)
        {
        }
    }
}