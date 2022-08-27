using Account_Balance_Viewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance_Viewer.Core.Interfaces
{
    public interface IReportsRepository : IGenericRepository<Report>
    {
       
            Task<Report> GetCumulativeBalanceReportByMonthAndYear(int month,int year);
      
    }
}
