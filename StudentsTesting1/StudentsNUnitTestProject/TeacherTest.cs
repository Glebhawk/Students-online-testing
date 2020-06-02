using NUnit.Framework;
using StudentsTesting1.Logic.Users;

namespace StudentsNUnitTestProject
{
    class TeacherTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TeacherConstructorTest()
        {
            //Arrange
            string firstNameExpected = "Petro";
            string lastNameExpected = "Petrov";
            string teacherIdExpected = "ID";

            //Act
            Teacher teacher = new Teacher(firstNameExpected, lastNameExpected, teacherIdExpected);

            //Assert
            Assert.AreEqual(firstNameExpected, teacher.firstName);
            Assert.AreEqual(lastNameExpected, teacher.lastName);
            Assert.AreEqual(teacherIdExpected, teacher.teacherID);
        }
    }
}
