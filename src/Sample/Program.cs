using Sample.Model;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data:");
            Console.WriteLine(JsonUtil.SerializeObject(new UserInfo()));
            Console.ReadKey(true);
        }
    }
}
