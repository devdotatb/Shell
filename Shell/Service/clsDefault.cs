using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Data.Odbc;
using System.Collections;
using System.Net;

namespace Control
{
    public class clsDefault
    {

        public clsDefault()
        {
            ChannalID = "1580093265";
        }

        public string ChangeDateFormat(string src, string srcFormat, string destFormat)
        {
            string returnValue = "";
            string dd = "";
            string MM = "";
            string yyyy = "";
            string HH = "";
            string mm = "";
            string ss = "";
            if (src == "")
            {
                //src = "0000000000";
                return "";
            }
            switch (srcFormat)
            {
                case "MM/dd/yyyy":
                    MM = src.Substring(0, 2);
                    dd = src.Substring(4, 2);
                    yyyy = src.Substring(6, 4);
                    break;
                case "dd/MM/yyyy":
                    dd = src.Substring(0, 2);
                    MM = src.Substring(3, 2);
                    yyyy = src.Substring(6, 4);
                    break;
                case "yyyyMMdd":
                    dd = src.Substring(6, 2);
                    MM = src.Substring(4, 2);
                    yyyy = src.Substring(0, 4);
                    break;
                case "yyyy-MM-dd":
                    dd = src.Substring(8, 2);
                    MM = src.Substring(5, 2);
                    yyyy = src.Substring(0, 4);
                    break;
                case "yyyyMMddHHmm":
                    dd = src.Substring(6, 2);
                    MM = src.Substring(4, 2);
                    yyyy = src.Substring(0, 4);
                    HH = src.Substring(8, 2);
                    mm = src.Substring(10, 2);
                    break;
                case "yyyyMMddHHmmss":
                    dd = src.Substring(6, 2);
                    MM = src.Substring(4, 2);
                    yyyy = src.Substring(0, 4);
                    HH = src.Substring(8, 2);
                    mm = src.Substring(10, 2);
                    ss = "00";
                    break;
                case "dd/MM/yyyy HH:mm":
                    dd = src.Substring(0, 2);
                    MM = src.Substring(3, 2);
                    yyyy = src.Substring(6, 4);
                    HH = src.Substring(11, 2);
                    mm = src.Substring(14, 2);
                    break;
            }
            switch (destFormat)
            {
                case "MM/dd/yyyy":
                    returnValue = MM + "/" + dd + "/" + yyyy;
                    break;
                case "dd/MM/yyyy":
                    returnValue = dd + "/" + MM + "/" + yyyy;
                    break;
                case "yyyyMMdd":
                    returnValue = yyyy + MM + dd;
                    break;
                case "yyyy-MM-dd":
                    returnValue = yyyy + "-" + MM + "-" + dd;
                    break;
                case "dd/MM/yyyy HH:mm":
                    returnValue = dd + "/" + MM + "/" + yyyy + " " + HH + ":" + mm;
                    break;
                case "dd/MM/yyyy HH:mm:ss":
                    returnValue = dd + "/" + MM + "/" + yyyy + " " + HH + ":" + mm + ":" + "00";
                    break;
                case "yyyyMMddHHmm":
                    returnValue = yyyy + MM + dd + HH + mm;
                    break;
                case "HH:mm":
                    returnValue = HH + ":" + mm;
                    break;
                case "yyyy-MM-dd HH:mm:ss":
                    returnValue = yyyy + "-" + MM + "-" + dd + " " + HH + ":" + mm + ":00";
                    break;
            }
            return returnValue;
        }
        public bool ConvertToBool(string src)
        {
            bool returnValue = false;
            if (src == "1")
            {
                returnValue = true;
            }
            return returnValue;
        }
        public string ConvertToString(bool src)
        {
            string returnValue = "0";
            if (src)
            {
                returnValue = "1";
            }
            return returnValue;
        }


        public bool IsNumeric(string strToCheck)
        {
            //Format 99.99
            return Regex.IsMatch(strToCheck, "^\\d+(\\.\\d+)?$");
            //Format 99
            //return Regex.IsMatch(strToCheck, "^\\d+([#]\\d+)?$");
            //return Regex.IsMatch(strToCheck, "^\\d+([#]\\d+)?$");
        }

        public bool IsEmail(string strToCheck)
        {
            //Format 99.99
            //return Regex.IsMatch(strToCheck, "^\\d+(\\.\\d+)?$");
            //Format 99
            //return Regex.IsMatch(strToCheck, "^\\d+([#]\\d+)?$");
            return Regex.IsMatch(strToCheck, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        }

        public string Left(string param, int length)
        {
            string result = param;
            if (param.Length >= length)
            {
                result = param.Substring(0, length);
            }
            return result;
        }

        internal static string Right(string param, int length)
        {
            string result = param;
            if (param.Length >= length)
            {
                result = param.Substring(param.Length - length, length);
            }
            return result;
        }

        public string Mid(string param, int startIndex, int length)
        {
            string result = "";
            if ((startIndex + length) <= param.Length) result = param.Substring(startIndex - 1, length);
            return result;
        }

        public string Mid(string param, int startIndex)
        {
            string result = "";
            if (startIndex <= param.Length) result = param.Substring(startIndex);
            return result;
        }


        public string ChannalID { get; set; }
        public StreamReader LineDataReader(string data)
        {
            string url = "https://api.aiya.ai/v5.0/message/push";
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
        public StreamReader LineTag(string data, string userid)
        {
            string url = string.Format("https://api.aiya.ai/v5.0/friend/{0}/tags", userid);
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
        public StreamReader LineTagClear(string userid)
        {
            string url = string.Format("https://api.aiya.ai/v5.0/friend/{0}/tags/reset", userid);
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
        public string ReplaceText(string txt)
        {
            return txt.Replace(@"'", "").Replace("&#8203;", "").Trim();
        }
    }
}
