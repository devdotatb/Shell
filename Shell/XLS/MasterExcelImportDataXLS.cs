using ClosedXML.Excel;
using Shell.Data;
using Shell.Service;
using System.Data;

namespace Shell.XLS
{
    public class MasterExcelImportDataXLS
    {
        public byte[] Edition(List<MasterExcelImportData> data)
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

            var tmp = ExceltoDatatable.ToDataTable(data);

            var ws = wb.AddWorksheet(tmp,"sheetNNNAme");
            for (int i = 2; i <= tmp.Rows.Count + 1; i++)
            {
                ws.Cell(i, "A").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "B").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "C").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "D").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "E").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "F").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "G").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);

                ws.Cell(i, "H").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent4, 0.8);
                ws.Cell(i, "I").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent4, 0.8);

                ws.Cell(i, "J").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent6, 0.8);
                ws.Cell(i, "K").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent6, 0.8);

                ws.Cell(i, "L").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);
                ws.Cell(i, "M").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);
                ws.Cell(i, "N").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);
                ws.Cell(i, "O").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);

                ws.Cell(i, "P").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "Q").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "R").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "S").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "T").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "U").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "V").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);

                ws.Cell(i, "W").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent4, 0.8);

                ws.Cell(i, "X").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent6, 0.8);

                ws.Cell(i, "Y").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent2, 0.8);

                ws.Cell(i, "Z").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
                ws.Cell(i, "AA").Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent5, 0.8);
            }
            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
