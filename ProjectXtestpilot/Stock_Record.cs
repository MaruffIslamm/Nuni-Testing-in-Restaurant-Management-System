using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectXtestpilot
{
    public partial class Stock_Record : Form
    {
        DataAccessStock dt_stock;
        BusinessLogic_StockRecord Businesss_Stock = new BusinessLogic_StockRecord();
   
        public Stock_Record()
        {
            dt_stock = new DataAccessStock();
            //Businesss_Stock = new BusinessLogic_StockRecord();
            InitializeComponent();
        }

        private void Show_Button_Click(object sender, EventArgs e)
        {
            String item_code = Get_Item_Code_Box.Text;

            Stock_DataGridView.DataSource = Businesss_Stock.Show_Stock_BL();
            this.Stock_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Stock_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            String item_code = Get_Item_Code_Box.Text;

            Stock_DataGridView.DataSource = Businesss_Stock.Search_Stock_BL(item_code);
            this.Stock_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Stock_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }
        private void Stock_Record_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            String update_date = Get_Update_Date_Box.Text;
            String update_time = Get_Update_Time_Box.Text;

            //Show_Date_Box.Text = Businesss_Stock.Show_Stock_Date_BL().ToString("d/M/yyyy");
            //Show_Time_Box.Text = Businesss_Stock.Show_Stock_Date_BL().ToString("HH:mm:ss");
            Get_Update_Date_Box.Text = Businesss_Stock.Show_Stock_Date_BL().ToString("d/M/yyyy"); 
            Get_Update_Time_Box.Text = Businesss_Stock.Show_Stock_Date_BL().ToString("HH:mm:ss"); 
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            String item_code = Get_Item_Code_Box.Text;
            String item_name = Get_Item_Name_Box.Text;
            String quantity = Get_Quantity_Box.Text;
            String price = Get_Price_Box.Text;
            String available = Get_Available_Box.Text;
            String update_date = Get_Update_Date_Box.Text;
            String update_time = Get_Update_Time_Box.Text;

            Businesss_Stock.Add_Stock(item_code, item_name, quantity, price, available, update_date, update_time);
            //MessageBox.Show("Added Successfully");
        }

        private void Get_Available_Box_Click(object sender, EventArgs e)
        {
            Get_Available_Box.Text = "";
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            //int item_code = System.Convert.ToInt32(Get_Item_Code_Box.Text);
            string item_code = Get_Item_Code_Box.Text;
            Businesss_Stock.DeleteStock(item_code);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Get_Item_Code_Box_TextChanged(object sender, EventArgs e)
        {
            Get_Item_Name_Box.Text = "";
            Get_Quantity_Box.Text = "";
            Get_Price_Box.Text = "";
            Get_Available_Box.Text = "";
        }
    }

    public class DataAccessStock
    {
        public SqlConnection conn;
        public SqlCommand comm;
        public DataAccessStock()
        {
            conn = new SqlConnection();
            comm = new SqlCommand();
            //conn.ConnectionString = "Server=MARUF-LAPTOP\SQLEXPRESS;Database=StudentDataBase;Trusted_Connection=True;" name="StudentString";
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ProjectXtestpilotString"].ConnectionString;
            comm.Connection = conn;
        }
    }
}
