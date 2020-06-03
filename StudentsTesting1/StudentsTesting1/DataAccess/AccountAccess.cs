using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.Views;
using System.Data;

namespace StudentsTesting1.DataAccess
{
    public class AccountAccess
    {
        private IDBAccess dbaccess;
        private StudentAccess studentAccess;
        private TeacherAccess teacherAccess;

        public AccountAccess(IDBAccess iDBAccess)
        {
            dbaccess = iDBAccess;
            studentAccess = new StudentAccess(dbaccess);
            teacherAccess = new TeacherAccess(dbaccess);
        }
        public void RegisterStudent(string login, int password, Student student, string groupTitle, string role)
        {
            studentAccess.InsertStudentToDB(student, groupTitle);
            string command = "INSERT INTO ACCOUNTS(\"LOGIN\",\"PASSWORD_HASH\", \"ROLE\", \"USER_ID\") VALUES " +
                "(\"" + login + "\", " + password + ", \"" + role + "\", (SELECT MAX(ID) FROM STUDENTS));";
            dbaccess.SQLExecute(command);
        }

        public void RegisterTeacher(string login, int password, Teacher teacher, string role)
        {
            teacherAccess.InsertTeacherToDB(teacher);
            string command = "INSERT INTO ACCOUNTS(\"LOGIN\",\"PASSWORD_HASH\", \"ROLE\", \"USER_ID\") VALUES " +
                "(\"" + login + "\", " + password + ", \"" + role + "\", (SELECT MAX(ID) FROM TEACHERS));";
            dbaccess.SQLExecute(command);
        }
        public AccountView TryToLogin(string login, string passwordHash)
        {
            DataTable dataTable = dbaccess.SQLGetTableData
                ("SELECT * FROM ACCOUNTS WHERE LOGIN = \"" + login + "\" AND PASSWORD_HASH = \"" + passwordHash + "\";");
            if (dataTable.Rows.Count > 0)
            {
                string role = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
                switch (role)
                {
                    case ("admin"):
                        {
                            return new AccountView(Convert.ToInt32(dataTable.Rows[0].ItemArray[0]), login, role);
                        }
                    case ("teacher"):
                        {
                            return new AccountView(Convert.ToInt32(dataTable.Rows[0].ItemArray[0]), login, role);
                        }
                    case ("student"):
                        {
                            return new AccountView(Convert.ToInt32(dataTable.Rows[0].ItemArray[0]), login, role);
                        }
                    default: return null;
                }
            }
            return null;
        }
    }
}
