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
        /// it fetched today's todal bill count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalBill(int ibus_cd, int icomp_cd);

        /// <summary>
        /// it fetched dashboard summary accordingly date
        /// </summary>
        /// <returns>count as string</returns>
        MyResponse GetDashboardSummary(string from, string to, int icomp_cd, int ibus_cd);


        /// <summary>
        /// it returns company's details
        /// </summary>
        /// <returns>details as company_master</returns>
        MyResponse GetCompanyDetails(int? iuser_cd);


        /// <summary>
        /// it fetched today's todal guests count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalGuest(int ibus_cd, int icomp_cd);
        /// <summary>
        /// it fetched today's todal sales count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalSales(int ibus_cd, int icomp_cd);
        /// <summary>
        /// it fetched today's todal expenses count
        /// </summary>
        /// <returns>count as string</returns>
        string GetTodaysTotalExpenses(int ibus_cd, int icomp_cd);

        /// <summary>
        /// it fetched daily money collection 
        /// </summary>
        /// <returns>list of payment info</returns>
        List<object> GetDailyMoneyCollection(int ibus_cd, int icomp_cd);
    }
}
