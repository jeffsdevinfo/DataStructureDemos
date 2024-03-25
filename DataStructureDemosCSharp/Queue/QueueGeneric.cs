namespace DataStructureDemosCSharp.Queue
{
    internal class QueueGeneric<T>
    {
        private QueueGenericNode<T>? Front;
        private QueueGenericNode<T>? Back;

        public QueueGeneric()
        {
            Front = Back = null;
        }

        public bool IsEmpty()
        {
            return Front == null;
        }

        public void Enqueue(T? data)
        {
            QueueGenericNode<T>? newNode = new QueueGenericNode<T>(data, null);            
            if(Back == null)
            {
                Front = Back = newNode;
            }
            else
            {
                Back.Next = newNode;
                Back = newNode;
            }
        }

        public T? Dequeue()
        {
            if(IsEmpty()) { return default; }

            T? dataToReturn = Front.Data;
            Front = Front.Next;
            if(Front == null)
            {
                Back = null;
            }
            return dataToReturn;
        }
    }

    internal class QueueGenericNode<T>
    {
        public T? Data;
        public QueueGenericNode<T>? Next;

        public QueueGenericNode(T? data, QueueGenericNode<T>? next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
