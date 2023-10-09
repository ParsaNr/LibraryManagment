using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface INewStudentRepository
    {
        bool Insert(string sname, string sno, string sem, Int64 contact, string email);
    }
}
