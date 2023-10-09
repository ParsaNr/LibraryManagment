using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface IViewStudentInfoRepository
    {
        DataTable SelecAll();
        DataTable SelectRow(int bid);
        DataTable Search(string txtSearchStudentNo);
        bool Update(Int64 bid, string name, string no, string semester, Int64 contact, string email);
        bool Delete(Int64 bid);
    }
}
