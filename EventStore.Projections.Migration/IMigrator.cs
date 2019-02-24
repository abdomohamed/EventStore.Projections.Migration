using System.Threading.Tasks;

namespace EventStore.Projections.Migrations
{
    public interface IMigrator
    {
        Task Run();
    }
}