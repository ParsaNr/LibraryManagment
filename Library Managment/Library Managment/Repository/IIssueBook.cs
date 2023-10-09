using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface IIssueBook
    {
        bool Insert(string sno, string sname, string sem, Int64 contact, string email, string bookname, string bookIssueDate);

    }
}
