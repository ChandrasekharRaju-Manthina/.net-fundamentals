
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            this.Name = name;
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
                throw new ArgumentException($"Invalid grade {grade}");
            }
        }

        public Statistics GetStatistics()
        {
            var sum = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            // foreach (var number in grades)
            for (int index = 0; index < grades.Count; index++)
            {
                sum += grades[index];
                highGrade = Math.Max(highGrade, grades[index]);
                lowGrade = Math.Min(lowGrade, grades[index]);
            }
            var statistics = new Statistics();
            statistics.Average = sum / grades.Count;
            statistics.High = highGrade;
            statistics.Low = lowGrade;

            switch (statistics.Average)
            {
                case var d when d >= 90.0:
                    statistics.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    statistics.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    statistics.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    statistics.Letter = 'D';
                    break;
                default:
                    statistics.Letter = 'F';
                    break;
            }

            return statistics;
        }
    }
}