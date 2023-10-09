using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Library_Managment
{
    interface ILoginTableRepository
    {
        DataTable SelectAll(String username, string pass);
        bool Insert(string username, string pass);
    }
}
