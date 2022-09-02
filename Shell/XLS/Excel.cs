using Microsoft.JSInterop;
using Shell.Model;
using Shell.Data.ExcelData;

namespace Shell.XLS
{
    public class Excel
    {
        public async Task GenerateMasterExcelImportDataAsync(IJSRuntime js, List<MasterExcelData> data, string filename = "export.xlsx",bool isUseEveryData = false)
        {
            var xxls = new MasterExcelExport();
            var XLSStream = xxls.Edition(data, isUseEveryData);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateProductExcelImportDataAsync(IJSRuntime js, List<ProductExcelData> data, string filename = "export.xlsx", bool isUseEveryData = false)
        {
            var xxls = new ProductExcelExport();
            var XLSStream = xxls.Edition(data, isUseEveryData);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateOrderExportLotExcelImportDataAsync(IJSRuntime js, List<ExportLotExcelData> data, string filename = "export.xlsx", bool isUseEveryData = false)
        {
            var xxls = new OrderExportLotExport();
            var XLSStream = xxls.Edition(data, isUseEveryData);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateExportLotExcelImportDataAsync(IJSRuntime js, List<ExportLotExcelData> data, string filename = "export.xlsx", bool isUseEveryData = false)
        {
            var xxls = new LotExportLotExport();
            var XLSStream = xxls.Edition(data, isUseEveryData);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateProductPointExcelImportDataAsync(IJSRuntime js, List<ProductPointExcelData> data, string filename = "export.xlsx", bool isUseEveryData = false)
        {
            var xxls = new ProductPointExport();
            var XLSStream = xxls.Edition(data, isUseEveryData);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
    }
}
