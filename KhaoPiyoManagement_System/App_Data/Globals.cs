



using KhaoPiyoManagement_System;
using KhaoPiyoManagement_System.Models;
using System.Collections.Generic;
//using Company_Master = KhaoPiyoManagement_System.Models.Company_Master;

public sealed class  GlobalProperties {


   // public  KPEntity entities { get; set; }
    public List<breadcumb> breadcumbs { get; set; }
    public string dateformate { get; set ;  }
    public string AuditReportdateformate { get; set ;  }

    private static GlobalProperties prGlobal = null;
    public  Company_Master companyDetails = null;
    public string companyLogo = null;
    public  string conStringName = string.Empty;

    private GlobalProperties() {
        dateformate = "MM-dd-yyyy";
        AuditReportdateformate = "MM-dd-yyyy HH:mm:ss";
    }

    public static GlobalProperties Instance
    {
        get
        {
            if (prGlobal == null)
            {
                prGlobal = new GlobalProperties();
            }
            return prGlobal;
        }
    }
}
