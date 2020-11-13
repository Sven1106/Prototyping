using System;
using System.Threading.Tasks.Dataflow;

namespace TPLDataflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Project
    {
        public BufferBlock<int> NewNumbers { get; set; }
    }
}
