using Canonical_Mediator.ChatApp;
using Canonical_Mediator.Structural;

namespace Canonical_Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teamChat = new TeamChatRoom();

            var steve = new Developer("Steve");
            var justin = new Developer("Justin");
            var jenna = new Developer("Jenna");
            var brian = new Tester("Brian");
            var amanda = new Tester("Amanda");
            teamChat.RegisterMembers(steve, justin, jenna, brian, amanda);

            steve.Send("Hey, everyone! I just pushed a new feature.");
            brian.Send("Roger that, Steve. I'll test it now.");

            Console.WriteLine();
            steve.SendTo <Developer>("Make sure to execute your unit tests before checking in!");

        }

        private static void StructuralExample()
        {
            var mediator = new ConcreateMediator();

            //basic implementation with constructor injection
            //var c1 = new Colleague1(mediator);
            //var c2 = new Colleague2(mediator);

            //var c1 = new Colleague1();
            //var c2 = new Colleague2();

            //mediator.Colleague1 = c1;
            //mediator.Colleague2 = c2;

            //Use of a method instead of the constructor to setup the bidirectional references
            //mediator.Register(c1);
            //mediator.Register(c2); ;

            //Delegate both the registering and creation of the colleagues to the mediator
            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();

            c1.Send("Hello, World! (from c1)");
            c2.Send("hi, there! (from c2)");
        }
    }
}
