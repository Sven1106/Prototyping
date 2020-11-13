using System;

namespace TestingFoxholeDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            Foxhole.ImageCache imageCache = new Foxhole.ImageCache();
            var bla = imageCache.TryGetScaledImage("https://cdn.pixabay.com/photo/2016/12/25/22/32/gladiator-1931077_960_720.jpg", 500);
            Console.WriteLine("Hello World!");
        }
    }
}
