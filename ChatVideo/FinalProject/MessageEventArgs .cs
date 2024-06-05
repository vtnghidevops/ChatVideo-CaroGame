using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
