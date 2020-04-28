using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("HelloBook");
            book.GradeAdded += OnGradeAdd;

            Console.WriteLine("Enter the grade or 'q' to quit");
            var input = Console.ReadLine();
            while (input != "q")
            {
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                input = Console.ReadLine();
            }

            var statistics = book.GetStatistics();

            Console.WriteLine($"The gradebook name is {book.Name}");
            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The avarage grade is {statistics.Avarage:N1}");
            Console.WriteLine($"The grade letter is {statistics.Letter}");

        }

        static void OnGradeAdd(object sender, EventArgs args)
        {
            Console.WriteLine("Grade added");
        }
    }
}
