//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectXtestpilot
{
    [TestFixture]
    public class TestLibrary
    {
        private BusinessLogic_StockRecord BL = new BusinessLogic_StockRecord();

        [Test]
        public void Test1_Delete()
        {
            string ResultDelete = BL.DeleteStock("10000");//Delete with int input
            Assert.AreEqual(ResultDelete, "successfull");
        }
        [Test]
        public void Test2_Delete()
        {

            Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.DeleteStock(null)).ParamName, "fail");//Delete with null
        }
        [Test]
        public void Test3_Delete()
        {
            string ResultDelete = BL.DeleteStock("ABC");//Delete with string input
            Assert.AreEqual(ResultDelete, "item Code should be numeric value");
        }


        [Test]
        public void Test1_Add_Stock()
        {
            //Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock(null, "10008", "ABC", "10000", null, "01-12-2017", "00:43:45")).ParamName, "item_code null");
            Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock(null, "10008", "ABC", "10000", null, "01-12-2017", "00:43:45")).ParamName, "null");//item_code
            //Assert.AreEqual(result1_Add_Stock,"Item Code/Quantity/Price should be numeric value");
        }
        [Test]
        public void Test2_Add_Stock()
        {
            Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock("10001", null, "10998", "10000", "12345", "01-12-2017", "00:43:45")).ParamName, "null");//item_name
        }
        [Test]
        public void Test3_Add_Stock()
        {
            Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock("ABC", "ABC", null, "10000", "ABC", "01-12-2017", "00:43:45")).ParamName, "null");//quantity
        }
        [Test]
        public void Test4_Add_Stock()
        {
            Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock("ABC", "19988", "16677", "ABC", null, "01-12-2017", "00:43:45")).ParamName, "null");//available
        }
        [Test]
        public void Test5_Add_Stock()
        {
            string result_available = BL.Add_Stock("11256", "ABC", "16677", "15679", "123467", "01-12-2017", "00:43:45");
            Assert.AreEqual(result_available, "available should be Y or N");//available check
        }
        [Test]
        public void Test6_Add_Stock()
        {
            string result_name = BL.Add_Stock("11256", "12345", "16677", "15679", "Y", "01-12-2017", "00:43:45");
            Assert.AreEqual(result_name, "Enter a valid Item Name");//name check
        }
        [Test]
        public void Test7_Add_Stock()
        {
            string result_time = BL.Add_Stock("11256", "ABC", "16677", "15679", "Y", "01-12-2017", "ABC");
            Assert.AreEqual(result_time, "Update date should be in dd/mm/yy format and update time should in hh:mm:ss format");//time check
        }
        [Test]
        public void Test8_Add_Stock()
        {
            string result_date = BL.Add_Stock("11256", "ABC", "16677", "15679", "Y", "ABC", "00:43:45");
            Assert.AreEqual(result_date, "Update date should be in dd/mm/yy format and update time should in hh:mm:ss format");//date check
        }
        [Test]
        public void Test9_Add_Stock()
        {
            string result_name_Add_Stock = BL.Add_Stock("ABC", "ABC", "1234", "10000", "Y", "01-12-2017", "00:43:45");
            //Assert.AreEqual(Assert.Throws<ArgumentNullException>(() => BL.Add_Stock(null, "10008", "ABC", "10000", null, "01-12-2017", "00:43:45")).ParamName, "item_code null");
            //Assert.AreEqual(Assert.Throws<ArgumentException>(() => BL.Add_Stock("ABC", "ABC", "1234", "10000", "Y", "01-12-2017", "00:43:45")).ParamName, "null");//item_code
            Assert.AreEqual(result_name_Add_Stock, "Item Code/Quantity/Price should be numeric value");
        }
        //[Test]
        //public void Test10_Add_Stock()
        //{
        //    string result_successfull_Add_Stock = BL.Add_Stock("10010", "ABC", "1234", "10000", "Y", "01-12-2017", "00:43:45");
        //    Assert.AreEqual(result_successfull_Add_Stock, "successfull");
        //}
    }
}
