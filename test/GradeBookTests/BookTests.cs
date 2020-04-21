using System;
using GradeBook;
using Xunit;

namespace GradeBookTests
{
    public class BookTests
    {
        [Fact]
        public void GetStatistics_Grades_ReturnAvarage()
        {

            //Given
            var book = new Book("");

            book.AddGrade(80.1);
            book.AddGrade(40.2);
            book.AddGrade(75.8);

            //When
            var statistics = book.GetStatistics();


            //Then
            Assert.Equal(65.4, statistics.Avarage, 1);
            Assert.Equal(80.1, statistics.High, 1);
            Assert.Equal(40.2, statistics.Low, 1);

        }
    }
}
