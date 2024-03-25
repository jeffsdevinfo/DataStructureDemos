namespace DataStructureDemosCSharp.Stack
{
    internal class StackGenericRunner : BaseRunner
    {
        public override void Run()
        {
            base.Run();
            Console.WriteLine("\n\nRunning StackGenericRunner\n");
            StackGeneric<int> stackGeneric = new StackGeneric<int>();
            stackGeneric.Push(50);
            stackGeneric.Push(2);
            stackGeneric.Push(80);
            stackGeneric.Push(100);
            stackGeneric.Push(150);
            stackGeneric.Push(20);

            while(!stackGeneric.IsEmpty())
            {
                Console.WriteLine(stackGeneric.Pop().ToString());
            }
        }
    }
}
