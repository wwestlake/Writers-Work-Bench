using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagDaemon.WWB.AbstractPatterns;
using LagDaemon.WWB.AbstractPatternsTests;
using LagDaemon.WWB.Model;

namespace TestConsole
{
    class BaseClass : IVisitable
    {
        public static int id = 0;

        public BaseClass()
        {
            id++;
        }

        public void Accept(IVisitor<IVisitable> visitor)
        {
            visitor.Visit(this);
        }
    }

    class ClassA : BaseClass
    {
        public void ClassA_Special()
        {
            Console.WriteLine("Class A Special!!! {0}", id);
        }
    }


    class ClassB : BaseClass
    {

        public void ClassB_Special()
        {
            Console.WriteLine("Class B Special!!!! {0}", id);
        }
    }

    class ActionA : VisitorAction
    {
        long count = 0;

        public void Visit(ClassA a)
        {
            Console.WriteLine("Class A Visited {0}", count++);
            a.ClassA_Special();
        }
    }

    class ActionB : VisitorAction
    {
        long count = 0;

        public void Visit(ClassB b)
        {
            Console.WriteLine("Class B Visited {0}", count++);
            b.ClassB_Special();
        }
    }




    class Program
    {

        static void Main(string[] args)
        {
            CharacterBuilder builder = new CharacterBuilder();
            List<Character> list = new List<Character>
            {
                builder.New()
                    .Name("Main Hero")
                    .FirstName("Bill")
                    .LastName("Walsh")
                    .Age(29)
                    .Build(),

                builder.New()
                    .Name("Enemy")
                    .FirstName("Jack")
                    .LastName("Kemper")
                    .Age(56)
                    .Build(),

                builder.New()
                    .Name("Librarian")
                    .FirstName("Janet")
                    .LastName("Riggs")
                    .Age(37)
                    .Build()
            };

            foreach (Character c in list)
            {
               
                Console.WriteLine(c);
            }


            Console.ReadKey();
        }

        static void ProducerTests(string[] args)
        {
            Producer producer = new Producer();
            producer.RegisterType<ProducerInterface_A, ProducerClass_A>();
            producer.RegisterType<ProducerInterface_B, ProducerClass_B>();
            producer.RegisterType<ProducerInterface_C, ProducerClass_C>();

            ProducerInterface_C testClass = producer.Instance<ProducerInterface_C>();


            Console.ReadKey();
        }

        static void CoRTEst(string[] args)
        {
            List<BaseClass> list = new List<BaseClass>();
            list.Add(new ClassA());
            list.Add(new ClassB());
            list.Add(new ClassA());
            list.Add(new ClassB());
            list.Add(new ClassA());
            list.Add(new ClassB());

            Visitor<BaseClass> visitor = new Visitor<BaseClass>();
            visitor.AddAction<ActionA>(typeof(ClassA), new ActionA())
                   .AddAction<ActionB>(typeof(ClassB), new ActionB())
                   ;

            foreach (BaseClass b in RandomClasses) visitor.Visit(b);


            Console.ReadKey();
        }

        static Random rand = new Random();

        static IEnumerable<BaseClass> RandomClasses
        {
            get
            {
                while(true)
                {
                    double r = rand.NextDouble();
                    if (r < 0.5) yield return new ClassA();
                    else yield return new ClassB();
                }
            }
        }

    }
}
