using RealChatTelegramDIscord.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RealChatTelegramDIscord;

namespace RealChatTelegramDIscord.ViewesModels
{
    
    class DiscordViewModel
    { 

        private ConnectService service = MainWindow.service;
       


    public DiscordModel DiscordModel { get; set; } = PlikHelper.OdczytajDiscord();
    
    
    public void Odczyt()
    {
        _idchanel = DiscordModel.GuildId.ToString();
        _textChanneldId = DiscordModel.TextChanneldId.ToString();
    }

    public DiscordViewModel()
    {
        Odczyt();

    }
    public void StartDiscord()
    {
        try
        {
            DiscordModel.GuildId = StrToUlong(_idchanel);
            DiscordModel.TextChanneldId = StrToUlong(_textChanneldId);
            DiscordModel.Token = Token;
                _ = service.DiscordIni(DiscordModel);

        }
        catch

        {
            DiscordModel.GuildId = 0;
            DiscordModel.TextChanneldId = 0;
            DiscordModel.Token = "błędne dane";
        }

    }



    public string Token { get { return DiscordModel.Token; } set { this.DiscordModel.Token = value; RaisePropertyChanged(DiscordModel.Token); } }


    private string _idchanel;
    public string Idchanel
    {
        get { return _idchanel; }
        set { this._idchanel = value; RaisePropertyChanged(_idchanel); }
    }
    private string _textChanneldId;
    public string TextChanneldId { get { return _textChanneldId; } set { this._textChanneldId = value; RaisePropertyChanged(_textChanneldId); } }


    public ulong StrToUlong(string s)
    {
        try
        {
            return ulong.Parse(s);
        }
        catch
        {
            return 0;
        }
    }


    private ICommand _logDiscord = null;

    public ICommand LogDiscord
    {
        get
        {
            if (_logDiscord == null) _logDiscord = new RelayCommand(
            (object o) =>
            {
                StartDiscord();
              
            },
            (object o) =>
            {
                return service.isDiscord is false;
            });
            return _logDiscord;
        }
        set { }
    }

    private ICommand _logUDiscord = null;
    public ICommand LogUDiscord
    {
        get
        {
            if (_logUDiscord == null) _logUDiscord = new RelayCommand(
            (object o) =>
            {
                service.DisconnedDiscord();
          
            },
            (object o) =>
            {
                return service.isDiscord is true;
            });
            return _logUDiscord;
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