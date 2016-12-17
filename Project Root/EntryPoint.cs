using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SpeechSynthesizerBot
{
    internal class EntryPoint
    {
        private static TelegramBotClient client;

        public static void Main(string[] args)
        {
            ClientRun();
            Thread.Sleep(TimeSpan.FromDays(10));
        }

        private static void ClientRun()
        {
            var taskFactory = new TaskFactory();
            taskFactory.StartNew(() =>
            {
                client = new TelegramBotClient("273498589:AAFsGYS2dP8n5Wrou_VtXOZHXxu5k3-Hops");
                client.StartReceiving();
                client.OnMessage += OnMessageDelegate;
            });
        }

        private static void OnMessageDelegate(object sender, MessageEventArgs messageEventArgs)
        {
            var chatId = messageEventArgs.Message.Chat.Id;
            var result = client.SendTextMessageAsync(chatId, "It is alpha version.").Result;
        }
    }
}
