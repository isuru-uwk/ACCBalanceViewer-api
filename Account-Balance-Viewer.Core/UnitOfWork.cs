using Account_Balance_Viewer.Data.Models;
using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Core.Repositories;

namespace Account_Balance_Viewer.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ReportsRepository _reportRepository; 


        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IReportsRepository Reports => _reportRepository = _reportRepository ?? new ReportsRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
