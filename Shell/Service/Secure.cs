using Microsoft.AspNetCore.Components;
using Shell.Model;
using Shell.Data;

namespace Shell.Service
{
    public interface ISecure
    {
        void restart();
        Task<bool> Page_Init();
        Task<int> Check_Menu_Authorize(string cma_id);
        Task<int> Check_Document_Authorize(string cda_id, string per_id);
    }
    public class Secure : ISecure
    {
        private readonly NavigationManager _navMagager;
        private readonly Blazored.SessionStorage.ISessionStorageService _sessionStorage;
        public Secure(NavigationManager navManager, Blazored.SessionStorage.ISessionStorageService sessionStorage)
        {
            _navMagager = navManager;
            _sessionStorage = sessionStorage;
        }
        public void restart()
        {
            _sessionStorage.ClearAsync();
            _navMagager.NavigateTo("/login");
        }
        public async Task<bool> Page_Init()
        {
            try
            {
                var session_user = await _sessionStorage.GetItemAsync<string>("UserID");
                if (string.IsNullOrWhiteSpace(session_user))
                {
                    //Response.Redirect("invalid");
                    _navMagager.NavigateTo("/invalid");
                    return false;
                }
            }
            catch (Exception)
            {
                _navMagager.NavigateTo("/invalid");
                return false;
            }
            return true;
        }

        public async Task<int> Check_Menu_Authorize(string cma_id)
        {
            var session_db_menu_user = await _sessionStorage.GetItemAsync<string>("db_menu_user");
            string cma_id_name = "," + cma_id + "@";
            if (session_db_menu_user.IndexOf(cma_id_name) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> Check_Document_Authorize(string cda_id, string per_id)
        {
            /*
             * 
             0* doc_id, 
             1* Create_Per, 
             2* Edit_Per, 
             3* View_Per, 
             4* Delete_Per, 
             5* Approve_Per, 
             6* Print_Per,   
             7* Export_Per
             
             */


            var session_db_doc_user = await _sessionStorage.GetItemAsync<List<SecureSessionDocData>>("db_doc_user");
            if (cda_id != "" && per_id != "")
            {
                bool per_id_bool = false;
                foreach (var eachrow in session_db_doc_user)
                {
                    switch (per_id)
                    {
                        case "0":
                            {
                                break;
                            }
                        case "1":
                            {
                                if (eachrow.CreatePer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "2":
                            {
                                if (eachrow.EditPer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "3":
                            {
                                if (eachrow.ViewPer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "4":
                            {
                                if (eachrow.DeletePer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "5":
                            {
                                if (eachrow.ApprovePer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "6":
                            {
                                if (eachrow.PrintPer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        case "7":
                            {
                                if (eachrow.ExportPer == true)
                                {
                                    per_id_bool = true;
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    if (eachrow.doc_id == cda_id && per_id_bool)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
