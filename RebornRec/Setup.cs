using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RebornRec
{
    internal class Setup
    {
        public static bool firsttime = false;
        public static void setup()
        {
            Console.WriteLine("Setting up... (May take a minute to download everything.)");
            Directory.CreateDirectory("SaveData\\Inventions\\");
            Directory.CreateDirectory("SaveData\\Profile\\");
            Directory.CreateDirectory("SaveData\\Photos\\");
            Directory.CreateDirectory("SaveData\\Rooms\\");
            if (!(File.Exists("SaveData\\appsettings.txt")))
            {
                File.WriteAllText("SaveData\\appsettings.txt", JsonConvert.SerializeObject(new server_configs.Settings()));
                firsttime = true;
            }
            if (!File.Exists("SaveData\\avatar.txt") || File.ReadAllText("SaveData\\avatar.txt") == "")
            {
                File.WriteAllText("SaveData\\avatar.txt", new WebClient().DownloadString($"{server_configs.github_url}/avatar.txt"));
            }
            if (!(File.Exists("SaveData\\avataritems.txt")))
            {
                File.WriteAllText("SaveData\\avataritems.txt", new WebClient().DownloadString($"{server_configs.github_url}/avataritems.txt"));
            }
            if (!(File.Exists("SaveData\\bookmarks.txt")))
            {
                File.WriteAllText("SaveData\\bookmarks.txt", "[]");
            }
            if (!(File.Exists("SaveData\\consumables.txt")))
            {
                File.WriteAllText("SaveData\\consumables.txt", new WebClient().DownloadString($"{server_configs.github_url}/consumables.txt"));
            }
            if (!(File.Exists("SaveData\\equipment.txt")))
            {
                File.WriteAllText("SaveData\\equipment.txt", new WebClient().DownloadString($"{server_configs.github_url}/equipment.txt"));
            }
            if (!(File.Exists("SaveData\\extravataritems.txt")))
            {
                File.WriteAllText("SaveData\\extravataritems.txt", "[]");
            }
            if (!(File.Exists("SaveData\\gameconfigs.txt")))
            {
                File.WriteAllText("SaveData\\gameconfigs.txt", new WebClient().DownloadString($"{server_configs.github_url}/gameconfigs.txt"));
            }
            if (!(File.Exists("SaveData\\outfits.txt")))
            {
                File.WriteAllText("SaveData\\outfits.txt", "");
            }
            if (!(File.Exists("SaveData\\profileimage.png")))
            {
                File.WriteAllBytes("SaveData\\profileimage.png", new WebClient().DownloadData($"{server_configs.github_url}/profileimage.png"));
            }
            if (!(File.Exists("SaveData\\settings.txt")))
            {
                File.WriteAllText("SaveData\\settings.txt", JsonConvert.SerializeObject(api.Settings.CreateDefaultSettings()));
            }

            if (!(File.Exists("SaveData\\Profile\\cheer.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\cheer.txt", new Random().Next(0, 50).ToString());
            }
            if (!(File.Exists("SaveData\\Profile\\level.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\level.txt", new Random().Next(0, 50).ToString());
            }
            if (!(File.Exists("SaveData\\Profile\\userid.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\userid.txt", new Random().Next(10000, 10000000).ToString());
            }
            if (!(File.Exists("SaveData\\Profile\\username.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\username.txt", "RebornRec User#" + new Random().Next(0, 1000000));
            }
        }
    }
}
