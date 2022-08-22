using Microsoft.JSInterop;
using Shell.Model;
using Shell.Data.ExcelData;

namespace Shell.XLS
{
    public class Excel
    {
        public async Task GenerateMasterExcelImportDataAsync(IJSRuntime js, List<MasterExcelImportData> data, string filename = "export.xlsx")
        {
            var masterxls = new MasterExcelExport();
            var XLSStream = masterxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
        public async Task GenerateProductExcelImportDataAsync(IJSRuntime js, List<ProductExcelImportData> data, string filename = "export.xlsx")
        {
            var masterxls = new ProductExcelExport();
            var XLSStream = masterxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
    }
}
