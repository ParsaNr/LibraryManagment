using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface IReturnBookRepository
    {
        DataTable SelectRow(string txtStudentNo);
        bool Update(string book_return_date, string std_no, Int64 id);
    }
}
