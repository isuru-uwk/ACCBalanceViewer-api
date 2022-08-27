using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance_Viewer.Core.Repositories
{
    public class ReportsRepository : GenericRepository<Report>, IReportsRepository
    {
        public ReportsRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Report> GetCumulativeBalanceReportByMonthAndYear(int month, int year)
        {
            var allReports = ApplicationDbContext.Reports.Where(r => r.Month <= month && r.Year == year);
            var cumulativeBalanceReport = new Report();

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
