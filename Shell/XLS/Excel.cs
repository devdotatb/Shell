using Microsoft.JSInterop;
using Shell.Model;
using Shell.Data.ExcelData;

namespace Shell.XLS
{
    public class Excel
    {
        public async Task GenerateMasterExcelImportDataAsync(IJSRuntime js, List<MasterExcelImportData> data, string filename = "export.xlsx")
        {
            var xxls = new MasterExcelExport();
            var XLSStream = xxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateProductExcelImportDataAsync(IJSRuntime js, List<ProductExcelImportData> data, string filename = "export.xlsx")
        {
            var xxls = new ProductExcelExport();
            var XLSStream = xxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateOrderExportLotExcelImportDataAsync(IJSRuntime js, List<ExportLotExportData> data, string filename = "export.xlsx")
        {
            var xxls = new OrderExportLotExport();
            var XLSStream = xxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateExportLotExcelImportDataAsync(IJSRuntime js, List<ExportLotExportData> data, string filename = "export.xlsx")
        {
            var xxls = new LotExportLotExport();
            var XLSStream = xxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
    }
}
