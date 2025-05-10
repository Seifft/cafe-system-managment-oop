using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cafe_system_managment
{
    public class Add
    {
        public static void AddToDgvfare(DataGridView dgvfare, TextBox txtname, TextBox txtprice, TextBox txtquantity,List<product2> productlist, BindingSource bs)
        {

            
            product2 newItem = new product2(txtname.Text, decimal.Parse(txtprice.Text), int.Parse(txtquantity.Text));
            dgvfare.Rows.Add(newItem.name, newItem.price, newItem.quantity);
            /*List<product2> productLis;
             dgvfare.DataSource = new BindingSource(productlist, null); الكود ده هو الي بيطلع الايرور
            bs.DataSource = productlist; وده بردوا بيطلع نفس الايرور
            dgvfare.DataSource = bs;*/


        }
        public static void AddTocombobox(List<product2> productlist, TextBox txtname, TextBox txtprice, TextBox txtquantity, ComboBox cbxproduct, BindingSource bs, TextBox txtinvoiceprice)
        {

            string name = txtname.Text;
            decimal price = Convert.ToDecimal(txtprice.Text);
            int quantity = Convert.ToInt32(txtquantity.Text);
            product2 newItem = new product2(name, price, quantity);
            productlist.Add(newItem);
            bs.DataSource = productlist;
            cbxproduct.DataSource = bs;
            cbxproduct.DisplayMember = "name";
            cbxproduct.ValueMember = "price";
            cbxproduct.DataSource = new BindingSource(productlist, null);



            txtinvoiceprice.Clear();

        }
        public static void AddToDgvproduct(DataGridView dgvproduct, ComboBox cbxproduct, TextBox txtinvoiceprice, TextBox txtinvoicequantity)
        {
            string name = cbxproduct.Text;
            decimal price = Convert.ToDecimal(txtinvoiceprice.Text);

            int quantity = Convert.ToInt32(txtinvoicequantity.Text);
            decimal subtotal = price * quantity;

            datadgvproduct data = new datadgvproduct(name, price, quantity, subtotal);
            dgvproduct.Rows.Add(data.name, data.price, data.quantity, data.subtotal);
            txtinvoicequantity.Clear();
        }
        public static void Addoverallprice(DataGridView dgvproduct, TextBox txtoverall)
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvproduct.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    grandTotal += Convert.ToDecimal(row.Cells[3].Value);
                }
            }
            txtoverall.Text = grandTotal + "EGP";
        }
        public static void Addoverallpricewithdiscount(DataGridView dgvproduct, TextBox txtoverall, TextBox txtdiscount)
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvproduct.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    grandTotal += Convert.ToDecimal(row.Cells[3].Value);
                }
            }
            txtoverall.Text = grandTotal - (grandTotal * (Convert.ToDecimal(txtdiscount.Text) / 100)) + "EGP";

        }
    }
}

