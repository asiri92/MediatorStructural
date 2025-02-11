using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canonical_Mediator.ChatApp
{
    public class TeamChatRoom : ChatRoom
    {
        private List<TeamMember> members = new List<TeamMember>();
        public override void Register(TeamMember member)
        {
            member.SetChatRoom(this);
            this.members.Add(member);
        }

        public override void Send(string from, string message)
        {
            this.members.ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] members)
        {
            foreach (var member in members)
            {
                this.Register(member);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            this.members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
        }
    }
}
