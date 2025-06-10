using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RebornRec;

namespace RebornRec.server
{
    internal class NameServer
    {
        public NameServer()
        {
            try
            {
                Console.WriteLine("[NameServer.cs] has started.");
                new Thread(new ThreadStart(this.StartListen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
            }
        }

        private void StartListen()
        {
            //nameserver is ONLY for 2018
            this.listener.Prefixes.Add("http://localhost:2059/");
            for (; ; )
            {
                this.listener.Start();
                Console.WriteLine("[NameServer.cs] is listening.");
                HttpListenerContext context = this.listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string rawUrl = request.RawUrl;
                string s = "";
                if (rawUrl == "?v=2")
                {
                    NSData2 data = new NSData2()
                    {
                        API = "http://localhost:2056",
                        Accounts = "http://localhost:2056",
                        Auth = "http://localhost:2056",
                        CDN = "http://localhost:2058",
                        Chat = "http://localhost:2056",
                        Clubs = "http://localhost:2056",
                        Commerce = "http://localhost:2056",
                        DataCollection = "http://localhost:2056",
                        Images = "http://localhost:2058",
                        Leaderboard = "http://localhost:2056",
                        Link = "http://localhost:2056",
                        Matchmaking = "http://localhost:2056",
                        Moderation = "http://localhost:2056",
                        Notifications = "http://localhost:2057",
                        PlatformNotifications = "http://localhost:2056",
                        RoomComments = "http://localhost:2056",
                        Rooms = "http://localhost:2056",
                        Storage = "http://localhost:2056",
                        WWW = "http://localhost:2056"
                    };
                    s = JsonConvert.SerializeObject(data);
                }
                else
                {
                    NSData data = new NSData()
                    {
                        API = "http://localhost:2056",
                        Images = "http://localhost:2058",
                        Notifications = "http://localhost:2057",
                    };
                    s = JsonConvert.SerializeObject(data);
                }
                Console.WriteLine("NameServer Response: " + s);

                byte[] bytes = Encoding.UTF8.GetBytes(s);
                response.ContentLength64 = (long)bytes.Length;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);

                Thread.Sleep(400);

                outputStream.Close();
                this.listener.Stop();
            }
        }

        public class NSData
        {
            public string API { get; set; }
            public string Images { get; set; }
            public string Notifications { get; set; }
        }
        public class NSData2
        {
            public string API { get; set; }
            public string Accounts { get; set; }
            public string Auth { get; set; }
            public string CDN { get; set; }
            public string Chat { get; set; }
            public string Clubs { get; set; }
            public string Commerce { get; set; }
            public string DataCollection { get; set; }
            public string Images { get; set; }
            public string Leaderboard { get; set; }
            public string Link { get; set; }
            public string Matchmaking { get; set; }
            public string Moderation { get; set; }
            public string Notifications { get; set; }
            public string PlatformNotifications { get; set; }
            public string RoomComments { get; set; }
            public string Rooms { get; set; }
            public string Storage { get; set; }
            public string WWW { get; set; }
        }
        private HttpListener listener = new HttpListener();
    }
}
