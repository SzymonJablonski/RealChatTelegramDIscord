using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChatTelegramDIscord.Models
{
    static class PlikHelper
    {
        private const string nazwaPliku = "ustawieniaDiscord.txt";
        private const string nazwaPliku1 = "ustawieniaTelegram.txt";

        public static void ZapiszDiscord(this DiscordModel model)
        {
            string lancuch = model.GuildId.ToString();
            lancuch += " ";
            lancuch += model.TextChanneldId.ToString();
            lancuch += " ";
            lancuch += model.Token.ToString();

            File.WriteAllText(nazwaPliku, lancuch);

        }
        public static DiscordModel OdczytajDiscord()
        {

            try
            {
                string lancuch = File.ReadAllText(nazwaPliku);
                string[] rob = lancuch.Split(' ');
                ulong idGuild = ulong.Parse(rob[0]);
                ulong idChanel = ulong.Parse(rob[1]);
                string token = rob[2];



                return new DiscordModel() { GuildId = idGuild, TextChanneldId = idChanel, Token = token };
            }


            catch
            {
                return new DiscordModel();
            }
        }


        public static void ZapisTelegram(this TelegramModel model)
        {
            string lancuch = model.ChanneldId;
            lancuch += " ";
            lancuch += model.Token;


            File.WriteAllText(nazwaPliku1, lancuch);

        }
        public static TelegramModel OdczytajTelegram()
        {

            try
            {
                string lancuch = File.ReadAllText(nazwaPliku1);
                string[] rob = lancuch.Split(' ');
                string idChanel = rob[0];
                string token = rob[1];



                return new TelegramModel() { ChanneldId = idChanel, Token = token };
            }


            catch
            {
                return new TelegramModel();
            }
        }

    }
}