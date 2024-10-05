
namespace Application.SeedOfWork
{
public interface IUnitOfWork:IDisposable
    {

        Task<int> CompletedAsync(CancellationToken cancellation);
       
    }
}
