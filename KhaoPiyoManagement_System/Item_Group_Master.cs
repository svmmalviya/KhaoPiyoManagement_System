//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item_Group_Master
    {
        public int AutoCode { get; set; }
        public string sRefId { get; set; }
        public Nullable<int> iItemGrp_Cd { get; set; }
        public string sItemGrp_Nm { get; set; }
        public Nullable<int> iItem_Cd { get; set; }
        public int iItemOpt_Cd { get; set; }
        public string sTitle { get; set; }
        public Nullable<double> Rate1 { get; set; }
        public int iComp_Cd { get; set; }
        public int iBus_Cd { get; set; }
        public Nullable<int> iUser_Cd { get; set; }
        public Nullable<System.DateTime> dUpdate_Dt { get; set; }
        public Nullable<byte> bActive { get; set; }
        public Nullable<byte> iMin_Value { get; set; }
        public Nullable<byte> iMax_Value { get; set; }
    }
}
