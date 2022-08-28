using Account_Balance_Viewer.Data.Models;
using Microsoft.AspNetCore.Http;


namespace Account_Balance_Viewer.Core.Interfaces
{
    public interface IFileReaderService
    {
        Task<Report> GetReportFromExcelFile(IFormFile file, string year, string month,string createdBy);
        Task<Report> GetReportFromTextFile(IFormFile file, string year, string month, string createdBy);
    }
}
