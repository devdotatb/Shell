using Shell.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Data;
using Shell.Data;
using System.Net;
using System.Text;

namespace Shell.Service
{
    public interface IclsDefault
    {
        string WebRootPath();
        string ContentRootPath();
        Task<string> GenImportID(string Prefix);
        Task<string> GenShoppingNO();
        Task<string> GenInvoiceNo();
        Task<string> GenLotNo();
        Task<string> GenCampaignCode();
        string ReplaceText(string txt);
        StreamReader LineDataReader(string data);
        StreamReader LineTag(string data, string userid);
        StreamReader LineTagClear(string userid);
    }
    public class clsDefault : IclsDefault
    {
        private readonly IWebHostEnvironment _env;

        public clsDefault(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ContentRootPath()
        {
            return _env.ContentRootPath;
        }
        public string WebRootPath()
        {
            return _env.WebRootPath;
        }

        //MENGGIEUNDONE


        public async Task<string> GenImportID(string Prefix)//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                var ReturnValue_Param = new SqlParameter("ReturnValue", SqlDbType.VarChar, 8) { Direction = ParameterDirection.Output };

                using (var db = new SHELLREGContext())
                {
                    await db.Database.ExecuteSqlRawAsync("EXEC clsDefault_GenID @ReturnValue output", new[] { ReturnValue_Param });
                }
                ReturnValue = (string)(ReturnValue_Param.Value);
                return Prefix + ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string ReplaceText(string txt)
        {
            return txt.Replace(@"'", "").Replace("&#8203;", "").Trim();
        }


        //MENGGIEUNDONE


        public async Task<string> GenShoppingNO()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {

                        //MENGGIEUNDONE


                        cmd.CommandText = "select dbo.GenShoppingNo()";
                        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        //cmd.Parameters.Add(new SqlParameter("Ticket", ticket));
                        //cmd.Parameters.Add(new SqlParameter("Reference", reference));
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //MENGGIEUNDONE


        public async Task<string> GenInvoiceNo()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "select dbo.GenInvoiceNo()";
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //MENGGIEUNDONE


        public async Task<string> GenLotNo()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "select dbo.GenLotNo()";
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //MENGGIEUNDONE


        public async Task<string> GenCampaignCode()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "select dbo.GenCampaignCode()";
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //MENGGIEUNDONE


        public StreamReader LineDataReader(string data)
        {
            string url = "";//"https://api.aiya.ai/v5.0/message/push";
            string AppId = "d5475e3021";
            string SecretKey = "3OhasFDgNHrXRv83dLqf6eTgxlDWyofp";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Method = "POST";
            myReq.ContentType = "application/json;charset=UTF-8";
            myReq.Headers.Add("Authorization", "Bearer " + AppId + ":" + SecretKey);
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

        //MENGGIEUNDONE


        public StreamReader LineTag(string data, string userid)
        {
            string url = "";//string url = string.Format("https://api.aiya.ai/v5.0/friend/{0}/tags", userid);
            string AppId = "d5475e3021";
            string SecretKey = "3OhasFDgNHrXRv83dLqf6eTgxlDWyofp";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Method = "POST";
            myReq.ContentType = "application/json;charset=UTF-8";
            myReq.Headers.Add("Authorization", "Bearer " + AppId + ":" + SecretKey);
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

        //MENGGIEUNDONE


        public StreamReader LineTagClear(string userid)
        {
            string url = "";//string url = string.Format("https://api.aiya.ai/v5.0/friend/{0}/tags/reset", userid);
            string AppId = "d5475e3021";
            string SecretKey = "3OhasFDgNHrXRv83dLqf6eTgxlDWyofp";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Method = "POST";
            myReq.ContentType = "application/json;charset=UTF-8";
            myReq.Headers.Add("Authorization", "Bearer " + AppId + ":" + SecretKey);
            HttpWebResponse wr = (HttpWebResponse)myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            return reader;
        }
    }
}
