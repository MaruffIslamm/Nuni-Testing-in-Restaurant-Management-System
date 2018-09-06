using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectXtestpilot
{
    public class BusinessLogic_StockRecord
    {
        DataAccess_StockRecord DA = new DataAccess_StockRecord();

        public string DeleteStock(string item_code)
        {
            if (item_code == null)
            {
                throw new ArgumentNullException("fail");
            }
            if (Microsoft.VisualBasic.Information.IsNumeric(item_code)==false)
            {
                MessageBox.Show("item Code should be numeric value");
                return "item Code should be numeric value";
            }

            DA.DeleteFromDB(item_code);
            return "successfull";
        }

        public string Add_Stock(String item_code, String item_name, String quantity, String price, String available, String update_date, String update_time)
        {
            if((item_code == null)||(item_name==null)|| (quantity == null)|| (price == null) || (available == null) || (available == null))
            {
                throw new ArgumentNullException("null");
            }

            if ((Microsoft.VisualBasic.Information.IsNumeric(item_code) == false) || (Microsoft.VisualBasic.Information.IsNumeric(quantity) == false) || (Microsoft.VisualBasic.Information.IsNumeric(price) == false) || (item_name.Any(char.IsDigit)==true) || (available.Any(char.IsDigit)==true))
            {
                if ((item_name.Any(char.IsDigit)==true))
                {
                    MessageBox.Show("Enter a valid Item Name");
                    return "Enter a valid Item Name";
                    
                }
                else if ((available.Any(char.IsDigit)==true))
                {
                    return "available should be Y or N";
                }

                MessageBox.Show("Item Code/Quantity/Price should be numeric value");
                //throw new ArgumentException("Item Code/Quantity/Price should be numeric value");
                return ("Item Code/Quantity/Price should be numeric value");
            }
            if((update_date.All(char.IsLetter) == true) || (update_time.All(char.IsLetter) == true))
            {
                return "Update date should be in dd/mm/yy format and update time should in hh:mm:ss format";
            }
            DA.AddToDB(item_code, item_name, quantity, price, available, update_date, update_time);
            return "successfull";            
        }
        public DataTable Show_Stock_BL()
        {
            DataTable get_stk = new DataTable();
            get_stk = DA.ShowFromDB();
            return get_stk;
        }
        public DataTable Search_Stock_BL(String item_code)
        {
            DataTable search_stk = new DataTable();
            if(Microsoft.VisualBasic.Information.IsNumeric(item_code) == false)
            {
                MessageBox.Show("Item Code is invalid");
            }
            search_stk = DA.SearchFromDB(item_code);
            return search_stk;
        }
        public DateTime Show_Stock_Date_BL()
        {
            DateTime nDate = DateTime.Now;
            return nDate;
        }
    }
}
