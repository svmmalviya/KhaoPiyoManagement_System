namespace KhaoPiyoManagement_System
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KPEntity : DbContext
    {
        public KPEntity()
            : base("name="+GlobalProperties.Instance.conStringName)
        {
        }

        public virtual DbSet<Acc_Group_Master> Acc_Group_Master { get; set; }
        public virtual DbSet<Account_Master> Account_Master { get; set; }
        public virtual DbSet<Advance_Tran> Advance_Tran { get; set; }
        public virtual DbSet<App_BillMaster> App_BillMaster { get; set; }
        public virtual DbSet<AspNet_SqlCacheTablesForChangeNotification> AspNet_SqlCacheTablesForChangeNotification { get; set; }
        public virtual DbSet<Attendent_Master> Attendent_Master { get; set; }
        public virtual DbSet<Bank_Master> Bank_Master { get; set; }
        public virtual DbSet<Billing_Detail> Billing_Detail { get; set; }
        public virtual DbSet<Billing_Detail_Vend> Billing_Detail_Vend { get; set; }
        public virtual DbSet<Billing_Master> Billing_Master { get; set; }
        public virtual DbSet<Billing_Master_Vend> Billing_Master_Vend { get; set; }
        public virtual DbSet<Billing_Online> Billing_Online { get; set; }
        public virtual DbSet<Billing_Payment> Billing_Payment { get; set; }
        public virtual DbSet<Billing_Tax> Billing_Tax { get; set; }
        public virtual DbSet<Billing_Tax_Vend> Billing_Tax_Vend { get; set; }
        public virtual DbSet<BillPrint_Record> BillPrint_Record { get; set; }
        public virtual DbSet<Business_Master> Business_Master { get; set; }
        public virtual DbSet<Category_Master> Category_Master { get; set; }
        public virtual DbSet<Company_Master> Company_Master { get; set; }
        public virtual DbSet<Configration_Master> Configration_Master { get; set; }
        public virtual DbSet<Consume_Tran> Consume_Tran { get; set; }
        public virtual DbSet<CustBillItem> CustBillItems { get; set; }
        public virtual DbSet<CustBillMaster> CustBillMasters { get; set; }
        public virtual DbSet<Daily_Cash> Daily_Cash { get; set; }
        public virtual DbSet<Daily_Mail> Daily_Mail { get; set; }
        public virtual DbSet<DataCopy> DataCopies { get; set; }
        public virtual DbSet<Discount_Master> Discount_Master { get; set; }
        public virtual DbSet<Est_Billing> Est_Billing { get; set; }
        public virtual DbSet<Expenses_Master> Expenses_Master { get; set; }
        public virtual DbSet<Expenses_Tran> Expenses_Tran { get; set; }
        public virtual DbSet<Feedback_Master> Feedback_Master { get; set; }
        public virtual DbSet<Feedback_Tran> Feedback_Tran { get; set; }
        public virtual DbSet<Fin_Yr_Master> Fin_Yr_Master { get; set; }
        public virtual DbSet<FoodOrder_Customer_Master> FoodOrder_Customer_Master { get; set; }
        public virtual DbSet<FoodOrder_Item_Master> FoodOrder_Item_Master { get; set; }
        public virtual DbSet<FoodOrder_Order_Master> FoodOrder_Order_Master { get; set; }
        public virtual DbSet<FoodOrder_Order_Status> FoodOrder_Order_Status { get; set; }
        public virtual DbSet<FoodOrder_Reference_Master> FoodOrder_Reference_Master { get; set; }
        public virtual DbSet<FoodOrder_Rider_Status> FoodOrder_Rider_Status { get; set; }
        public virtual DbSet<Form_Master> Form_Master { get; set; }
        public virtual DbSet<Gravy_Master> Gravy_Master { get; set; }
        public virtual DbSet<Guest_Master> Guest_Master { get; set; }
        public virtual DbSet<Income_Master> Income_Master { get; set; }
        public virtual DbSet<Income_Tran> Income_Tran { get; set; }
        public virtual DbSet<Inv_Category_Master> Inv_Category_Master { get; set; }
        public virtual DbSet<Inv_Consume_Master> Inv_Consume_Master { get; set; }
        public virtual DbSet<Inv_Item_Master> Inv_Item_Master { get; set; }
        public virtual DbSet<Inv_Unit_Master> Inv_Unit_Master { get; set; }
        public virtual DbSet<Item_Description_Master> Item_Description_Master { get; set; }
        public virtual DbSet<Item_Group_Master> Item_Group_Master { get; set; }
        public virtual DbSet<Item_Master> Item_Master { get; set; }
        public virtual DbSet<Item_Master_Time> Item_Master_Time { get; set; }
        public virtual DbSet<KOT_Delete> KOT_Delete { get; set; }
        public virtual DbSet<KOT_Master> KOT_Master { get; set; }
        public virtual DbSet<Location_Master> Location_Master { get; set; }
        public virtual DbSet<Loyalty_Master> Loyalty_Master { get; set; }
        public virtual DbSet<Loyalty_Program_Master> Loyalty_Program_Master { get; set; }
        public virtual DbSet<Loyalty_Tran> Loyalty_Tran { get; set; }
        public virtual DbSet<MainForm_Master> MainForm_Master { get; set; }
        public virtual DbSet<Map_Sale_Tax> Map_Sale_Tax { get; set; }
        public virtual DbSet<Meal_Master> Meal_Master { get; set; }
        public virtual DbSet<Month_Master> Month_Master { get; set; }
        public virtual DbSet<Online_Item_Master> Online_Item_Master { get; set; }
        public virtual DbSet<Online_Master> Online_Master { get; set; }
        public virtual DbSet<Online_Meal_Master> Online_Meal_Master { get; set; }
        public virtual DbSet<Online_Tag_Master> Online_Tag_Master { get; set; }
        public virtual DbSet<Opening_Balance> Opening_Balance { get; set; }
        public virtual DbSet<Opening_Balance_Inv_Item> Opening_Balance_Inv_Item { get; set; }
        public virtual DbSet<Opening_Balance_Vend> Opening_Balance_Vend { get; set; }
        public virtual DbSet<Outlet_Master> Outlet_Master { get; set; }
        public virtual DbSet<Payment_Master> Payment_Master { get; set; }
        public virtual DbSet<Payment_Master_Vend> Payment_Master_Vend { get; set; }
        public virtual DbSet<PayMode_Master> PayMode_Master { get; set; }
        public virtual DbSet<Recipe_Master> Recipe_Master { get; set; }
        public virtual DbSet<Reference_Master> Reference_Master { get; set; }
        public virtual DbSet<Sale_Master> Sale_Master { get; set; }
        public virtual DbSet<SMS_Recharge> SMS_Recharge { get; set; }
        public virtual DbSet<State_Master> State_Master { get; set; }
        public virtual DbSet<Tab_Process> Tab_Process { get; set; }
        public virtual DbSet<Table_Category_Master> Table_Category_Master { get; set; }
        public virtual DbSet<Table_Master> Table_Master { get; set; }
        public virtual DbSet<Table_Shift> Table_Shift { get; set; }
        public virtual DbSet<Tax_Master> Tax_Master { get; set; }
        public virtual DbSet<User_Address> User_Address { get; set; }
        public virtual DbSet<User_Master> User_Master { get; set; }
        public virtual DbSet<User_Rights> User_Rights { get; set; }
        public virtual DbSet<User_Rights_Main> User_Rights_Main { get; set; }
        public virtual DbSet<Vendor_Master> Vendor_Master { get; set; }
        public virtual DbSet<Void_Bill> Void_Bill { get; set; }
        public virtual DbSet<View_BillPrint> View_BillPrint { get; set; }
        public virtual DbSet<View_Hour> View_Hour { get; set; }
        public virtual DbSet<View_Inv_Item_Master> View_Inv_Item_Master { get; set; }
        public virtual DbSet<View_Inv_TaxDetail> View_Inv_TaxDetail { get; set; }
        public virtual DbSet<View_Item_Master> View_Item_Master { get; set; }
        public virtual DbSet<View_Pay> View_Pay { get; set; }
        public virtual DbSet<View_Pay_Vend> View_Pay_Vend { get; set; }
        public virtual DbSet<View_RunningTable> View_RunningTable { get; set; }
        public virtual DbSet<View_TaxDetail> View_TaxDetail { get; set; }
        public virtual DbSet<View_Top10> View_Top10 { get; set; }
        public virtual DbSet<View_Top15> View_Top15 { get; set; }
        public virtual DbSet<View_Top3> View_Top3 { get; set; }
        public virtual DbSet<View_Tran> View_Tran { get; set; }
        public virtual DbSet<View_Tran_Vend> View_Tran_Vend { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acc_Group_Master>()
                .Property(e => e.sGrp_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Master>()
                .Property(e => e.sAcc_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Master>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Master>()
                .Property(e => e.sGSTIN)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Master>()
                .Property(e => e.sAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Master>()
                .Property(e => e.sEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Advance_Tran>()
                .Property(e => e.sGuest)
                .IsUnicode(false);

            modelBuilder.Entity<Advance_Tran>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Advance_Tran>()
                .Property(e => e.sPax)
                .IsUnicode(false);

            modelBuilder.Entity<Advance_Tran>()
                .Property(e => e.sTime)
                .IsUnicode(false);

            modelBuilder.Entity<Advance_Tran>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Attendent_Master>()
                .Property(e => e.sAttd_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Master>()
                .Property(e => e.sBank_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Detail>()
                .Property(e => e.HSN)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Detail>()
                .Property(e => e.ItemDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Detail_Vend>()
                .Property(e => e.HSN)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Detail_Vend>()
                .Property(e => e.ItemDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sBillType)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sGuest_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.GSTIN)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sNCReason)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sDis)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sVoidReason)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.sDis_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.iWayOffRemark)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.iTipRemark)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master>()
                .Property(e => e.iDonationRemark)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master_Vend>()
                .Property(e => e.sBillSRNo)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master_Vend>()
                .Property(e => e.sDis)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Master_Vend>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Payment>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Payment>()
                .Property(e => e.sValue)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Payment>()
                .Property(e => e.sCardValue)
                .IsUnicode(false);

            modelBuilder.Entity<Billing_Payment>()
                .Property(e => e.sPaytmValue)
                .IsUnicode(false);

            modelBuilder.Entity<BillPrint_Record>()
                .Property(e => e.RNo)
                .IsFixedLength();

            modelBuilder.Entity<BillPrint_Record>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Category_Master>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.sComp_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.TagLine)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.GSTIN)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.ImgName)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Master>()
                .Property(e => e.DBaseNm)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sKOTLang)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sKOTType)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sBillPrinterType)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sBillTax)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sBillType)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.SMSSenderID)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.SMSKey)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.SMSLang)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.SMSNo)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sQTPrinterType)
                .IsUnicode(false);

            modelBuilder.Entity<Configration_Master>()
                .Property(e => e.sEBillType)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillItem>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillItem>()
                .Property(e => e.Rate)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillItem>()
                .Property(e => e.Amount)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.BillNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.TabelNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.BillDate)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.SubTotal)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.Discount)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.TaxAmount)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.Total)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.RoundOff)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.GrandTotal)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.TagLine)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.GST)
                .IsUnicode(false);

            modelBuilder.Entity<CustBillMaster>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<DataCopy>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<Discount_Master>()
                .Property(e => e.sDis_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Est_Billing>()
                .Property(e => e.sGuset)
                .IsUnicode(false);

            modelBuilder.Entity<Est_Billing>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Est_Billing>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Est_Billing>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<Expenses_Master>()
                .Property(e => e.sExp_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Expenses_Tran>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback_Tran>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback_Tran>()
                .Property(e => e.sCustomerReview)
                .IsUnicode(false);

            modelBuilder.Entity<Fin_Yr_Master>()
                .Property(e => e.sFin_Yr_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<FoodOrder_Customer_Master>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Customer_Master>()
                .Property(e => e.Biz_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Customer_Master>()
                .Property(e => e.UPR_Order_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Item_Master>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Item_Master>()
                .Property(e => e.Biz_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Item_Master>()
                .Property(e => e.UPR_Order_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Master>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Master>()
                .Property(e => e.Biz_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Master>()
                .Property(e => e.UPR_Order_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Status>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Status>()
                .Property(e => e.UPR_Order_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Order_Status>()
                .Property(e => e.Order_Status_Pre)
                .IsUnicode(false);

            modelBuilder.Entity<FoodOrder_Reference_Master>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Rider_Status>()
                .Property(e => e.AutoCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Rider_Status>()
                .Property(e => e.UPR_Order_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoodOrder_Rider_Status>()
                .Property(e => e.User_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Form_Master>()
                .Property(e => e.sName)
                .IsUnicode(false);

            modelBuilder.Entity<Form_Master>()
                .Property(e => e.sForm_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sGuest_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sWebsite)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Guest_Master>()
                .Property(e => e.sComment)
                .IsUnicode(false);

            modelBuilder.Entity<Income_Master>()
                .Property(e => e.sIncome_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Income_Tran>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Inv_Category_Master>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Inv_Consume_Master>()
                .Property(e => e.sConsume_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Inv_Unit_Master>()
                .Property(e => e.sUnit_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Item_Group_Master>()
                .Property(e => e.sItemGrp_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<KOT_Delete>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<KOT_Master>()
                .Property(e => e.sGuestName)
                .IsUnicode(false);

            modelBuilder.Entity<KOT_Master>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Location_Master>()
                .Property(e => e.sLoc_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Loyalty_Master>()
                .Property(e => e.PointSystem)
                .IsUnicode(false);

            modelBuilder.Entity<Loyalty_Master>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<MainForm_Master>()
                .Property(e => e.sName)
                .IsUnicode(false);

            modelBuilder.Entity<MainForm_Master>()
                .Property(e => e.sForm_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Meal_Master>()
                .Property(e => e.sMeal_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Month_Master>()
                .Property(e => e.sMnth_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Online_Master>()
                .Property(e => e.sOnline_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master>()
                .Property(e => e.Cheque)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master>()
                .Property(e => e.sBank_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master_Vend>()
                .Property(e => e.Cheque)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master_Vend>()
                .Property(e => e.sBank_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Master_Vend>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<PayMode_Master>()
                .Property(e => e.sPay_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe_Master>()
                .Property(e => e.iMenu_Item_Cd)
                .IsFixedLength();

            modelBuilder.Entity<Reference_Master>()
                .Property(e => e.sRef_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<Reference_Master>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Sale_Master>()
                .Property(e => e.sSale_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<SMS_Recharge>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Table_Shift>()
                .Property(e => e.sReason)
                .IsUnicode(false);

            modelBuilder.Entity<Table_Shift>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Tax_Master>()
                .Property(e => e.sTax_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<User_Address>()
                .Property(e => e.sMac_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<User_Master>()
                .Property(e => e.sUser_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<User_Master>()
                .Property(e => e.sFull_nm)
                .IsUnicode(false);

            modelBuilder.Entity<User_Master>()
                .Property(e => e.sPIN)
                .IsUnicode(false);

            modelBuilder.Entity<User_Master>()
                .Property(e => e.sPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor_Master>()
                .Property(e => e.sBank)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor_Master>()
                .Property(e => e.sBankAcc)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor_Master>()
                .Property(e => e.IFSC)
                .IsUnicode(false);

            modelBuilder.Entity<Void_Bill>()
                .Property(e => e.sVoidReason)
                .IsUnicode(false);

            modelBuilder.Entity<Void_Bill>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.sGuest_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.HSN)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.GSTIN)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.sAttd_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_BillPrint>()
                .Property(e => e.sBillType)
                .IsUnicode(false);

            modelBuilder.Entity<View_Hour>()
                .Property(e => e.Dt)
                .IsUnicode(false);

            modelBuilder.Entity<View_Inv_Item_Master>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Inv_Item_Master>()
                .Property(e => e.sUnit_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Inv_Item_Master>()
                .Property(e => e.sSale_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Inv_TaxDetail>()
                .Property(e => e.sTax_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Inv_TaxDetail>()
                .Property(e => e.sSale_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Item_Master>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Item_Master>()
                .Property(e => e.sMeal_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Item_Master>()
                .Property(e => e.sSale_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay>()
                .Property(e => e.sPay_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay>()
                .Property(e => e.sAcc_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay>()
                .Property(e => e.Cheque)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay>()
                .Property(e => e.sBank_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay_Vend>()
                .Property(e => e.sPay_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay_Vend>()
                .Property(e => e.Cheque)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay_Vend>()
                .Property(e => e.sBank_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Pay_Vend>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<View_RunningTable>()
                .Property(e => e.sGuest_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_TaxDetail>()
                .Property(e => e.sTax_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_TaxDetail>()
                .Property(e => e.sSale_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Top3>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sGuest_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sMobile)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.GSTIN)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sNCReason)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sDis)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sAttd_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sDis_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.HSN)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.ItemDesc)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sDis_Type)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sMeal_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.iWayOffRemark)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.iTipRemark)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.iDonationRemark)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sVoidReason)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sBillType)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran>()
                .Property(e => e.sRef_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.sBillSRNo)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.sDis)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.sType)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.sCat_Nm)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.HSN)
                .IsUnicode(false);

            modelBuilder.Entity<View_Tran_Vend>()
                .Property(e => e.ItemDesc)
                .IsUnicode(false);
        }
    }
}
