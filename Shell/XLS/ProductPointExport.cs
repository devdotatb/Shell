using ClosedXML.Excel;
using Shell.Data.ExcelData;
using Shell.Service;
using System.Data;

namespace Shell.XLS
{
    public class ProductPointExport
    {
        public byte[] Edition(List<ProductPointExcelData> data, bool isUseEveryData)
        {
            var wb = new XLWorkbook();

            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var tmp = ExceltoDatatable.ToDataTable(data, "ProductPoint", isUseEveryData);

            var ws = wb.AddWorksheet(tmp, "sheetname_shell");

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
