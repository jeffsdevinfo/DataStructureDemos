using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemosCSharp.Heap
{
    internal class MinHeapInt
    {
        private int[] _heap;
        private int _size;
        private int _capacity;

        public MinHeapInt(int capacity)
        {
            _heap = new int[capacity];
            _capacity = capacity;
            _size = 0;
        }

        private bool HasParent(int child) { return GetParent(child) >= 0; }
        private bool HasLeft(int parent) { return GetLeft(parent) < _size; }
        private bool HasRight(int parent) { return GetRight(parent) < _size; }

        private int GetParent(int child) { return (child - 1) / 2; }
        private int GetLeft(int parent) { return (parent * 2) + 1; }

        private int GetRight(int parent) { return (parent * 2) + 2; }

        private void EnsureSize()
        {
            if(_size ==_capacity)
            {
                _capacity *= 2;
                int[] temp = new int[_capacity];
                _heap.CopyTo(temp, 0);
                _heap = temp;
            }
        }

        public bool IsEmpty()
        {
            return _size <= 0;
        }

        private void Swap(int i, int j)
        {
            int temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        public void Add(int value)
        {
            EnsureSize();
            _heap[_size++] = value;
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            int index = _size - 1;
            while(HasParent(index) && _heap[GetParent(index)] > _heap[index])
            {
                int parent = GetParent(index);
                Swap(index, parent);
                index = parent;
            }
        }

        public int Poll()
        { 
            if(_size <= 0)
            {
                return -1;
            }

            int returnVal = _heap[0];
            _size--;
            if(_size >= 1)
            {
                //swap the last to the first
                Swap(0, _size);
                //HeapifyDown
                HeapifyDown();
            }

            return returnVal;
        }

        private void HeapifyDown()
        {
            int index = 0;
            while(HasLeft(index))
            {
                int relativeIndex = GetLeft(index);
                if(HasRight(index) && _heap[GetRight(index)] < _heap[relativeIndex])
                {
                    relativeIndex = GetRight(index);
                }
                if (_heap[index] > _heap[relativeIndex])
                {
                    Swap(index, relativeIndex);
                }
                index = relativeIndex;
            }
        }
    }
}
