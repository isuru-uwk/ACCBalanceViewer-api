using Account_Balance_Viewer.Common.ViewModels;
using Account_Balance_Viewer.Data.Models;




namespace Account_Balance_Viewer.Core.Interfaces
{
    public interface IReportsRepository : IGenericRepository<Report>
    {
        Task<ReportViewModel> GetCumulativeBalanceReportByMonthAndYear(int month, int year);

    }
}
