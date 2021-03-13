
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

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var sum = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                sum += number;
                highGrade = Math.Max(highGrade, number);
                lowGrade = Math.Min(lowGrade, number);
            }

            var statistics = new Statistics();
            statistics.Average = sum / grades.Count;
            statistics.High = highGrade;
            statistics.Low = lowGrade;

            return statistics;
        }
    }
}