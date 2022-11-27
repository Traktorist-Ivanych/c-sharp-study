using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace SkillBox9_4
{
    class Program
    {
        static Dictionary<string,string> picturesDictionary;
        static string picturesPath;
        static string startUrl;
        static WebClient wc;

        static void Main(string[] args)
        {
            ReadPicturesDictionary();

            string token = File.ReadAllText(@"D:\Study\SkillBox\Token.txt");

            wc = new WebClient() { Encoding = Encoding.UTF8 };

            int updateId = 0;
            startUrl = $@"https://api.telegram.org/bot{token}/";

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={updateId}";
                string downloadedMessage = wc.DownloadString(url);

                Console.WriteLine(downloadedMessage);

                var messages = JObject.Parse(downloadedMessage)["result"].ToArray();

                foreach (dynamic message in messages)
                {
                    updateId = Convert.ToInt32(message.update_id) + 1;

                    string userMessage = message.message.text;
                    string userId = message.message.from.id;
                    string userFirstrName = message.message.from.first_name;

                    string decryptedText = $"{userFirstrName} {userId} {userMessage}";

                    Console.WriteLine(decryptedText);

                    if (userMessage.ToLower() == "вечер в хату")
                    {
                        SendMessage("Часик в радость, чифир в сладость, " + userFirstrName, userId);
                    }
                    else if (userMessage.ToLower() == "где трактор?")
                    {
                        SendMessage("Всегда при мне!", userId);
                        SendPhoto(userId);
                    }
                }

                Thread.Sleep(500);
            }
        }

        static void ReadPicturesDictionary()
        {
            picturesDictionary = new Dictionary<string, string>();
            picturesPath = @"D:\Study\SkillBox\C#\9.4\SkillBox9_4\Pictures\PicturesID.txt";
            string[] infoInLines = File.ReadAllLines(picturesPath);
            foreach (string infoInWords in infoInLines)
            {
                string[] infoForDictionary = infoInWords.Split(new string[] {@"\"}, StringSplitOptions.RemoveEmptyEntries);
                picturesDictionary.Add(infoForDictionary[0], infoForDictionary[1]);
            }
        }

        static void SendMessage(string responseText, string userId)
        {
            string responseMessage = responseText;
            string url = $"{startUrl}sendMessage?chat_id={userId}&text={responseMessage}";
            Console.WriteLine(wc.DownloadString(url));
        }

        static void SendPhoto(string userId)
        {
            if (picturesDictionary.TryGetValue("Tractor", out string resultPhotoId))
            {
                string url = $"{startUrl}sendPhoto?chat_id={userId}&photo={resultPhotoId}";
                Console.WriteLine(wc.DownloadString(url));
            }
        }
    }
}
