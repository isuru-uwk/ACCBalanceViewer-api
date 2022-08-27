using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Core.Services;
using Account_Balance_Viewer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account_Balance_Viewer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IFileReaderService _fileReaderService;
        public ReportsController(IUnitOfWork unit, IFileReaderService fileReaderService)
        {
            _unit = unit;
            _fileReaderService = fileReaderService;

        }

        [HttpGet("cumulative/{year}/{month}")]
        public async Task<IActionResult> GetLatestAccountBalanceReport(int month, int year)
        {
            try
            {
                var result = await this._unit.Reports.GetCumulativeBalanceReportByMonthAndYear(month, year);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("add")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(50 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 50 * 1024 * 1024)]
        public async Task<IActionResult> AddReport(
            [FromForm] string year,
            [FromForm] string month,
            [FromForm] IFormFile file)
        {
            try
            {
                var createdBy = User.FindFirst(c => c.Type == "name")?.Value ?? "UnAuthorized";


                if (file.ContentType == "text/plain")
                {
                    var report = await _fileReaderService.GetReportFromTextFile(file, year, month, createdBy);
                    await this._unit.Reports.AddAsync(report);

                }
                else
                {
                    var report = await _fileReaderService.GetReportFromExcelFile(file, year, month, createdBy);
                    await this._unit.Reports.AddAsync(report);
                }
                var result = await _unit.CommitAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
