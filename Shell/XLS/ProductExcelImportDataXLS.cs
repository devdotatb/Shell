using ClosedXML.Excel;
using Shell.Data;
using Shell.Service;
using System.Data;

namespace Shell.XLS
{
    public class ProductExcelImportDataXLS
    {
        public byte[] Edition(List<ProductExcelImportData> data)
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

            var tmp = ExceltoDatatable.ToDataTable(data, "Product");

            var ws = wb.AddWorksheet(tmp,"sheetNNNAme");
            for (int i = 2; i <= tmp.Rows.Count + 1; i++)
            {
                ws.Cell(i, "A").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent3, 0.8);
                ws.Cell(i, "B").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);
                ws.Cell(i, "C").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent3, 0.8);
                ws.Cell(i, "D").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent3, 0.8);

                ws.Cell(i, "F").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Text1, 0.8);
                ws.Cell(i, "G").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Text1, 0.8);
            }
            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
