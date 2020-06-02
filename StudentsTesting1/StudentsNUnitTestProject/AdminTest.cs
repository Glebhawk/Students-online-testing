using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Subjects;
using NUnit.Framework;
using StudentsTesting1.IoC;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.DataAccess;
using Moq;

namespace StudentsNUnitTestProject
{
    class AdminTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdminCreateTeacherTest()
        {
            //Arrange
            bool isTeacherCreated = false;

            Admin admin = new Admin("Admin", "Adminov", "adminId");
            TeacherAccess teacherAccess = new TeacherAccess(new DBAccess());
            admin.teacherAccess = teacherAccess;
            var DBAccessMock = new Mock<IDBAccess>();
            DBAccessMock.Setup(r => r.GetInstance()). Returns(new DBAccess());

            //Act
            admin.CreateTeacher("Petro", "Petrov", "ID");

            //Assert
            Assert.IsTrue(isTeacherCreated);
        }
    }
}
