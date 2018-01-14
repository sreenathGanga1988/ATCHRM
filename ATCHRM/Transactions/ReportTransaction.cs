using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
namespace ATCHRM.Transactions
{
    class ReportTransaction
    {


        /// <summary>
        /// get All the Payback detail of an Period
        /// </summary>
        /// <param name="BranchlctnPK"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>

        public DataTable GetAllPayBackDetails(int BranchlctnPK, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid AS Empid, EmployeePersonalMaster_tbl.empno AS [Emp No], 
                         EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS Name, AdvanceApplicationMaster_tbl.AddvanceAppnum AS Appnum, 
                         AdvanceApprovalMaster_tbl.Level3ApprovalDate AS [Approved Date], AdvanceApprovalMaster_tbl.Level3Amount AS [Approved Amount],
                           isnull(  (SELECT        SUM(Amount) AS PayAmount
                               FROM            AdvancePayBackDetail_tbl
                               WHERE        (AdvanceAppPk = AdvanceApplicationMaster_tbl.AdvanceAppPk)
                               GROUP BY DateofPay
                               HAVING         (DateofPay BETWEEN @fromdate AND @todate)),0) AS PayBack,0000 as Balance
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         AdvanceApplicationMaster_tbl ON EmployeePersonalMaster_tbl.empid = AdvanceApplicationMaster_tbl.empid INNER JOIN
                         AdvanceApprovalMaster_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvanceApprovalMaster_tbl.AdvanceAppPk INNER JOIN
                         AdvancePayBackDetail_tbl AS AdvancePayBackDetail_tbl_1 ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvancePayBackDetail_tbl_1.AdvanceAppPk AND 
                         AdvanceApplicationMaster_tbl.empid = AdvancePayBackDetail_tbl_1.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND (AdvanceApprovalMaster_tbl.Islevel3 = N'A')", con);



                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }

        /// <summary>
        /// get the UOt status Before closeregister
        /// </summary>
        /// <param name="BranchlctnPK"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public DataTable GetAllOTandUOTBeforeCloseRegister(int BranchlctnPK, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeSwipeDaily_tbl.empid, EmployeePersonalMaster_tbl.empno, DepartmentMaster_tbl.DepartmentName, EmployeeDesignation_tbl.IsOtApplicable, 
                         EmployeSwipeDaily_tbl.Date, EmployeSwipeDaily_tbl.Outstatus, EmployeSwipeDaily_tbl.OutValue, ISNULL(OtApplicationDetails_tbl.Duration, 0) 
                         AS [Approved Duration], CASE WHEN ISNULL(OtApplicationDetails_tbl.Duration, 0) > 0 THEN ISNULL(OtApplicationDetails_tbl.Duration, 0) 
                         ELSE 0 END AS [Assigned OT], EmployeSwipeDaily_tbl.OutValue - (CASE WHEN ISNULL(OtApplicationDetails_tbl.Duration, 0) 
                         > 0 THEN ISNULL(OtApplicationDetails_tbl.Duration, 0) ELSE 0 END) AS [UOT Left]
FROM            EmployeSwipeDaily_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeSwipeDaily_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK LEFT OUTER JOIN
                         OtApplicationDetails_tbl ON EmployeSwipeDaily_tbl.empid = OtApplicationDetails_tbl.empid AND EmployeSwipeDaily_tbl.Date = OtApplicationDetails_tbl.OTDate AND
                          OtApplicationDetails_tbl.Islevel2 = N'A'
WHERE        (EmployeSwipeDaily_tbl.Date BETWEEN @fromdate AND @todate) AND 
                         (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK)   AND( (EmployeSwipeDaily_tbl.Outstatus = 'UOT')   OR
                         (EmployeSwipeDaily_tbl.Outstatus = 'OT') OR
                         (EmployeSwipeDaily_tbl.Outstatus = 'OT1.5') OR
                         (EmployeSwipeDaily_tbl.Outstatus = 'OT2.0'))        ", con);



                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }


        /// <summary>
        /// get all the payroll details
        /// </summary>
        /// <param name="payrollid"></param>
        /// <returns></returns>
        public DataTable GetPayrollDetailsFull(int payrollid)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        Payroll_PayDetails.Pay_Id, Payroll_PayDetails.Pay_Det_Id, Payroll_PayDetails.Emp_Id, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.Status, EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name, 
                         DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, Payroll_PayDetails.Total_Salary, Payroll_PayDetails.Disburs_Amnt, 
                         Payroll_PayDetails.Deduct_Amnt, Payroll_PayDetails.Basic_Sal, Payroll_PayDetails.HRA_Allow, Payroll_PayDetails.Special_Allow, Payroll_PayDetails.OT_Amnt, 
                         Payroll_PayDetails.Gross_Amnt, Payroll_PayDetails.Tax_Deduct, Payroll_PayDetails.NSSF, Payroll_PayDetails.NHIF, Payroll_PayDetails.Total_Deduct, 
                         Payroll_PayDetails.Absent_No, Payroll_PayDetails.Ot_Hrs, Payroll_PayDetails.Leave_Days, Payroll_PayDetails.Actual_OTamnt, Payroll_PayDetails.Paye_Amnt, 
                         Payroll_PayDetails.OfOt_Hrs, Payroll_PayDetails.Ofot_amnt, Payroll_PayDetails.Department_Id, Payroll_PayDetails.total_disb, Payroll_PayDetails.holidayno, 
                         Payroll_PayDetails.offdays, Payroll_PayDetails.Payrolldays, Payroll_PayDetails.ActualBasic, Payroll_PayDetails.PerkAmount, Payroll_PayDetails.PerkTaxable, 
                         Payroll_PayDetails.LeaveOnOff, Payroll_PayDetails.PaidLeaves, Payroll_PayDetails.halfdayleave, Payroll_PayDetails.halfdayAbscent, 
                         Payroll_PayDetails.Normal_OTHours, Payroll_PayDetails.GrossTotal, Payroll_PayDetails.AdvanceToPay
FROM            DesignationMaster_tbl INNER JOIN
                         Payroll_PayDetails INNER JOIN
                         EmployeePersonalMaster_tbl ON Payroll_PayDetails.Emp_Id = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK
WHERE        (Payroll_PayDetails.Pay_Id = @Param1)", con);



                cmd.Parameters.AddWithValue("@Param1", payrollid);
              

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }






    }


}
