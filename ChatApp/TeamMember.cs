using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canonical_Mediator.ChatApp
{
    public abstract class TeamMember
    {
        private ChatRoom chatroom;

        public TeamMember(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        internal void SetChatRoom(ChatRoom chatroom)
        {
            this.chatroom = chatroom;
        }

        public void Send(string message)
        {
            this.chatroom.Send(this.Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"From {from}: '{message}'");
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            this.chatroom.SendTo<T>(this.Name, message);
        }
    }
}
