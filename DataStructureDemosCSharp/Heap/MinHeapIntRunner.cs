﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemosCSharp.Heap
{
    internal class MinHeapIntRunner : BaseRunner
    {
        public override void Run()
        {
            base.Run();
            MinHeapInt minHeapInt = new MinHeapInt(20);
            minHeapInt.Add(20);
            minHeapInt.Add(5);
            minHeapInt.Add(4);
            minHeapInt.Add(15);
            minHeapInt.Add(10);
            minHeapInt.Add(3);

            while (!minHeapInt.IsEmpty())
            {
                Console.WriteLine($"{minHeapInt.Poll()} ");
            }
        }
    }    
}