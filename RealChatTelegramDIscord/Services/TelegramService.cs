using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChatTelegramDIscord.ViewesModels
{
    using Models;
    using Telegram.Bot;
    using Telegram.Bot.Args;

    public class TelegramViwe
    {
        private TelegramBotClient botClient;
        public bool initializationFinished = false;
        private TelegramModel idTelegram;

        public void TelegramInitialize(TelegramModel model)
        {
            idTelegram = model;
            idTelegram = new TelegramModel();
            botClient = new TelegramBotClient(idTelegram.Token);
            botClient.OnMessage += NewMessageHandler;
            botClient.StartReceiving();
            initializationFinished = true;
            
        }

        public void TelegramDisconect()
        {
           
            botClient.StopReceiving();
            initializationFinished = false;
        }

        /*public void SetTeleObject(DiscordService discord) =>
            this.discord = discord;*/
        private void NewMessageHandler(object sender, MessageEventArgs e)
        {
            if (initializationFinished)
            {
                string msg = e.Message.From.Username + " " + e.Message.Date + ":\n" + e.Message.Text;

                if (MainWindow.service.Discord != null)
                {
                    MainWindow.service.SendMessageDiscord(e.Message.Text);
                }

            }
        }
        public async Task SendMessage(string message) =>
            await botClient.SendTextMessageAsync(idTelegram.ChanneldId, message);
    }
}
