using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Implements
{
    public class ChatMediator : IMediator
    {
        private List<Colleague> _user= [];
        public ChatMediator() 
        {}

        public void Register(Colleague colleague)
        {
            if (!_user.Contains(colleague))
            {
                _user.Add(colleague);
            }
        }
        public void Send(string message, Colleague sender)
        {
            foreach (var user in _user)
            {
                if (user != sender)
                {
                    user.Receive(message);
                }
            }
        }
    }
}
