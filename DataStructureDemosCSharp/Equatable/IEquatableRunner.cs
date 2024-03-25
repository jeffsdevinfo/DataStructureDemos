using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemosCSharp.Equatable
{
    internal class IEquatableRunner : BaseRunner
    {
        public override void Run()
        {
            base.Run();

            Console.WriteLine("\nEqualsOverrideDemo.Equals(object obj) comparison");
            EqualsOverrideDemo eod = new EqualsOverrideDemo(15);
            EqualsOverrideDemo eod2 = new EqualsOverrideDemo(15);
            Console.WriteLine($"\tDoes object1 with value:{eod.Value} equal object2 with value:{eod2.Value} ? {eod.Equals(eod2)}");
            EqualsOverrideDemo eod3 = new EqualsOverrideDemo(92);
            Console.WriteLine($"\tDoes object1 with value:{eod.Value} equal object3 with value:{eod3.Value} ? {eod.Equals(eod3)}");


            Console.WriteLine("\n\nIEquatableInheritDemo.Equals(IEquatableInheritDemo obj) comparison");
            IEquatableInheritDemo eod4 = new IEquatableInheritDemo(15);
            IEquatableInheritDemo eod5 = new IEquatableInheritDemo(15);
            Console.WriteLine($"\tDoes object4 with value:{eod4.Value} equal object5 with value:{eod5.Value} ? {eod4.Equals(eod5)}");
            IEquatableInheritDemo eod6 = new IEquatableInheritDemo(92);
            Console.WriteLine($"\tDoes object4 with value:{eod4.Value} equal object6 with value:{eod6.Value} ? {eod4.Equals(eod6)}");


            Console.WriteLine("\n\nEqualsAndIEquatableDemo.Equals(EqualsAndIEquatableDemo obj) comparison");
            EqualsAndIEquatableDemo eod7 = new EqualsAndIEquatableDemo(15);
            EqualsAndIEquatableDemo eod8 = new EqualsAndIEquatableDemo(15);
            Console.WriteLine($"\tDoes object7 with value:{eod7.Value} equal object8 with value:{eod8.Value} ? {eod7.Equals(eod8)}");
            EqualsAndIEquatableDemo eod9 = new EqualsAndIEquatableDemo(92);
            Console.WriteLine($"\tDoes object7 with value:{eod7.Value} equal object9 with value:{eod9.Value} ? {eod7.Equals(eod9)}");

        }
    }

    internal class EqualsOverrideDemo
    {        
        protected int value;

        public int Value { get { return value; } }

        public EqualsOverrideDemo(int value)
        {
            this.value = value;
        }   

        public override bool Equals(object? obj)
        {
            Console.WriteLine("\n\tCalling EqualsOverrideDemo.Equals(object? obj)");

            if (obj == null || GetType() != obj.GetType()) 
                return false;
            EqualsOverrideDemo eod = (EqualsOverrideDemo)obj;
            return this.value == eod.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    internal class IEquatableInheritDemo : IEquatable<IEquatableInheritDemo>
    {
        private int value;
        public int Value { get { return value; } }

        public IEquatableInheritDemo(int value)
        {
            this.value = value;
        }

        public bool Equals(IEquatableInheritDemo other)
        {
            Console.WriteLine("\n\tCalling IEquatableInheritDemo.Equals(IEquatableInheritDemo other)");
            if (other == null) return false;

            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    internal class EqualsAndIEquatableDemo : EqualsOverrideDemo, IEquatable<EqualsAndIEquatableDemo>
    {
        public EqualsAndIEquatableDemo(int value) : base(value)
        {

        }

        public bool Equals(EqualsAndIEquatableDemo other)
        {
            Console.WriteLine("\n\tCalling EqualsAndIEquatableDemo.Equals(EqualsAndIEquatableDemo other)");
            if (other == null)
                return false;

            return base.Equals(other);
        }
    }
}
