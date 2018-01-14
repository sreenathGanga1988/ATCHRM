using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ATCHRM.SwipeAction
{
    public class Database
    {
        public static DataSet GetDataSet(SqlCommand command, string TableName)
        {
            DataSet sourceDataSet;
            SqlDataAdapter adapter = null;
            SqlConnection Connection = new SqlConnection(Program.ConnStr);
            try
            {
                command.Connection = Connection;
                command.CommandTimeout = 0;
                Connection.Open();
                adapter = new SqlDataAdapter(command);
                sourceDataSet = new DataSet();
                adapter.Fill(sourceDataSet, TableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
            return sourceDataSet;
        }

        public static DataSet GetDataSet(string Query, string TableName)
        {
            DataSet sourceDataSet;
            SqlDataAdapter adapter = null;
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            command.CommandText = Query;
            command.CommandType = CommandType.Text;
            SqlConnection Connection = new SqlConnection(Program.ConnStr);
            try
            {
                command.Connection = Connection;
                Connection.Open();
                adapter = new SqlDataAdapter(command);
                
                sourceDataSet = new DataSet();
                adapter.Fill(sourceDataSet, TableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
            return sourceDataSet;
        }

        public static void ExecuteCommand(SqlCommand cmd)
        {
            using (var con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    if (cmd == null) { throw new Exception("Required Parameter Missing in command"); }
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }

            }


        }

        public static void ExecuteQuery(string Query)
        {
            using (var con = new SqlConnection(Program.ConnStr))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Query;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

    }
}
