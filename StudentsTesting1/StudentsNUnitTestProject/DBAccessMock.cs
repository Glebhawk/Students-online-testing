using System;
using System.Collections.Generic;
using System.Text;
using StudentsTesting1.DataAccess;

namespace StudentsNUnitTestProject
{
    class DBAccessMock : IDBAccess
    {
        private static DBAccessMock Instance { get; set; }

        public IDBAccess GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DBAccessMock();
            }
            return Instance;
        }
    }
}
