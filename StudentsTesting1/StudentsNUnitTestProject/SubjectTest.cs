using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StudentsTesting1.Logic.Subjects;

namespace StudentsNUnitTestProject
{
    class SubjectTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SubjectConstructorTest()
        {
            //Arrange
            string subjectTitleExpected = "Subject";

            //Act
            Subject subject = new Subject(subjectTitleExpected);

            //Assert
            Assert.AreEqual(subjectTitleExpected, subject.subjectTitle);
        }

        [Test]
        public void SubjectAnotherConstructorTest()
        {
            //Arrange
            string subjectTitleExpected = "Subject";
            int subjectIdExpected = 1;

            //Act
            Subject subject = new Subject(subjectIdExpected ,subjectTitleExpected);

            //Assert
            Assert.AreEqual(subjectTitleExpected, subject.subjectTitle);
            Assert.AreEqual(subjectIdExpected, subject.id);
        }
    }
}
