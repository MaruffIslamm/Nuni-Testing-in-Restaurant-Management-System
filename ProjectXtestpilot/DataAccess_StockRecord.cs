using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ProjectXtestpilot
{
    class DataAccess_StockRecord
    {
        DataAccessStockk dt_stock = new DataAccessStockk();
        public void DeleteFromDB(string item_code)
        {
            dt_stock.conn.Open();
            dt_stock.comm.CommandText = "delete Stock_Table where ITEM_CODE = '" + item_code + "'";
            dt_stock.comm.ExecuteNonQuery();
            dt_stock.conn.Close();
            MessageBox.Show("Deleted Successfully");
        }

        public void AddToDB(String item_code,String item_name,String quantity,String price,String available,String update_date,String update_time)
        {
            dt_stock.conn.Open();
            dt_stock.comm.CommandText = "insert into Stock_Table values ('" + item_code + "','" + item_name + "','" + quantity + "','" + price + "','" + available + "', '" + update_date + "','" + update_time + "')";
            dt_stock.comm.ExecuteNonQuery();
           
            dt_stock.conn.Close();
            MessageBox.Show("Added Successfully");
        }
        public DataTable ShowFromDB()
        {
            DataTable get_stock = new DataTable();

            dt_stock.comm.CommandText = "Select * from Stock_Table";
            dt_stock.conn.Open();
            SqlDataReader reader = dt_stock.comm.ExecuteReader();
            get_stock.Load(reader);
            dt_stock.conn.Close();
            return get_stock;
        }
        public DataTable SearchFromDB(String item_code)
        {
            DataTable get_search_stock = new DataTable();
            dt_stock.comm.CommandText = "Select * from Stock_Table where ITEM_CODE = '" + item_code + "'";
            dt_stock.conn.Open();
            SqlDataReader reader = dt_stock.comm.ExecuteReader();
            get_search_stock.Load(reader);
            dt_stock.conn.Close();
            return get_search_stock;
        }
    }

    public class DataAccessStockk
    {
        public SqlConnection conn;
        public SqlCommand comm;
        public DataAccessStockk()
        {
            conn = new SqlConnection();
            comm = new SqlCommand();
            //conn.ConnectionString = "Server=MARUF-LAPTOP\SQLEXPRESS;Database=StudentDataBase;Trusted_Connection=True;" name="StudentString";
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ProjectXtestpilotString"].ConnectionString;
            comm.Connection = conn;
        }
    }
}
