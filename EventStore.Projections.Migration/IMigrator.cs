using System.Threading.Tasks;

namespace EventStore.Projections.Migration
{
    public interface IMigrator
    {
        Task Run();
    }
}