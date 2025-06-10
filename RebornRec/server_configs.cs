using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebornRec
{
    /// <summary>
    /// this is for configing the server
    /// </summary>
    internal class server_configs
    {
        public class Settings
        {
            public string privaterooms = "";
            public int pridorm = 1; // Why is it a one, make it a bool
            public string buildsdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + server_configs.build_name;
            public bool discordpres = true;
            public bool astolfo = false;
            public string region = "us"; // The photon server region you want to connect to
        }

        public static string build_brance = "Public Release";
        public static string build_version = "5.2.0";
        public static string build_name = "RebornRec";
        public static string github_url = "https://raw.githubusercontent.com/nito9999/rebornrecmod/refs/heads/main";
    }
}
