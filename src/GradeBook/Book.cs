using System;
using System.Collections.Generic;

namespace GradeBook
{

    public class Book
    {
        List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {

            var result = new Statistics();
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Avarage += grade;
            }

            result.Avarage /= grades.Count;

            return result;
        }


    }
}