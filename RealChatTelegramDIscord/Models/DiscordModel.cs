using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChatTelegramDIscord.Models
{
    public class DiscordModel
    {

        private ulong _guildId;
        private ulong _textChanneldId;
        private string _token;
        public ulong GuildId { get { return _guildId; } set { _guildId = value; } }
        public ulong TextChanneldId { get { return _textChanneldId; } set { _textChanneldId = value; } }
        public string Token { get { return _token; } set { _token = value; } }

    }
}
