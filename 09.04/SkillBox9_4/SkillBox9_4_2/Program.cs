using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace SkillBox9_4_2
{
    class Program
    {

        static Dictionary<string, string> photoDictionary = new Dictionary<string, string>(); //ключом является имя фото, значением - FileId
        static List<long> waitingPhotoPersonIds = new List<long>(); //список Id людей, которые ждут отправки фото ботом
        static string dictionartyseparator = "/$/";
        static string photoDictionaryName = "PhotoDictionary.txt";
        static string token;
        static ITelegramBotClient bot;
        static WebClient wc;

        static void Main(string[] args)
        {
            if (System.IO.File.Exists(photoDictionaryName)) // если файл уже создан, то при первом запуске считываем из него всю информацию
            {
                string[] photoDictionaryLines = System.IO.File.ReadAllLines(photoDictionaryName);
                if (photoDictionaryLines.Length > 0)
                {
                    foreach (string photoDictionaryLine in photoDictionaryLines)
                    {
                        string[] photoDictionaryParts = photoDictionaryLine.Split(new string[] { dictionartyseparator }, StringSplitOptions.RemoveEmptyEntries);
                        photoDictionary.Add(photoDictionaryParts[0], photoDictionaryParts[1]); // [0] - KeyPhotoName, [1] - Photo ID
                    }
                }
            }
            else
            {
                System.IO.File.AppendAllText(photoDictionaryName, string.Empty);
            }


            token = System.IO.File.ReadAllText(@"D:\Study\SkillBox\Token.txt");
            bot = new TelegramBotClient(token);

            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            wc = new WebClient() { Encoding = Encoding.UTF8 };

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }

        /// <summary>
        /// Метод Update
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text != null)
                {
                    if (!IsWaitingPhotoNameFromPerson(message.From.Id.ToString(), message.Text))
                    {
                        if (IsWaitingPhotoNameToSend(message.From.Id))
                        {
                            if (photoDictionary.TryGetValue(message.Text, out string foundPhotoId))
                            {
                                await SendPhoto(botClient, message, foundPhotoId);
                            }
                            else
                            {
                                await SendMessage(botClient, message, "Указанного фото не найдено! Где-то совершена ошибка.");
                            }
                        }
                        else if (message.Text.ToLower() == "/start")
                        {
                            await SendMessage(botClient, message, "Добро пожаловать, " + message.From.FirstName + ".");
                        }
                        else if (message.Text.ToLower() == "вечер в хату")
                        {
                            await SendMessage(botClient, message, "Часик в радость, чифир в сладость!");
                        }
                        else if (message.Text.ToLower() == "пришли фото")
                        {
                            StringBuilder photoDictionaryAllKeys = new StringBuilder();
                            foreach (string photoDictilaryKey in photoDictionary.Keys)
                            {
                                photoDictionaryAllKeys.Append(photoDictilaryKey + "\n");
                            }
                            string choicePhotoMessage = "Напиши название фото из указанного ниже списка и я отправлю его тебе!\n";
                            await SendMessage(botClient, message, choicePhotoMessage + photoDictionaryAllKeys.ToString());
                            waitingPhotoPersonIds.Add(message.From.Id);
                        }
                    }
                }

                if (message.Photo != null)
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Неплохое фото, сохраняю! \nКак назвать фото?");
                    int photoLength = message.Photo.Length;
                    string photoIdToDownload = message.Photo[photoLength - 1].FileId;
                    photoDictionary.Add(message.From.Id.ToString(), photoIdToDownload);
                }

                if (message.Document != null)
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Получил файл!");
                    await DownloadAnyFile(message.Document.FileId, "_" + message.Document.FileName);
                }
            }
        }

        /// <summary>
        /// Выводит на экран информацию об ошибке, при ее возникновении
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        /// <summary>
        /// Отправляет указанное сообщение пользователю
        /// </summary>
        /// <param name="telegramBotClient"></param>
        /// <param name="message"> Загруженное сообщение от пользователя </param>
        /// <param name="messageText"> Текст сообщения для отправки пользователю от бота </param>
        /// <returns></returns>
        private static async Task SendMessage(ITelegramBotClient telegramBotClient, Message message, string messageText)
        {
            await telegramBotClient.SendTextMessageAsync(message.Chat, messageText);
        }

        /// <summary>
        /// Отправляет пользователю фото из списка по введенному FileId
        /// </summary>
        /// <param name="telegramBotClient"></param>
        /// <param name="message"> Загруженное сообщение от пользователя </param>
        /// <param name="photoId"> FileId, найденное по ключу из списка </param>
        /// <returns></returns>
        private static async Task SendPhoto(ITelegramBotClient telegramBotClient, Message message, string photoId)
        {
            await telegramBotClient.SendPhotoAsync(message.Chat, photoId);
        }

        /// <summary>
        /// Скачивает отправленный пользователем файл на компьютер
        /// </summary>
        /// <param name="fileIdToDownload"> FileId, по которому будет происходить скачивание </param>
        /// <param name="fileName"> Название созданного файла на компьютере </param>
        /// <returns></returns>
        private static async Task DownloadAnyFile(string fileIdToDownload, string fileName)
        {
            var file = await bot.GetFileAsync(fileIdToDownload);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// Проверка, ожидает ли программа от пользователя название отправленного фото для сохранения в списке
        /// </summary>
        /// <param name="personId"> Id пользователя </param>
        /// <param name="personPhotoNameText"> Текст, отправленный пользователем, которым будет названа новая фотография </param>
        /// <returns> True - если программа ждала ответ от пользователя, False - если программа не ждала ответ от пользователя </returns>
        private static bool IsWaitingPhotoNameFromPerson(string personId, string personPhotoNameText)
        {
            if (photoDictionary.TryGetValue(personId, out string foundPhotoId))
            {
                photoDictionary.Remove(personId);
                photoDictionary.Add(personPhotoNameText, foundPhotoId);
                string newPhoto = personPhotoNameText + "/$/" + foundPhotoId;
                System.IO.File.AppendAllText(photoDictionaryName, newPhoto + "\n");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка, ждет ли программа введенного от пользователя названия фото для отправки ему
        /// </summary>
        /// <param name="personId"> Id пользователя </param>
        /// <returns> True - если программа ждала ответ от пользователя, False - если программа не ждала ответ от пользователя </returns>
        private static bool IsWaitingPhotoNameToSend(long personId)
        {
            for (int i = 0; i < waitingPhotoPersonIds.Count; i++)
            {
                if (waitingPhotoPersonIds[i] == personId)
                {
                    waitingPhotoPersonIds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
