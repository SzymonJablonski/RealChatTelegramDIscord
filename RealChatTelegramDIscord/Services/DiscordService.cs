using Discord;
using Discord.WebSocket;
using RealChatTelegramDIscord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealChatTelegramDIscord;

namespace RealChatTelegramDIscord.ViewesModels
{
    public class DiscordService
    {
        private DiscordSocketClient client;
        DiscordModel idDiscord;
        private TimeZoneInfo currentTZ;
        public bool initFinished = false;

        public DiscordService()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            currentTZ = TimeZoneInfo.Local;
        }

        public async Task<bool> DiscordInitialize(DiscordModel model)
        {
            client = new DiscordSocketClient();
            client.MessageReceived += NewMessageHAndler;
            client.Ready += InitializeMessageList;
            idDiscord = model;

            await client.LoginAsync(TokenType.Bot, idDiscord.Token); ;
            await client.StartAsync();
            initFinished = true;

            return Task.CompletedTask.IsCompleted;
        }
        private Task NewMessageHAndler(SocketMessage msg)
        {

            if (!msg.Author.IsBot)
            {
                MainWindow.service.SendMessageTelegram(msg.Content);
            }
            string date = DateTime.Now.ToString();
            string message = msg.Author.Username + " " + date + ":\n" + msg.Content;

            Console.WriteLine(message);


            return Task.CompletedTask;
        }

        public async Task DisConnectAsync()
        {

            
            await client.StopAsync();
            initFinished = false;
            client = new DiscordSocketClient();
        }
        private Task InitializeMessageList()
        {

            initFinished = true;

            return Task.CompletedTask;
        }
        public async Task SendMessage(string message) =>
            await client.GetGuild(idDiscord.GuildId).GetTextChannel(idDiscord.TextChanneldId).SendMessageAsync(message);
    }
}