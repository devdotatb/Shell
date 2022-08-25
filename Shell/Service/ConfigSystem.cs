using Nancy.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Shell.Service
{
    public interface IConfigSystem
    {
        StreamReader ApiDataReader(string data, string url, string method, Dictionary<string, string> header);
        string GetAccessToken();
        string Get_UrlApiEndPoint_authenticateclient();
        string Get_UrlApiEndPoint_getclientordercatalogue();
        string Get_UrlApiEndPoint_addclientorders();
        string Get_UrlApiEndPoint_getpointsummary();
        string Get_UrlApiEndPoint_ExtTradeRegistration();
        string Get_UrlApiEndPoint_ShareAppRedirection();
        string Get_ERToken();
        string Get_CountryCode();
        string Get_LanguageCode();

        string Get_client_id();
        string Get_user_id();
        string Get_workshop_shell_code();
    }
    public class ConfigSystem : IConfigSystem
    {
        public ConfigSystem()
        {
            UrlApiEndPoint_authenticateclient = "https://share.prm-uat.com/services/api/exttradeauthentication/authenticateclient";
            UrlApiEndPoint_getclientordercatalogue = "https://share.prm-uat.com/services/api/extorder/getclientordercatalogue";
            UrlApiEndPoint_addclientorders = "https://share.prm-uat.com/services/api/extorder/addclientorders";
            UrlApiEndPoint_getpointsummary = "https://share.prm-uat.com/services/api/extorder/getpointsummary";
            UrlApiEndPoint_ExtTradeRegistration = "https://share.prm-uat.com/services/api/prelogin/ExtTradeRegistration";
            UrlApiEndPoint_ShareAppRedirection = "https://share.prm-uat.com/services/api/ExtTradeAuthentication/ShareAppRedirection";
            ERToken = "SHARE-297992CD-74CE-415C-B7D1-B1805A79F398";
            CountryCode = "764";
            LanguageCode = "1";

            client_id = "180C341C-E6EE-49E6-85E1-6F01AF0D89D9";
            user_id = "lineadmin";
            workshop_shell_code = "lineadmin";
        }

        public string UrlApiEndPoint_authenticateclient { get; set; }
        public string UrlApiEndPoint_getclientordercatalogue { get; set; }
        public string UrlApiEndPoint_addclientorders { get; set; }
        public string UrlApiEndPoint_getpointsummary { get; set; }
        public string UrlApiEndPoint_ExtTradeRegistration { get; set; }
        public string UrlApiEndPoint_ShareAppRedirection { get; set; }
        public string ERToken { get; set; }
        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }

        public string client_id { get; set; }
        public string user_id { get; set; }
        public string workshop_shell_code { get; set; }

        public string Get_UrlApiEndPoint_authenticateclient() { return UrlApiEndPoint_authenticateclient; }
        public string Get_UrlApiEndPoint_getclientordercatalogue() { return UrlApiEndPoint_getclientordercatalogue; }
        public string Get_UrlApiEndPoint_addclientorders() { return UrlApiEndPoint_addclientorders; }
        public string Get_UrlApiEndPoint_getpointsummary() { return UrlApiEndPoint_getpointsummary; }
        public string Get_UrlApiEndPoint_ExtTradeRegistration() { return UrlApiEndPoint_ExtTradeRegistration; }
        public string Get_UrlApiEndPoint_ShareAppRedirection() { return UrlApiEndPoint_ShareAppRedirection; }
        public string Get_ERToken() { return ERToken; }
        public string Get_CountryCode() { return CountryCode; }
        public string Get_LanguageCode() { return LanguageCode; }

        public string Get_client_id() { return client_id; }
        public string Get_user_id() { return user_id; }
        public string Get_workshop_shell_code() { return workshop_shell_code; }


        public StreamReader ApiDataReader(string data, string url, string method, Dictionary<string, string> header)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Method = method;
            myReq.ContentType = "application/json;charset=UTF-8";
            foreach (KeyValuePair<string, string> item in header)
            {
                myReq.Headers.Add(item.Key, item.Value);
            }
            if (!string.IsNullOrEmpty(data))
            {
                byte[] bytedata = Encoding.UTF8.GetBytes(data);
                myReq.ContentLength = bytedata.Length;
                using (Stream ds = myReq.GetRequestStream())
                {
                    ds.Write(bytedata, 0, bytedata.Length);
                }
            }
            HttpWebResponse wr = (HttpWebResponse)myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            return reader;
        }

        public string GetAccessToken()
        {
            string access_token = "";
            string content = "";
            string jsondata = "";
            Dictionary<string, string> header = new Dictionary<string, string>();
            try
            {
                jsondata = new JavaScriptSerializer().Serialize(new
                {
                    client_id = client_id,
                    user_id = user_id,
                    workshop_shell_code = workshop_shell_code
                });

                header.Add("ER-Token", ERToken);

                content = ApiDataReader(jsondata, UrlApiEndPoint_authenticateclient, "POST", header).ReadToEnd();

                JObject rss = JObject.Parse(content);
                if (rss["ResponseCode"].ToString() == "9100")
                {
                    access_token = rss["Data"]["access_token"].ToString();
                }
            }
            catch (Exception ex)
            {
                access_token = "";
            }
            return access_token;
        }
    }
}
