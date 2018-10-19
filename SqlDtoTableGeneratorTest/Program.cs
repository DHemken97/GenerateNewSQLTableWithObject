using System;

namespace SqlDtoTableGeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(SQLQueryCreator.GenerateNewTableQueryString(new TestDto()));
            Console.ReadLine();
        }
    }
}
