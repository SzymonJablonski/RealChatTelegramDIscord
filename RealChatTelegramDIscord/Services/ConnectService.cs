using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChatTelegramDIscord.ViewesModels
{
    using Models;
    using System.ComponentModel;


    public class ConnectService
    {
        private DiscordService _discord = null;
        private TelegramViwe _telegram = null;
        public bool isDiscord = false;
        public bool isTelegram = false;

        

        public DiscordService Discord
        {
            get { return this._discord; }
            set { _discord = value; }
        }

        public TelegramViwe Telegram
        {
            get { return this._telegram; }
            set { _telegram = value; }
        }
        public void DisconnedDiscord()
        {
            _ = _discord.DisConnectAsync();
            _discord = null;
            isDiscord = false;

    }

        public void DisconnedTelegram()
        {
            
            _telegram.TelegramDisconect();
            _telegram= null;
            isTelegram = false;
        }



        public void TelegramIni(TelegramModel model)
        {
            try
            {
                _telegram = new TelegramViwe();
                _telegram.TelegramInitialize(model);
                isTelegram = true;
                PlikHelper.ZapisTelegram(model);


            }
            catch
            {
                _telegram = null;
                
            }
       


        }

        public void SendMessageTelegram(string message)
        {
            if (_telegram.initializationFinished && isTelegram && isDiscord)
            {
                _telegram.SendMessage(message);
            }

        }

        public void SendMessageDiscord(string message)
        {
            if (_discord.initFinished && isTelegram && isDiscord)
            {
                _discord.SendMessage(message);
            }

        }


        public async Task DiscordIni(DiscordModel model)
        {
            try
            {
                _discord = new DiscordService();
                await _discord.DiscordInitialize(model);
                PlikHelper.ZapiszDiscord(model);
                isDiscord = true;
            }
            catch
            {
                _discord = null;
            }


        }

    }
}
