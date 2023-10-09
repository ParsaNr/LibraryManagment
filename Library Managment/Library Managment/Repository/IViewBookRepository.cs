using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    interface IViewBook
    {
        DataTable SelecAll();
        DataTable SelectRow(int bid);
        DataTable Search(string txtBookName);
        bool Update(Int64 bid, string bname, string bauthor, string publication, string pdate, Int64 price, Int64 quan);
        bool Delete(Int64 bid);
    }
}
