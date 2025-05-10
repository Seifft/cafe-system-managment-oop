using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe_system_managment
{
    internal class edit
    {
        public static void Editdgvfare(DataGridView dgvfare, TextBox txtname, TextBox txtprice, TextBox txtquantity)
        {
            /*if (dgvfare.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvfare.SelectedRows[0].Index;
                dgvfare.Rows[selectedIndex].Cells[0].Value = txtname.Text;
                dgvfare.Rows[selectedIndex].Cells[1].Value = Convert.ToDecimal(txtprice.Text);
                dgvfare.Rows[selectedIndex].Cells[2].Value = Convert.ToInt32(txtquantity.Text);
            }*/
            string name = txtname.Text;

            decimal price = decimal.Parse(txtprice.Text);

            int quantity = int.Parse(txtquantity.Text);


            product2 newItem = new product2(name, price, quantity);
            dgvfare.CurrentRow.Cells[0].Value = newItem.name;
            dgvfare.CurrentRow.Cells[1].Value = newItem.price;
            dgvfare.CurrentRow.Cells[2].Value = newItem.quantity;

        }
        public static void editcombobox(List<product2> productlist, TextBox txtname, TextBox txtprice, TextBox txtquantity, ComboBox cbxproduct, BindingSource bs, TextBox txtinvoiceprice, string searchname)
        {
            // string searchName = searchvalue;

            product2 newItem = new product2(txtname.Text, decimal.Parse(txtprice.Text), int.Parse(txtquantity.Text));
            var foundItem = productlist.FirstOrDefault(item => item.name == searchname);

            if (foundItem != null)
            {
                cbxproduct.SelectedItem = foundItem;
            }
            else { MessageBox.Show("item not found"); return; }

            int selectedIndex = cbxproduct.SelectedIndex;
            if (selectedIndex >= 0)
            {

             productlist[selectedIndex] = newItem;

                bs.DataSource = productlist;
                cbxproduct.DataSource = bs;
                cbxproduct.DisplayMember = "name";
                cbxproduct.ValueMember = "price";
                bs.ResetBindings(false);


               // cbxproduct.SelectedIndex = selectedIndex;
                txtinvoiceprice.Clear();
            }
        }
    }
}
