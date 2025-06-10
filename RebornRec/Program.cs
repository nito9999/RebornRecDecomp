using System.Net;

namespace RebornRec
{
    internal class Start
    {
        static void Main(string[] args)
        {
            Setup.setup();
        Tutorial:
            if (Setup.firsttime == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Title = "RebornRec - Intro";
                Console.WriteLine($"Welcome to RebornRec {server_configs.build_version}!");
                Console.WriteLine("Is this your first time using RebornRec?");
                Console.WriteLine("Press (Y) for Yes, or (N) for No");
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.Title = "RebornRec - Tutorial";
                    Console.WriteLine("In that case, welcome to RebornRec!");
                    Console.WriteLine("RebornRec is server software that emulates the servers of previous Rec Room versions.");
                    Console.WriteLine("To use RebornRec, you'll need to have builds aswell!");
                    Console.WriteLine("To obtain builds, go to any of the builds channels inside the Discord server to download one, or use the Build Manager." + Environment.NewLine);

                    Console.WriteLine("Press (D) if downloading from Discord, or (B) for Build Manager");
                    ConsoleKeyInfo keyinfo2 = Console.ReadKey();
                    if (keyinfo2.Key == ConsoleKey.B)
                    {
                        Console.WriteLine("Todo: make download system");
                        Console.ReadKey();
                        goto Start;
                    }

                    Console.Clear();
                    Console.WriteLine("Now that you have a build, what you're going to do is as follows:" + Environment.NewLine);
                    Console.WriteLine("1. Unzip the build into its own folder");
                    Console.WriteLine("2. Start the server by pressing 5 on the main menu");
                    Console.WriteLine("3. Run Recroom_Release.exe from the folder of the build you downloaded." + Environment.NewLine);
                    Console.WriteLine("And that's it! Press any key to go to the main menu, where you will be able to start the server!");
                    Console.ReadKey();
                    Console.Clear();
                    goto Start;
                }
                else
                {
                    Console.Clear();
                    goto Start;
                }
            }
            else
            {
                goto Start;
            }

        Start:
            Console.Title = "RebornRec - Main Menu";
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"RebornRec - Old RecRoom Server Software. (Version: {server_configs.build_version} {server_configs.build_version})");
#if server_info
            Console.WriteLine("GitHub Repository and Wiki: https://github.com/aqquad/RebornRec");
            Console.WriteLine("Discord Server: https://discord.gg/yWBNpcAQTf" + Environment.NewLine);
#else
            Console.WriteLine("GitHub server Repository: https://github.com/nito9999/RebornRecDecomp");
            Console.WriteLine("GitHub data Repository and Wiki: https://github.com/nito9999/rebornrecmod");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("this is a decomp of RebornRec server" + Environment.NewLine);
#endif
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!new WebClient().DownloadString($"{server_configs.github_url}/version.txt").Contains(server_configs.build_version))
            {
                Console.WriteLine("This version of RebornRec is outdated. We recommend you install the latest version, RebornRec " + new WebClient().DownloadString($"{server_configs.github_url}/version.txt"));
            }
            Console.ForegroundColor = ConsoleColor.Yellow;

        }
    }
}
