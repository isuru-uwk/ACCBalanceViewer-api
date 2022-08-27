using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Data.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Account_Balance_Viewer.Core.Services
{
    public class FileReaderService : IFileReaderService
    {

        public async Task<Report> GetReportFromExcelFile(IFormFile file,string year,string month,string createBy)
        {

            var stream = file.OpenReadStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            try
            {
                var report = new Report();

                //if(file.ContentType == "text/plain")
                //{
                //    using (StreamReader textfile = new StreamReader(file.OpenReadStream()))
                //    {
                //        int counter = 0;
                //        string ln;

                //        while ((ln = textfile.ReadLine()) != null)
                //        {
                //            if (ln.Split('\t')[0] == "R&D")
                //                report.RD = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                //            if (ln.Split('\t')[0] == "Canteen")
                //                report.Canteen = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                //            if (ln.Split('\t')[0] == "CEO’s car")
                //                report.CEOCarExpences = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                //            if (ln.Split('\t')[0] == "Marketing")
                //                report.Marketing = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                //            if (ln.Split('\t')[0] == "Parking fines")
                //                report.Parking = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                //        }
                //        textfile.Close();
                //        //Console.WriteLine($ "File has {counter} lines.");
                //    }
                //}





                using (ExcelPackage excel = new ExcelPackage(stream))
                {
                    var workbook = excel.Workbook;
                    var sheet = excel.Workbook.Worksheets.First();
                    int colCount = sheet.Dimension.End.Column;  //get Column Count
                    int rowCount = sheet.Dimension.End.Row;     //get row count


                    report.RD = Convert.ToDecimal(sheet.Cells[2, 1].Value ?? 0);
                    report.Canteen = Convert.ToDecimal(sheet.Cells[2, 2].Value ?? 0);
                    report.CEOCarExpences = Convert.ToDecimal(sheet.Cells[2, 3].Value ?? 0);
                    report.Marketing = Convert.ToDecimal(sheet.Cells[2, 4].Value ?? 0);
                    report.Parking = Convert.ToDecimal(sheet.Cells[2, 5].Value ?? 0);


                    report.CreatedDate = DateTime.Now;
                    report.ModifiedDate = DateTime.Now;
                    report.Year = int.Parse(year);
                    report.Month = int.Parse(month);
                    report.CreatedBy = createBy;


                    //for (int row = 2; row <= rowCount; row++)
                    //{
                    //    for (int col = 1; col <= colCount; col++)
                    //    {
                    //        var value = sheet.Cells[row, col].Value;
                    //        Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + sheet.Cells[row, col].Value?.ToString().Trim());
                    //    }
                    //}
                }


                return report;


            }
            catch (Exception ex)//open xls file
            {
                return new Report();

            }
        }

        public async Task<Report> GetReportFromTextFile(IFormFile file, string year, string month, string createdBy)
        {
            var report = new Report();

            try
            {

              
                    using (StreamReader textfile = new StreamReader(file.OpenReadStream()))
                    {
                        int counter = 0;
                        string ln;

                        while ((ln = textfile.ReadLine()) != null)
                        {
                            if (ln.Split('\t')[0] == "R&D")
                                report.RD = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                            if (ln.Split('\t')[0] == "Canteen")
                                report.Canteen = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                            if (ln.Split('\t')[0] == "CEO’s car")
                                report.CEOCarExpences = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                            if (ln.Split('\t')[0] == "Marketing")
                                report.Marketing = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                            if (ln.Split('\t')[0] == "Parking fines")
                                report.Parking = Convert.ToDecimal(ln.Split('\t')[1] ?? "0");
                        }
                        textfile.Close();
                        //Console.WriteLine($ "File has {counter} lines.");
                    }
                    report.CreatedDate = DateTime.Now;
                    report.ModifiedDate = DateTime.Now;
                    report.Year = int.Parse(year);
                    report.Month = int.Parse(month);
                    report.CreatedBy = createdBy;
                

                return report;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            }
    }
    
}
