using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WebNoti
{
    //class WebNoti_FirebaseService
    //{
    //}
    public static class WebNoti_FirebaseService
    {
        private static Uri FireBasePushNotificationsURL = new Uri("https://fcm.googleapis.com/fcm/send");
        private static string ServerKey = "AAAAK5SVx7M:APA91bFLqmRCKMbLN26RVqR4oM7CVO4-c_FvikYnrS4_3y8-ex22WspCZ3_zDwQ2OTZXL0HbpKbTPBaIbIZrBAptmiDaT54E3xsIZbVYWOZgtUvrb00TT85f77hLqxDDtz7U6Q-u-xdS";
        private static string Icon = "https://www.5bb.com.mm/Images/Noti/noti_fivebb_logo.png";
        public static async Task<bool> SendPushNotification(string[] deviceTokens, string title, string body, object data,String FirebaseServerkey)
        {
            bool sent = false;
            ServerKey = FirebaseServerkey;
            //if (deviceTokens.Count() > 0)
            //{
            //Object creation

            var messageInformation = new 
            {
                //notification = new Notification1()
                //{
                //    title = title,
                //    text = body,
                //    icon = Icon,
                //    priority = "high",
                //    content_available = true,
                //    mutable_content = true
                //},
                //  data = data,
                notification = new
                {
                    title = title,
                    text = body,
                    icon = Icon,
                    priority = "high",
                    content_available = true,
                    mutable_content = true
                },
                data = new
                {
                    title = title,
                    body = body,
                    priority = "high",
                    content_available = true,
                    mutable_content = true
                },
                registration_ids = deviceTokens
            };

            //Object to JSON STRUCTURE => using Newtonsoft.Json;
            string jsonMessage = JsonConvert.SerializeObject(messageInformation);

            /*
             ------ JSON STRUCTURE ------
             {
                notification: {
                                title: "",
                                text: ""
                                },
                data: {
                        action: "Play",
                        playerId: 5
                        },
                registration_ids = ["id1", "id2"]
             }
             ------ JSON STRUCTURE ------
             */

            //Create request to Firebase API
            var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);

            request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
            request.Headers.TryAddWithoutValidation("project_id", "187176437683");
            request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                result = await client.SendAsync(request);
                sent = sent && result.IsSuccessStatusCode;
            }
            // }

            return sent;
        }


        public static async Task<string> SendPushNotificationbyTopic(string Id, string Title, string Message)
        {
            try
            {
                var result = "";
                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"key={ServerKey}");
                httpWebRequest.Method = "POST";
                //using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var obj = new
                    {
                        to = "/topics/" + Id,
                        data = new
                        {
                            title = Title,
                            body = Message,
                            priority = "high",
                            content_available = true,
                            mutable_content = true
                        },
                        notification = new
                        {
                            title = Title,
                            body = Message,
                            //sound = "default",
                            //icon = Icon,
                            priority = "high",
                            content_available = true,
                            mutable_content = true
                        }
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                //Console.WriteLine(result);
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.GetType().ToString();
                //throw;
            }

        }

    }

    public class Message1
    {
        public string[] registration_ids { get; set; }
        public Notification1 notification { get; set; }
        public object data { get; set; }
    }
    public class Notification1
    {
        public string title { get; set; }
        public string text { get; set; }
    }
}
