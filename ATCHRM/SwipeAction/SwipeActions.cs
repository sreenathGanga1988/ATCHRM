using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ATCHRM.SwipeAction
{
    public class SwipeActions : IDisposable
    {

        public String con = Program .ConnStr;
        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            Connection.Dispose();
        }
        public SwipeActions()
        {
            Connection = new SqlConnection(con);
            Connection.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = "select earlycheckinupto,latecheckinupto,earlycheckoutupto,latecheckoutupto,EarlyCheckInaction,LateCheckInaction,EarlyCheckoutaction," +
                             " LateCheckOutAction,fromtime,totime from swipetimerule_tbl where IsOnUse='Active'";
            Cmd.CommandType = CommandType.Text;
            DataTable swiperuledata = Database.GetDataSet(Cmd, "A").Tables["A"];

            EarlyCheckinupto = Convert.ToInt32(swiperuledata.Rows[0][0].ToString());   //Early Check in 
            LateCheckinUpto = Convert.ToInt32(swiperuledata.Rows[0][1].ToString()); // Late check in
            EarlyCheckoutupto = Convert.ToInt32(swiperuledata.Rows[0][2].ToString()); //Early Check out
            LateCheckoutupto = Convert.ToInt32(swiperuledata.Rows[0][3].ToString()); //late check out
            Swipeinfromtime = Convert.ToInt32(swiperuledata.Rows[0][8].ToString()); // from time
            SwipeinTotime = Convert.ToInt32(swiperuledata.Rows[0][9].ToString()); //to time
            EarlyCheckInaction = swiperuledata.Rows[0]["EarlyCheckInaction"].ToString(); //to time
            LateCheckInaction = swiperuledata.Rows[0]["LateCheckInaction"].ToString(); //to time
            EarlyCheckoutaction = swiperuledata.Rows[0]["EarlyCheckoutaction"].ToString(); //to time
            LateCheckOutAction = swiperuledata.Rows[0]["LateCheckOutAction"].ToString(); //to time
        }

        int inoutvalue;
        public SqlConnection Connection { get; set; }
        string ShiftPk; string SwipeType;
        public void MarkSwipe(string EmployeeID, DateTime SwipedTime)
        {
            string month = SwipedTime.Month.ToString();
            String day = SwipedTime.Day.ToString();
            if (ifSwipedidntexist(EmployeeID, SwipedTime))
            {
                DateTime Swipedate = getSwipeDate(EmployeeID, SwipedTime);
                String Swipestatus = swipe_checknew(EmployeeID, Swipedate);
                if (SwipeType == "In")
                {
                    if (!Pr_abscent(EmployeeID, Swipedate))
                    {
                        //String insertquery = String.Format(@"insert into  EmployeSwipeDaily_tbl ( empid, Swipin, Date, deviceid, InStatus,Invalue,swiped_date,shift_pk)
                        //values ({0}, '{1}' ,'{2:dd/MM/yyyy}',100, '{3}',{4},'{2:dd/MM/yyyy} {5}',{6})"
                        //    , empid, Swipedate, Convert.ToDateTime(Swipedate), Swipestatus, inoutvalue, ShiftIntime, shiftpk);

                        //setData(insertquery, con);

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"insert into  EmployeSwipeDaily_tbl ( empid, Swipin, Date, deviceid, InStatus,Invalue,swiped_date,shift_pk)
                        values (@empid, @Swipin, @Date, @deviceid, @InStatus,@Invalue,@swiped_date,@shift_pk)";
                        cmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = EmployeeID;
                        cmd.Parameters.Add(new SqlParameter("@Swipin", SqlDbType.DateTime)).Value = Swipedate;
                        cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)).Value = Swipedate.Date;
                        cmd.Parameters.Add(new SqlParameter("@deviceid", SqlDbType.Int)).Value = 100;
                        cmd.Parameters.Add(new SqlParameter("@InStatus", SqlDbType.NVarChar, 50)).Value = Swipestatus;
                        cmd.Parameters.Add(new SqlParameter("@Invalue", SqlDbType.BigInt)).Value = inoutvalue;
                        cmd.Parameters.Add(new SqlParameter("@swiped_date", SqlDbType.DateTime)).Value = new DateTime(Swipedate.Year, Swipedate.Month, Swipedate.Day, ActualShiftTime.Hour, ActualShiftTime.Minute, ActualShiftTime.Second);
                        cmd.Parameters.Add(new SqlParameter("@shift_pk", SqlDbType.Int)).Value = ShiftPk;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = Connection;
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {

                        if (In_abscent(EmployeeID, Swipedate))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = @"update EmployeSwipeDaily_tbl set InStatus=@InStatus,Swipin=@Swipin, Invalue=@Invalue
                           ,swiped_date=@swiped_date where empid=@empid  and Date=@Date";
                            cmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = EmployeeID;
                            cmd.Parameters.Add(new SqlParameter("@Swipin", SqlDbType.DateTime)).Value = Swipedate;
                            cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)).Value = Swipedate.Date;

                            cmd.Parameters.Add(new SqlParameter("@InStatus", SqlDbType.NVarChar, 50)).Value = Swipestatus;
                            cmd.Parameters.Add(new SqlParameter("@Invalue", SqlDbType.BigInt)).Value = inoutvalue;
                            cmd.Parameters.Add(new SqlParameter("@swiped_date", SqlDbType.DateTime)).Value = new DateTime(Swipedate.Year, Swipedate.Month, Swipedate.Day, ActualShiftTime.Hour, ActualShiftTime.Minute, ActualShiftTime.Second);
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = Connection;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (SwipeType == "Out")
                {
                    if (Out_abscent(EmployeeID, Swipedate))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"update EmployeSwipeDaily_tbl set outstatus=@outstatus,swipeout=@swipeout, outvalue=@outvalue
                           ,swiped_date=@swiped_date where empid=@empid  and Date=@Date";
                        cmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = EmployeeID;
                        cmd.Parameters.Add(new SqlParameter("@swipeout", SqlDbType.DateTime)).Value = Swipedate;




                        if (ShiftPk == "68" || ShiftPk == "59")
                           {
                               DateTime prevdate = Swipedate.Date.AddDays(-1);
                               cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime)).Value = prevdate;
                           }
                           else
                           {
                               cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime)).Value = Swipedate.Date;
                           }

                        cmd.Parameters.Add(new SqlParameter("@outstatus", SqlDbType.NVarChar, 50)).Value = Swipestatus;
                        cmd.Parameters.Add(new SqlParameter("@outvalue", SqlDbType.BigInt)).Value = inoutvalue;
                        cmd.Parameters.Add(new SqlParameter("@swiped_date", SqlDbType.DateTime)).Value = new DateTime(Swipedate.Year, Swipedate.Month, Swipedate.Day, ActualShiftTime.Hour, ActualShiftTime.Minute, ActualShiftTime.Second);
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = Connection;
                        cmd.ExecuteNonQuery();


                    }
                    else
                    {
                        if (!Pr_abscent(EmployeeID, Swipedate))
                        {


                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = @"insert into  EmployeSwipeDaily_tbl ( empid, Swipeout, Date, deviceid, outStatus,outvalue,swiped_date,shift_pk)
                                                        values (@empid, @Swipeout, @Date, @deviceid, @outStatus,@outvalue,@swiped_date,@shift_pk) ";
                            cmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = EmployeeID;
                            cmd.Parameters.Add(new SqlParameter("@Swipeout", SqlDbType.DateTime)).Value = Swipedate;

                            if (ShiftPk == "68" || ShiftPk == "59")
                            {
                                DateTime prevdate = Swipedate.Date.AddDays(-1);
                                cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime)).Value = prevdate;
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)).Value = Swipedate.Date;
                            }

                         
                            cmd.Parameters.Add(new SqlParameter("@deviceid", SqlDbType.Int)).Value = 100;
                            cmd.Parameters.Add(new SqlParameter("@outStatus", SqlDbType.NVarChar, 50)).Value = Swipestatus;
                            cmd.Parameters.Add(new SqlParameter("@outvalue", SqlDbType.BigInt)).Value = inoutvalue;
                            cmd.Parameters.Add(new SqlParameter("@swiped_date", SqlDbType.DateTime)).Value = new DateTime(Swipedate.Year, Swipedate.Month, Swipedate.Day, ActualShiftTime.Hour, ActualShiftTime.Minute, ActualShiftTime.Second);
                            cmd.Parameters.Add(new SqlParameter("@shift_pk", SqlDbType.Int)).Value = ShiftPk;
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = Connection;
                            cmd.ExecuteNonQuery();

                        }
                        //new code done by sreenath for serach
                        else
                        {


                        }

                    }

                }
            }

        }
        public Boolean Out_abscent(string empid, DateTime swipedate)
        {
            Boolean isabcent = false;
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = String.Format("select outstatus from EmployeSwipeDaily_tbl where empid={0} and cast(date as Date)=cast(@date as date)", empid);
                    if (ShiftPk == "68" || ShiftPk == "59")
                    {
                        DateTime prevdate = swipedate.Date.AddDays(-1);
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = prevdate;
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = swipedate.Date;
                    }
                    cmd.Connection = Connection;
                    cmd.CommandType = CommandType.Text;

                    dt = Database.GetDataSet(cmd, "A").Tables["A"];




                }


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        //if (dt.Rows[0][0] != DBNull.Value || !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                        //{
                        //    isabcent = true ;
                        //}

                        if (dt.Rows[0][0].ToString().Trim() == "" || dt.Rows[0][0] != DBNull.Value)
                        {
                            isabcent = true;
                        }
                    }


                }



            }
            catch (Exception)
            {

                throw;
            }



            return isabcent;
        }

        public Boolean In_abscent(string empid, DateTime swipedate)
        {
            Boolean isabcent = false;
            DataTable dt = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = String.Format("select Instatus from EmployeSwipeDaily_tbl where empid={0} and cast(date as Date)=cast(@date as date)", empid);


                    if (ShiftPk == "68" || ShiftPk == "59")
                    {
                        DateTime prevdate = swipedate.Date.AddDays(-1);
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = prevdate;
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date)).Value = swipedate.Date;
                    }
                    cmd.Connection = Connection;
                    cmd.CommandType = CommandType.Text;

                    dt = Database.GetDataSet(cmd, "A").Tables["A"];




                }


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        //if (dt.Rows[0][0] != DBNull.Value || !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                        //{
                        //    isabcent = true ;
                        //}

                        if (dt.Rows[0][0].ToString().Trim() == "" || dt.Rows[0][0] != DBNull.Value)
                        {
                            isabcent = true;
                        }
                    }


                }



            }
            catch (Exception)
            {

                throw;
            }



            return isabcent;
        }



        /// <summary>
        /// check whether employee have a punch on that day
        /// returns false if no record found
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="swipedate"></param>
        /// <returns></returns>
        public Boolean Pr_abscent(string empid, DateTime swipedate)
        {
            Boolean isPresent = false;
            int countvalue = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = String.Format("select count(1) from EmployeSwipeDaily_tbl where empid={0} and date=cast(@date as date)", empid);
                    if (ShiftPk == "68" || ShiftPk == "59")
                    {
                        if (SwipeType == "Out")
                        {
                            DateTime prevdate = swipedate.Date.AddDays(-1);
                            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = prevdate;
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = swipedate.Date;
                        }
                    }
                    else
                    {

                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = swipedate.Date;
                    }
                  
                
                    cmd.Connection = Connection;
                    cmd.CommandType = CommandType.Text;
                    countvalue = int.Parse(cmd.ExecuteScalar().ToString());
                }
                isPresent = countvalue == 0 ? false : true;
            }
            catch (Exception)
            {
                throw;
            }
            return isPresent;
        }

        /// <summary>
        /// check whether the record is there for swipe
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="swipedate"></param>
        /// <returns></returns>
        public Boolean ifSwipedidntexist(string empid, DateTime swipedate)
        {

            int countvalue = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = String.Format("Select count(1) FROM  EmployeSwipeDaily_tbl WHERE     (empid = {0}) AND ( (Swipin = @Swipin) or (SwipeOut  =@Swipin))", empid);
                cmd.Parameters.Add(new SqlParameter("@Swipin", SqlDbType.DateTime)).Value = swipedate;
                cmd.Connection = Connection;
                cmd.CommandType = CommandType.Text;
                countvalue = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return (countvalue == 0) ? true : false;

        }
        public DateTime getSwipeDate(string empid, DateTime swiperecievedtime)
        {
            double hoursdiffernce = 0;
            DateTime swipedate = DateTime.MinValue;
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = this.Connection;
            Cmd.CommandText = String.Format("Select max(swiped_date) from EmployeSwipeDaily_tbl where empid={0}", empid);
            object Pts = Cmd.ExecuteScalar();
            DateTime lastwsipedate = Pts == DBNull.Value ? swiperecievedtime.AddDays(-1) : Convert.ToDateTime(Pts);
            hoursdiffernce = (swiperecievedtime - lastwsipedate).TotalHours;
            lastwsipedate = lastwsipedate.AddDays(1);

            return ((hoursdiffernce >= 20) && (hoursdiffernce <= 30) || (hoursdiffernce >= 45) && (hoursdiffernce <= 48)) ?
            new DateTime(lastwsipedate.Year, lastwsipedate.Month, lastwsipedate.Day, swiperecievedtime.Hour, swiperecievedtime.Minute, swiperecievedtime.Second)
                :
             swiperecievedtime;

        }

        public int EarlyCheckinupto { get; set; }
        public int LateCheckinUpto { get; set; }
        public int EarlyCheckoutupto { get; set; }
        public int LateCheckoutupto { get; set; }
        public int Swipeinfromtime { get; set; }
        public int SwipeinTotime { get; set; }
        public string EarlyCheckInaction { get; set; }

        public string LateCheckInaction { get; set; }
        public string EarlyCheckoutaction { get; set; }
        public string LateCheckOutAction { get; set; }


        public string swipe_checknew(string empid, DateTime swipedate)
        {

            //    Swpdat = swipedate.ToString("dd/MM/yyyy");
            String resultstatus = "";
            int daysection = 0;

            DateTime ActualShiftTime = Shift_time(empid, 1, swipedate, out ShiftPk, out SwipeType); //shift time of that employee
            DateTime SwipeinStarttime = ActualShiftTime.AddMinutes(-Swipeinfromtime);// early check
            //  String sgdt2 = swipedate.ToString("HH:mm:ss tt");
            DateTime AllowedLatecheck = ActualShiftTime.AddMinutes(SwipeinTotime); // late check
            // String Swipestarttime = SwipeinStarttime.ToString("HH:mm:ss tt");
            // String latecheckallowedtime = AllowedLatecheck.ToString("HH:mm:ss tt");


            daysection = ((SwipeinStarttime <= swipedate) && (AllowedLatecheck >= swipedate)) ? 1 : 2;





            Double SwipeDiffernceMinute = 0;
            DateTime ActualTimeforSwipe = Shift_time(empid, daysection, swipedate, out ShiftPk, out SwipeType);//Swipe Out Time
            //  String shifttimeactual = ActualTimeforSwipe.ToString("HH:mm:ss tt");
            //  String actualswipetime = swipedate.ToString("HH:mm:ss tt");

            SwipeDiffernceMinute = (swipedate - ActualTimeforSwipe).TotalMinutes;
            inoutvalue = int.Parse(Math.Abs(Math.Round(SwipeDiffernceMinute)).ToString());

            if (daysection == 1) //if morning section
            {

                if (SwipeDiffernceMinute <= 0)//Employee swiped Early
                {
                    if (EarlyCheckinupto >= SwipeDiffernceMinute) //if  earlycheckin allowed minute is greater than difference 
                    {

                        // result = Convert.ToString(ds.Tables(0).Rows(0)(4))
                        //changed by sreenath on 25-11-2013
                        resultstatus = "P";
                    }
                    else
                    {

                        resultstatus = EarlyCheckInaction;
                    }
                }
                else // IF LATE CHECK IN
                {
                    if (LateCheckinUpto >= Math.Abs(SwipeDiffernceMinute))// IF LATE CHECK IN MINUTES WITHIN ALOWED RANGE
                    {
                        resultstatus = "P";
                    }
                    else ///IF LATER THAN ALLOWED TIME
                    {
                        resultstatus = LateCheckInaction;
                    }
                }
            }
            else //if evening section
            {
                if (SwipeDiffernceMinute <= 0) //IF EARLY  SWIPE
                {
                    if (EarlyCheckoutupto <= Math.Abs(SwipeDiffernceMinute))
                    {
                        resultstatus = EarlyCheckoutaction;
                    }
                    else
                    {
                        resultstatus = "P";
                    }


                }
                else
                {
                    if (LateCheckoutupto >= Math.Abs(SwipeDiffernceMinute))
                    {
                        resultstatus = "P";
                    }
                    else
                    {
                        resultstatus = LateCheckOutAction;
                    }

                }


            }





            return resultstatus;
        }
        DateTime ActualShiftTime;
        public DateTime Shift_time(string empid, int daysec, DateTime Swipedate, out string ShiftpkOut, out string SwipeType)
        {
            SwipeType = ShiftpkOut = string.Empty;

            DateTime shifttime = DateTime.MinValue;
            String Dayoffweek = Swipedate.DayOfWeek.ToString();

            String shiftgetquery = "SELECT st.fromTime,st.toTime,et.shiftpk FROM EmployeShift_tbl AS et INNER JOIN" +
                      "  ShiftDayDetails_tbl AS st ON et.Shiftpk = st.ShiftPk " +
                     " WHERE et.Empid = " + empid + " and st.DayOFWeekname = '" + Dayoffweek + "'";

            DataTable ShiftTable = Database.GetDataSet(shiftgetquery, "A").Tables["A"];

            if (ShiftTable != null)
            {
                if (ShiftTable.Rows.Count != 0)
                {
                    ShiftpkOut = ShiftTable.Rows[0][2].ToString();

                    if (daysec == 1)
                    {
                        ActualShiftTime = Convert.ToDateTime(ShiftTable.Rows[0][0]);
                        SwipeType = "In";
                    }
                    else
                    {
                        ActualShiftTime = Convert.ToDateTime(ShiftTable.Rows[0][1]);
                        SwipeType = "Out";
                    }
                    shifttime = new DateTime(Swipedate.Year, Swipedate.Month, Swipedate.Day, ActualShiftTime.Hour, ActualShiftTime.Minute, ActualShiftTime.Second);//Convert.ToDateTime(temptime);
                }
            }
            return shifttime;
        }
    }
}
