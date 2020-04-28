using System;
using System.Collections.Generic;

namespace GradeBook
{

    public class Book
    {
        List<double> grades;

        public string Name
        {
            get;
            set;
        }


        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
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
                case 'E':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
            }
        }

        public void AddGrade(double grade)
        {

            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

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

            switch (result.Avarage)
            {
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d > 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public event GradeAddedDelegate GradeAdded;


    }
}