namespace DataStructureDemosCSharp.Queue
{
    internal class QueueGenericRunner : BaseRunner
    {
        public override void Run()
        {
            base.Run();
            Console.WriteLine("\n\nRunning QueueGenericRunner\n");

            QueueGeneric<int> queueGeneric = new QueueGeneric<int>();
            queueGeneric.Enqueue(1);
            queueGeneric.Enqueue(2);
            queueGeneric.Enqueue(3);
            queueGeneric.Enqueue(4);
            queueGeneric.Enqueue(5);
            queueGeneric.Enqueue(7);
            queueGeneric.Enqueue(6);

            while(!queueGeneric.IsEmpty())
            {
                Console.WriteLine(queueGeneric.Dequeue().ToString());
            }
        }
    }
}
