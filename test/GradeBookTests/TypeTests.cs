using System;
using GradeBook;
using Xunit;

namespace GradeBookTests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {

        int count = 0;

        [Fact]
        public void WriteLogDelegate_Call_CanPointToMethod()
        {
            //Given            
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessageToLower;
            //When
            var result = log("Hello!");
            //Then

            Assert.Equal(2, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        string ReturnMessageToLower(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void MakeUpperCase_String_ReturnCopyValue()
        {
            var name = "ornelas";
            var upper = MakerUpperCase(name);

            Assert.Equal("ornelas", name);
            Assert.Equal("ORNELAS", upper);

        }

        private object MakerUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void SetInt_ValueTypePassAsRef_UpdateSameValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(2, x);
        }

        private void SetInt(ref int x)
        {
            x = 2;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void GetBookSetName_PassByReference_UpdateSameObject()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void GetBookSetName_FromReference_UpdateOtherObject()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.NotEqual("New Name", book1.Name);
        }


        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void SetName_FromReference_UpdateSameObject()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBook_TwoTimes_ReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void GetBook_VarAssignment_RefSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}