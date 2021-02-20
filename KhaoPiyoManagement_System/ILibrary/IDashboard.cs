using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaoPiyoManagement_System.Models;

namespace KhaoPiyoManagement_System.ILibrary
{
   public interface IDashboard
    {

        /// <summary>
        /// it fetches running tables accordingly given parameters
        /// </summary>
        /// <param name="iBusiness_Cd">Business code</param>
        /// <param name="iCompany_Cd">Company code</param>
        /// <returns>RunningTables</returns>
        RunningTables GetRunningTables(int iCompany_Cd, int iBusiness_Cd);
        /// <summary>
        /// it return the running table accordingly given table code
        /// </summary>
        /// <param name="tablecd">Table code</param>
        /// <returns></returns>
        List<TableDetails> GetRunningTableDetail(int tablecd);

        /// <summary>
        /// it fetched today's todal bill count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalBill();

        /// <summary>
        /// it fetched today's todal guests count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalGuest();
        /// <summary>
        /// it fetched today's todal sales count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalSales();
        /// <summary>
        /// it fetched today's todal expenses count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalExpenses();
    }
}
