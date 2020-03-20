using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

namespace EFTHighlightDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Highlight Detector";
            var highlightPath = Path.Combine(Path.GetTempPath(), @"Highlights/Escape From Tarkov");
            var tarkovConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Escape from Tarkov/shared.ini");

            if (!NvidiaCheck())
            {
                Console.WriteLine("It appears that no Nvidia cards were found, although, this could be a false positive.\nAre you sure your card is Nvidia Highlights compatible? (Y/N)");
                Console.WriteLine();
                Console.Write("-> ");
                var key = Console.ReadKey();
                if (key.KeyChar.ToString().ToLower() != "y") Environment.Exit(0);
            }

            Console.Clear();

            PrepHighlightDir(highlightPath);

            PrepTarkovConfig(tarkovConfigPath);

            var listThread = new Thread(new ParameterizedThreadStart(Listener));
            listThread.Start(highlightPath);
        }
        private static bool NvidiaCheck()
        {
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            var gpuInf = new List<ManagementBaseObject>();

            bool cardFound = false;
            foreach (ManagementObject obj in objvide.Get())
                if (obj["Name"].ToString().ToLower().Contains("nvidia")) cardFound = true;

            return cardFound;
        }
        private static void PrepHighlightDir(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            else if (Directory.GetFiles(path).Length > 0)
            {
                Directory.Delete(path);
                Directory.CreateDirectory(path);
            }
        }
        private static void PrepTarkovConfig(string confPath)
        {
            if (File.Exists(confPath))
            {
                string confPlain;
                using (StreamReader confReader = new StreamReader(confPath))
                {
                    confPlain = confReader.ReadToEnd();
                    confReader.Close();
                }
                JObject confObj = JObject.Parse(confPlain);
                JProperty nvProp = confObj.Property("NVidiaHighlightsEnabled");
                bool isEnabled = nvProp.Value.Value<bool>();

                if (!isEnabled)
                {
                    Console.Write("Nvidia Highlights is NOT enabled! Enabling... ");
                    nvProp.Value = true;
                    string updatedPlain = JsonConvert.SerializeObject(confObj, Formatting.Indented);
                    confObj = null;
                    File.Delete(confPath);
                    using (StreamWriter confWriter = new StreamWriter(confPath))
                    {
                        confWriter.WriteLine(updatedPlain);
                        confWriter.Flush();
                    }
                    Console.WriteLine("OK");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Could not find the tarkov config location!\nPlease make sure you manually enable Nvidia Highlights in the settings");
                Console.ReadKey();
            }
        }
        private static void Listener(Object highlightPath) 
        {
            int actCount = 0;
            var path = (string)highlightPath;
            var killPlayer = new System.Media.SoundPlayer(@"audio.wav");
            var notificationList = new List<string>();

            Console.WriteLine("Listening for activities...");
            Console.WriteLine();
            while (true)
            {
                var files = Directory.GetFiles(path);
                if (files.Length > actCount)
                {
                    Console.WriteLine("{0} - {1} kills", DateTime.Now.ToString("hh:mm:ss"), files.Length);
                    killPlayer.Stop();
                    killPlayer.Play();
                }
                else if (files.Length == 0 && actCount != 0)
                {
                    Console.Clear();
                    notificationList.Add(String.Format("{0} - Game finished, recorded {1} activities", DateTime.Now.ToString("hh:mm:ss"), actCount));
                    foreach (var notification in notificationList) Console.WriteLine(notification);
                    Console.WriteLine();
                    Console.WriteLine("Listening for activities...");
                    Console.WriteLine();
                }
                actCount = files.Length;
                Thread.Sleep(1000);
            }
        }
    }
}
