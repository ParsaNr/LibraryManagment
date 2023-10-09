using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface INewBookRepository
    {
        bool Insert(string bName, string bAuthor, string bPubl, string bPDate, Int64 bPrice, Int64 bQuan);
    }
}
