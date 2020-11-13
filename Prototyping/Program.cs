using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.Collections;
using System.Threading.Tasks;


namespace Prototyping
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeStruct time = new TimeStruct();
            time.Seconds = 10;
            UpdateTime(time);

            TimeClass timeClass = new TimeClass();
            timeClass.Seconds = 10;
            UpdateTime(timeClass);
        }

        public static void UpdateTime(TimeStruct time)
        {
            time.Seconds++;
        }
        public static void UpdateTime(TimeClass time)
        {
            time.Seconds++;
        }
    }

    struct TimeStruct
    {
        private int seconds;
        public int Seconds { get { return seconds; } set { seconds = value; } }

        public int CalulateMinutes() {
            return seconds / 60;
        }
    }

    class TimeClass
    {
        private int seconds;
        public int Seconds { get { return seconds; } set { seconds = value; } }

        public int CalulateMinutes()
        {
            return seconds / 60;
        }
    }
}
