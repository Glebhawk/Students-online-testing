using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.IoC;

namespace StudentsTesting1.Logic.Users
{
    class Admin : User
    {
        public string adminID { get; private set; }
        private IoCContainer IoC { get; set; } = new IoCContainer();

        public Admin(string FirstName, string LastName, string ID) : base(FirstName, LastName)
        {
            adminID = ID;
            IoC.RegisterObject<IGroup, Group>();
            IoC.RegisterObject<ISubject, Subject>();
        }

        public Teacher CreateTeacher(string firstName, string lastName, string ID)
        {
            return new Teacher(firstName, lastName, ID);
        }

        public Subject CreateSubject(string title)
        {
            List<object> param = new List<object> { title };
            return IoC.ResolveObject(typeof(Subject), param) as Subject;
        }

        public Group CreateGroup(string title)
        {

            List<object> param = new List<object> { title };
            return IoC.ResolveObject(typeof(Group), param) as Group;
        }

        public Student CreateStudent(string firstName, string lastName, Group group, string studentID)
        {
            Student student = new Student(firstName, lastName, studentID);
            group.AddStudent(student);
            return student;
        }

        public void AssignTeacherToSubject(Teacher teacher, Subject subject)
        {
            teacher.AddSubject(subject);
        }

        public void AssignSubjectToGroup(Subject subject, Group group)
        {
            subject.AddGroup(group);
        }
    }
}
