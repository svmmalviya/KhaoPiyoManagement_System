using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaoPiyoManagement_System.Models;

namespace KhaoPiyoManagement_System.ILibrary
{
   public interface ISalesRegister
    {
        MyResponse GetTransaction(string from, string to,string filterValue, int ibus_cd, int icomp_cd);
    }
  
}
