using System;
using NUnit.Framework;
using StudentsTesting1.Logic.Users;

namespace StudentsNUnitTestProject
{
    class StudentTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StudentConstructorTest()
        {
            //Arrange
            string firstNameExpected = "Ivan";
            string lastNameExpected = "Ivanov";
            string studentIdExpected = "Studak";
            string recordBookExpected = "Zachotka";

            //Act
            Student student = new Student(firstNameExpected, lastNameExpected, studentIdExpected, recordBookExpected);

            //Assert
            Assert.AreEqual(firstNameExpected, student.firstName);
            Assert.AreEqual(lastNameExpected, student.lastName);
            Assert.AreEqual(studentIdExpected, student.studentID);
            Assert.AreEqual(recordBookExpected, student.recordBook);
        }
    }
}
