namespace DataStructureDemosCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseRunner runner;
            runner = new Heap.MinHeapIntRunner();
            runner.Run();

            runner = new Stack.StackGenericRunner();
            runner.Run();

            runner = new Queue.QueueGenericRunner();
            runner.Run();
        }
    }
}