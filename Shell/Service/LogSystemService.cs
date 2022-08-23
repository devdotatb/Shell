using Shell.Data;
using Shell.Model;
using System.Data;

namespace Shell.Service
{
    public class LogSystemService
    {
        string sql = "", error = "";
        string curr_date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
        string curr_date_full = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + DateTime.Now.ToString("HH:mm:ss");
        public LogSystemService()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void InsertLog(string UserID, string LogType, string IPaddress)
        {
            using (var db = new SHELLREGContext())
            {
                db.LogSystems.Add(new LogSystem()
                {
                    UserId = UserID,
                    LogType = LogType,
                    LogDate = curr_date_full,
                    Ipaddress = IPaddress
                });
                db.SaveChanges();
            }
        }

        public void InsertLogSendLine(string LogType, string LogName, string LogUID, string LogJson, string LogResult)
        {
            using (var db = new SHELLREGContext())
            {
                db.LogSendLines.Add(new LogSendLine()
                {
                    LogType = LogType,
                    LogName = LogName,
                    LogUid = LogUID,
                    LogJson = LogJson,
                    LogResult = LogResult,
                    LogDate = curr_date_full,
                });
                db.SaveChanges();
            }
        }
    }
}
