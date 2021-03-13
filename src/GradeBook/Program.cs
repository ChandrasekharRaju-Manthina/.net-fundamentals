using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scot's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(12.7);
            book.AddGrade(10.3);
            book.AddGrade(56.1);
            var statistics = book.GetStatistics();

            Console.WriteLine($"Average grade is {statistics.Average:N2}");
            Console.WriteLine($"Highest grade is {statistics.High}");
            Console.WriteLine($"Lowest grade is {statistics.Low}");
        }
    }
}
