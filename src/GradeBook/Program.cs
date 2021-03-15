using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            var book = new DiskBook("Scot's Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;

            EnterGrades(book);

            var statistics = book.GetStatistics();

            Console.WriteLine($"Book name {book.Name}");
            Console.WriteLine($"Average grade is {statistics.Average:N2}");
            Console.WriteLine($"Highest grade is {statistics.High}");
            Console.WriteLine($"Lowest grade is {statistics.Low}");
            Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.Write("Enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade is added.");
        }

    }


}
