namespace DataStructureDemosCSharp.Stack
{
    internal class StackGeneric<T>
    {
        private StackGenericNode<T>? _top;

        public StackGeneric()
        {
            _top = null;
        }

        public void Push(T data)
        {
            StackGenericNode<T> newTop = new StackGenericNode<T>(data, _top);
            _top = newTop;
        }

        public T? Pop()
        {
            StackGenericNode<T>? returnVal = _top;
            _top = _top.Next;
            return returnVal != null ? returnVal.Data : default;
        }

        public T? Peek()
        {
            StackGenericNode<T>? returnVal = _top;            
            return returnVal != null ? returnVal.Data : default;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

    }

    internal class StackGenericNode<T>
    {
        public T? Data;
        public StackGenericNode<T>? Next;

        public StackGenericNode(T? data, StackGenericNode<T>? next = null)
        {
            Data = data;
            Next = next;
        }        
    }
}
