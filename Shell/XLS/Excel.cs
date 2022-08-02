using Microsoft.JSInterop;
using Shell.Model;
using Shell.Data;

namespace Shell.XLS
{
    public class Excel
    {
        public async Task GenerateMasterExcelImportDataAsync(IJSRuntime js, List<MasterExcelImportData> data, string filename = "export.xlsx")
        {
            var masterxls = new MasterExcelImportDataXLS();
            var XLSStream = masterxls.Edition(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
    }
}
