using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChatTelegramDIscord.Models
{
    public class TelegramModel
    {
        private string _channeldId = "1817054335";
        private string _token = "1884288110:AAG1j21WfXfmLfT25hJliSMSeHutp6WzJwo";
        public string Token { get { return _token; } set { _token = value; } }
        public string ChanneldId { get { return _channeldId; } set { _channeldId = value; } }
    }
}
