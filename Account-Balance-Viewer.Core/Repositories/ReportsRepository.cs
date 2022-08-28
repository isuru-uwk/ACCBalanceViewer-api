using Account_Balance_Viewer.Common.ViewModels;
using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Data.Models;

namespace Account_Balance_Viewer.Core.Repositories
{
    public class ReportsRepository : GenericRepository<Report>, IReportsRepository
    {
        public ReportsRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ReportViewModel> GetCumulativeBalanceReportByMonthAndYear(int month, int year)
        {
            var allReports = ApplicationDbContext.Reports.Where(r => r.Month <= month && r.Year == year).GroupBy(r => r.Month).Select(r => r.OrderByDescending(r => r.CreatedDate).FirstOrDefault()).ToList();
            var cumulativeBalanceReport = new ReportViewModel();

            foreach (var report in allReports)
            {
                cumulativeBalanceReport.RD += report.RD;
                cumulativeBalanceReport.Canteen += report.Canteen;
                cumulativeBalanceReport.CEOCarExpences += report.CEOCarExpences;
                cumulativeBalanceReport.Marketing += report.Marketing;
                cumulativeBalanceReport.Parking += report.Parking;
            }

            return cumulativeBalanceReport;

        }


        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
