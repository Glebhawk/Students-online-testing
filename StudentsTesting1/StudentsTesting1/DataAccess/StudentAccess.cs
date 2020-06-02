using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Users;
using System.Data;

namespace StudentsTesting1.DataAccess
{
    public class StudentAccess
    {
        private IDBAccess dbaccess;

        public StudentAccess(IDBAccess iDBAccess)
        {
            dbaccess = iDBAccess;
        }
        public void InsertStudentToDB(Student student, string groupTitle)
        {
            string command = "INSERT INTO STUDENTS(\"FIRST_NAME\",\"LAST_NAME\",\"STUDENTID\",\"RECORDBOOK\",\"GROUP_ID\") VALUES " +
                "(\"" + student.firstName + "\", \"" + student.lastName + "\", \"" + student.studentID + "\", \"" + student.recordBook + "\", " +
                "(SELECT ID AS GROUP_ID FROM GROUPS WHERE TITLE = \"" + groupTitle + "\"));";
            dbaccess.SQLExecute(command);
        }

        public List<Student> GetStudentsFromGroup(string groupTitle)
        {
            DataTable dataTable = dbaccess.SQLGetTableData("SELECT * FROM STUDENTS JOIN GROUPS ON STUDENTS.GROUP_ID = GROUPS.ID WHERE GROUPS.TITLE = \"" + groupTitle + "\";");
            List<Student> students = new List<Student>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    students.Add(new Student(Convert.ToString(dataTable.Rows[i].ItemArray[1]),
                    Convert.ToString(dataTable.Rows[i].ItemArray[2]), Convert.ToString(dataTable.Rows[i].ItemArray[3]), 
                    Convert.ToString(dataTable.Rows[i].ItemArray[4])));
                }
            }
            return students;
        }

        public Student GetStudentByID(int id)
        {
            DataTable dataTable = dbaccess.SQLGetTableData("SELECT * FROM STUDENTS WHERE ID = " + id + ";");
            if (dataTable.Rows.Count > 0)
            {
                Student student = new Student(Convert.ToString(dataTable.Rows[0].ItemArray[1]),
                        Convert.ToString(dataTable.Rows[0].ItemArray[2]), Convert.ToString(dataTable.Rows[0].ItemArray[3]), 
                        Convert.ToString(dataTable.Rows[0].ItemArray[4]));
                return student;
            }
            return null;
        }
    }
}
