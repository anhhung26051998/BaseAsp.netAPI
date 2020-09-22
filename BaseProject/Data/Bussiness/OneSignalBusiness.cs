
using Data.Model;
using Data.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Business
{
    public class OneSignalBusiness : GenericBusiness
    {
        //public OneSignalBusiness(GO_TECHEntities context = null) : base()
        //{
        //}
        public string StartPushNoti(object obj, List<string> deviceID, string contents, string headerStr, int? sound = null)
        {
            OneSignalInput input = new OneSignalInput();
            TextInput header = new TextInput();
            header.en = "Thông báo !";
            TextInput content = new TextInput();
            content.en = headerStr;
            input.app_id = SystemParam.APP_ID;
            input.data = obj;
            input.headings = header;
            input.contents = content;
            input.android_channel_id = SystemParam.ANDROID_CHANNEL_ID;
            input.include_player_ids = deviceID;
            return JsonConvert.SerializeObject(input);
        }

        public OneSignalOutputModel PushOneSignals(string value, string deviceID = "")
        {

            string url = SystemParam.URL_ONESIGNAL;

            var request = HttpWebRequest.Create(string.Format(url));

            request.Headers["Authorization"] = SystemParam.Authorization;
            request.Headers["https"] = SystemParam.URL_BASE_https;
            var byteData = Encoding.UTF8.GetBytes(value);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                OneSignalOutputModel data = JsonConvert.DeserializeObject<OneSignalOutputModel>(responseString.ToString());
                return data;

            }
            catch (WebException e)
            {
                OneSignalOutputModel data = new OneSignalOutputModel { errors = e.ToString() };
                return data;
            }
        }
        public void SaveLog(string content, string body)
        {
            var reportDirectory = string.Format("~/text/{0}/", DateTime.Now.ToString("yyyy-MM-dd"));
            reportDirectory = System.Web.Hosting.HostingEnvironment.MapPath(reportDirectory);
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            var dailyReportFullPath = string.Format("{0}text_{1}.log", reportDirectory, DateTime.Now.Day);
            var logContent = string.Format("{0}-{1}-{2}", DateTime.Now, "noti: " + content + " / " + body, Environment.NewLine);
            File.AppendAllText(dailyReportFullPath, logContent);
        }

    }
}
