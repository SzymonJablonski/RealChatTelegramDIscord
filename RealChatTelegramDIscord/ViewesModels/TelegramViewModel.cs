using RealChatTelegramDIscord.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RealChatTelegramDIscord.ViewesModels
{
    class TelegramViewModel
    {
       

        private ConnectService service = MainWindow.service;
        public TelegramModel TelegramModel { get; set; } = PlikHelper.OdczytajTelegram();
        

        public TelegramViewModel()
        {
            
           
        }
        

        public void StartTelegram()
        {
            try
            {
                TelegramModel.Token = TokenTelegram;
                TelegramModel.ChanneldId = ChanneldIdTelegram;
                service.TelegramIni(TelegramModel);
            }
            catch
            {
                TelegramModel.Token = "";
                TelegramModel.ChanneldId = "";
            }

        }

        public void StopTelegram()
        {
            service.DisconnedTelegram();
        }

        public string TokenTelegram { get { return TelegramModel.Token; } set { this.TelegramModel.Token = value; RaisePropertyChanged(TelegramModel.Token); } }


        public string ChanneldIdTelegram { get { return TelegramModel.ChanneldId; } set { this.TelegramModel.ChanneldId = value; RaisePropertyChanged(TelegramModel.ChanneldId); } }



        private ICommand _logTelegram = null;

        public ICommand LogTelegram
        {
            get
            {
                if (_logTelegram == null) _logTelegram = new RelayCommand(
                (object o) =>
                {
                    StartTelegram();
                    
                },
                (object o) =>
                {
                    return service.isTelegram is false;
                });
                return _logTelegram;
            }
            set { }
        }

        private ICommand _logUTelegram = null;

        public ICommand LogUTelegram
        {
            get
            {
                if (_logUTelegram == null) _logUTelegram = new RelayCommand(
                (object o) =>
                {
                    StopTelegram();

                },
                (object o) =>
                {
                    return service.isTelegram is true;
                });
                return _logUTelegram;
            }
            set { }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        private void RaisePropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
