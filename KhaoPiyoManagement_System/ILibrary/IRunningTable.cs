using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaoPiyoManagement_System.Models;

namespace KhaoPiyoManagement_System.ILibrary
{
   public interface IRunningTables
    {

        /// <summary>
        /// it fetches running tables accordingly given parameters
        /// </summary>
        /// <param name="iBusiness_Cd">Business code</param>
        /// <param name="iCompany_Cd">Company code</param>
        /// <returns>RunningTables</returns>
        Models.RunningTables GetRunningTables(int iCompany_Cd, int iBusiness_Cd);
        /// <summary>
        /// it return the running table accordingly given table code
        /// </summary>
        /// <param name="tablecd">Table code</param>
        /// <returns></returns>
        List<TableDetails> GetRunningTableDetail(int tablecd);
       
    }
}
