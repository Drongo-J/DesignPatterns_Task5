using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Task5.Models
{
    public interface IMessage
    {
        string GetMessages();
    }


    class Message : IMessage
    {
        public string GetMessages()
        {
            return "Default";
        }
    }

    public class MessageDecorator : IMessage
    {
        private IMessage _message;

        public MessageDecorator(IMessage message)
        {
            _message = message;
        }

        public virtual string GetMessages()
        {
            return _message.GetMessages();
        }
    }

    public class InstagramNotifier : MessageDecorator
    {
        public InstagramNotifier(IMessage message) : base(message)
        {

        }

        public override string GetMessages()
        {
            string messages = base.GetMessages();
            messages += " instagram";
            return messages;
        }
    }
    public class FacebookNotifier : MessageDecorator
    {
        public FacebookNotifier(IMessage message) : base(message)
        {

        }

        public override string GetMessages()
        {
            string messages = base.GetMessages();
            messages += " facebook";
            return messages;
        }
    }
    public class TwitterNotifier : MessageDecorator
    {
        public TwitterNotifier(IMessage message) : base(message)
        {

        }

        public override string GetMessages()
        {
            string messages = base.GetMessages();
            messages += " twitter";
            return messages;
        }
    }
    public class TelegramNotifier : MessageDecorator
    {
        public TelegramNotifier(IMessage message) : base(message)
        {

        }

        public override string GetMessages()
        {
            string messages = base.GetMessages();
            messages += " telegram";
            return messages;
        }
    }
}
