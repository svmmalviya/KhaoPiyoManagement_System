



using KhaoPiyoManagement_System;
using KhaoPiyoManagement_System.Models;
using System.Collections.Generic;

public sealed class  GlobalProperties {


    public  KhaoPiyoEntities entities { get; set; }
    public List<breadcumb> breadcumbs { get; set; }
    public string dateformate { get; set ;  }
    public string AuditReportdateformate { get; set ;  }

    private static GlobalProperties prGlobal = null;
    public  Company_Master companyDetails = null;
    public string companyLogo = null;

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
