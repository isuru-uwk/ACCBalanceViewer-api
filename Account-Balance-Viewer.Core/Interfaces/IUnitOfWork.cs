using Account_Balance_Viewer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance_Viewer.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReportsRepository Reports { get; }
        Task<int> CommitAsync();
    }
}

