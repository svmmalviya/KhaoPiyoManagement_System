using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaoPiyoManagement_System.Models;

namespace KhaoPiyoManagement_System.ILibrary
{
   public interface IItemSummary
    {

        MyResponse GetTransactionItemWise(string from, string to);
        MyResponse GetTransactionMealWise(string from, string to);
        MyResponse GetTransactionCatWise(string from, string to);
        MyResponse GetTransactionAuditReport(string from, string to);

    }
}
