using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("HelloBook");
            book.AddGrade(200.1);
            book.AddGrade(50.8);
            book.AddGrade(10.2);
            book.AddGrade(70);

            var statistics = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The avarage grade is {statistics.Avarage:N1}");
            Console.WriteLine($"The grade letter is {statistics.Letter}");

        }
    }
}
