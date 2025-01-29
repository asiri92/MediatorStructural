using Canonical_Mediator.Structural;

namespace Canonical_Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreateMediator();
            //var c1 = new Colleague1(mediator);
            //var c2 = new Colleague2(mediator);

            var c1 = new Colleague1();
            var c2 = new Colleague2();

            //mediator.Colleague1 = c1;
            //mediator.Colleague2 = c2;

            mediator.Register(c1);
            mediator.Register(c2); ;

            c1.Send("Hello, World! (from c1)");
            c2.Send("hi, there! (from c2)");
        }
    }
}
