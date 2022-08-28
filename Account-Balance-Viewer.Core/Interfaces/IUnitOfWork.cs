

namespace Account_Balance_Viewer.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReportsRepository Reports { get; }
        Task<int> CommitAsync();
    }
}

